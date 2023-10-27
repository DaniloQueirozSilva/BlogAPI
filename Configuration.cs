namespace Blog
{
    public static class Configuration
    {
        public static string JwtKey { get; set; } = "oJ3mIvbMK02gmq5NJR+2BQ==";
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "da9f6713671da24a575ffbe6f0749ecb613efe7f3887b5c9f3e6cc8a94982ae9";
        public static SmtpConfiguration Smtp = new();
    
        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }

      
    
    }
}
