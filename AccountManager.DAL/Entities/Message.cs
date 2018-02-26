using System;

namespace AccountManager.DAL.Entities
{
    public class Message
    {
        public long ID { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public long ReciverID { get; set; }
        public long SenderID { get; set; }
    }
}
