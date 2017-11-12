using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsSiteFrontSection
    {
        public string FSite { get; set; }
        public string FFrontSection { get; set; }
        public Guid FPageView { get; set; }
        public int? NPermit { get; set; }
        public Guid Id { get; set; }

        public CmsFrontSection FFrontSectionNavigation { get; set; }
        public CmsPageViews FPageViewNavigation { get; set; }
        public MainSites FSiteNavigation { get; set; }
    }
}
