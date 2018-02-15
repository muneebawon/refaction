using System.Data.Entity.ModelConfiguration;

namespace RefactorMe.Data.Mappings
{
    public abstract class MappingBase<T> : EntityTypeConfiguration<T> where T : class
    {
        #region Ctor

        protected MappingBase()
        {
            PostInitialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }

        #endregion
    }
}
