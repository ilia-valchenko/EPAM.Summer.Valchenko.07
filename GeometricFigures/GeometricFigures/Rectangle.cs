using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Rectangle : Quadrilateral
    {
        public new double SideA => base.SideA;
        public new double SideB => base.SideB;

        public Rectangle():this(0.0,0.0) { }

        public Rectangle(double a, double b):base(a, b, a, b) { }

        public override double GetAreaOfFigure() => SideA*SideB;

        public override double GetPerimeterOfFigure() => 2*SideA + 2*SideB;
    }
}
