using CQRS.Core.Exceptions;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Post.Cmd.Api.Commands;
using Post.Common.DTOs;

namespace Post.Cmd.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DeletePostController : ControllerBase
    {
        private readonly ILogger<DeletePostController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public DeletePostController(ILogger<DeletePostController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostAsync(Guid id)
        {
            try
            {
                await _commandDispatcher.Send(new DeletePostCommand { Id = id });

                return Ok(new BaseResponse
                {
                    Message = "Delete post request completed successfully!"
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
                var safeErrorMessage = $"Error while processing request to delete post with ID - {id}.";
                _logger.LogError(ex, safeErrorMessage);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = safeErrorMessage
                });
            }
        }
    }
}