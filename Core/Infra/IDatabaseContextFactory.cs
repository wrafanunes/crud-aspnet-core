namespace Core.Infra
{
    public interface IDatabaseContextFactory
    {
        IDatabaseContext Context ();
    }
}
