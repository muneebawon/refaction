using System;

namespace RefactorMe.Data.Entities
{
    public class ProductOption : BaseEntity
    {
        #region Properties

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Product Product { get; set; }

        #endregion
    }
}
