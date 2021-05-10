using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketManager.Repository.Models;
using TicketManager.ViewModels.Comment;

namespace TicketManager.Extensions.ViewModel
{
    public static class CommentViewModelExtensions
    {
        public static CommentGetViewModel ToViewModel(this Comment comment)
        {
            return new CommentGetViewModel
            {
                Content = comment.Content,
                CreationDate = comment.CreationDate,
                ID = comment.ID,
                UserID = comment.UserID
            };
        }

        public static Comment ToModel(this CommentAddEditViewModel comment)
        {
            return new Comment
            {
                Content = comment.Content,
                ID = comment.ID,
                TicketID = comment.TicketID,
                UserID = comment.UserID
            };
        }
    }
}
