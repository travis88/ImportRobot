using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainSlider
    {
        public Guid Id { get; set; }
        public string FSite { get; set; }
        public DateTime DDate { get; set; }
        public string CTitle { get; set; }
        public string CDesc { get; set; }
        public string CPhoto { get; set; }
        public string CUrl { get; set; }
        public short NPermit { get; set; }
        public bool? BTarget { get; set; }
        public bool? BDisabled { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
