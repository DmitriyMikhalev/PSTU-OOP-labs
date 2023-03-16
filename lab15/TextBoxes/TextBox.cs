namespace TextBoxes
{
    public class Textbox: Drawable
    {
        protected RectangleShape rectangle;
        protected Text text;
        protected Font font;
        private readonly string filename = "/ofont.ru_Impact.ttf";
        private readonly string directory = Directory.GetCurrentDirectory();
        public Textbox()
        { 
            rectangle = new RectangleShape();
            text = new Text();
            font = new Font(filename: directory + filename);

            text.OutlineThickness = 0;
            text.Font = font; 
        }
        public Textbox(in Textbox textbox)
        {
            rectangle = new RectangleShape();
            text = new Text();
            font = new Font(directory + filename);

            text.Font = font;
            SetTextCharacterSize((int)textbox.text.CharacterSize);
            SetString(textbox.text.DisplayedString);
            SetTextColor(textbox.text.FillColor);
            SetRectangleOutlineColor(textbox.rectangle.OutlineColor);
            SetRectangleOutlineThicknes(textbox.rectangle.OutlineThickness);
            SetRectangleFillColor(textbox.rectangle.FillColor);
            SetRectangleSize(textbox.rectangle.Size);
            SetPosition(textbox.rectangle.Position);
        }
        public void SetTextColor(Color color)
        {
            text.FillColor = color;
        }
        public void SetRectangleFillColor(Color color)
        {
            rectangle.FillColor = color;
        }
        public void SetRectangleOutlineColor(Color color)
        {
            rectangle.OutlineColor = color;
        }
        public void SetRectangleOutlineThicknes(float thickness)
        {
            rectangle.OutlineThickness = thickness;
        }
        public void SetRectangleSize(float width, float height)
        {
            rectangle.Size = new Vector2f(
                x: width,
                y: height
            );
            rectangle.Origin = new Vector2f(
                x: width / 2,
                y: height / 2
            );
        }
        public void SetRectangleSize(Vector2f size)
        {
            rectangle.Size = size;
            rectangle.Origin = new Vector2f(
                x: size.X / 2,
                y: size.Y / 2
            );
        }
        public void SetPosition(float x, float y)
        {
            text.Origin = new Vector2f(
                x: text.GetGlobalBounds().Width / 2f,
                y: text.GetGlobalBounds().Height / 2f + text.CharacterSize / 6f
            );
            rectangle.Position = new Vector2f(x, y);
            text.Position = new Vector2f(x, y);

        }
        public void SetPosition(Vector2f vector)
        {
            text.Origin = new Vector2f(
                text.GetGlobalBounds().Width / 2f,
                text.GetGlobalBounds().Height / 2f + text.CharacterSize / 6f
            );
            rectangle.Position = vector;
            text.Position = vector;
        }
        public void SetTextCharacterSize(int size)
        {
            text.CharacterSize = (uint)size;
            text.Origin = new Vector2f(
                x: text.GetGlobalBounds().Width / 2f,
                y: text.GetGlobalBounds().Height / 2f + text.CharacterSize / 6f
            );
        }
        public void SetString(string str)
        {
            text.DisplayedString = str;
            text.Origin = new Vector2f(
                x: text.GetGlobalBounds().Width / 2f,
                y: text.GetGlobalBounds().Height / 2f + text.CharacterSize / 6f
            );
        }
        public string GetString() => text.DisplayedString;
        public Vector2f GetPosition() => rectangle.Position;
        public bool Contains(float x, float y) => rectangle.GetGlobalBounds().Contains(x, y);
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(rectangle, states);
            target.Draw(text, states);
        }
    }
}
