using System.Linq.Dynamic.Core;

namespace rayna.Persistence.Helper;

public static class SortingExtensions
{
    public static IQueryable<T> ApplySorting<T>(IQueryable<T> data, string sortBy, bool isSortAscending)
    {
        data = data.OrderBy(sortBy + (isSortAscending ? "" : " desc"));

        return data;
    }

    public static IQueryable<T> ApplyPagination<T>(IQueryable<T> data, int pageNumber, float pageSize)
    {
        return data.Skip((pageNumber - 1) * (int)pageSize).Take((int)pageSize);
    }
}
