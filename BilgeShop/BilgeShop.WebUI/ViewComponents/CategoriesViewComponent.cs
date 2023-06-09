﻿using BilgeShop.Business.Services;
using BilgeShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeShop.WebUI.ViewComponents
{
    // Bir nevi harici controller
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {

            var categoriesDtos = _categoryService.GetCategories();

            var viewModel = categoriesDtos.Select(x => new CategoryViewModel
            {
                Id= x.Id,
                Name = x.Name,
            }).ToList();

            return View(viewModel);
        }

    }
}
