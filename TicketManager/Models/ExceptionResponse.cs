using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.Models
{
    public class ExceptionResponse
    {
        public int Status { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
