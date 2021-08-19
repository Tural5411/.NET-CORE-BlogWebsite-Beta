using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonsuzbilgiV2.Shared.Utilities.Extensions;
using SonsuzbilgiV2.Shared.Utilities.Results.ComplexTypes;
using SonsuzBilgiV2.Entities.Concrete;
using SonsuzBilgiV2.Entities.DTOs;
using SonsuzBilgiV2.Mvc.Areas.Admin.Helpers.Abstract;
using SonsuzBilgiV2.Mvc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IImageHelper _imageHelper;

        public UserController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            var users =await  _userManager.Users.ToListAsync();
            return View(new UserListDto 
            { 
            Users=users,
            ResultStatus=ResultStatus.Succes
            });
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<JsonResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userListDto =JsonSerializer.Serialize(new UserListDto
            {
                Users = users,
                ResultStatus = ResultStatus.Succes
            },new JsonSerializerOptions { 
                ReferenceHandler=ReferenceHandler.Preserve
            });
            return Json(userListDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                var uploadedImageDtoResult = await _imageHelper.UploadUserImage(userAddDto.UserName,userAddDto.PictureFile);
                userAddDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Succes ?
                    uploadedImageDtoResult.Data.FullName : "userImages/defaultUser.png"; 
                var user = _mapper.Map<User>(userAddDto);
                var result = await _userManager.CreateAsync(user, userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddAjaxModel = JsonSerializer.Serialize(new UserAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = ResultStatus.Succes,
                            Message = $"{user.UserName} adlı istifadəçi əlavə edildi.",
                            User = user
                        },
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAjaxViewModel
                    {
                        UserAddDto = userAddDto,
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxErrorModel);
                }
            }
            else
            {
                var userAddAjaxModelStateErrorModel = JsonSerializer.Serialize(new UserAjaxViewModel
                {
                    UserAddDto = userAddDto,
                    UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                });
                return Json(userAddAjaxModelStateErrorModel);
            }
            
           
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<PartialViewResult> Update(int userId)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
            
            return PartialView("_UserUpdatePartial", userUpdateDto);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUploaded = false;
                var oldUser = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
                var oldUserPicture = userUpdateDto.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    var uploadedImageDtoResult = await _imageHelper.UploadUserImage(userUpdateDto.UserName, userUpdateDto.PictureFile);
                    userUpdateDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Succes ?
                        uploadedImageDtoResult.Data.FullName : "userImages/defaultUser.png";
                    if (oldUserPicture != "userImages/defaultUser.png")
                    {
                        isNewPictureUploaded = true;
                    }
                }
                var updatedUser = _mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await _userManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewPictureUploaded)
                    {
                        _imageHelper.ImageDelete(oldUserPicture);
                    }
                    var userUpdatedViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = ResultStatus.Succes,
                            Message = $"{updatedUser.UserName} adlı istifadəçi uğurla editləndi.",
                            User = updatedUser
                        },
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                    });
                    return Json(userUpdatedViewModel);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    var userUpdatedErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                    {
                        UserUpdateDto=userUpdateDto,
                        UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                    });
                    return Json(userUpdatedErrorViewModel);
                }
            }
            else
            {
                var userUpdatedModalStateErrorViewModel = JsonSerializer.Serialize(new UserUpdateAjaxViewModel
                {
                    UserUpdateDto = userUpdateDto,
                    UserUpdatePartial = await this.RenderViewToStringAsync("_UserUpdatePartial", userUpdateDto)
                });
                return Json(userUpdatedModalStateErrorViewModel);
            }
        }
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> Delete(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                var deletedUser = JsonSerializer.Serialize(new UserDto
                {
                    ResultStatus = ResultStatus.Succes,
                    Message = $"{user.UserName} adlı istifadəçi uğurla silindi.",
                    User=user
                });
                return Json(deletedUser);
            }
            else
            {
                string errorMessages = string.Empty;
                foreach (var error in result.Errors)
                {
                    errorMessages=$"*{error.Description}\n";
                }
                var deletedUserErrorModal = JsonSerializer.Serialize(new UserDto
                {
                    Message = $"{user.UserName} adlı istifadəçi silinə bilmədi.\n{errorMessages}",
                    ResultStatus = ResultStatus.Error,
                    User=user
                });
                return Json(deletedUserErrorModal);
            }
            
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("UserLogin");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
                if (user!=null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", errorMessage: "Email və ya şifrəniz yanlışdır");
                        return View("UserLogin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", errorMessage: "Email və ya şifrəniz yanlışdır");
                    return View("UserLogin");
                }
            }
            else
            {
                return View("UserLogin");
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<ViewResult> ChangeDetails()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var updateDto = _mapper.Map<UserUpdateDto>(user);
            return View(updateDto);
        } 
        [HttpPost]
        public async Task<IActionResult> ChangeDetails(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool isNewPictureUploaded = false;
                var oldUser = await _userManager.GetUserAsync(HttpContext.User);
                var oldUserPicture = userUpdateDto.Picture;
                if (userUpdateDto.PictureFile != null)
                {
                    var uploadedImageDtoResult = await _imageHelper.UploadUserImage(userUpdateDto.UserName, userUpdateDto.PictureFile);
                    userUpdateDto.Picture = uploadedImageDtoResult.ResultStatus == ResultStatus.Succes ?
                        uploadedImageDtoResult.Data.FullName : "userImages/defaultUser.png";
                    if (oldUserPicture != "userImages/defaultUser.png")
                    {
                        isNewPictureUploaded = true;
                    }
                }
                var updatedUser = _mapper.Map<UserUpdateDto, User>(userUpdateDto, oldUser);
                var result = await _userManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    if (isNewPictureUploaded)
                    {
                        _imageHelper.ImageDelete(oldUserPicture);
                    }
                    TempData.Add("SuccessMessage", $"{userUpdateDto.UserName} adlı istifadəçi uğurla editləndi.");
                    return View(userUpdateDto);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(userUpdateDto);
                }
            }
            else
            {
                return View(userUpdateDto);
            }
        }
        [HttpGet]
        public ViewResult PasswordChange()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PasswordChange(UserPasswordChangeDto userPasswordChangeDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var isVerified = await _userManager.CheckPasswordAsync(user, userPasswordChangeDto.CurrentPassword);
                if (isVerified)
                {
                    var result = await _userManager.ChangePasswordAsync(user, 
                        userPasswordChangeDto.CurrentPassword, userPasswordChangeDto.NewPassword);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userPasswordChangeDto.NewPassword, true, false);
                        TempData.Add("SuccessMessage", "Şifrəniz uğurla dəyişdirildi.");
                        return View();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(userPasswordChangeDto);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Zəhmət olmasa yeni şifrənizi bir daha yoxlayın");
                    return View(userPasswordChangeDto);
                }
            }
            else
            {
                return View(userPasswordChangeDto);
            }
        }

        [HttpGet]
        public ViewResult AccesDenied()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}
