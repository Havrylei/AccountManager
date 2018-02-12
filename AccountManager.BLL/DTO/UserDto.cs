using System;

namespace AccountManager.BLL.DTO
{
    public class UserDto
    {
        public long ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int GradeID { get; set; }
        public GradeDto Grade { get; set; }
        public int GroupID { get; set; }
        public GroupDto Group { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public int CountryID { get; set; }
        public CountryDto Country { get; set; }
        public string City { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HideEmail { get; set; }
        public bool HidePhone { get; set; }

    }
}
