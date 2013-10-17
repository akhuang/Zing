using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zing.UI.Navigation
{
    public class Pagination
    {
        /// <summary>
        /// the default page number.
        /// </summary>
        public const int PageDefault = 1;

        /// <summary>
        /// default page size
        /// </summary>
        public const int PageSizeDefault = 10;

        public Pagination(PagerParameters parameters)
            : this(parameters.Page, parameters.PageSize)
        {

        }

        public Pagination(int? page, int? pageSize = null)
        {
            Page = (int)(page != null ? (page > 0 ? page : PageDefault) : PageDefault);
            PageSize = pageSize ?? PageSizeDefault;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

        public int GetStartIndex(int? page = null)
        {
            return ((page ?? Page) - PageDefault) * PageSize;
        }
    }
}
