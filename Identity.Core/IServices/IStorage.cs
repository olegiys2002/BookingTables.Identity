﻿using Microsoft.AspNetCore.Http;

namespace Identity.Core.IServices
{
    public interface IStorage
    {
        Task UploadAvatarAsync(IFormFile formFile);
    }
}
