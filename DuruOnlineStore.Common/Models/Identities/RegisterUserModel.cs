using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuruOnlineStore.Common.Models.Identities
{
    public class RegisterUserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi değil.")]
        [Display(Name = "E-Posta Adresi")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor!")]
        [Display(Name = "Şifre (Tekrar)")]
        public string PasswordConfirm { get; set; } = default!;
    }
}
