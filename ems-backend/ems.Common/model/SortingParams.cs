namespace ems.Common.Helper
{
    public class SortingParams
    {
        public int PageNumber { get; set; } = 1;
        public float PageSize { get; set; } = 10;
        public string SortBy { get; set; } = "1";
        public bool IsSortAscending { get; set; } = false;
    }
}
