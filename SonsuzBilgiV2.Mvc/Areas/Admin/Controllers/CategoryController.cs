using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SonsuzbilgiV2.Shared.Utilities.Extensions;
using SonsuzbilgiV2.Shared.Utilities.Results.ComplexTypes;
using SonsuzBilgiV2.Entities.DTOs;
using SonsuzBilgiV2.Mvc.Areas.Admin.Models;
using SonsuzBilgiV2.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SonsuzBilgiV2.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Editor")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAllByNonDelete();
            
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Add(categoryDto,"Tural Abdulxaliqov");
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    var categoryAddAjaxModel = JsonSerializer.Serialize(new CategoryAjaxViewModel
                    {
                        CategoryDto = result.Data,
                        CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryDto)
                    });
                    return Json(categoryAddAjaxModel);
                }
            }
                var categoryAddAjaxErrorModel = JsonSerializer.Serialize(new CategoryAjaxViewModel
                {
                    //Partialda xeta mesajlarini gosterecek
                    CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryDto)
                });
                return Json(categoryAddAjaxErrorModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int categoryId)
        {
            var result = await _categoryService.GetUpdateDto(categoryId);
            if (result.ResultStatus==ResultStatus.Succes)
            {
                return PartialView("_CategoryUpdatePartial",result.Data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.Update(categoryUpdateDto, "Tural Abdulxaliqov");
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    var categoryUpdateAjaxModel = JsonSerializer.Serialize(new CategoryAjaxUpdateViewModel
                    {
                        CategoryDto = result.Data,
                        CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)
                    });
                    return Json(categoryUpdateAjaxModel);
                }
            }
            var categoryUpdateAjaxErrorModel = JsonSerializer.Serialize(new CategoryAjaxUpdateViewModel
            {
                //Partialda xeta mesajlarini gosterecek
                CategoryUpdatePartial = await this.RenderViewToStringAsync("_CategoryUpdatePartial", categoryUpdateDto)
            });
            return Json(categoryUpdateAjaxErrorModel);
        }
        [HttpGet]
        public async Task<JsonResult> GetAllCategories()
        {
            var result = await _categoryService.GetAllByNonDelete();
            var categories = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(categories);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int categoryId)
        {
            var result = await _categoryService.Delete(categoryId,"Tural Abdulxaliqov");
            var deletedCategory = JsonSerializer.Serialize(result.Data);
            return Json(deletedCategory);
        }
    }
}
