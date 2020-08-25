using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestTaskArticles.Models
{
    /// <summary>
    /// Модель комментария
    /// </summary>
    public class CommentsModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо ввести комментарий")]
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public string ArticleText { get; set; }

        [Required(ErrorMessage ="Необходимо ввести Id пользователя(число)")]
        [Remote(action: "CheckUserId", controller: "Articles", ErrorMessage = "Пользователь с данным Id не найден в базе")]
        public int UserId { get; set; }
        public int ParentId { get; set; }
        public string UserName { get; set; }
        public List<CommentsModel> ChildComments { get; set; }
    }
}
