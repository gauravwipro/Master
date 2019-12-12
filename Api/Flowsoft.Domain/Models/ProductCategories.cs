using System;
using System.Collections.Generic;

namespace Flowsoft.Domain.Models
{
    public partial class ProductCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
