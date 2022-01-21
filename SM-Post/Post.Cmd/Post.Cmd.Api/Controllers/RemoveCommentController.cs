using CQRS.Core.Exceptions;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Cmd.Api.Commands;
using Post.Common.DTOs;

namespace Post.Cmd.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RemoveCommentController : ControllerBase
    {
        private readonly ILogger<RemoveCommentController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public RemoveCommentController(ILogger<RemoveCommentController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditMessageAsync(Guid id, RemoveCommentCommand command)
        {
            try
            {
                command.Id = id;
                await _commandDispatcher.Send(command);

                return Ok(new BaseResponse
                {
                    Message = "Remove comment request completed successfully!"
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Client made a bad request.");

                return BadRequest(new BaseResponse
                {
                    Message = ex.ToString()
                });
            }
            catch (AggregateNotFoundException ex)
            {
                _logger.LogWarning(ex, "Could not retrieve aggregate, client passed an incorrect post ID targetting the aggregate.");

                return BadRequest(new BaseResponse
                {
                    Message = ex.ToString()
                });
            }
            catch (Exception ex)
            {
                var safeErrorMessage = $"Error while processing request to remove a comment with ID - {command.CommentId} that was made on a post with ID - {id}.";
                _logger.LogError(ex, safeErrorMessage, id);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = safeErrorMessage
                });
            }
        }
    }
}