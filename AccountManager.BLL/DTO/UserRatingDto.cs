using System;

namespace AccountManager.BLL.DTO
{
    public class UserRatingDto
    {
        public long ID { get; set; }
        public long ReciverID { get; set; }
        public long SenderID { get; set; }
    }
}
