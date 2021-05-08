using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketManager.ViewModels.Comment
{
    public class CommentAddEditViewModel
    {
        [JsonIgnore]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TicketID { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
