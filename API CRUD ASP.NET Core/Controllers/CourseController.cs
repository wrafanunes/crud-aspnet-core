using Aprendizado.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_ASP.NET_Core.Controllers
{
    ///<summary>
    /// Este controlador é usado para gerenciar os endpoints da classe &lt; Course. 
    ///</summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repository;

        /// <summary>
        /// Construtor com injeção de dependência do repositório obrigatório CourseRepository
        /// </summary>
        /// <param name="repository"></param>
        public CourseController (ICourseRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Obter todos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Course> Get ()
        {
            return _repository.GetAll("select * from courses");
        }
    }
}
