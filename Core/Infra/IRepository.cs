using Core.DomainObjects;
using System.Data.SqlClient;

namespace Core.Infra
{
    /// <summary>
    /// Interface genérica de repositório
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        int Insert (T entity, string insertSql, SqlTransaction sqlTransaction);
        int Update (T entity, string updateSql, SqlTransaction sqlTransaction);
        int Delete (int id, string deleteSql, SqlTransaction sqlTransaction);
        T GetById (int id, string getByIdSql);
        IEnumerable<T> GetAll (string getAllSql);
    }
}
