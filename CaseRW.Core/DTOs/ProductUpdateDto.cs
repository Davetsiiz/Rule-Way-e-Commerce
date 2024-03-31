namespace CaseRW.Core.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int? CategoryId { get; set; }
    }
}
