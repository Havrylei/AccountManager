using System;

namespace AccountManager.BLL.DTO
{
    public class MessageDto
    {
        public long ID { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public long ReciverID { get; set; }
        public long SenderID { get; set; }
    }
}
