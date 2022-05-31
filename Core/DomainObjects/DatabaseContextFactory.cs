using Core.Infra;

namespace Core.DomainObjects
{
    internal class DatabaseContextFactory : IDatabaseContextFactory
    {
        private IDatabaseContext? _dataContext;

        /// <summary>
        /// If data context remain null then initialize new context 
        /// </summary>
        /// <returns>dataContext</returns>
        public IDatabaseContext Context ()
        {
            return _dataContext ??= new DatabaseContext();
        }

        /// <summary>
        /// Dispose existing context
        /// </summary>
        public void Dispose ()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
