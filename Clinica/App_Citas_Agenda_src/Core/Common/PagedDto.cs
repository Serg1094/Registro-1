using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class PagedDto<T> where T : class
    {
        public int TotalRecords { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public T Data { get; set; } = default!;

        public PagedDto() { }

        public PagedDto(int totalRecords, int currentPage, int pageSize, T data)
        {
            TotalRecords = totalRecords;
            TotalPage = pageSize > 0 ? (int)Math.Ceiling((double)totalRecords / pageSize) : 0;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Data = data;
        }
    }
}
