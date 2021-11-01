using ijlynivfhp.WEBService.ProductServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.WEBService.ProductServices.Services
{
    /// <summary>
    /// 商品服务接口
    /// </summary>
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void Create(Product Product);
        void Update(Product Product);
        void Delete(Product Product);
        bool ProductExists(int id);
    }
}
