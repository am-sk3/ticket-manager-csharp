using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.Models
{
    public class CompanyClient
    {
        [Required]
        public string Name { get; set; }
    }
}
