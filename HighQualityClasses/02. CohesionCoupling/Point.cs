using System;
using System.Linq;

// Create class Point with properties Width, Height and Depth with private set
// Create constructor
// Use the properties in the methods CalcVolume(), CalcDiagonalInSpace(), CalcDiagonalInFieldXY(),
// CalcDiagonalInFieldXZ() and CalcDiagonalInFieldYZ()
// Use class Geometry
namespace CohesionCoupling
{
    class Point
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Depth { get; private set; }

        public Point(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double CalcVolume()
        {
            double volume = Math.Abs(this.Width) * Math.Abs(this.Height) * Math.Abs(this.Depth);
            return volume;
        }

        public double CalcDiagonalInSpace()
        {
            double distance = Geometry.CalcDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalcDiagonalInFieldXY()
        {
            double distance = Geometry.CalcDistance2D(0, 0, this.Width, this.Height);
            return distance;
        }

        public double CalcDiagonalInFieldXZ()
        {
            double distance = Geometry.CalcDistance2D(0, 0, this.Width, this.Depth);
            return distance;
        }

        public double CalcDiagonalInFieldYZ()
        {
            double distance = Geometry.CalcDistance2D(0, 0, this.Height, this.Depth);
            return distance;
        }
    }
}