namespace Exercise3
{
    public class Rectangle : Shape
    {
        public Rectangle(float width, float height) : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return Width * Height;
        }
    }
}