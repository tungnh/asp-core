namespace OM.Application.Models.Paging
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }

        public PaginatedList()
        {
        }

        public PaginatedList(List<T> items)
        {
            this.AddRange(items);
        }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
            : base(items)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalElements = count;
        }

        public bool IsFirst => PageIndex == 0;
        public bool IsLast => PageIndex == TotalPages - 1;
        public bool HasNext => PageIndex < TotalPages - 1;
        public bool HasPrevious => PageIndex > 0;
    }
}
