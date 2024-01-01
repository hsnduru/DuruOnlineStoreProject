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

namespace DuruOnlineStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DuruStoreContext _context;
		private readonly IProductSearchService _productService;

		public ProductsController(DuruStoreContext context, IProductSearchService productSearchService)
		{
			_context = context;
			_productService = productSearchService;
		}

		// GET: Products
		public async Task<IActionResult> Index(ProductSearchModel? model)
        {
			model = model ?? new ProductSearchModel();

			var data = _productService.Search(model);
			return View(data);
		}

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Products == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .Include(p => p.Campaign)
        //        .Include(p => p.Category)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    var viewModel = new ProductItemViewModel
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Category = product.Category.Name,
        //        Campaign = product.Campaign.Name,
        //        StockQuantity = product.StockQuantity ?? 0,
        //        ImageUrl = MyApplicationConfig.ImageBaseUrl + product.ImageName,
        //        Price = product.Price,
        //        DiscountRate = product.Campaign.DiscountRate,
        //    };

        //    return View("Details", viewModel);
        //}

        public async Task<IActionResult> Details()
        {
            return View();
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
