using RefactorMe.Data.Entities;
using System.Collections.Generic;

namespace RefactorMe.Models
{
    public class ProductsReturn
    {
        #region Ctor

        public ProductsReturn()
        {
        }

        public ProductsReturn(IEnumerable<Product> products)
        {
            this.Items = products;
        }

        #endregion

        #region Properties

        public IEnumerable<Product> Items { get; private set; }

        #endregion
    }
}