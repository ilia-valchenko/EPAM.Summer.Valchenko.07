using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public sealed class Square : IFigure
    {
        public double Side
        {
            get
            {
                return side;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side can't be less or equals to zero.");
                side = value;
            }
        }

        private double side;

        public Square():this(0.0) { }

        public Square(double side) { Side = side; }

        public double GetAreaOfFigure() => Side*Side;

        public double GetPerimeterOfFigure() => 4*Side;
    }
}
