using Core.Infra;
using System.Data.SqlClient;

namespace Aprendizado.Domain
{
    internal class CourseFacade
    {
        private ICourseRepository _courseRepository;
        private IUnitOfWork _unitOfWork;

        public CourseFacade (ICourseRepository repository, IUnitOfWork uow)
        {
            _courseRepository = repository;
            _unitOfWork = uow;
        }

        public int Save (Course person)
        {
            int i = 0;
            try
            {
                // _unitOfWork.BeginTransaction();
                SqlTransaction sqlTransaction = _unitOfWork.BeginTransaction();
                string strSql = "Insert into Course (LastName, FirstName, Age) VALUES (@LastName, @FirstName, @Age)";
                i = _courseRepository.Insert(person, strSql, sqlTransaction);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int Update (Course person)
        {
            int i = 0;
            try
            {
                SqlTransaction sqlTransaction = _unitOfWork.BeginTransaction();
                string strSql = "Update Course set LastName = @LastName, FirstName = @FirstName, Age = @Age Where Id = @Id";
                i = _courseRepository.Update(person, strSql, sqlTransaction);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int Delete (int id)
        {
            int i = 0;
            try
            {
                SqlTransaction sqlTransaction = _unitOfWork.BeginTransaction();
                string strSql = "Delete from Course Where Id = @Id";
                i = _courseRepository.Delete(id, strSql, sqlTransaction);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public Course GetById (int id)
        {
            string strSql = "select * from dbo.Course where id = @id";
            return _courseRepository.GetById(id, strSql);
        }

        public IEnumerable<Course> GetAll ()
        {
            return _courseRepository.GetAll("SELECT * FROM Course");
        }
    }
}
