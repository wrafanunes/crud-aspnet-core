using System.Data.SqlClient;

namespace Core.Infra
{
    public interface IDatabaseContext
    {
        SqlConnection Connection { get; }
        void Dispose ();
    }
}
