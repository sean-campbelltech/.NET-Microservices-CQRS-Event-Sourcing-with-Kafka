using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Query.Api.Queries;
using Post.Query.Domain.Entities;

namespace Post.Query.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PostLookupController : ControllerBase
    {
        private readonly ILogger<PostLookupController> _logger;
        private readonly IQueryDispatcher<PostEntity> _queryDispatcher;

        public PostLookupController(ILogger<PostLookupController> logger, IQueryDispatcher<PostEntity> queryDispatcher)
        {
            _logger = logger;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPosts()
        {
            var posts = await _queryDispatcher.Send(new FindAllPostsQuery());

            if (posts == null || !posts.Any())
                return NoContent();

            return Ok(posts);
        }
    }
}