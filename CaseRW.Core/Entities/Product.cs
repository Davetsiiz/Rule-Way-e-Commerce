namespace CaseRW.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
