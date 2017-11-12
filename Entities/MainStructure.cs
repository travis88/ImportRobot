using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainStructure
    {
        public Guid Id { get; set; }
        public string CTitle { get; set; }
        public string CDesc { get; set; }
        public string CKeyw { get; set; }
        public string CText { get; set; }
        public string FSite { get; set; }
        public string CUrl { get; set; }
        public int? NPermit { get; set; }
        public bool? BDisabled { get; set; }
        public int? NOldId { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
