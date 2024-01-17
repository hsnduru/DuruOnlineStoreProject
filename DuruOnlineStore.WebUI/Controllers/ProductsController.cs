using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.WebUI.Models;
using DuruOnlineStore.WebUI.Services;
using DuruOnlineStore.Common.Configurations;
using X.PagedList;

namespace DuruOnlineStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DuruStoreContext _context;
		private readonly IProductSearchService _productSearchService;
		private readonly IListService _listService;

		public ProductsController(DuruStoreContext context, IProductSearchService productSearchService, IListService listService)
		{
			_context = context;
			_productSearchService = productSearchService;
			_listService = listService;
		}

		// GET: Products
		public async Task<IActionResult> Index(ProductSearchModel? model, int categoryId = 0, int page =1)
        {
			model = model ?? new ProductSearchModel();

			var categoryList = _listService.GetCategoryList();
			ViewBag.CategoryList = categoryList;

			// Kategoriye özel ürünleri listeleme
			if (categoryId > 0)
			{
				// Kategoriye ait ürünleri filtreleme işlemi
				model.CategoryId = categoryId;
				var categoryProducts = _productSearchService.Search(model);
				return View(categoryProducts.ToPagedList(page, 15));
			}

			// Tüm ürünleri listeleme
			var data = _productSearchService.Search(model);
			return View(data.ToPagedList(page,15));
		}

        // GET: Details
        public async Task<IActionResult> Details(int? id, ProductSearchModel? model)
        {
            if (id == null)
            {
                return NotFound();
            }

            model ??= new ProductSearchModel();

            model.Id = id;

            if (model.CategoryId.HasValue)
            {
                return RedirectToAction("Index", "Products", model);
            }

            var productViewModel = _productSearchService.Search(model).FirstOrDefault();

            if (productViewModel == null)
            {
                return NotFound();
            }

            return View("Details", productViewModel);
        }
    }
}
