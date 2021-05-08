using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Models;

namespace TicketManager.ViewModels.Ticket
{
    public class TicketGetAllViewModel
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public int UserID { get; set; }
        public DateTime CreationDate { get; set; }
        public TicketStatus Status { get; set; }
        public int CompanyID { get; set; }
    }
}
