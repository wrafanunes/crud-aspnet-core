namespace Core.DomainObjects
{
#pragma warning disable CS1591
    /// <summary>
    /// Entidade base
    /// </summary>
    public abstract class Entity
    {
        public long Id { get; set; }

        protected abstract void Validate ();

        public override bool Equals (object? entity)
        {
            return entity != null
               && entity is Entity entity1
               && this == entity1;
        }

        public override int GetHashCode ()
        {
            return Id.GetHashCode();
        }

        public static bool operator == (Entity entity1, Entity entity2)
        {
            if (entity1 is null && entity2 is null)
            {
                return true;
            }

            if (entity1 is null || entity2 is null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator != (Entity entity1,
            Entity entity2)
        {
            return !(entity1 == entity2);
        }
    }
}
