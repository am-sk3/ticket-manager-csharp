using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.ViewModels.User
{
    public class UserGetAdminViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsEnabled { get; set; }
    }
}
