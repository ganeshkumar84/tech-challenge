using System;

namespace TechChallenge.Services
{
    public class NumberToWordsConversion: INumberToWordsConversion
    {
        public string ConvertNumberintoWords( string number )
        {
            var convertStringtodouble = Convert.ToDouble( number );
            var numberToWords = ConvertNumberToWords( convertStringtodouble );
            return numberToWords;
        }

        public string ConvertNumberToWords( double doubleNumber )
        {

            var beforeFloatingPoint = ( int )Math.Floor( doubleNumber );
            var beforeFloatingPointWord = $"{NumberToWords( beforeFloatingPoint )} dollars";
            var regex = new System.Text.RegularExpressions.Regex( "(?<=[\\.])[0-9]+" );
            /* Below logic executes if the number is decimal. Ex:485.26  */
            var number = doubleNumber.ToString();
            if ( regex.IsMatch( number ) )
            {
                string decimalPlaces = regex.Match( number ).Value;
                if( decimalPlaces.Length > 2)
                {
                    decimalPlaces = decimalPlaces.Substring( 0, 2 );
                }
                int numberconvertion;
                if( int.TryParse( decimalPlaces, out numberconvertion ) )
                {
                    var afterFloatingPointWord =
                    $"{ConvertSmallNumberToWord( numberconvertion, "" )} cents";
                    return $"{beforeFloatingPointWord} and {afterFloatingPointWord}";
                }
            }
            return $"{beforeFloatingPointWord}";
        }

        private  string NumberToWords( int number )
        {
            if ( number == 0 )
                return "zero";

            if ( number < 0 )
                return "minus " + NumberToWords( Math.Abs( number ) );

            var words = "";

            if ( number / 1000000000 > 0 )
            {
                words += NumberToWords( number / 1000000000 ) + " billion ";
                number %= 1000000000;
            }

            if ( number / 1000000 > 0 )
            {
                words += NumberToWords( number / 1000000 ) + " million ";
                number %= 1000000;
            }

            if ( number / 1000 > 0 )
            {
                words += NumberToWords( number / 1000 ) + " thousand ";
                number %= 1000;
            }

            if ( number / 100 > 0 )
            {
                words += NumberToWords( number / 100 ) + " hundred ";
                number %= 100;
            }

            words = ConvertSmallNumberToWord( number, words );

            return words;
        }

        private  string ConvertSmallNumberToWord( int number, string words )
        {
            if ( number <= 0 ) return words;
            words = words.Trim();
            if ( words != "" )
                words += " ";

            var unitsMap = new[ ] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var tensMap = new[ ] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if ( number < 20 )
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ( ( number % 10 ) > 0 )
                    words += "-" + unitsMap[number % 10];
            }
            return words;
        }

    }
}
