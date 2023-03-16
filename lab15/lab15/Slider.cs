using SFMLgraphics = SFML.Graphics;
using SFMLsystem = SFML.System;

namespace lab15
{
    public class Slider : SFMLgraphics.Drawable
    {
        protected SFMLgraphics.RectangleShape rectangle;
        protected SFMLgraphics.RectangleShape menu1;
        protected SFMLgraphics.RectangleShape menu2;
        protected SFMLgraphics.CircleShape end1;
        protected SFMLgraphics.CircleShape end2;
        protected SFMLgraphics.CircleShape active;
        protected int value;
        protected delegate float coord(float x);
        protected delegate int val(float x);
        protected delegate float startPos(int val);
        protected coord mvf;
        protected val v;
        protected startPos start;
        public float actualPos = 0;
        protected float defaultFunc(float x) => x >= 0 && x <= rectangle.Size.X ? x : active.Position.X - rectangle.Position.X+rectangle.Size.X / 2;
        protected int toInt(float val) => (int)val;
        protected float startFunc(int value) => value + rectangle.Position.X - rectangle.Size.X / 2;
        public Slider()
        {
            rectangle = new SFMLgraphics.RectangleShape();
            end1 = new SFMLgraphics.CircleShape();
            end2 = new SFMLgraphics.CircleShape();
            menu1 = new SFMLgraphics.RectangleShape();
            menu2 = new SFMLgraphics.RectangleShape();
            active = new SFMLgraphics.CircleShape();
            mvf += defaultFunc;
            v += toInt;
            start += startFunc;
            value = 0;
        }
        public void setFillColorRectangle(SFMLgraphics.Color color)
        {
            rectangle.FillColor = end1.FillColor = end2.FillColor = color;
            menu1.FillColor = menu2.FillColor = color;
        }
        public void setRectangleSize(float x, float y)
        {
            rectangle.Size = new SFMLsystem.Vector2f(x - y, y);
            rectangle.Origin = new SFMLsystem.Vector2f((x-y) / 2, y / 2);

            end1.Radius = y / 2;
            end1.Origin = new SFMLsystem.Vector2f(y / 2, y / 2);
            end2.Radius = y / 2;
            end2.Origin = new SFMLsystem.Vector2f(y / 2, y / 2);

            menu1.Size = new SFMLsystem.Vector2f(y / 2 + rectangle.OutlineThickness, y);
            menu1.Origin = new SFMLsystem.Vector2f(0, y / 2);

            menu2.Size = new SFMLsystem.Vector2f(y / 2 + rectangle.OutlineThickness, y);
            menu2.Origin = new SFMLsystem.Vector2f(y / 2 + rectangle.OutlineThickness, y / 2);
        }
        public void setSliderPos(float x, float y)
        {
            rectangle.Position = new SFMLsystem.Vector2f(x, y);

            end1.Position = new SFMLsystem.Vector2f(x - rectangle.Size.X / 2, y);
            end2.Position = new SFMLsystem.Vector2f(x + rectangle.Size.X / 2, y);

            menu1.Position = new SFMLsystem.Vector2f(x - rectangle.Size.X / 2, y);
            menu2.Position = new SFMLsystem.Vector2f(x + rectangle.Size.X / 2, y);

            active.Position = new SFMLsystem.Vector2f(x - rectangle.Size.X / 2, y);
        }
        public void setActualRadius(float val)
        {
            active.Radius = val;
            active.Origin = new SFMLsystem.Vector2f(val, val);
        }
        public void setActualFillColor(SFMLgraphics.Color color)
        {
            active.FillColor = color;
        }
        public void setActualOutlineColor(SFMLgraphics.Color color)
        {
            active.OutlineColor = color;
        }
        public void setActualOutlineThickness(float val)
        {
            active.OutlineThickness = val;
        }
        public void setStartPos(int value)
        {
            this.value = value;
            active.Position = new SFMLsystem.Vector2f(start(value), active.Position.Y);
        }

        public void Draw(SFMLgraphics.RenderTarget target, SFMLgraphics.RenderStates states)
        {
            target.Draw(rectangle, states);
            target.Draw(end1, states);
            target.Draw(end2, states);
            target.Draw(menu2, states);
            target.Draw(menu1, states);
            target.Draw(active, states);
        }

    }
}
