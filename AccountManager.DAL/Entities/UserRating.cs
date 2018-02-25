using System;

namespace AccountManager.DAL.Entities
{
    public class UserRating
    {
        public long ID { get; set; }
        public long ReciverID { get; set; }
        public long SenderID { get; set; }
    }
}
