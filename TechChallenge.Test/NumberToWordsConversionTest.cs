using Xunit;
using TechChallenge.Services;

namespace TechChallenge.Test
{
    public class NumberToWordsConversionTest
    {
        NumberToWordsConversion numberToWordsConversion = new NumberToWordsConversion();
        [Fact]
        public void Test1()
        {
            var numberInWords = numberToWordsConversion.ConvertNumberToWords( 1234.56 );

            Assert.Equal( "one thousand two hundred thirty-four dollars and fifty-six cents", numberInWords );
        }

        [Fact]
        public void Test2()
        {
            var numberInWords = numberToWordsConversion.ConvertNumberToWords( 8956.25 );

            Assert.Equal( "eight thousand nine hundred fifty-six dollars and twenty-five cents", numberInWords );
        }

        [Fact]
        public void Test3()
        {
            var numberInWords = numberToWordsConversion.ConvertNumberToWords( 85 );

            Assert.Equal( "eighty-five dollars", numberInWords );
        }

        [Fact]
        public void Test5()
        {
            var numberInWords = numberToWordsConversion.ConvertNumberToWords( 859633.35 );

            Assert.Equal( "eight hundred fifty-nine thousand six hundred thirty-three dollars and thirty-five cents", numberInWords );
        }
        
    }
}
