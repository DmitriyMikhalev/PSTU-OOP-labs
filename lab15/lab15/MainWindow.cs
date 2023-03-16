using TextBoxes;

namespace lab15
{
    internal class Window
    {
        public RenderWindow window;
        public volatile float sliderPosition = 0;
        protected AutoResetEvent waitHandler = new(true);
        protected List<Textbox> firstPriorities = new();
        protected List<Textbox> firstToDraw = new();
        protected List<Textbox> secondPriorities = new();
        protected List<Textbox> secondToDraw = new();
        protected Slider slider = new();
        protected Sprite arrow = new(), arrowPr;
        protected Thread first, second, controllerThread;
        readonly AutoResetEvent resetEventTry = new(true);
        public Window()
        {
            window = new RenderWindow(new VideoMode(1280, 720), "lab15");
            window.MouseMoved += HandlePr1Moved;
            window.MouseMoved += HandlePr2Moved;
            window.MouseButtonPressed += HandlePr2Pressed;
            window.MouseButtonPressed += HandlePr1Pressed;
            window.Closed += Closed;
            window.SetFramerateLimit(60);
            InitTextboxesPriorities(firstPriorities);
            InitTextboxesPriorities(secondPriorities);
            firstPriorities[0].SetPosition(84, 19);
            firstToDraw.Add(firstPriorities[0]);
            secondToDraw.Add(secondPriorities[0]);

            arrow.Texture = new Texture(new Image(Directory.GetCurrentDirectory() + @"\arrow.jpg"));
            arrow.Origin = new Vector2f(256f, 256f);
            arrow.Scale = new Vector2f(0.1f, 0.1f);
            arrow.Position = new Vector2f(185.6f, 20.6f);

            arrowPr = new(arrow);
            arrowPr.Position = new Vector2f(1175.6f, 20.6f);

            slider.setActualFillColor(Color.White);
            slider.setActualOutlineColor(new Color(0, 113, 188));
            slider.setFillColorRectangle(new Color(0, 113, 188));
            slider.setRectangleSize(400, 20);
            slider.setActualRadius(20);
            slider.setActualOutlineThickness(15);
            slider.setSliderPos(640, 210);
        }
        public void Start()
        {
            first = new Thread(ChangeTo25);
            second = new Thread(ChangeTo355);
            controllerThread = new Thread(Changings);

            first.Start();
            second.Start();
            controllerThread.Start();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.White);
                window.Draw(arrow);
                window.Draw(arrowPr);
                foreach (Textbox textbox in firstToDraw)
                {
                    window.Draw(textbox);
                }
                foreach (Textbox textbox in secondToDraw)
                {
                    window.Draw(textbox);
                }
                window.Draw(slider);
                window.Display();
            }
        }
        public void Closed(object? source, EventArgs args)
        {
            if (source is SFML.Window.Window window)
            {
                window.Close();
            }
        }
        public void ChangeTo25()
        {
            while (window.IsOpen)
            {
                resetEventTry.WaitOne();
                sliderPosition = 25;
                waitHandler.Set();
            }
        }
        public void ChangeTo355()
        {
            while (window.IsOpen)
            {
                resetEventTry.WaitOne();
                sliderPosition = 355;
                waitHandler.Set();
            }
        }
        public void Changings()
        {
            while (window.IsOpen)
            {
                waitHandler.WaitOne();
                slider.setStartPos((int)sliderPosition);
                Thread.Sleep(150);
                resetEventTry.Set();
            }
        }
        public void HandlePr1Moved(object? source, MouseMoveEventArgs args)
        {
            if (arrow.GetGlobalBounds().Contains(args.X, args.Y))
            {
                arrow.Color = new Color(255, 0, 255, 122);
            }
            else
            {
                arrow.Color = Color.White;
            }
            for (int i = 1; i < firstToDraw.Count; ++i)
            {
                if (firstToDraw[i].Contains(args.X, args.Y))
                {
                    firstToDraw[i].SetRectangleFillColor(Color.Magenta);
                }
                else
                {
                    firstToDraw[i].SetRectangleFillColor(Color.White);
                }
            }
        }
        public void HandlePr2Moved(object? source, MouseMoveEventArgs args)
        {
            if (arrowPr.GetGlobalBounds().Contains(args.X, args.Y))
            {
                arrowPr.Color = new Color(255, 0, 255, 122);
            }
            else
            {
                arrowPr.Color = Color.White;
            }
            for (int i = 1; i < secondToDraw.Count; ++i)
            {
                if (secondToDraw[i].Contains(args.X, args.Y))
                {
                    secondToDraw[i].SetRectangleFillColor(Color.Magenta);
                }
                else
                {
                    secondToDraw[i].SetRectangleFillColor(Color.White);
                }
            }
        }
        public void HandlePr1Pressed(object? source, MouseButtonEventArgs args)
        {
            for (int i = 1; i < firstToDraw.Count; ++i)
            {
                if (firstToDraw[i].Contains(args.X, args.Y))
                {
                    firstToDraw[0] = firstToDraw[i];
                    firstToDraw.RemoveRange(1, firstToDraw.Count - 1);
                    firstToDraw[0].SetPosition(new Vector2f(84, 19));
                    firstToDraw[0].SetRectangleFillColor(Color.White);
                    ChangePriority(firstToDraw[0].GetString(), true);
                    arrow.Rotation = 0;
                    break;
                }
            }
            if (arrow.GetGlobalBounds().Contains(args.X, args.Y))
            {
                if (arrow.Rotation == 0)
                {
                    List<Textbox> needToAdd = firstPriorities.FindAll(x => x.GetString() != firstToDraw[0].GetString());
                    for (int i = 0; i < needToAdd.Count; ++i)
                    {
                        needToAdd[i].SetPosition(firstToDraw[i].GetPosition() + new Vector2f(0, 30));
                        firstToDraw.Add(needToAdd[i]);
                    }
                    arrow.Rotation = 180;
                }
                else
                {
                    firstToDraw.RemoveRange(1, firstToDraw.Count - 1);
                    arrow.Rotation = 0;
                }
            }
        }
        public void HandlePr2Pressed(object? source, MouseButtonEventArgs args)
        {
            for (int i = 1; i < secondToDraw.Count; ++i)
            {
                if (secondToDraw[i].Contains(args.X, args.Y))
                {
                    secondToDraw[0] = secondToDraw[i];
                    secondToDraw.RemoveRange(1, secondToDraw.Count - 1);
                    secondToDraw[0].SetPosition(new Vector2f(1080, 19));
                    secondToDraw[0].SetRectangleFillColor(Color.White);
                    ChangePriority(secondToDraw[0].GetString(), false);
                    arrowPr.Rotation = 0;
                    break;
                }
            }
            if (arrowPr.GetGlobalBounds().Contains(args.X, args.Y))
            {
                if (arrowPr.Rotation == 0)
                {
                    List<Textbox> needToAdd = secondPriorities.FindAll(x => x.GetString() != secondToDraw[0].GetString());
                    for (int i = 0; i < needToAdd.Count; ++i)
                    {
                        needToAdd[i].SetPosition(secondToDraw[i].GetPosition() + new Vector2f(0, 30));
                        secondToDraw.Add(needToAdd[i]);
                    }
                    arrowPr.Rotation = 180;
                }
                else
                {
                    secondToDraw.RemoveRange(1, secondToDraw.Count - 1);
                    arrowPr.Rotation = 0;
                }
            }
        }
        public void ChangePriority(string exp, bool isFirst)
        {
            if (exp == "1%")
            {
                first.Priority = isFirst ? ThreadPriority.Lowest : first.Priority;
                second.Priority = !isFirst ? ThreadPriority.Lowest : second.Priority;
            }
            else if (exp == "25%")
            {
                first.Priority = isFirst ? ThreadPriority.BelowNormal : first.Priority;
                second.Priority = !isFirst ? ThreadPriority.BelowNormal : second.Priority;
            }
            else if (exp == "50%")
            {
                first.Priority = isFirst ? ThreadPriority.Normal : first.Priority;
                second.Priority = !isFirst ? ThreadPriority.Normal : second.Priority;
            }
            else if (exp == "75%")
            {
                first.Priority = isFirst ? ThreadPriority.AboveNormal : first.Priority;
                second.Priority = !isFirst ? ThreadPriority.AboveNormal : second.Priority;
            }
            else if (exp == "100%")
            {
                first.Priority = isFirst ? ThreadPriority.Highest : first.Priority;
                second.Priority = !isFirst ? ThreadPriority.Highest : second.Priority;
            }
        }
        public static void InitTextboxesPriorities(List<Textbox> textboxes)
        {
            Textbox textbox = new();
            textbox.SetTextColor(Color.Black);
            textbox.SetRectangleFillColor(Color.White);
            textbox.SetRectangleOutlineColor(Color.Black);
            textbox.SetRectangleOutlineThicknes(2);
            textbox.SetTextCharacterSize(16);
            textbox.SetPosition(1080, 19);
            textbox.SetRectangleSize(150, 30);

            textbox = new(textbox);
            textbox.SetString("1%");
            textboxes.Add(textbox);

            textbox = new(textbox);
            textbox.SetString("25%");
            textboxes.Add(textbox);

            textbox = new(textbox);
            textbox.SetString("50%");
            textboxes.Add(textbox);

            textbox = new(textbox);
            textbox.SetString("75%");
            textboxes.Add(textbox);

            textbox = new(textbox);
            textbox.SetString("100%");
            textboxes.Add(textbox);
        }
    }
}
