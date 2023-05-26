using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class PagedListRequest<T>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public T entityFilter { get; set; }
    }
}
