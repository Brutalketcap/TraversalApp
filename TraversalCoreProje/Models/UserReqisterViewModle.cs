

using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserReqisterViewModle
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınız giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen kullanıcı şifrenizi giriniz")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz")]
        [Compare("Password", ErrorMessage = "sifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }
    }
}
