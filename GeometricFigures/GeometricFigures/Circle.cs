using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public sealed class Circle : IFigure
    {
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if(radius < 0)
                    throw new ArgumentException("Radius can't be less than zero.");
                radius = value;
            }
        }

        private double radius;

        public Circle():this(0.0) { }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetAreaOfFigure() => Math.PI*Math.Pow(radius, 2);

        public double GetPerimeterOfFigure() => 2*Math.PI*radius;
    }
}
