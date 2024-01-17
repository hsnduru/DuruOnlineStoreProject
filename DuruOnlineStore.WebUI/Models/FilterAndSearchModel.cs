using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuruOnlineStore.WebUI.Models
{
    public class FilterAndSearchModel
    {
        public List<SelectListItem> CategoryList { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
