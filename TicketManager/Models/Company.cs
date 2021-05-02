using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
