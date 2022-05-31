using Aprendizado.Domain;
using Core.DomainObjects;
using Core.Infra;
using System.Data.SqlClient;

namespace Aprendizado.Infra
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository (IUnitOfWork uow) : base(uow) { }

        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters (Course entity, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Category", entity.Category);
        }
        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters (Course entity, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Name", entity.Name);
            cmd.Parameters.AddWithValue("@Category", entity.Category);
        }

        /// <summary>
        /// Passes the parameters to command for Delete Statement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void DeleteCommandParameters (int id, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Passes the parameters to command for populate by key statement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void GetByIdCommandParameters (int id, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override Course Map (SqlDataReader reader)
        {
            Course course = new();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    course.Id = Convert.ToInt32(reader["Id"].ToString());
                    course.Name = reader["Name"].ToString() ?? throw new NullReferenceException("Por favor insira um " +
                        "nome para o curso");
                    course.Category = reader["Category"].ToString() ?? throw new NullReferenceException("Por favor insira uma " +
                        "categoria para o curso");
                }
            }
            return course;
        }

        /// <summary>
        /// Maps data for populate all statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override List<Course> Maps (SqlDataReader reader)
        {
            List<Course> courses = new();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new()
                    {
                        Id = Convert.ToInt32(reader["Id"].ToString()),
                        Name = reader["Name"].ToString() ?? throw new NullReferenceException("Por favor, insira um " +
                        "nome para o curso."),
                        Category = reader["Category"].ToString() ?? throw new NullReferenceException("Por favor, insira uma " +
                        "categoria para o curso.")
                    };
                    courses.Add(course);
                }
            }
            return courses;
        }
    }
}
