using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.WebUI.Models;

namespace DuruOnlineStore.WebUI.Services
{
    public interface IProductService
    {
        Product GetProductById(int productId);
        public List<ProductItemViewModel> GetProducts(int count);
    }
}