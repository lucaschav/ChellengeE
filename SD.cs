namespace ChellengeE
{
    public static class SD
    {
        public static string UrlApiBase { get; set; }
        public static string ApiKey { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
