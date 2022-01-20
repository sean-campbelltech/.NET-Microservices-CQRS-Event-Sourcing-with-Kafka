using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Cmd.Api.Commands;
using Post.Cmd.Api.DTOs;
using Post.Common.DTOs;

namespace Post.Cmd.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NewPostController : ControllerBase
    {
        private readonly ILogger<NewPostController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public NewPostController(ILogger<NewPostController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> NewPost([FromBody] NewPostCommand command)
        {
            var id = Guid.NewGuid();
            command.Id = id;

            try
            {
                await _commandDispatcher.Send(command);

                return StatusCode(StatusCodes.Status201Created, new NewPostResponse
                {
                    Message = "New post creation request completed successfully!",
                    Id = id
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.Log(LogLevel.Warning, ex, "Client made a bad request.");

                return BadRequest(new BaseResponse
                {
                    Message = ex.ToString()
                });
            }
            catch (Exception ex)
            {
                var safeErrorMessage = $"Error while processing request to create a new post for ID - {id}.";
                _logger.Log(LogLevel.Error, ex, safeErrorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, new NewPostResponse
                {
                    Message = safeErrorMessage,
                    Id = id
                });
            }
        }
    }
}