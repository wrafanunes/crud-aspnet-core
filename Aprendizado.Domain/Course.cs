using Core.DomainObjects;

namespace Aprendizado.Domain
{
    public class Course : Entity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        protected override void Validate ()
        {
            throw new NotImplementedException();
        }
    }
}
