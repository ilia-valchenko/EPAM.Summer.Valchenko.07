using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public sealed class Square : Quadrilateral
    {
        public double Side => base.SideA;

        public Square():this(0.0) { }

        public Square(double side):base(side, side, side, side) { }

        public override double GetAreaOfFigure() => base.SideA*base.SideA;

        public override double GetPerimeterOfFigure() => 4*base.SideA;
    }
}
