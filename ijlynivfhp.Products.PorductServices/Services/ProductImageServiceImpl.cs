using ijlynivfhp.Projects.ProductServices.Models;
using ijlynivfhp.Projects.ProductServices.Repositories;
using System.Collections.Generic;

namespace ijlynivfhp.Projects.ProductImageServices.Services
{
    /// <summary>
    /// 商品服务实现
    /// </summary>
    public class ProductImageServiceImpl : IProductImageService
    {
        public readonly IProductImageRepository ProductImageRepository;

        public ProductImageServiceImpl(IProductImageRepository ProductImageRepository)
        {
            this.ProductImageRepository = ProductImageRepository;
        }

        public void Create(ProductImage ProductImage)
        {
            ProductImageRepository.Create(ProductImage);
        }

        public void Delete(ProductImage ProductImage)
        {
            ProductImageRepository.Delete(ProductImage);
        }

        public ProductImage GetProductImageById(int id)
        {
            return ProductImageRepository.GetProductImageById(id);
        }

        public IEnumerable<ProductImage> GetProductImages()
        {
            return ProductImageRepository.GetProductImages();
        }

        public void Update(ProductImage ProductImage)
        {
            ProductImageRepository.Update(ProductImage);
        }

        public bool ProductImageExists(int id)
        {
            return ProductImageRepository.ProductImageExists(id);
        }

        public IEnumerable<ProductImage> GetProductImages(ProductImage productImage)
        {
            return ProductImageRepository.GetProductImages(productImage);
        }
    }
}
