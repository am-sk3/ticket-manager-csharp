using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.Repository.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TicketID { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
