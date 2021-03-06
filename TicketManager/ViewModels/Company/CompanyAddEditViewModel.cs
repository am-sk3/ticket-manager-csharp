using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketManager.ViewModels.Company
{
    public class CompanyAddEditViewModel
    {
        [JsonIgnore]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
