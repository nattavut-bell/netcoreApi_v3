namespace NetCoreAPI_v3.DTOs
{
    public class ProductGroupFilterDto : PaginationDto
    {
        //Filter
        public string SearchDetail { get; set; }

        //Ordering
        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true;

    }
}