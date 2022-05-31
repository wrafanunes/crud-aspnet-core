namespace Core.Infra
{
    internal interface IDatabaseContextFactory
    {
        IDatabaseContext Context ();
    }
}
