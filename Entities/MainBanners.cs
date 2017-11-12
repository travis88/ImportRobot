using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainBanners
    {
        public Guid Id { get; set; }
        public string FSite { get; set; }
        public string CTitle { get; set; }
        public string CPhoto { get; set; }
        public string CUrl { get; set; }
        public string CText { get; set; }
        public DateTime DDate { get; set; }
        public string FType { get; set; }
        public string FSection { get; set; }
        public short NPermit { get; set; }
        public bool? BTarget { get; set; }
        public short NVisits { get; set; }
        public short NClicks { get; set; }
        public bool? BDisabled { get; set; }
        public string CUrlText { get; set; }
        public Guid? UidSection { get; set; }
        public DateTime? DDateEnd { get; set; }

        public MainSites FSiteNavigation { get; set; }
        public CmsSectionsGroupItems UidSectionNavigation { get; set; }
    }
}
