using Flowsoft.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowsoft.DataServices.Interfaces
{
    public interface IProductService
    {

        IEnumerable<Products> GetAllProducts();
        int AddProduct(Products product);
        int UpdateProduct(Products product);
        Products GetProductData(int id);
        int DeleteProduct(int id);

    }
}
