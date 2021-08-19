using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SonsuzbilgiV2.Shared.Utilities.Extensions;
using SonsuzbilgiV2.Shared.Utilities.Results.Abstract;
using SonsuzbilgiV2.Shared.Utilities.Results.ComplexTypes;
using SonsuzbilgiV2.Shared.Utilities.Results.Concrete;
using SonsuzBilgiV2.Entities.DTOs;
using SonsuzBilgiV2.Mvc.Areas.Admin.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Mvc.Areas.Admin.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private readonly string imgFolder = "img";
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> ImageDelete(string PictureName)
        {
            
            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}", PictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = PictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Succes, imageDeletedDto);
            }
            return new DataResult<ImageDeletedDto>(ResultStatus.Error, "Şəkil Tapılmadı",null);
        }

        public async Task<IDataResult<ImageUploadedDto>> UploadUserImage(string userName, IFormFile pictureFile, string folderName="userImages")
        {
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            //TuralAbdulxaliqov/542_5_10_12_2020.png
            string newFileName = $"{userName}_{dateTime.FullDateAndStringWithUnderScore()}_{fileExtension}";
            string path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }
            return new DataResult<ImageUploadedDto>(ResultStatus.Succes, $"{userName} adlı istifadəçinin şəkli uğurla yükləndi.",
                new ImageUploadedDto
                {
                    FullName = $"{folderName}/{newFileName}",
                    OldName = oldFileName,
                    Extension = fileExtension,
                    FolderName = folderName,
                    Path = path,
                    Size = pictureFile.Length
                });
        }
    }
}
