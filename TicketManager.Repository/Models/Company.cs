﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManager.Repository.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}