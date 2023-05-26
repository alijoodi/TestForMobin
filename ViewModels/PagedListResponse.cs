using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PagedListResponse<T>
    {
        public List<T> list;
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

    }
}
