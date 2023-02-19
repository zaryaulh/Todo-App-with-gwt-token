using Integrify.Application.Todo.Dtos;
using Integrify.Domain.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Application.Todo.Servcies
{
    public class TodoService : ITodoServcie
    {
        private readonly ITodoRepository _iTodoRepository;
        public TodoService(ITodoRepository iTodoRepository)
        {
            _iTodoRepository = iTodoRepository;
        }

        public async Task Create(CreateTodoDto dto , Guid userId)
        {
            _iTodoRepository.Create(dto , userId);
            _iTodoRepository.Commit();

        }

        public async Task Delete(Guid todoId)
        {
            _iTodoRepository.DeleteTodo(todoId);
            _iTodoRepository.Commit();
        }
        public async Task<TodoL> GetTodo(Guid todoId)
        {
            var todo = await _iTodoRepository.GetTodoItemAsync(todoId);
            return todo;
        }
        public async Task Update(UpdateTodoDto dto, Guid todoId)
        {
            _iTodoRepository.UpdateTodo(dto, todoId);
            _iTodoRepository.Commit();
        }
        public async Task<ICollection<TodoL>> GetAllTodo(Status status)
        {
            return await _iTodoRepository.GetAllTodo(status);
        }
        public async Task<ICollection<TodoL>> GetAllTodo()
        {
            return await _iTodoRepository.GetAllTodo();
        }
    }
}