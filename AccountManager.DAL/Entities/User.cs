using System;
using Microsoft.AspNetCore.Identity;

namespace AccountManager.DAL.Entities
{
    public class User : IdentityUser
    {
        public int GenderID { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public int? CountryID { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HideEmail { get; set; }
        public bool HidePhone { get; set; }
    }
}
