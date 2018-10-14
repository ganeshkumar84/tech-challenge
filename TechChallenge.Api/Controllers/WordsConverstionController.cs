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

        // GET api/WordsConverstion/5
        [HttpGet("{inputnumber}")]
        public ActionResult<string> Get( string inputnumber )
        {
           NumberToWordsConversion numberToWordsConversion = new NumberToWordsConversion();

            return numberToWordsConversion.ConvertNumberintoWords(inputnumber);
        }
    }
}
