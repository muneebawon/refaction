using System;
using System.Net;
using System.Web.Http;
using RefactorMe.Service;
using System.Net.Http;
using RefactorMe.Data.Entities;
using RefactorMe.Models;

namespace RefactorMe.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        #region Fields

        private readonly IProductService _productService;

        #endregion

        #region Ctor

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Products

        //GET /products - gets all products.
        public HttpResponseMessage Get()
        {
            var products = _productService.GetAllProducts();
            return Request.CreateResponse(new ProductsReturn(products));
        }

        // GET /products/{id} - gets the project that matches the specified ID - ID is a GUID.        
        [Route("{id:guid}", Name = "GetProductById")]
        public HttpResponseMessage Get(Guid id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(product);
        }

        //GET /products? name = { name } -- finds all products matching the specified name.
        public HttpResponseMessage Get(string name)
        {
            var resuts = _productService.GetProductsByName(name);
            return Request.CreateResponse(new ProductsReturn(resuts));
        }

        // POST /products - creates a new product.
        public HttpResponseMessage Post(Product product)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            _productService.InsertProduct(product);

            return Request.CreateResponse(HttpStatusCode.Created, product);
        }

        // PUT /products/{id} - updates a product.
        public HttpResponseMessage Put(Guid id, Product product)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            if (!id.Equals(product.Id))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Id");

            if (!_productService.DoesProductExist(id))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            _productService.UpdateProduct(product);

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        // DELETE /products/{id} - deletes a product and its options.
        public HttpResponseMessage Delete(Guid id)
        {
            if (!_productService.DoesProductExist(id))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _productService.DeleteProduct(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion

        #region Product Options

        //GET /products/{ id}/options - finds all options for a specified product.
        [Route("{productId:guid}/options")]
        public HttpResponseMessage GetOptions(Guid productId)
        {
            var options = _productService.GetAllProductOptions(productId);
            return Request.CreateResponse(new ProductOptionsReturn(options));
        }

        //GET /products/{id}/options/{optionId} - finds the specified product option for the specified product.
        [Route("{productId:guid}/options/{optionId:guid}", Name = "GetOptionById")]
        public HttpResponseMessage GetOption(Guid productId, Guid optionId)
        {
            if (!_productService.DoesProductOptionExist(productId, optionId))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            var option = _productService.GetProductOptionById(productId, optionId);
            return Request.CreateResponse(option);
        }

        // POST /products/{id}/options - adds a new product option to the specified product.
        [Route("{productId:guid}/options")]
        public HttpResponseMessage CreateOption(Guid productId, ProductOption productOption)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            if (!_productService.DoesProductExist(productId))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            _productService.InsertProductOption(productOption);

            return Request.CreateResponse(HttpStatusCode.Created, productOption);
        }

        // PUT /products/{ productId}/options/{optionId} - updates the specified product option.
        [Route("{productId:guid}/options/{optionId}")]
        public HttpResponseMessage UpdateOption(Guid productId, Guid optionId, ProductOption productOption)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);

            if (!_productService.DoesProductOptionExist(productId, optionId))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            // return latest updates
            _productService.UpdateProductOption(productOption);
            return Request.CreateResponse(HttpStatusCode.OK, productOption);
        }

        // DELETE /products/{productId}/options/{optionId} - deletes the specified product option.
        [Route("{productId:guid}/options/{optionId:guid}")]
        public HttpResponseMessage DeleteOption(Guid productId, Guid optionId)
        {
            if (!_productService.DoesProductOptionExist(productId, optionId))
                return Request.CreateResponse(HttpStatusCode.NotFound);

            _productService.DeleteProductOption(optionId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion        
    }
}
