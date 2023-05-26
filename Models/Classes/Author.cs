using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Author : EntityBase.EntityBase
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}

namespace Models.Classes.EntityConfig
{
}