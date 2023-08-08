using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.SteamAPI;
using System.Xml;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")] // /API/Profile
    public class TestProfileController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SteamProfile> TestGet() 
        {
            RecentlyPlayed rp = new RecentlyPlayed();
            rp.GameId = "27488374792";
            rp.GameName = "Metal Gear Triangle";

            SteamProfile sp = new SteamProfile();
            sp.SteamId = "76561198091475347";
            sp.SteamName = "ANSIMI";
            sp.ProfilePicture = "https://avatars.cloudflare.steamstatic.com/f4f2fc58620a769dfcc51defda89ed5cb8fa7d75_full.jpg";
            sp.RecentlyPlayedGames = new List<RecentlyPlayed>();
            sp.RecentlyPlayedGames.Add(rp);

            return new List<SteamProfile> { sp };
        }
    }
}