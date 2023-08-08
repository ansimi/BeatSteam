using System.Xml;
using API.Models;
using Newtonsoft.Json.Linq;

namespace API.SteamAPI
{
    public class GetSteamPlayerProfile
    {
        public string steamId = string.Empty;

        /// <summary>
        /// Get Steam Player Profile from a Steam Username
        /// </summary>
        /// <param name="steamName">Steam Username</param>
        /// <returns>Model: Steam Profile</returns>
        public async Task<SteamProfile> GetSteamProfile(string steamName)
        {
            string profileUrl = Constants.URLs.BaseUrl 
                + Constants.URLs.SteamUser + "GetPlayerSummaries/v0002/?"
                + Constants.URLs.Key + Constants.URLs.APIKey + Constants.URLs.Ampersand
                + Constants.URLs.SteamIds + "{0}"; 

            string recentlyPlayedUrl = Constants.URLs.BaseUrl
                + Constants.URLs.PlayerService + "GetRecentlyPlayedGames/v0001/?"
                + Constants.URLs.Key + Constants.URLs.APIKey + Constants.URLs.Ampersand
                + Constants.URLs.SteamId + "{0}" + Constants.URLs.Ampersand
                + Constants.URLs.IncludeAppInfo + Constants.URLs.True + Constants.URLs.Ampersand
                + Constants.URLs.Format;

            SteamProfile profile = new();
            List<RecentlyPlayed> recentlyPlayed = new();

            //Get SteamId
            XmlDocument xmlDoc = await GetSteamProfileInfoXml(steamName);
            GetSteamId(xmlDoc);
            
            // Append Steam ID to URLs
            profileUrl = String.Format(profileUrl, steamId);
            recentlyPlayedUrl = String.Format(recentlyPlayedUrl, steamId);

            using (HttpClient client = new())
            {
                string response = await client.GetStringAsync(recentlyPlayedUrl);

                //Parse JSON
                JObject responseJson = JObject.Parse(response);
                int totalCount = Int32.Parse(responseJson.SelectToken("response").Value<string>("total_count"));
                for(int i = 0; i < totalCount; i++)
                {
                    string gameid = responseJson.SelectToken(String.Format("response.games[{0}]", i)).Value<string>("appid");
                    string gamename = responseJson.SelectToken(String.Format("response.games[{0}]", i)).Value<string>("name");
                    string pttwoweeks = responseJson.SelectToken(String.Format("response.games[{0}]", i)).Value<string>("playtime_2weeks");
                    string ptforever = responseJson.SelectToken(String.Format("response.games[{0}]", i)).Value<string>("playtime_forever");


                    RecentlyPlayed rp = new()
                    {
                        GameId = gameid,
                        GameName = gamename,
                        PlayTimeTwoWeeks = pttwoweeks,
                        PlayTimeForever = ptforever
                    };

                    recentlyPlayed.Add(rp);
                }
                
            }

            using (HttpClient client = new())
            {
                string response = await client.GetStringAsync(profileUrl);

                //Parse JSON
                JObject responseJson = JObject.Parse(response);
                string personname = responseJson.SelectToken("response.players[0]").Value<string>("personaname");
                string steamid = responseJson.SelectToken("response.players[0]").Value<string>("steamid");
                string avatarfull = responseJson.SelectToken("response.players[0]").Value<string>("avatarfull");
                string profileurl = responseJson.SelectToken("response.players[0]").Value<string>("profileurl");
                string realname = responseJson.SelectToken("response.players[0]").Value<string>("realname") ?? personname;
                string loccountrycode = responseJson.SelectToken("response.players[0]").Value<string>("loccountrycode");

                //Assign JSON value to SteamProfile Object
                profile.SteamName = personname;
                profile.SteamId = steamid;
                profile.ProfilePicture = avatarfull;
                profile.RecentlyPlayedGames = recentlyPlayed;
                profile.ProfileURL = profileurl;
                profile.RealName = realname;
                profile.CountryCode = loccountrycode;

                return profile;
            } 
        }

