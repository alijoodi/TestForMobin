using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityBase
{
    public class EntityBase
    {
        [Key]
        [Required]
        [DisplayName("شناسه")]
        public int Id { get; set; }

        [Required]
        public bool Deleted { get; set; }
        public EntityBase()
        {
            Deleted = false;
        }
    }
}
