using ijlynivfhp.Core.WEBService.ProductServices.Context;
using ijlynivfhp.Core.WEBService.ProductServices.Models;
using ijlynivfhp.Core.WEBService.ProductServices.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RuanMou.MicroService.ProductService.Repositories
{
    /// <summary>
    /// 商品仓储实现
    /// </summary>
    public class ProductImageRepository : IProductImageRepository
    {
        public ProductContext productContext;
        public ProductImageRepository(ProductContext productContext)
        {
            this.productContext = productContext;
        }
        public void Create(ProductImage ProductImage)
        {
            productContext.ProductImages.Add(ProductImage);
            productContext.SaveChanges();
        }

        public void Delete(ProductImage ProductImage)
        {
            productContext.ProductImages.Remove(ProductImage);
            productContext.SaveChanges();
        }

        public ProductImage GetProductImageById(int id)
        {
            return productContext.ProductImages.Find(id);
        }

        public IEnumerable<ProductImage> GetProductImages()
        {
            return productContext.ProductImages.ToList();
        }

        public void Update(ProductImage ProductImage)
        {
            productContext.ProductImages.Update(ProductImage);
            productContext.SaveChanges();
        }
        public bool ProductImageExists(int id)
        {
            return productContext.ProductImages.Any(e => e.Id == id);
        }

        public IEnumerable<ProductImage> GetProductImages(ProductImage productImage)
        {
            return productContext.ProductImages
                           .Where(e => e.ProductId == productImage.ProductId)
                           /*.Where(e => e.ImageSort == productImage.ImageSort)
                           .Where(e => e.ImageUrl == productImage.ImageUrl)
                           .Where(e => e.Id == productImage.Id)*/
                           .ToList();
        }
    }
}
