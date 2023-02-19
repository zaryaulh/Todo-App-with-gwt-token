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
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TodoController(ILogger<TodoController> logger, ITodoServcie iTodoService, 
            UserManager<IdentityUser> userManager)
        {
            _logger=logger;
            _iTodoService = iTodoService;
            _userManager=userManager;
        }
        /// <summary>
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
