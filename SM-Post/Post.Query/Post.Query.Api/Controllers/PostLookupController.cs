using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Common.DTOs;
using Post.Query.Api.DTOs;
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
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindAllPostsQuery());

                if (posts == null || !posts.Any())
                    return NoContent();

                var count = posts.Count;
                return Ok(new PostLookupResponse
                {
                    Posts = posts,
                    Message = $"Successfully returned {count} post{(count > 1 ? "s" : string.Empty)}!"
                });
            }
            catch (Exception ex)
            {
                const string safeErrorMessage = "Error while processing request to retrieve all posts!";
                _logger.LogError(ex, safeErrorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = safeErrorMessage
                });
            }
        }

        [HttpGet("byId/{postId}")]
        public async Task<ActionResult> GetPostById(Guid postId)
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindPostByIdQuery { Id = postId });

                if (posts == null || !posts.Any())
                    return NoContent();

                return Ok(new PostLookupResponse
                {
                    Posts = posts,
                    Message = $"Successfully returned post!"
                });
            }
            catch (Exception ex)
            {
                const string safeErrorMessage = "Error while processing request to retrieve post by ID!";
                _logger.LogError(ex, safeErrorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = safeErrorMessage
                });
            }
        }

        [HttpGet("byAuthor/{author}")]
        public async Task<ActionResult> GetPostByAuthor(string author)
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindPostsByAuthorQuery { Author = author });

                if (posts == null || !posts.Any())
                    return NoContent();

                var count = posts.Count;
                return Ok(new PostLookupResponse
                {
                    Posts = posts,
                    Message = $"Successfully returned {count} post{(count > 1 ? "s" : string.Empty)}!"
                });
            }
            catch (Exception ex)
            {
                const string safeErrorMessage = "Error while processing request to retrieve post by author!";
                _logger.LogError(ex, safeErrorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = safeErrorMessage
                });
            }
        }

        [HttpGet("withComments")]
        public async Task<ActionResult> GetPostsWithComments()
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindPostsWithCommentsQuery());

                if (posts == null || !posts.Any())
                    return NoContent();

                var count = posts.Count;
                return Ok(new PostLookupResponse
                {
                    Posts = posts,
                    Message = $"Successfully returned {count} post{(count > 1 ? "s" : string.Empty)}!"
                });
            }
            catch (Exception ex)
            {
                const string safeErrorMessage = "Error while processing request to retrieve all posts with comments!";
                _logger.LogError(ex, safeErrorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = safeErrorMessage
                });
            }
        }

        [HttpGet("withLikes/{numberOfLikes}")]
        public async Task<ActionResult> GetPostWithLikes(int numberOfLikes)
        {
            try
            {
                var posts = await _queryDispatcher.SendAsync(new FindPostsWithLikesQuery { NumberOfLikes = numberOfLikes });

                if (posts == null || !posts.Any())
                    return NoContent();

                var count = posts.Count;
                return Ok(new PostLookupResponse
                {
                    Posts = posts,
                    Message = $"Successfully returned {count} post{(count > 1 ? "s" : string.Empty)}!"
                });
            }
            catch (Exception ex)
            {
                const string safeErrorMessage = "Error while processing request to retrieve posts with likes!";
                _logger.LogError(ex, safeErrorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = safeErrorMessage
                });
            }
        }
    }
}