using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ArticleApi.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Resume { get; set; }
        public Date publishedOn { get; set; }
        public int Quantity { get; set; }
        public int Like { get; set; }
        public bool IsPublished { get; set; }

      
    }
}
