namespace Exercise3
{
    public abstract class Shape
    {
        protected Shape(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public abstract double CalculateSurface();
    }
}