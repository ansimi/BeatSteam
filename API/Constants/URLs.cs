namespace API.Constants
{
    public static class URLs
    {
        //BaseURLs
        public const string BaseUrl = "http://api.steampowered.com/";
        public const string SteamProfileUrl = "https://steamcommunity.com/id/{0}/?xml=1"; // {0} - Steam Username
        
        //SubFolders
        public const string SteamNews = "ISteamNews/";
        public const string SteamUser = "ISteamUser/";
        public const string PlayerService = "IPlayerService/";

        //Parameters
        public const string Key = "key=";
        public const string SteamId = "steamid=";
        public const string SteamIds = "steamids=";
        public const string AppId = "appid=";
        public const string Count = "count=";
        public const string MaxLength = "maxlength=";
        public const string Format = "format=json";
        public const string IncludeAppInfo = "include_appinfo=";
        public const string Ampersand = "&";
        public const string True = "true";
        public const string False = "false";

        //Misc
        public const string SteamIdXml = "steamID64";


        //Move To Config
        public const string APIKey = "A59E3F389079E1B6D56B664B8938A516";
    
    }
}