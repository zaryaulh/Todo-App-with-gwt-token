using Abp;
using Abp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Domain.Todo
{
    public class TodoL : Entity<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        //public IdentityUser User { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }
        public Status ItemStatus { get; private set; }
        private TodoL(Guid id, string name, string description, Guid userId, DateTime createdOn,
            DateTime updatedOn, Status itemStatus)
        {
            Id = id;
            Name=name;
            Description=description;
            UserId=userId;
            CreatedOn=createdOn;
            UpdatedOn=updatedOn;
            ItemStatus = itemStatus;
        }
        public static TodoL Create(string name, string description, Guid userId, DateTime createdOn,
            DateTime updatedOn, Status status)
        {

            var todo = new TodoL(Guid.NewGuid(), name, description, userId, createdOn, updatedOn, status);
            todo.Validate();
            return todo;
        }
        public void Validate()
        {
            Check.NotNull(Id.ToString(), nameof(Id));
            Check.NotNullOrWhiteSpace(Name, nameof(Name));
            Check.NotNullOrWhiteSpace(Description, nameof(Description));
        }
        public void Update(Guid id, string name, string description)
        {
            Validate();
            Id = id;
            Name = name;
            Description = description;
        }
    }
}