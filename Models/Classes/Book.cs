using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Book : EntityBase.EntityBase
    {
        [Required]
        [DisplayName("ISBN")]
        public string ISBN { get; set; }

        [Required]
        [DisplayName("عنوان کتاب")]
        public string Title { get; set; }

        [Required]
        [DisplayName("نویسنده")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [Required]
        [DisplayName("تعداد صفحات")]
        public int PageCount { get; set; }

        [DisplayName("ناشران")]
        [Required]
        public string Publisher { get; set; }

        [DisplayName("تیراژ")]
        [Required]
        public int Circulation { get; set; }
    }
}
