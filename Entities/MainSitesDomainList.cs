using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainSitesDomainList
    {
        public Guid Id { get; set; }
        public string FSiteId { get; set; }
        public string CDomain { get; set; }
        public int Num { get; set; }

        public MainSites FSite { get; set; }
    }
}
