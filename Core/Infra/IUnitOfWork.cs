using System.Data.SqlClient;

namespace Core.Infra
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        IDatabaseContext DataContext { get; }
        SqlTransaction BeginTransaction ();

        /// <summary>
        /// The Commit.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        void Commit ();
    }
}
