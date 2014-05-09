using System.ComponentModel.DataAnnotations;

namespace Skermstafir.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Núverandi lykilorð")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lykilorðið verður að vera a.m.k. {2} stafir að lengd.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nýtt lykilorð")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Staðfesta lykilorð")]
        [Compare("NewPassword", ErrorMessage = "Þetta er ekki sama lykilorð og þú skrifaðir fyrir ofan, reyndu aftur.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [Display(Name = "Muna eftir mér?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Notendanafn")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Lykilorðið verður að vera a.m.k. {2} stafir að lengd.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lykilorð")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Staðfesta lykilorð")]
        [Compare("Password", ErrorMessage = "Þetta er ekki sama lykilorð og þú skrifaðir fyrir ofan, reyndu aftur.")]
        public string ConfirmPassword { get; set; }
    }
}
