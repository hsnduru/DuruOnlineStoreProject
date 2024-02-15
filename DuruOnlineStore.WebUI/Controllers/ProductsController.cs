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
        public IActionResult Index(ProductSearchModel? model, bool? showFlashProducts, int categoryId = 0, int page = 1)
        {
            model = model ?? new ProductSearchModel();

            var categoryList = _listService.GetCategoryList();
            ViewBag.CategoryList = categoryList;

            ViewBag.RandomProducts = _productSearchService.GetRandomProducts(3);

            if (showFlashProducts.HasValue && showFlashProducts.Value)
            {
                // Kampanyalı ürünleri listeleme
                ViewBag.CategoryName = "FLAŞ ÜRÜNLER";
                var flashProducts = _productSearchService.GetFlashProducts(); 
                ViewBag.TotalProductCount = flashProducts.Count;
                return View(flashProducts.ToPagedList(page, 18));
            }

            if (categoryId > 0)
            {
                // Kategoriye ait ürünleri listeleme
                var category = _listService.GetCategoryById(categoryId);

                if (category != null)
                {
                    ViewBag.CategoryName = category.Name;
                    model.CategoryId = categoryId;
                    var categoryProducts = _productSearchService.Search(model);
                    ViewBag.TotalProductCount = _productSearchService.GetTotalProductCount(model);
                    return View(categoryProducts.ToPagedList(page, 18));
                }
                else
                {
                    // Kategori bulunamadı
                }
            }

            // Tüm ürünleri listeleme
            ViewBag.CategoryName = "TÜM KATEGORİLER";

            var data = _productSearchService.Search(model);
            ViewBag.TotalProductCount = _productSearchService.GetTotalProductCount(model);

            return View(data.ToPagedList(page, 18));
        }

        // GET: Details
        public IActionResult Details(int? id, ProductSearchModel? model)
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

            var relatedProducts = _context.Products.Where(p => p.CategoryId == productViewModel.CategoryId && p.Id != id)
                .Select(p => new ProductItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    Category = p.Category != null ? p.Category.Name : "",
                    Campaign = p.Campaign != null ? p.Campaign.Name : "",
                    Description = p.Description != null ? p.Description : "",
                    StockQuantity = p.StockQuantity ?? 0,
                    ImageUrl = MyApplicationConfig.ImageBaseUrl + p.ImageName,
                    Price = p.Price,
                    DiscountRate = p.Campaign != null ? p.Campaign.DiscountRate : 0,
                }).Take(4).ToList();

            ViewBag.RelatedProducts = relatedProducts;

            return View("Details", productViewModel);
        }
    }
}
