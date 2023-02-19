using Abp.Runtime.Security;
using Integrify.Application.Todo.Dtos;
using Integrify.Application.Todo.Servcies;
using Integrify.Domain.Todo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Integrify.Gui.Todo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoServcie _iTodoService;
        public TodoController(ILogger<TodoController> logger, ITodoServcie iTodoService, 
            UserManager<IdentityUser> userManager)
        {
            _logger=logger;
            _iTodoService = iTodoService;
        }
        /// <summary>
        /// This will use to create a Todo that will belong to a logged in user .
        /// if you are not logged in it will not work
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/todos")]
        public async Task<ActionResult> Create([FromBody] CreateTodoDto dto)
        {
            var userExists =  HttpContext.User.FindFirstValue("jti");
            var id = Guid.Parse(userExists);

            await _iTodoService.Create(dto,id);
            return Created("Data Added successfully...!!!", null);
        }
        /// <summary>
        /// It will update a Todo based on the id we will provide in the controller.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("api/v1/todos/{id}")]
        public async Task<ActionResult> Update(UpdateTodoDto dto, Guid id)
        {
            await _iTodoService.Update(dto, id);
            return NoContent();
        }
        /// <summary>
        /// It will get us a specific Todo based on id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CreateTodoDto), 200)]
        [Route("api/v1/todos/{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var todoItem = await _iTodoService.GetTodo(id);
            return Ok(todoItem);    
        }
        /// <summary>
        /// It will Delete the Todo item based on the id we provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(CreateTodoDto), 200)]
        [Route("api/v1/todos/{id}")]
        public async Task<ActionResult> DeleteTodo(Guid id)
        {
            var todoItem = _iTodoService.Delete(id);
            return NoContent();
        }
        /// <summary>
        /// It will return us the Todo based on the Status.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(TodoL), 200)]
        [Route("api/v1/todos/status={status}")]
        public async Task<ActionResult> GetAllByStatus(Status status)
        {
             var getAll = await _iTodoService.GetAllTodo(status);
             return Ok(getAll);
        }
        /// <summary>
        /// It will return all the Todo item of the Logged in user.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(TodoL), 200)]
        [Route("api/v1/todos")]
        public async Task<ActionResult> GetAll()
        {
            var getAll = await _iTodoService.GetAllTodo();
            return Ok(getAll);
        }
    }
}
