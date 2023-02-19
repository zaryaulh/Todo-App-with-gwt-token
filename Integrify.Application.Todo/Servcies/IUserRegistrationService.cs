using Integrify.Application.Todo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Application.Todo.Servcies
{
    public interface IUserRegistrationService
    {
        Task Create(Guid id , string email, string password , DateTime createdOn ,DateTime updatedOn);
    }
}
