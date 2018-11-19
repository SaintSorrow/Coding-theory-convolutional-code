using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
