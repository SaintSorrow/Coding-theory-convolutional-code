using System.Text.RegularExpressions;

namespace CodingTheory
{
    public class Validator
    {
        public static bool IsBinary(string _text)
        {
            return Regex.IsMatch(_text, "^[01]+$") ? true : false;
        }

        public static bool IsAscii(string _text)
        {
            foreach (char c in _text)
            {
                if (((int)c) > 127)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsNoiseValid(string _text)
        {
            bool isValid;

            if (!Regex.IsMatch(_text, @"^1\.\d{1,4}$") &&
                !Regex.IsMatch(_text, @"^0\.\d{1,4}$") &&
                !Regex.IsMatch(_text, @"^[0-1]$"))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
