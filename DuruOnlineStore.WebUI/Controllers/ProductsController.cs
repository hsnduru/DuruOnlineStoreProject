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

		public ProductsController(DuruStoreContext context, IProductSearchService productSearchService)
		{
			_context = context;
			_productSearchService = productSearchService;
		}

		// GET: Products
		public async Task<IActionResult> Index(ProductSearchModel? model, int page =1)
        {
			model = model ?? new ProductSearchModel();

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
