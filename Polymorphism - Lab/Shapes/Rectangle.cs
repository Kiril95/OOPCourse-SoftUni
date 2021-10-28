namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height { get; protected set; }
        public double Width { get; protected set; }
        
        public override double CalculatePerimeter()
        {
            return (this.Height + this.Width) * 2;
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}