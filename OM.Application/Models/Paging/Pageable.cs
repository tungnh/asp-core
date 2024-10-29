using OM.Application.Utils;

namespace OM.Application.Models.Paging
{
    public class Pageable
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = Constants.DefaultPageSize;
        public string[]? Sort { get; set; }
    }
}
