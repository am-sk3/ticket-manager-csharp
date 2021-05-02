using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime? CloseDate { get; set; }
        public int CompanyID { get; set; }
        public bool IsDeleted { get; set; }
        public int LastUpdateUserID { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
