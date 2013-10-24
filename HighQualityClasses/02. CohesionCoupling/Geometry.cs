using System;

// Extract methods CalcDistance2D and CalcDistance3D in class Geometry
// Use additional variable squaredDistance
// Use widthOne, heightOne, depthOne, widthTwo, heightTwo and depthTwo instead of x1, y1, z1, x2, y2 and z2
namespace CohesionCoupling
{
    static class Geometry
    {
        public static double CalcDistance2D(double widthOne, double heightOne,
            double widthTwo, double heightTwo)
        {
            double squaredDistance =
                (widthTwo - widthOne) * (widthTwo - widthOne) +
                (heightTwo - heightOne) * (heightTwo - heightOne);
            double distance = Math.Sqrt(squaredDistance);
            return distance;
        }

        public static double CalcDistance3D(double widthOne, double heightOne, double depthOne,
            double widthTwo, double heightTwo, double depthTwo)
        {
            double squaredDistance =
                (widthTwo - widthOne) * (widthTwo - widthOne) +
                (heightTwo - heightOne) * (heightTwo - heightOne) +
                (depthTwo - depthOne) * (depthTwo - depthOne);
            double distance = Math.Sqrt(squaredDistance);
            return distance;
        }
    }
}