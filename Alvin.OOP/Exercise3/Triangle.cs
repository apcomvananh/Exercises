namespace Exercise3
{
    public class Triangle : Shape
    {
        public Triangle(float width, float height) : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (Height * Width) / 2;
        }
    }
}