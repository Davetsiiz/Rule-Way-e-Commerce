﻿namespace CaseRW.Core.Entities
{
    public class Category : BaseEntity
    {

       
        public string Name { get; set; }
        public int MinStock { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
