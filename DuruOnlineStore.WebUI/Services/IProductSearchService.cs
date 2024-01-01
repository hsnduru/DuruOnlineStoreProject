using DuruOnlineStore.WebUI.Models;

namespace DuruOnlineStore.WebUI.Services
{
	public interface IProductSearchService
	{
		List<ProductItemViewModel> Search(ProductSearchModel model);
	}
}