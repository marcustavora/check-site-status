using System;

namespace SiteStatus.Domain.Entities
{
    public class Status : BaseEntity
    {
        public string Uri { get; set; }

        public bool IsUp { get; set; }

        public DateTime CheckDate { get; set; }
    }
}