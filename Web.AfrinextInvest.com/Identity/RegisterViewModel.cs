using System.ComponentModel.DataAnnotations;

namespace Web.AfrinextInvest.com.Identity
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Veuillez donner un nom d'utilisateur")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password), Compare(nameof(RegisterViewModel.Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Portable { get; set; }
    }
}
