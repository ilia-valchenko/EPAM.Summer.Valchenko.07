using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public class Triangle : IFigure
    {
        public double SideA
        {
            get
            {
                return sideA;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side A can't be less or equals to zero.");
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
                    throw new ArgumentException("Side B can't be less or equals to zero.");
                sideB = value;
            }
        }

        public double SideC
        {
            get
            {
                return sideC;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Side C can't be less or equals to zero.");
                sideC = value;
            }
        }

        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle():this(0.0, 0.0, 0.0) { }

        public Triangle(double sideA, double sideB, double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public double GetAreaOfFigure()
        {
            double p = GetPerimeterOfFigure();
            return Math.Sqrt(p*(p-sideA)*(p-sideB)*(p-sideC));
        }

        public double GetPerimeterOfFigure() => sideA + sideB + sideC;
    }
}
