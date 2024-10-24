namespace OM.Application.Models.Paging
{
    public class Pageable
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 20;
        public string[]? Sort { get; set; }
    }

    public enum OrderDirection
    {
        ASC,
        DESC
    }
}
