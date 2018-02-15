using RefactorMe.Data.Entities;
using System.Collections.Generic;

namespace RefactorMe.Models
{
    public class ProductOptionsReturn
    {
        #region Ctor

        public ProductOptionsReturn(IEnumerable<ProductOption> options)
        {
            this.Items = options;
        }

        #endregion

        #region Properties

        public IEnumerable<ProductOption> Items { get; private set; }

        #endregion
    }
}