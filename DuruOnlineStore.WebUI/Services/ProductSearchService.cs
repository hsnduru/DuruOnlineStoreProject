using DuruOnlineStore.Common.Configurations;
using DuruOnlineStore.Data.Context;
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
						   (String.IsNullOrEmpty(model.Name) || p.Name.Contains(model.Name))
							&& (!model.CategoryId.HasValue || p.CategoryId == model.CategoryId)
							&& (!model.CampaignId.HasValue || p.CampaignId == model.CampaignId)
						 orderby p.Name
						 select new ProductItemViewModel()
						 {
							 Id = p.Id,
							 Name = p.Name,
							 Category = p.Category.Name,
							 Campaign = p.Campaign.Name,
							 StockQuantity = p.StockQuantity ?? 0,
							 ImageUrl = MyApplicationConfig.ImageBaseUrl + p.ImageName,
							 Price = p.Price,
							 DiscountRate = p.Campaign.DiscountRate,
						 };

			return result.ToList();
			//return result.Take(15).ToList();
		}
	}
}
