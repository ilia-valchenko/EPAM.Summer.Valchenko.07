using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public sealed class Circle : Figures
    {
        public double Radius => radius;
        private double radius;

        public Circle():this(0.0) { }

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double GetAreaOfFigure() => Math.PI*Math.Pow(radius, 2);

        public override double GetPerimeterOfFigure() => 2*Math.PI*radius;
    }
}
