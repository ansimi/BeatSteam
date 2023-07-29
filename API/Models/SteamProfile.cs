namespace API.Models
{
    public class SteamProfile
    {
        public string SteamId { get; set; }
        public string SteamName { get; set; }
        public string ProfilePicture { get; set; }
        public List<RecentlyPlayed> RecentlyPlayedGames { get; set; }
    }
}