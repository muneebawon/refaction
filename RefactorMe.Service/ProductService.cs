using RefactorMe.Data;
using RefactorMe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe.Service
{
    public class ProductService : IProductService
    {
        #region Fields

        private readonly IRepository<Product> _productRepository;

        private readonly IRepository<ProductOption> _productOptionRepository;

        #endregion

        #region Ctor

        public ProductService(IRepository<Product> productRepository, IRepository<ProductOption> productOptionRepository)
        {
            _productRepository = productRepository;
            _productOptionRepository = productOptionRepository;
        }

        #endregion

        #region Products

        public void InsertProduct(Product product)
        {
            _productRepository.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            var entity = this._productRepository.GetById(product.Id);

            if (entity == null)
            {
                throw new AppException("Product not found");
            }
            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;
            entity.DeliveryPrice = product.DeliveryPrice;
            _productRepository.Update(entity);
        }

        public void DeleteProduct(Guid productId)
        {
            var entity = _productRepository.GetById(productId);
            if (entity == null)
            {
                throw new AppException("Product not found");
            }

            _productRepository.Delete(entity);
        }

        public IList<Product> GetAllProducts()
        {
            return _productRepository.Table.ToList();
        }

        public Product GetProductById(Guid productId)
        {
            return _productRepository.GetById(productId);
        }

        public IList<Product> GetProductsByName(string productName)
        {
            return _productRepository.Table.Where(x => x.Name.ToLower().Contains(productName.ToLower())).ToList();
        }

        public bool DoesProductExist(Guid productId)
        {
            return _productRepository.Table.Any(x => x.Id == productId);
        }

        #endregion

        #region ProductOptions

        public void InsertProductOption(ProductOption productOption)
        {
            _productOptionRepository.Insert(productOption);
        }

        public void UpdateProductOption(ProductOption productOption)
        {
            var entity = _productOptionRepository.GetById(productOption.Id);

            if (entity == null)
            {
                throw new AppException("ProductOption not found");
            }

            entity.Name = productOption.Name;
            entity.Description = productOption.Description;

            _productOptionRepository.Update(entity);
        }

        public void DeleteProductOption(Guid productOptionId)
        {
            var entity = _productOptionRepository.GetById(productOptionId);
            if (entity == null)
            {
                throw new AppException("ProductOption not found");
            }

            _productOptionRepository.Delete(entity);
        }

        public IList<ProductOption> GetAllProductOptions(Guid productId)
        {
            return _productRepository.Table.Where(prod => prod.Id == productId).SelectMany(prod => prod.Options).ToList();
        }

        public ProductOption GetProductOptionById(Guid productId, Guid productOptionId)
        {
            return _productRepository.Table.Where(prod => prod.Id == productId).SelectMany(prod => prod.Options.Where(opt => opt.Id == productOptionId)).FirstOrDefault();
        }

        public IList<ProductOption> GetProductOptionsByProductId(Guid productId)
        {
            return _productOptionRepository.Table.Where(prod => prod.ProductId == productId).ToList();
        }

        public IList<ProductOption> GetProductOptionsByName(string productOptionName)
        {
            return _productOptionRepository.Table.Where(x => x.Name.ToLower().Contains(productOptionName.ToLower())).ToList();
        }

        public bool DoesProductOptionExist(Guid productId, Guid productOptionId)
        {
            return _productRepository.Table.Where(prod => prod.Id == productId).Any(x => x.Id == productOptionId);
        }

        #endregion
    }
}
