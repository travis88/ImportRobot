using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainMemory
    {
        public Guid Id { get; set; }
        public DateTime DDate { get; set; }
        public bool? BDisabled { get; set; }
        public string CTitle { get; set; }
        public string CDesc { get; set; }
        public string CKeyw { get; set; }
        public string CPhoto { get; set; }
        public string CText { get; set; }
        public string CUrl { get; set; }
        public bool? BRepeat { get; set; }
        public int NYear { get; set; }
        public int NMonth { get; set; }
        public int NDay { get; set; }
        public string FSite { get; set; }
        public string CAlias { get; set; }
        public int? NOldId { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
