using SiteStatus.Background.Config.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiteStatus.Background.Config
{
    public class ConfigBase : IConfigBase
    {
        public virtual ConfigInterval Interval { get; set; }
        public virtual ConfigRecurrence Recurrence { get; set; }
        public bool IsInterval { get { return Interval != null; } }
        public bool IsRecurrence { get { return Recurrence != null; } }
    }
}