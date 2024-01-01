using DuruOnlineStore.Data.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuruOnlineStore.AdminUI.Servces
{
    public interface IListService
    {
        SelectList GetProductList(object? selectedItem = null);
        SelectList GetSelectList<TEntity>(object? selectedItem = null) where TEntity : class, INameEntity;
    }
}