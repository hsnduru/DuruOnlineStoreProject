﻿using System.ComponentModel.DataAnnotations;

namespace DuruOnlineStore.WebUI.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "E-Posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi değil.")]
        public string Email { get; set; }
    }
}
