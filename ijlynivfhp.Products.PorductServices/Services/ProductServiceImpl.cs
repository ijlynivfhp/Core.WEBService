using ijlynivfhp.WEBService.ProductServices.Models;
using ijlynivfhp.WEBService.ProductServices.Repositories;
using System.Collections.Generic;

namespace ijlynivfhp.WEBService.ProductServices.Services
{
    /// <summary>
    /// 商品服务实现
    /// </summary>
    public class ProductServiceImpl : IProductService
    {
        public readonly IProductRepository ProductRepository;

        public ProductServiceImpl(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }

        public void Create(Product Product)
        {
            ProductRepository.Create(Product);
        }

        public void Delete(Product Product)
        {
            ProductRepository.Delete(Product);
        }

        public Product GetProductById(int id)
        {
            return ProductRepository.GetProductById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductRepository.GetProducts();
        }

        public void Update(Product Product)
        {
            ProductRepository.Update(Product);
        }

        public bool ProductExists(int id)
        {
            return ProductRepository.ProductExists(id);
        }
    }
}
