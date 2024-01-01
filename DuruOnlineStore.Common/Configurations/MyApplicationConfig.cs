using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Common.Configurations
{
    public class MyApplicationConfig
    {
        public static string AdminSiteUrl { get; set; } = "https://localhost:7146/";
        public static string WebSiteUrl { get; set; } = "https://localhost:7167/";

        //public static string AdminImageBaseUrl => AdminSiteUrl + "images/products/";
        public static string ImageBaseUrl => WebSiteUrl + "images/products/";
       
        public static string ImageBaseFolder { get; set; } = "C:\\Users\\hasan\\Desktop\\DuruStore\\DuruOnlineStoreProject\\DuruOnlineStore.WebUI\\wwwroot\\images\\products\\";
    }
}
