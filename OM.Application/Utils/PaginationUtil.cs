using System.Text;

namespace OM.Application.Utils
{
    public class PaginationUtil
    {
        public static string CreateSortOrder(string property, string direction = OrderDirection.Asc)
        {
            return string.Format("{0},{1}", property, direction);
        }

        public static string[] CreateSortOrder(string direction, params string[] properties)
        {
            var sortList = new List<string>();
            foreach (var property in properties)
            {
                sortList.Add(CreateSortOrder(property, direction));
            }
            return sortList.ToArray();
        }

        public static string[] CreateSortOrder(params string[] properties)
        {
            return CreateSortOrder(OrderDirection.Asc, properties);
        }
    }
}
