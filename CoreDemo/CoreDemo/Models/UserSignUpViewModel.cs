using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz")]

        public string NameSurname { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Lütfen Parola Giriniz")]

        public string Password { get; set; }

        [Display(Name = "Parola Doğrula")]
        [Compare("Password", ErrorMessage = "Parolalar Uyuşmuyor!")]

        public string ConfirmPassword { get; set; }

        [Display(Name = "E-posta")]
        [Required(ErrorMessage = "Lütfen E-posta Giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }
    }

}
