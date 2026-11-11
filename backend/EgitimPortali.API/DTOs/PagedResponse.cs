namespace EgitimPortali.API.DTOs
{
    public class PagedResponse<T>
    {
        public List<T> Data { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages
        {
            get
            {
                return (int )Math.Ceiling(TotalRecords / (double)PageSize);
            }
        }
        public PagedResponse(List<T>data,int pageNumber,int pageSize,int totalRecords)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;

        }

    }
}
    