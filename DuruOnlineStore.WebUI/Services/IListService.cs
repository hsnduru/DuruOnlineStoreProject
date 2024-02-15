using DuruOnlineStore.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuruOnlineStore.WebUI.Services
{
    public interface IListService
    {
        SelectList GetCategoryList(object? selectedItem = null);
        SelectList GetProductList(object? selectedItem = null);
        public Category GetCategoryById(int categoryId);
	}
}