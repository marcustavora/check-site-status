namespace SiteStatus.Domain.Interfaces.Infra
{
    public  interface IMyMapper
    {
        T Map<T>(object obj);
    }
}