using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class Specialty:BaseEntity
    {
       
        public string Name { get; set; }
        public string Description { get; set; }
        public Collection<Docktor> Docktors { get; set; } = new Collection<Docktor>();
    }
}
