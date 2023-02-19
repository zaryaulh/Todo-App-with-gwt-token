using Integrify.Application.Todo.Dtos;
using Integrify.Data.Todo;
using Integrify.Domain.Todo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Integrify.Application.Todo
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _todoContext;

        public TodoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        public void Create(CreateTodoDto todo , Guid userId)
        {
            var createTodo = TodoL.Create(todo.Name, todo.Description, userId, todo.CreatedOn, todo.UpdatedOn
                , todo.ItemStatus);
            _todoContext.Add(createTodo);
        }
        public async void UpdateTodo(UpdateTodoDto dto, Guid todoId)
        {
            var toDoItemModel = _todoContext.Todos.SingleOrDefault(x => x.Id == todoId);
            if (toDoItemModel != null)
            {
                _todoContext.Update(toDoItemModel);
            }

            throw new Exception($"{toDoItemModel} Todo not found");
        }
        public async Task<TodoL> GetTodoItemAsync(Guid todoId)
        {
            var toDoItemModel = await _todoContext.Todos.FindAsync(todoId);
            return toDoItemModel;
        }

        public void DeleteTodo(Guid todoId)
        {
            var toDoItemModel = _todoContext.Todos.SingleOrDefault(x => x.Id == todoId);
            if (toDoItemModel != null)
            {
                _todoContext.Remove(toDoItemModel);
            }

            throw new Exception($"{toDoItemModel} Todo not found");
        }
        public void Commit()
        {
            _todoContext.SaveChanges();
        }

        public async Task<ICollection<TodoL>> GetAllTodo(Status status)
        {
                var allTodoWithStatus = await _todoContext.Todos.Where(x => x.ItemStatus==status).ToListAsync();
                return allTodoWithStatus;
        }
        public async Task<ICollection<TodoL>> GetAllTodo()
        {
            var allTodoWithoutStatus = _todoContext.Todos.ToList();
            return allTodoWithoutStatus;
        }
    }
}
