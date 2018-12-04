using System.Text.RegularExpressions;

namespace CodingTheory
{
    /// <summary>
    /// Klasė skirta patikrinti ar iš formos paimtas tekstas yra atitinkamo formato
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// Tikrinama ar tekstas sudarytas iš 0 ir 1
        /// </summary>
        /// <param name="_text">
        /// Tekstas, kurį reikia patikrinti
        /// </param>
        /// <returns>
        /// true - tekstas atitinka formatą
        /// false - tekstas neatitinka formato
        /// </returns>
        public static bool IsBinary(string _text)
        {
            return Regex.IsMatch(_text, "^[01]+$") ? true : false;
        }

        /// <summary>
        /// Tikrina ar įvesto teksto simboliai priklauso ascii lentelei
        /// </summary>
        /// <param name="_text">
        /// Tekstas
        /// </param>
        /// <returns></returns>
        public static bool IsAscii(string _text)
        {
            char[] tmpArray = _text.ToCharArray();
            char charValue;

            for (int position = 0; position < tmpArray.Length; position++)
            {
                charValue = tmpArray[position];

                if ((int)charValue > 127)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Tikrinama ar gerai įvesta klaidos tikimybė
        /// </summary>
        /// <param name="_text">
        /// Tekstas, kurį reikioa patikrinti
        /// </param>
        /// <returns>
        /// true - tekstas atitinka formatą
        /// false - tekstas neatitinka formato
        /// </returns>
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
