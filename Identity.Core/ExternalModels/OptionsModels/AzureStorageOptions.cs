namespace Identity.Core.ExternalModels.OptionsModels
{
    public class AzureStorageOptions
    {
        public const string AzureStorageSettings = "AzureConfiguration";
        public string StorageConnectionString { get; set; }
        public string Container { get; set; }
    }
}
