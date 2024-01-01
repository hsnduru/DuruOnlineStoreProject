using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;

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
    }
}
