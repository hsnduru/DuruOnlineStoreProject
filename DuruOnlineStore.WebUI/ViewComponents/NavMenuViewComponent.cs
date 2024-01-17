using DuruOnlineStore.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DuruOnlineStore.WebUI.ViewComponents
{
	public class NavMenuViewComponent : ViewComponent
	{
		private readonly DuruStoreContext _context;

		public NavMenuViewComponent(DuruStoreContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			// İlk 3 kategoriyi belirliyoruz
			var excludedCategories = new List<string> { "Makyaj", "Parfüm ve Deodorant", "Kişisel Bakım" };

			// İlk 5 kategoriyi alıyoruz (belirli kategoriler hariç)
			var categories = await _context.Categories
				.Where(c => !excludedCategories.Contains(c.Name))
				.OrderBy(c => c.Id)
				.Take(5)
				.ToListAsync();

			// Daha fazla kategoriyi alıyoruz (belirli kategoriler hariç)
			var moreCategories = await _context.Categories
				.Where(c => !excludedCategories.Contains(c.Name))
				.OrderBy(c => c.Id)
				.Skip(5)
				.ToListAsync();

			ViewBag.MoreCategories = moreCategories;

			return View(categories);
		}
	}
}
