using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Common.Models.Identities
{
    public class LoginUserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
