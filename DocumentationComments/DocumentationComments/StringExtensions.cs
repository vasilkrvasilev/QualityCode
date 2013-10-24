// Extract TRUE_VALUE, BULGARIAN_LETTERS, LATIN_REPRESENTATION_OF_BULGARIAN_LETTERS,
// LATIN_LETTERS, BULGARIAN_REPRESENTATION_OF_LATIN_KEYBOARD and
// FILE_EXTENTION_TO_CONTENT_TYPE as constants
// Use startFrom parameter GetStringBetween() method only once, don't change its value, use second time 0 insted of it
// Add Main() method
// Add comments and xml docimentation comments and generate DocumentationComments.XML in bin-Debug
// Generate CHM book
namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provide extension methods to convert, extract and modify string value
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// This readonly constant contains predefined string values evaluated as true
        /// </summary>
        /// <seealso cref="StringExtensions.ToBoolean"/>
        public static readonly string[] TRUE_VALUE = { "true", "ok", "yes", "1", "да" };

        /// <summary>
        /// This readonly constant contains bulgarian alphabet
        /// </summary>
        /// <seealso cref="StringExtensions.ConvertCyrillicToLatinLetters"/>
        public static readonly string[] BULGARIAN_LETTERS =
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };

        /// <summary>
        /// This readonly constant contains latin representation of bulgarian alphabet
        /// </summary>
        /// <seealso cref="StringExtensions.ConvertCyrillicToLatinLetters"/>
        public static readonly string[] LATIN_REPRESENTATION_OF_BULGARIAN_LETTERS =
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k", "l", "m", "n", "o", "p",
                "r", "s", "t", "u", "f", "h", "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };

        /// <summary>
        /// This readonly constant contains latin alphabet
        /// </summary>
        /// <seealso cref="StringExtensions.ConvertLatinToCyrillicKeyboard"/>
        public static readonly string[] LATIN_LETTERS =
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

        /// <summary>
        /// This readonly constant contains bulgarian representation of latin alphabet
        /// </summary>
        /// <seealso cref="StringExtensions.ConvertLatinToCyrillicKeyboard"/>
        public static readonly string[] BULGARIAN_REPRESENTATION_OF_LATIN_KEYBOARD =
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к", "л", "м", "н", "о", "п", 
                "я", "р", "с", "т", "у", "ж", "в", "ь", "ъ", "з"
            };

        /// <summary>
        /// This readonly constant contains representation of file extentions
        /// </summary>
        /// <seealso cref="StringExtensions.ToContentType"/>
        public static readonly Dictionary<string, string> FILE_EXTENTION_TO_CONTENT_TYPE = 
            new Dictionary<string, string> 
            {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" } 
            };

        /// <summary>
        /// Convert string (char by char) in hexadecimal format
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <returns>Converted string value</returns>
        public static string ToMd5Hash(this string input)
        {
            // Convert the input string to a byte array, compute the hash.
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
 
            // Format each byte as a hexadecimal string.
            var builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Convert string value to boolean value
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <seealso cref="StringExtensions.TRUE_VALUE"/>
        /// <returns>Converted string value</returns>
        public static bool ToBoolean(this string input)
        {
            return TRUE_VALUE.Contains(input.ToLower());
        }

        /// <summary>
        /// Convert string value to short value
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <returns>Converted string value or 0</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Convert string value to integer value
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <returns>Converted string value or 0</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Convert string value to long value
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <returns>Converted string value or 0</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Convert string value to DateTime value
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <returns>Converted string value or 1.1.0001 00:00:00</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Change the first char of string value to upercase
        /// </summary>
        /// <param name="input">String value to be changed</param>
        /// <returns>Changed string value</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + 
                input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Extract substring from string value
        /// </summary>
        /// <param name="input">String value from which is the substring exracted</param>
        /// <param name="startString">Marks the beginning of the substring to be exracted</param>
        /// <param name="endString">Marks the end of the substring to be exracted</param>
        /// <param name="startFrom">Marks the position in string value, from which start the search for a substring</param>
        /// <returns>Extracted substring or string.Empty</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            // If the previos is false there are startString and endString in the extacted substring
            // But have to check if endString is before startString
            var startPosition = 
                input.IndexOf(startString, 0, StringComparison.Ordinal) + startString.Length;
            var endPosition = 
                input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Convert cyrillic letters of string value to its latin representation
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <seealso cref="StringExtensions.BULGARIAN_LETTERS"/>
        /// <seealso cref="StringExtensions.LATIN_REPRESENTATION_OF_BULGARIAN_LETTERS"/>
        /// <returns>Converted string value</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            for (var i = 0; i < BULGARIAN_LETTERS.Length; i++)
            {
                input = input.Replace(BULGARIAN_LETTERS[i], LATIN_REPRESENTATION_OF_BULGARIAN_LETTERS[i]);
                input = input.Replace(BULGARIAN_LETTERS[i].ToUpper(), 
                    LATIN_REPRESENTATION_OF_BULGARIAN_LETTERS[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Convert latin letters of string value to its cyrillic representation
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <seealso cref="StringExtensions.LATIN_LETTERS"/>
        /// <seealso cref="StringExtensions.BULGARIAN_REPRESENTATION_OF_LATIN_KEYBOARD"/>
        /// <returns>Converted string value</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            for (int i = 0; i < LATIN_LETTERS.Length; i++)
            {
                input = input.Replace(LATIN_LETTERS[i], BULGARIAN_REPRESENTATION_OF_LATIN_KEYBOARD[i]);
                input = input.Replace(LATIN_LETTERS[i].ToUpper(), 
                    BULGARIAN_REPRESENTATION_OF_LATIN_KEYBOARD[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Replace cyrillic letters in string value to valid username
        /// </summary>
        /// <param name="input">String value to be changed</param>
        /// <seealso cref="StringExtensions.ConvertCyrillicToLatinLetters"/>
        /// <returns>Valid username</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Replace cyrillic letters in string value to valid filename
        /// </summary>
        /// <param name="input">String value to be changed</param>
        /// <seealso cref="StringExtensions.ConvertCyrillicToLatinLetters"/>
        /// <returns>Valid filename</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Extract substring from string value
        /// </summary>
        /// <param name="input">String value from which is the substring exracted</param>
        /// <param name="charsCount">Length of the extracted substring in chars</param>
        /// <returns>Extracted substring</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Extract file extention from string value
        /// </summary>
        /// <param name="fileName">String value from which is the file extention exracted</param>
        /// <returns>Extracted file extention or string.Empty</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Convert file extention to content type
        /// </summary>
        /// <param name="fileExtension">File extention to be converted</param>
        /// <returns>Converted file extention</returns>
        public static string ToContentType(this string fileExtension)
        {
            if (FILE_EXTENTION_TO_CONTENT_TYPE.ContainsKey(fileExtension.Trim()))
            {
                return FILE_EXTENTION_TO_CONTENT_TYPE[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Convert string value (char by char) to array of bytes
        /// </summary>
        /// <param name="input">String value to be converted</param>
        /// <returns>Converted string value</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}