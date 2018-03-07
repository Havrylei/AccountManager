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
        public int GradeID { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
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
