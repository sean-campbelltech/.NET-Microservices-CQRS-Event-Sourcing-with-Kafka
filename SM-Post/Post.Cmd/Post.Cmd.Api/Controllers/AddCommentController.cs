using CQRS.Core.Exceptions;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Cmd.Api.Commands;
using Post.Common.DTOs;

namespace Post.Cmd.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AddCommentController : ControllerBase
    {
        private readonly ILogger<AddCommentController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public AddCommentController(ILogger<AddCommentController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditMessageAsync(Guid id, AddCommentCommand command)
        {
            try
            {
                command.Id = id;
                await _commandDispatcher.Send(command);

                return Ok(new BaseResponse
                {
                    Message = "Add comment request completed successfully!"
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
                var safeErrorMessage = $"Error while processing request to add a comment to post with ID - {id}.";
                _logger.LogError(ex, safeErrorMessage, id);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = safeErrorMessage
                });
            }
        }
    }
}