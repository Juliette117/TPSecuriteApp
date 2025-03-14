namespace ArticleApi.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);

    }
}
