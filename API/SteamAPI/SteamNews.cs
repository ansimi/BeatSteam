namespace API.SteamAPI
{
    public class SteamNews
    {
        //Create a API Call Method with a URL Builder Switch instead of a class for each HTTP Request
        public async Task<string> GetNewsForApp(Int64 appId, Int32 count, Int32 maxlength) 
        {
            string url = Constants.URLs.BaseUrl 
                + Constants.URLs.SteamNews + "GetNewsForApp/v0002/?" 
                + Constants.URLs.AppId + appId + Constants.URLs.Ampersand
                + Constants.URLs.Count + count  + Constants.URLs.Ampersand
                + Constants.URLs.MaxLength + maxlength + Constants.URLs.Ampersand
                + Constants.URLs.Format;

            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                return response;
            } 
        }
    }
}