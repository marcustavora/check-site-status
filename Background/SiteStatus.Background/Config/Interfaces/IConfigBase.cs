namespace SiteStatus.Background.Config.Interfaces
{
    public interface IConfigBase
    {
        ConfigInterval Interval { get; set; }

        ConfigRecurrence Recurrence { get; set; }


        bool IsInterval { get; }

        bool IsRecurrence { get; }
    }
}