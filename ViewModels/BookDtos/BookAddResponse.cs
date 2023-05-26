using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.BookDtos
{
    public class BookAddResponse
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorFamily { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public int Circulation { get; set; }
    }
}
