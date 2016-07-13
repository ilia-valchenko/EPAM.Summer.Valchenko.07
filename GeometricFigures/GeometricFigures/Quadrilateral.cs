using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    public abstract class Quadrilateral : Figures
    {
        protected double SideA => sideA;
        protected double SideB => sideB;
        protected double SideC => sideC;
        protected double SideD => sideD;

        public Quadrilateral():this(0.0,0.0,0.0,0.0) { }

        public Quadrilateral(double a, double b, double c, double d)
        {
            sideA = a;
            sideB = b;
            sideC = c;
            sideD = d;
        }

        private double sideA;
        private double sideB;
        private double sideC;
        private double sideD;
    }
}
