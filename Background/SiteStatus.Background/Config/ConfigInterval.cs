using SiteStatus.Background.Infra.Quartz;

namespace SiteStatus.Background.Config
{
    public class ConfigInterval
    {
        public int Time { get; set; }

        public EUnitOfTime Unit { get; set; }
    }
}