using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.ViewModels.Ticket
{
    public class TicketAddViewModel
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public int CompanyID { get; set; }
    }
}
