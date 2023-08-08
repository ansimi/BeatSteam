using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.SteamAPI;

namespace API.Controllers
{
    [ApiController]
    [Route("API/[controller]")] // /API/SteamProfile
    public class SteamProfileController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<SteamProfile>> GetSteamProfile(string username)
        {
            SteamProfile sp = new();

            GetSteamPlayerProfile steamPlayerProfile = new();

            sp = await steamPlayerProfile.GetSteamProfile(username);

            return new List<SteamProfile> { sp };
        }

        [HttpGet("SteamProfileID")]
        public async Task<IEnumerable<SteamProfile>> GetSteamProfileFromSteamId(string steamid)
        {
            SteamProfile sp = new();

            GetSteamPlayerProfile steamPlayerProfile = new GetSteamPlayerProfile();

            sp = await steamPlayerProfile.GetSteamProfileFromSteamId(steamid);

            return new List<SteamProfile> { sp };

        }
    }
}