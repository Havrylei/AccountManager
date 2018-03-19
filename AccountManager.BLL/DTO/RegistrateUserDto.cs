using System;
using System.ComponentModel.DataAnnotations;

namespace AccountManager.BLL.DTO
{
    public class RegistrateUserDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string Confirm { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Choose gender")]
        public int GenderID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        public string Phone { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Choose country")]
        public int CountryID { get; set; }
        public string City { get; set; }
        public string Avatar { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HideEmail { get; set; }
        public bool HidePhone { get; set; }
    }
}
