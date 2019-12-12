using Flowsoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.DataServices.Interfaces
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategories> GetAllCategories();
        int AddProductCategory(ProductCategories ProductCategory);
        int UpdateProductCategory(ProductCategories productCategory);
        ProductCategories GetProductCategoryData(int id);
        int DeleteProductCategory(int id);
    }

}