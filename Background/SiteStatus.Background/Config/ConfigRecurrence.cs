using SiteStatus.Background.Infra.Quartz;

namespace SiteStatus.Background.Config
{
    public class ConfigRecurrence
    {
        public string Hour { get; set; }

        public string Minute { get; set; }

        public string DayOfWeek { get; set; }

        public string Interval { get; set; }

        public ERecurrence Recurrence { get; set; }

        public string Cron
        {
            get
            {
                switch (Recurrence)
                {
                    case ERecurrence.Minute:
                        return $"0 0/{Interval} * 1/1 * ? *";
                    case ERecurrence.Hour:
                        return $"0 0 0/{Interval} 1/1 * ? *";
                    case ERecurrence.Day:
                        return $"0 {Minute} {Hour} 1/1 * ? *";
                    case ERecurrence.Week:
                        return $"0 {Minute} {Hour} ? * {DayOfWeek} *";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}