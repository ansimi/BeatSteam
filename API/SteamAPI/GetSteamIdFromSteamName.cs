using System.Xml;

namespace API.SteamAPI
{
    public class GetSteamIdFromSteamName
    {
        public async Task<XmlDocument> GetSteamProfileInfoXml(string SteamName) 
        {
            XmlDocument xmlDoc = new XmlDocument();

            string url = String.Format("https://steamcommunity.com/id/{0}/?xml=1", SteamName);

            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                xmlDoc.LoadXml(response);
            } 

            return xmlDoc;
        }

        public string GetSteamId(XmlDocument xmlDoc)
        {
            XmlNodeList steamIdNode = xmlDoc.GetElementsByTagName("steamID64");
            string steamId = steamIdNode[0].InnerText;
            return steamId;
        }
    }
}