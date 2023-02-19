using Integrify.Application.Todo.Dtos;
using Integrify.Domain.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Application.Todo
{
    public interface ITodoRepository
    { 
        void Create(CreateTodoDto todo , Guid userId);
        void UpdateTodo(UpdateTodoDto dto, Guid todoId);
        void DeleteTodo(Guid todoId);
        void Commit();
        Task<TodoL> GetTodoItemAsync(Guid todoId);
        Task<ICollection<TodoL>> GetAllTodo(Status status);
        Task<ICollection<TodoL>> GetAllTodo();
    }
}
