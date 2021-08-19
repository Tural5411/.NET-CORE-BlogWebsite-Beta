using Microsoft.AspNetCore.Http;
using SonsuzbilgiV2.Shared.Entities.Abstract;
using SonsuzBilgiV2.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Entities.DTOs
{
    public class UserUpdateDto:DtoGetBase
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("İstifadəçi Adı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır")]
        [MaxLength(50, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string UserName { get; set; }
        [DisplayName("Email Ünvanı")]
        [Required(ErrorMessage = "{0} boş olmamalıdır")]
        [MaxLength(100, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(10, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [DisplayName("Telefon Nömrəsi")]
        [Required(ErrorMessage = "{0} boş olmamalıdır")]
        [MaxLength(13, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")] // +994503653319 
        [MinLength(13, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DisplayName("Şəkil")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        [DisplayName("Şəkil")]
        public string Picture { get; set; }
    }
}
