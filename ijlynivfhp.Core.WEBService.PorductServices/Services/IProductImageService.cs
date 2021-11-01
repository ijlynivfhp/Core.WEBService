using ijlynivfhp.Core.WEBService.ProductServices.Models;
using System.Collections.Generic;

namespace ijlynivfhp.Core.WEBService.ProductImageServices.Services
{
    /// <summary>
    /// 商品图片服务接口
    /// </summary>
    public interface IProductImageService
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
