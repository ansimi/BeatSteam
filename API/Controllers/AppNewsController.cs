using API.SteamAPI;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")] // /API/AppNews
    public class AppNewsController : ControllerBase
    {
        SteamNews steamNews = new SteamNews();

        [HttpGet]
        public async Task<ActionResult<string>> GetAppNews()
        {
            Int64 appId = 1687950;
            Int32 count = 3;
            Int32 maxlength = 300;

            return await steamNews.GetNewsForApp(appId, count, maxlength);
        }
    }

}