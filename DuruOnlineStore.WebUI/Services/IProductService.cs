using DuruOnlineStore.Data.Entities;

namespace DuruOnlineStore.WebUI.Services
{
    public interface IProductService
    {
        Product GetProductById(int productId);
    }
}