using Integrify.Application.Todo.Dtos;
using Integrify.Domain.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Application.Todo.Servcies
{
    public interface ITodoServcie
    {
        Task Create(CreateTodoDto dto , Guid UserId);
        Task<TodoL> GetTodo(Guid todoId);
        Task Update(UpdateTodoDto dto, Guid todoId);
        Task Delete(Guid todoId);
        Task<ICollection<TodoL>> GetAllTodo(Status status);
        Task<ICollection<TodoL>> GetAllTodo();

    }
}
