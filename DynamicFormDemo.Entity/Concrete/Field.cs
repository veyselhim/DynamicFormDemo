using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicFormDemo.Entity.Abstract;

namespace DynamicFormDemo.Entity.Concrete
{
    public class Field : BaseEntity
    {
        public int FormId { get; set; }
        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }

        [NotMapped]
        public override DateTime CreatedAt
        {
            get;
            set;
        }

        public Form? Form { get; set; }
    }
}
