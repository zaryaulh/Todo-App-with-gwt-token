using Integrify.Application.Todo.Dtos;
using Integrify.Domain.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Application.Todo.Servcies
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRegistrationRepo _iUserRegistrationRepo;

        public UserRegistrationService(IUserRegistrationRepo iUserRegistrationRepo)
        {
            _iUserRegistrationRepo=iUserRegistrationRepo;
        }
        public async Task Create(Guid id, string email, string password, DateTime createdOn, DateTime updatedOn)
        {
            _iUserRegistrationRepo.Register(id, email, password, createdOn, updatedOn);
            _iUserRegistrationRepo.Commit();
        }
    }
}
