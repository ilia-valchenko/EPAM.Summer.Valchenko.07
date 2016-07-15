using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public sealed class Rectangle : IFigure
    {
        public double SideA
        {
            get
            {
                return sideA;
            }
            set
            {
                if(value <= 0)
                    throw new ArgumentException("Side can't be less or equals to zero.");
                sideA = value;
            }
        }

        public double SideB
        {
            get
            {
                return sideB;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side can't be less or equals to zero.");
                sideB = value;
            }
        }

        private double sideA;
        private double sideB;

        public Rectangle():this(0.0,0.0) { }

        public Rectangle(double sideA, double sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public double GetAreaOfFigure() => SideA*SideB;

        public double GetPerimeterOfFigure() => 2*(SideA + SideB);
    }
}
