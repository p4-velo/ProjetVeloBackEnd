using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ProjetVeloBackEnd.API.Controllers
{
    public class TestController : Controller
    {
        private IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        } 

        [HttpGet("test")]
        public string get()
        {
            return _configuration.GetConnectionString("DefaultConnection");
             
        }
    }
}
