using System;
using System.Collections.Generic;

namespace Flowsoft.Domain.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductCategoryId { get; set; }
        public decimal? Price { get; set; }
        public bool? IsTaxable { get; set; }
        public decimal? TaxAmount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
