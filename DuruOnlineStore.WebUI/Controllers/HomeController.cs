using DuruOnlineStore.Common.Configurations;
using DuruOnlineStore.Data.Context;
using DuruOnlineStore.WebUI.Models;
using DuruOnlineStore.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DuruOnlineStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DuruStoreContext _context;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, DuruStoreContext context, IProductService productService)
        {
            _logger = logger;
            _context = context;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var latestProducts = _context.Products
                .OrderByDescending(p => p.AddedDate)
                .Take(8)
                .Select(p => new ProductItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    Category = p.Category.Name,
                    Campaign = p.Campaign.Name,
                    Description = p.Description,
                    StockQuantity = p.StockQuantity ?? 0,
                    ImageUrl = MyApplicationConfig.ImageBaseUrl + p.ImageName,
                    Price = p.Price,
                    DiscountRate = p.Campaign.DiscountRate,
                    AddedDate = p.AddedDate
                })
                .ToList();

            var discountedProducts = _context.Products
                .Where(p => p.Campaign != null)
                .Take(8)
                .Select(p => new ProductItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryId = p.CategoryId,
                    Category = p.Category.Name,
                    Campaign = p.Campaign.Name,
                    Description = p.Description,
                    StockQuantity = p.StockQuantity ?? 0,
                    ImageUrl = MyApplicationConfig.ImageBaseUrl + p.ImageName,
                    Price = p.Price,
                    DiscountRate = p.Campaign.DiscountRate,
                    AddedDate = p.AddedDate
                })
                .ToList();

            ViewBag.LatestProducts = latestProducts;
            ViewBag.DiscountedProducts = discountedProducts;

            var allRandomProducts = _productService.GetProducts(6).ToList();

            ViewBag.RandomProducts1 = allRandomProducts.Take(3).ToList();
            ViewBag.RandomProducts2 = allRandomProducts.Skip(3).Take(3).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}