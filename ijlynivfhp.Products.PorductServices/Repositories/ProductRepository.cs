using ijlynivfhp.WEBService.ProductServices.Context;
using ijlynivfhp.WEBService.ProductServices.Models;
using ijlynivfhp.WEBService.ProductServices.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RuanMou.MicroService.ProductService.Repositories
{
    /// <summary>
    /// 商品仓储实现
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        public ProductContext ProductContext;
        public ProductRepository(ProductContext ProductContext)
        {
            this.ProductContext = ProductContext;
        }
        public void Create(Product Product)
        {
            ProductContext.Products.Add(Product);
            ProductContext.SaveChanges();
        }

        public void Delete(Product Product)
        {
            ProductContext.Products.Remove(Product);
            ProductContext.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return ProductContext.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return ProductContext.Products.ToList();
        }

        public void Update(Product Product)
        {
            ProductContext.Products.Update(Product);
            ProductContext.SaveChanges();
        }
        public bool ProductExists(int id)
        {
            return ProductContext.Products.Any(e => e.Id == id);
        }
    }
}
