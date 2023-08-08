namespace API.Models
{
    public class RecentlyPlayed
    {
        public string GameId { get; set; }
        public string GameName { get; set; }
        public string PlayTimeTwoWeeks { get; set; }
        public string PlayTimeForever { get; set; }
    }
}