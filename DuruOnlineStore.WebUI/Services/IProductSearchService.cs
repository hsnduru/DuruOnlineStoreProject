using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.WebUI.Models;

namespace DuruOnlineStore.WebUI.Services
{
	public interface IProductSearchService
	{
		List<ProductItemViewModel> Search(ProductSearchModel model);
		public int GetTotalProductCount(ProductSearchModel model);
		public List<ProductItemViewModel> GetRandomProducts(int count);
		public List<ProductItemViewModel> GetFlashProducts();

    }
}