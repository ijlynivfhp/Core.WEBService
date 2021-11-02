using ijlynivfhp.Projects.ProductServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.ProductServices.Repositories
{
    /// <summary>
    /// 商品仓储接口
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void Create(Product Product);
        void Update(Product Product);
        void Delete(Product Product);
        bool ProductExists(int id);
    }
}
