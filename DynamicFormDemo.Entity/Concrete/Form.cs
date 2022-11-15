using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.Entity.Abstract;

namespace DynamicFormDemo.Entity.Concrete
{
    public class Form : BaseEntity
    {
        public int CreatedBy { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Field>? Fields { get; set; }
        public User? User { get; set; }

    }
}
