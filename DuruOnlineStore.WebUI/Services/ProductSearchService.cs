using DuruOnlineStore.Common.Configurations;
using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace DuruOnlineStore.WebUI.Services
{
	public class ProductSearchService : IProductSearchService
	{
		private readonly DuruStoreContext _db;

		public ProductSearchService(DuruStoreContext db)
		{
			_db = db;
		}

		public List<ProductItemViewModel> Search(ProductSearchModel model)
		{
            var result = from p in _db.Products
                 .Include(it => it.Category)
                 .Include(it => it.Campaign)
                         where
                           (model.Id == null || p.Id == model.Id) // Id'yi kontrol et
                           && (String.IsNullOrEmpty(model.Name) || p.Name.Contains(model.Name))
                           && (!model.CategoryId.HasValue || p.CategoryId == model.CategoryId)
                           && (!model.CampaignId.HasValue || p.CampaignId == model.CampaignId)
                         orderby p.Name
                         select new ProductItemViewModel()
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
                         };

            return result.ToList();
            //return result.Take(15).ToList();
        }

		public int GetTotalProductCount(ProductSearchModel model)
		{
			if (model.CategoryId > 0)
			{
				return _db.Products.Count(p => p.CategoryId == model.CategoryId);
			}

			return _db.Products.Count();
		}

		public List<ProductItemViewModel> GetRandomProducts(int count)
		{
			var randomProducts = _db.Products.OrderBy(p => Guid.NewGuid()).Take(count).ToList();

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

        public List<ProductItemViewModel> GetFlashProducts()
        {
            // Kampanyalı ürünleri listeleme
            var flashProducts = _db.Products
                .Where(p => p.Campaign != null)
                .OrderBy(p => Guid.NewGuid())
                .Take(18)
                .Include(p => p.Category)
                .Select(p => new ProductItemViewModel
                {
                    Id = p.Id,
                    ImageUrl = MyApplicationConfig.ImageBaseUrl + p.ImageName,
                    Category = p.Category.Name,
                    Name = p.Name,
                    Price = p.Price,
                    DiscountRate = p.Campaign.DiscountRate
                })
                .ToList();

            return flashProducts;
        }
    }
}
