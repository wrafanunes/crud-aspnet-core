namespace Domain.Interfaces
{
    /// <summary>
    /// Essa interface segue o Princípio da Segregação de Interface, que diz que uma interface não pode forçar uma 
    /// classe a implementar coisas que não vai utilizar
    /// </summary>
    public interface ICourseRepository : IRepository<Course>
    {
    }
}
