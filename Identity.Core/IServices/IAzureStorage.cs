namespace Identity.Core.IServices
{
    public interface IAzureStorage
    {
        Task UploadUserAvatarAsync();
    }
}
