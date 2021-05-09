using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.Ticket;

namespace TicketManager.Extensions.ViewModel
{
    public static class TicketViewModelExtensions
    {
        public static TicketGetViewModel ToViewModel(this Ticket ticket)
        {
            return new TicketGetViewModel
            {
                ID = ticket.ID,
                Status = ticket.Status,
                Subject = ticket.Subject,
                CloseDate = ticket.CloseDate,
                CompanyID = ticket.CompanyID,
                Content = ticket.Content,
                CreationDate = ticket.CreationDate,
                LastUpdateDate = ticket.LastUpdateDate,
                LastUpdateUserID = ticket.LastUpdateUserID,
                UserID = ticket.UserID,
            };
        }

        public static TicketGetAllViewModel ToGetAllViewModel(this Ticket ticket)
        {
            return new TicketGetAllViewModel
            {
                ID = ticket.ID,
                UserID = ticket.UserID,
                CompanyID = ticket.CompanyID,
                CreationDate = ticket.CreationDate,
                Status = ticket.Status,
                Subject = ticket.Subject
            };
        }

        public static Ticket ToModel(this TicketAddViewModel ticket)
        {
            return new Ticket
            {
                Subject = ticket.Subject,
                Content = ticket.Content,
                CompanyID = ticket.CompanyID,
                UserID = ticket.UserID
            };
        }
    }
}
