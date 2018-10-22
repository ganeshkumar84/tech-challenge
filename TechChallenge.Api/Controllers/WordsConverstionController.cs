using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.Services;

namespace TechChallenge.Api.Controllers
{
    [Route( "api/[controller]" )]
    [EnableCors( "TechChallengeApiAllowPolicy" )]
    [ApiController]
    public class WordsConverstionController : ControllerBase
    {
        public INumberToWordsConversion _numberToWordsConversion { get; set; }

        public WordsConverstionController(INumberToWordsConversion numberToWordsConversion)
        {
            _numberToWordsConversion = numberToWordsConversion;
        }
        // GET api/WordsConverstion/5
        [HttpGet("{inputnumber}")]
        public ActionResult<string> Get( string inputnumber )
        {
            return _numberToWordsConversion.ConvertNumberintoWords(inputnumber);
        }
    }
}
