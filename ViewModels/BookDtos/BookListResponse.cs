using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.BookDtos
{
    public class BookListResponse
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public int Circulation { get; set; }

    }
}
