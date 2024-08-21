using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Entities
{
    public abstract class BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

}
