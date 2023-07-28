using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")] // /API/Users
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Test() 
        {
            string url="http://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=1687950&count=3&maxlength=300&format=json"; //Have a separate class to send requests to SteamWebAPI and call those methods here
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                return response;
            }
        }
    }
}
