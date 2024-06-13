using Microsoft.AspNetCore.Mvc;

namespace ProjetVeloBackEnd.API.Controllers
{
    public class TestController : Controller
    {


        [HttpGet("test")]
        public string get()
        {
            return Environment.GetEnvironmentVariable("DefaultConnection");
             
        }
    }
}
