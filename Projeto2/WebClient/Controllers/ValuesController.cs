using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class ValuesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
    
        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
    
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("github");
            
            string result = await client.GetStringAsync("/");
            return Ok(result);
        }
    }
}