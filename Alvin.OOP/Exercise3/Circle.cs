using System;

namespace Exercise3
{
    public class Circle : Shape
    {
        public Circle(double radius) : base(radius, radius)
        {
        }

        public override double CalculateSurface()
        {
            return Math.PI * Width * Height;
        }
    }
}