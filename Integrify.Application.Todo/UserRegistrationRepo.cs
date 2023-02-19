using Integrify.Application.Todo.Servcies;
using Integrify.Data.Todo;
using Integrify.Domain.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Application.Todo
{
    public class UserRegistrationRepo : IUserRegistrationRepo
    {
        private readonly TodoContext _todoContext;
        public UserRegistrationRepo(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public void Commit()
        {
            _todoContext.SaveChanges();
        }

        public void Register(Guid userId, string email, string pass, DateTime createdOn, DateTime updatedOn)
        {
            var user = User.Create(userId, email, pass, createdOn, updatedOn);
            _todoContext.Add(user);
        }
        //public void Register()
        //{
        //    var user = User.Create()
        //}
    }
}
