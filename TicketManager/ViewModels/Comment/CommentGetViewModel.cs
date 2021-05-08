using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.ViewModels.Comment
{
    public class CommentGetViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
