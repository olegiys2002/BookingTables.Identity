﻿namespace Identity.Core.ExternalModels.OptionsModels
{
    public class FireStorageOptions
    {
        public const string FireStorageSettings = "FireStorageSettings";
        public string ApiKey { get; set; }
        public string Bucket { get; set; }
        public string AuthEmail { get; set; }
        public string AuthPassword { get; set; }
    }
}
