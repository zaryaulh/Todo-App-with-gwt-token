using Abp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Domain.Todo
{
    public class User : Entity<Guid>
    {
        //[Required(ErrorMessage = "Email is required")]
        public string Email { get; private set; }

        //[Required(ErrorMessage = "Password is required")]
        public string Password { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; set; }

        //private readonly List<TodoL> _todos;
        private User()
        {
            //_todos = new List<TodoL>();
        }
        private User(Guid id, string email, string password, DateTime createdOn,
            DateTime updatedOn) : this()
        {
            Id = id;
            Email = email;
            Password = password;
            CreatedOn = createdOn;
            UpdatedOn = updatedOn;

        }
        public static User Create(Guid id , string email, string password, DateTime createdOn,
            DateTime updatedOn)
        {
            var user = new User(id , email, password, createdOn, updatedOn);
            return user;
        }
    }
}