using System;

namespace Exercise3
{
    internal class Program
    {
        private static void Main()
        {
            var shapes = new Shape[]
            {
                new Rectangle(7, 6),
                new Triangle(7, 6),
                new Circle(5),
            };
            foreach (var shape in shapes)
            {
                Console.WriteLine("{0}: {1}", shape.GetType().Name, shape.CalculateSurface());
            }

            Console.ReadLine();
        }
    }
}