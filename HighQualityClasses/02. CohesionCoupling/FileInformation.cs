using System;
using System.Linq;

// Extract methods GetFileExtension() and GetFileNameWithoutExtension() in class FileInformation
// Verify its input parameters in the beginning of the method
// Use variables fileExtension and fileNameWithoutExtension instead of extension
namespace CohesionCoupling
{
    static class FileInformation
    {
        public static string GetFileExtension(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("Invalid input! You enter file name equal to null.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string fileExtension = fileName.Substring(indexOfLastDot + 1);
            return fileExtension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("Invalid input! You enter file name equal to null.");
            }

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string fileNameWithoutExtension = fileName.Substring(0, indexOfLastDot);
            return fileNameWithoutExtension;
        }
    }
}