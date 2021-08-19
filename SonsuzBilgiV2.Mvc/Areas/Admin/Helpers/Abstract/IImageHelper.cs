using Microsoft.AspNetCore.Http;
using SonsuzbilgiV2.Shared.Utilities.Results.Abstract;
using SonsuzBilgiV2.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Mvc.Areas.Admin.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, 
            IFormFile pictureFile, string folderName="userImages");
        IDataResult<ImageDeletedDto> ImageDelete(string PictureName);
    }
}
