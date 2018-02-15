using RefactorMe.Data.Entities;
using System;
using System.Collections.Generic;

namespace RefactorMe.Service
{
    /// <summary>
    /// Product service
    /// </summary>
    public partial interface IProductService
    {
        #region Products

        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="product">Product</param>
        void InsertProduct(Product product);

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="product">Product</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        void DeleteProduct(Guid productId);

        /// <summary>
        /// Gets all products 
        /// </summary>
        /// <returns>Products</returns>
        IList<Product> GetAllProducts();

        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product</returns>
        Product GetProductById(Guid productId);

        /// <summary>
        /// Gets products
        /// </summary>
        /// <param name="productName">Product name</param>
        /// <returns>Products</returns>
        IList<Product> GetProductsByName(string productName);

        /// <summary>
        /// Does product exists
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Boolean</returns>
        bool DoesProductExist(Guid productId);

        #endregion

        #region Product Options

        /// <summary>
        /// Inserts a product option
        /// </summary>
        /// <param name="productOption">Product option</param>
        void InsertProductOption(ProductOption productOption);

        /// <summary>
        /// Updates the product option
        /// </summary>
        /// <param name="productOption">Product option</param>
        void UpdateProductOption(ProductOption productOption);

        /// <summary>
        /// Delete a product option
        /// </summary>
        /// <param name="productOptionId">Product option identifier</param>
        void DeleteProductOption(Guid productOptionId);

        /// <summary>
        /// Gets all product options 
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>ProductOptions</returns>
        IList<ProductOption> GetAllProductOptions(Guid productId);

        /// <summary>
        /// Gets product option
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <param name="productOptionId">Product option identifier</param>
        /// <returns>ProductOption</returns>
        ProductOption GetProductOptionById(Guid productId, Guid productOptionId);

        /// <summary>
        /// Gets product options
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>ProductOptions</returns>
        IList<ProductOption> GetProductOptionsByProductId(Guid productId);

        /// <summary>
        /// Gets products
        /// </summary>
        /// <param name="productOptionName">Product option name</param>
        /// <returns>ProductOptions</returns>
        IList<ProductOption> GetProductOptionsByName(string productOptionName);

        /// <summary>
        /// Does product option exist
        /// </summary>
        /// <param name="productOptionId"></param>
        /// <returns>Boolean</returns>
        bool DoesProductOptionExist(Guid productId, Guid productOptionId);

        #endregion
    }
}
