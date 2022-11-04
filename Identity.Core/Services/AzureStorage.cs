using Azure.Storage.Blobs;
using Identity.Core.ExternalModels.OptionsModels;
using Identity.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Identity.Core.Services
{
    public class AzureStorage : IStorage
    {
        private readonly AzureStorageOptions _options;
        public AzureStorage(IOptions<AzureStorageOptions> options)
        {
            _options = options.Value;
        }
        public async Task UploadAvatarAsync(IFormFile formFile)
        {
            var azureClient = new BlobServiceClient(_options.StorageConnectionString);
            var container = azureClient.GetBlobContainerClient(_options.Container);
            var blobClient = container.GetBlobClient(formFile.FileName);
            await blobClient.UploadAsync(formFile.OpenReadStream());
        }
    }
}
