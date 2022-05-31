using Core.Infra;
using System.Data;
using System.Data.SqlClient;

namespace Core.DomainObjects
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity, IAggregateRoot, new()
    {
        private SqlConnection _conn;
        protected readonly IUnitOfWork _uow;

        /// <summary>
        /// Initialize the connection
        /// </summary>
        /// <param name="uow">UnitOfWork</param>
        public BaseRepository (IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("unitOfWork");
            _uow = uow;
            _conn = _uow.DataContext.Connection;
        }

        /// <summary>
        /// Base Method for Insert Data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="insertSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Insert (T entity, string insertSql, SqlTransaction sqlTransaction)
        {
            int i = 0;
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = insertSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTransaction;
                    InsertCommandParameters(entity, cmd);
                    i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        /// <summary>
        /// Base Method for Update Data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Update (T entity, string updateSql, SqlTransaction sqlTransaction)
        {
            int i = 0;
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = updateSql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = sqlTransaction;
                UpdateCommandParameters(entity, cmd);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Base Method for Delete Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deleteSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public int Delete (int id, string deleteSql, SqlTransaction sqlTransaction)
        {
            int i = 0;
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = deleteSql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = sqlTransaction;
                DeleteCommandParameters(id, cmd);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        /// <summary>
        /// Base Method for Populate Data by key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getByIdSql"></param>
        /// <returns></returns>
        public T GetById (int id, string getByIdSql)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = getByIdSql;
                cmd.CommandType = CommandType.Text;
                GetByIdCommandParameters(id, cmd);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return Map(reader);
                }

            }
        }

        /// <summary>
        /// Base Method for Populate All Data
        /// </summary>
        /// <param name="getAllSql"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll (string getAllSql)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = getAllSql;
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return Maps(reader);
                }
            }
        }

        protected abstract void InsertCommandParameters (T entity, SqlCommand cmd);
        protected abstract void UpdateCommandParameters (T entity, SqlCommand cmd);
        protected abstract void DeleteCommandParameters (int id, SqlCommand cmd);
        protected abstract void GetByIdCommandParameters (int id, SqlCommand cmd);
        protected abstract T Map (SqlDataReader reader);
        protected abstract List<T> Maps (SqlDataReader reader);

    }
}
