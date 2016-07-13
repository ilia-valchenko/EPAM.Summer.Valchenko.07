using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public class Triangle : Figures
    {
        public double SideA => sideA;
        public double SideB => sideB;
        public double SideC => sideC;

        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle():this(0.0, 0.0, 0.0) { }

        public Triangle(double sideA, double sideB, double sideC)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override double GetAreaOfFigure()
        {
            double p = GetPerimeterOfFigure();

            return Math.Sqrt(p*(p-sideA)*(p-sideB)*(p-sideC));
        }

        public override double GetPerimeterOfFigure() => sideA + sideB + sideC;
    }
}
