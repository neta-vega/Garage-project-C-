using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class StringValidation
    {
        public static bool ContainsOnlyLetters(string i_String)
        {
            bool isValid = i_String != null;

            foreach (char character in i_String)
            {
                if (!char.IsLetter(character))
                {
                    isValid = false;
                }
            }

            return isValid;
        }
        public static bool ContainsOnlyLettersAndNumbers(string i_String)
        {
            bool isValid = i_String != null;

            foreach (char character in i_String)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}

