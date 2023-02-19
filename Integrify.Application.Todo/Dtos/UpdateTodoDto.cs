using Integrify.Domain.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrify.Application.Todo.Dtos
{
    public class UpdateTodoDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
