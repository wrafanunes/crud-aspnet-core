using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Course : Entity, IAggregateRoot
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Category { get; set; }

        protected override void Validate ()
        {
            throw new NotImplementedException();
        }
    }
}
