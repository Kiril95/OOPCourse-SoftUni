using System;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public void Draw()
        {
            DrawLine('*', '*');
            for (int i = 1; i < this.Height - 2; i++)
            {
                DrawLine('*', ' ');
            }
            DrawLine('*', '*');
        }

        private void DrawLine(char start, char end)
        {
            Console.WriteLine($"{start}{new string(end, this.Width - 2)}{start}");
        }
    }
}
