using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Data.Base
{
    public class PersonBase : EntityBase<int>
    {
        [Display(Name = "Adı")]
        public string Name { get; set; } = "";

        [Display(Name = "İkinci Adı")]
        public string? MiddleName { get; set; } = null;

        [Display(Name = "Soyadı")]
        public string Surname { get; set; } = "";
        
        [NotMapped]
        public string FullName => $"{Name} {MiddleName} {Surname.ToUpper()}";
    }

}
