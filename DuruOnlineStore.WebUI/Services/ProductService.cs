using DuruOnlineStore.Common.Configurations;
using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace DuruOnlineStore.WebUI.Services
{
    public class ProductService : IProductService
    {
        private readonly DuruStoreContext _context;

        public ProductService(DuruStoreContext context)
        {
            _context = context;
        }

        public Product GetProductById(int Id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == Id);
        }

        public List<ProductItemViewModel> GetProducts(int count)
        {
            var randomProducts = _context.Products
                .OrderBy(p => Guid.NewGuid())
                .Take(count)
                .Include(p => p.Category)
                .ToList();

            // Product sınıfından ProductItemViewModel'a dönüştürme işlemi
            var result = randomProducts.Select(p => new ProductItemViewModel
            {
                Id = p.Id,
                ImageUrl = MyApplicationConfig.ImageBaseUrl + p.ImageName,
                Category = p.Category.Name,
                Name = p.Name,
                Price = p.Price
            }).ToList();

            return result;
        }
    }
}
