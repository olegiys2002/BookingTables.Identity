using Firebase.Auth;
using Firebase.Storage;
using Identity.Core.ExternalModels.OptionsModels;
using Identity.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
namespace Identity.Core.Services
{
    public class FireStorage : IStorage
    {
        private readonly FireStorageOptions _storageOptions;
        public FireStorage(IOptions<FireStorageOptions> options)
        {
            _storageOptions = options.Value;
        }
        public async Task UploadAvatarAsync(IFormFile formFile)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(_storageOptions.ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(_storageOptions.AuthEmail, _storageOptions.AuthPassword);
            var cancelletion = new CancellationTokenSource();

            var upload = new FirebaseStorage(
                _storageOptions.Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                }).Child("avatars").Child(formFile.FileName).PutAsync(formFile.OpenReadStream(), cancelletion.Token);

        }
    }
}
