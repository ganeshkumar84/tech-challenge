using System;

namespace TechChallenge.Services
{
    public class NumberToWordsConversion : INumberToWordsConversion
    {
        public string ConvertNumberintoWords(string number)
        {
            var convertStringtodouble = Convert.ToDouble(number);
            /* checks the input number is NAN*/
            if (!Double.IsNaN(convertStringtodouble) && !Double.IsInfinity(convertStringtodouble))
            {
                var numberToWords = ConvertNumberToWords(convertStringtodouble);
                return numberToWords;
            }
            else
            {
                return "please enter valid number";
            }
        }

        public string ConvertNumberToWords(double inputNumberToConvert)
        {

            var beforeFloatingPoint = (int)Math.Floor(inputNumberToConvert);
            /* convert number into words.(before precision value) */
            var beforeFloatingPointWord = $"{NumberToWords(beforeFloatingPoint)} dollars";
            var regexToMatchDecimalNumber = new System.Text.RegularExpressions.Regex("(?<=[\\.])[0-9]+");
            /* Below logic executes if the number is decimal. Ex:485.26  */
            var numberToConvert = inputNumberToConvert.ToString();
            if (regexToMatchDecimalNumber.IsMatch(numberToConvert))
            {
                string precisionFromNumber = regexToMatchDecimalNumber.Match(numberToConvert).Value;
                /*  if precision has 3 digits. example: .25 */
                if (precisionFromNumber.Length > 3)
                {
                    var roundedValueForThreeDigitPrecision = Math.Ceiling(inputNumberToConvert * 100) / 100;
                    precisionFromNumber = regexToMatchDecimalNumber.Match(roundedValueForThreeDigitPrecision.ToString()).Value;
                }
                /*  if precision has 2 digits. example: .25 */
                if (precisionFromNumber.Length > 2)
                {
                    precisionFromNumber = precisionFromNumber.Substring(0, 2);
                }
                /* convert precision into words */
                int numberconvertion;
                if (int.TryParse(precisionFromNumber, out numberconvertion))
                {
                    var afterFloatingPointWord =
                    $"{ConvertSmallNumberToWord(numberconvertion, "")} cents";
                    return $"{beforeFloatingPointWord} and {afterFloatingPointWord}";
                }
            }
            return $"{beforeFloatingPointWord}";
        }

        private string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            var words = "";

            if (number / 1000000000 > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if (number / 1000000 > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if (number / 1000 > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number / 100 > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            words = ConvertSmallNumberToWord(number, words);

            return words;
        }

        private string ConvertSmallNumberToWord(int number, string words)
        {
            if (number <= 0) return words;
            words = words.Trim();
            if (words != "")
                words += " ";

            var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += "-" + unitsMap[number % 10];
            }
            return words;
        }

    }
}
