using Microsoft.EntityFrameworkCore;

namespace ArticleApi.Data
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticlesDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
    }
}
