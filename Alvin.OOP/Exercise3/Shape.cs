namespace Exercise3
{
    public abstract class Shape
    {
        private double _width;
        private double _height;

        protected Shape(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public abstract double CalculateSurface();
    }
}