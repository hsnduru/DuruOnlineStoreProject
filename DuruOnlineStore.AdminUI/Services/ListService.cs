using DuruOnlineStore.Data.Base;
using DuruOnlineStore.Data.Context;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuruOnlineStore.AdminUI.Servces
{
    public class ListService : IListService
    {
        private readonly DuruStoreContext _context;

        public ListService(DuruStoreContext context)
        {
            _context = context;
        }

        public SelectList GetProductList(object? selectedItem = null)
        {
            return new SelectList(_context.Products.OrderBy(it => it.Name), "Id", "Name", selectedItem);
        }

        public SelectList GetSelectList<TEntity>(object? selectedItem = null)
            where TEntity : class, INameEntity
        {
            var data = _context.Set<TEntity>()

                .Select(x => new { x.Id, x.Name })
                .OrderBy(x => x.Name)
                .ToList();

            var sl = new SelectList(data, "Id", "Name", selectedItem);
            return sl;
        }
    }
}
