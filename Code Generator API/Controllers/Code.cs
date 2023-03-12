using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Code_Generator_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Code : ControllerBase
    {
        public Code()
        {

        }

        [HttpGet(Name = "Code")]
        public string GenerateBacode(string sku)
        {
            string[] strings = sku.Split(' ');
            string result = "";
            foreach (string s in strings)
            {
                if (s.Length <= 3)
                {
                    result += s + "/";
                }
                else if (s.EndsWith("g"))
                {
                    result += s.TrimEnd('g') + "/";
                }
                else
                {
                    result += s.Substring(0, s.Length/2 + 1) + "/";
                }
               
            }

            result = result.TrimEnd('/');
            result = result.ToUpper();
            return result;
        }
    }
}