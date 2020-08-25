using System.Collections.Generic;

namespace TestTaskArticles.Models
{
    /// <summary>
    /// Модель статьи
    /// </summary>
    public class ArticlesModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<CommentsModel> Comments { get; set; }
        
    }
        
}