        /// <summary>
        /// Get Steam Profile Information from SteamID
        /// </summary>
        /// <param name="steamId">SteamID</param>
        /// <returns>Model: Steam Profile</returns>
        public async Task<SteamProfile> GetSteamProfileFromSteamId(string steamId)
        {
            string profileUrl = Constants.URLs.BaseUrl 
                + Constants.URLs.SteamUser + "GetPlayerSummaries/v0002/?"
                + Constants.URLs.Key + Constants.URLs.APIKey + Constants.URLs.Ampersand
                + Constants.URLs.SteamIds + steamId; 

            string recentlyPlayedUrl = Constants.URLs.BaseUrl
                + Constants.URLs.PlayerService + "GetRecentlyPlayedGames/v0001/?"
                + Constants.URLs.Key + Constants.URLs.APIKey + Constants.URLs.Ampersand
                + Constants.URLs.SteamId + steamId + Constants.URLs.Ampersand
                + Constants.URLs.IncludeAppInfo + Constants.URLs.True + Constants.URLs.Ampersand
                + Constants.URLs.Format;

            SteamProfile profile = new();
            List<RecentlyPlayed> recentlyPlayed = new();

            using (HttpClient client = new())
            {
                string response = await client.GetStringAsync(recentlyPlayedUrl);

                //Parse JSON
                JObject responseJson = JObject.Parse(response);
                int totalCount = Int32.Parse(responseJson.SelectToken("response").Value<string>("total_count"));
                for(int i = 0; i < totalCount; i++)
                {
                    string gameid = responseJson.SelectToken(String.Format("response.games[{0}]", i)).Value<string>("appid");
                    string gamename = responseJson.SelectToken(String.Format("response.games[{0}]", i)).Value<string>("name");
                    string pttwoweeks = responseJson.SelectToken(String.Format("response.games[{0}]", i)).Value<string>("playtime_2weeks");
                    string ptforever = responseJson.SelectToken(String.Format("response.games[{0}]", i)).Value<string>("playtime_forever");

                    RecentlyPlayed rp = new()
                    {
                        GameId = gameid,
                        GameName = gamename,
                        PlayTimeTwoWeeks = pttwoweeks,
                        PlayTimeForever = ptforever
                    };

                    recentlyPlayed.Add(rp);
                }
                
            }

            using (HttpClient client = new())
            {
                string response = await client.GetStringAsync(profileUrl);

                //Parse JSON
                JObject responseJson = JObject.Parse(response);
                string personname = responseJson.SelectToken("response.players[0]").Value<string>("personaname");
                string steamid = responseJson.SelectToken("response.players[0]").Value<string>("steamid");
                string avatarfull = responseJson.SelectToken("response.players[0]").Value<string>("avatarfull");
                string profileurl = responseJson.SelectToken("response.players[0]").Value<string>("profileurl");
                string realname = responseJson.SelectToken("response.players[0]").Value<string>("realname") ?? personname;
                string loccountrycode = responseJson.SelectToken("response.players[0]").Value<string>("loccountrycode");

                //Assign JSON value to SteamProfile Object
                profile.SteamName = personname;
                profile.SteamId = steamid;
                profile.ProfilePicture = avatarfull;
                profile.RecentlyPlayedGames = recentlyPlayed;
                profile.ProfileURL = profileurl;
                profile.RealName = realname;
                profile.CountryCode = loccountrycode;

                return profile;
            } 
        }

        /// <summary>
        /// Get Steam Profile Information from Steam Username in an XML Format
        /// </summary>
        /// <param name="steamName">Steam Username</param>
        /// <returns>XML Formatted Steam Profile Information</returns>
        public async Task<XmlDocument> GetSteamProfileInfoXml(string steamName) 
        {
            XmlDocument xmlDoc = new();

            string url = String.Format(Constants.URLs.SteamProfileUrl, steamName);

            using (HttpClient client = new())
            {
                string response = await client.GetStringAsync(url);
                xmlDoc.LoadXml(response);
            } 

            return xmlDoc;
        }

        /// <summary>
        /// Assign SteamID to the global variable steamId
        /// </summary>
        /// <param name="xmlDoc">XML Document of Steam Profile</param>
        public void GetSteamId(XmlDocument xmlDoc)
        {
            XmlNodeList steamIdNode = xmlDoc.GetElementsByTagName(Constants.URLs.SteamIdXml);
            steamId = steamIdNode[0].InnerText;
        }
    }
}