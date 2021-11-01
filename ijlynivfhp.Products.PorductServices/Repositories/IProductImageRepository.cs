using ijlynivfhp.WEBService.ProductServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.WEBService.ProductServices.Repositories
{
    /// <summary>
    /// 商品图片仓储接口
    /// </summary>
    public interface IProductImageRepository
    {
        IEnumerable<ProductImage> GetProductImages();
        IEnumerable<ProductImage> GetProductImages(ProductImage productImage);
        ProductImage GetProductImageById(int id);
        void Create(ProductImage ProductImage);
        void Update(ProductImage ProductImage);
        void Delete(ProductImage ProductImage);
        bool ProductImageExists(int id);
    }
}
