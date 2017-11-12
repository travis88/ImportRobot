using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainMailing
    {
        public Guid Id { get; set; }
        public string CThema { get; set; }
        public string CText { get; set; }
        public string FSite { get; set; }
        public DateTime DDateCreate { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
