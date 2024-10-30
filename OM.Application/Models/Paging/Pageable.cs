using OM.Application.Utils;

namespace OM.Application.Models.Paging
{
    public class Pageable
    {
        /// <summary>
        /// Page number. Start from 0
        /// </summary>
        public int PageIndex { get; set; } = 0;
        /// <summary>
        /// Total elements in page
        /// </summary>
        public int PageSize { get; set; } = Constants.DefaultPageSize;
        /// <summary>
        /// Sorts the elements of a sequence
        /// ex: ["Name,asc", "Title,desc"]
        /// </summary>
        public string[]? Sort { get; set; }
    }
}
