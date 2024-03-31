namespace CaseRW.Core.DTOs
{
    public class ProductDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int? CategoryId { get; set; }
    }
}
