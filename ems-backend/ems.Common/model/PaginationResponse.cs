namespace ems.Common.model
{
    public class PaginationResponse<T>
    {
        public IList<T> Values { get; set; }
        public Pagination Pagination { get; set; }
    }
}
