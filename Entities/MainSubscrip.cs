using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainSubscrip
    {
        public Guid Id { get; set; }
        public string FSite { get; set; }
        public string CEmail { get; set; }
        public DateTime? DDateCreate { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
