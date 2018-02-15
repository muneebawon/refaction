using System.Collections.Generic;

namespace RefactorMe.Data.Entities
{
    public class Product : BaseEntity
    {
        #region Properties

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        public IList<ProductOption> Options { get; set; }

        #endregion
    }
}
