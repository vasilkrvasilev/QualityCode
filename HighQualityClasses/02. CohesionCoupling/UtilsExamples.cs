using System;

// Use classes FileInformation, Geometry and Point
namespace CohesionCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileInformation.GetFileExtension("example"));
            Console.WriteLine(FileInformation.GetFileExtension("example.pdf"));
            Console.WriteLine(FileInformation.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileInformation.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileInformation.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileInformation.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Geometry.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Geometry.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Point point = new Point(3, 4, 5);
            Console.WriteLine("Volume of the figure width points O(0,0,0) and A({0},{1},{2}) = {3:f2}",
                point.Width, point.Height, point.Depth, point.CalcVolume());
            Console.WriteLine("Diagonal in space from points O(0,0,0) and A({0},{1},{2}) = {3:f2}",
                point.Width, point.Height, point.Depth, point.CalcDiagonalInSpace());
            Console.WriteLine("Diagonal in field XY from points O(0,0) and A({0},{1}) = {2:f2}",
                point.Width, point.Height, point.CalcDiagonalInFieldXY());
            Console.WriteLine("Diagonal in field XZ from points O(0,0) and A({0},{1}) = {2:f2}",
                point.Width, point.Depth, point.CalcDiagonalInFieldXZ());
            Console.WriteLine("Diagonal in field YZ from points O(0,0) and A({0},{1}) = {2:f2}",
                point.Height, point.Depth, point.CalcDiagonalInFieldYZ());
        }
    }
}
