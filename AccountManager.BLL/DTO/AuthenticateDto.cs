using System.ComponentModel.DataAnnotations;

namespace AccountManager.BLL.DTO
{
    public class AuthenticateDto
    {
        [Required(ErrorMessage = "Login should be present")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Password should be present")]
        public string Password { get; set; }
    }
}
