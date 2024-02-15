using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DuruOnlineStore.WebUI.Services
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

        public SelectList GetCategoryList(object? selectedItem = null)
        {
            var data = _context.Categories
                .Where(it => it.Products.Count > 0)
                .OrderBy(it => it.Name)
                .ToList();
            return new SelectList(data, "Id", "Name", selectedItem);
        }

		public Category GetCategoryById(int categoryId)
		{
			return _context.Categories.Find(categoryId);
		}
	}
}
