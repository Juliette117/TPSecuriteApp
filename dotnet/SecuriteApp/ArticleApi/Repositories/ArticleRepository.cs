using ArticleApi.Data;

namespace ArticleApi.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleDbContext  _context;
        public ArticleRepository(ArticleDbContext context) 
        {
            _context = context;
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {

        }
    }
}
