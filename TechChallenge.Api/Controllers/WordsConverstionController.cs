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

        // GET api/values/5
        [HttpGet( "{nameandnumber}" )]
        public ActionResult<string> Get( string nameandnumber )
        {
           NumberToWordsConversion numberToWordsConversion = new NumberToWordsConversion();

            return numberToWordsConversion.ConvertNumberintoWords( nameandnumber );
        }
    }
}
