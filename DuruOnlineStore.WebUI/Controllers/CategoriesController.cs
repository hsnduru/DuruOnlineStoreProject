using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DuruOnlineStore.WebUI.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly IListService _listService;

		public CategoriesController(IListService listService)
		{
			_listService = listService;
		}

        public IActionResult NavigationMenu()
        {
			var categories = _listService.GetCategoryList();
            return ViewComponent("NavMenu", categories);
        }
	}
}
