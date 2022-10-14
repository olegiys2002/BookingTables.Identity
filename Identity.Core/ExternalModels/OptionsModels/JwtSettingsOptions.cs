namespace Identity.Core.ExternalModels.OptionsModels
{
    public class JwtSettingsOptions
    {
        public const string JwtSettings = "JwtSettings";
        public string SecretKey { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string Expires { get; set; }

    }
}
