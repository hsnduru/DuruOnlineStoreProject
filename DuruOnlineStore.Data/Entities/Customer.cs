using DuruOnlineStore.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Entities
{
    public class Customer : PersonBase
    {
        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Display(Name = "Soyadı")]
        public string Surname { get; set; }

        [EmailAddress, Display(Name = "E-posta")]
        public string EMail { get; set; }

        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
    }
}
