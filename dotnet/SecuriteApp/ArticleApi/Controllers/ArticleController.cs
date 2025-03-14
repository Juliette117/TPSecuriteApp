using ArticleApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace ArticleApi.Controllers
{
    [Route("api/articles")]
    [ApiController]
    [Authorize(Policy = "ApiScope")]

    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Utilisateur, Invité")]
        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _articleService.GetAllArticlesAsync();
        }

    }
}
