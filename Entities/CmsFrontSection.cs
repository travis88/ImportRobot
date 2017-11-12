using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsFrontSection
    {
        public CmsFrontSection()
        {
            CmsPageViews = new HashSet<CmsPageViews>();
            CmsSiteFrontSection = new HashSet<CmsSiteFrontSection>();
        }

        public Guid Id { get; set; }
        public string CName { get; set; }
        public string CAlias { get; set; }
        public Guid FDefaultView { get; set; }
        public int? NPermit { get; set; }

        public CmsPageViews FDefaultViewNavigation { get; set; }
        public ICollection<CmsPageViews> CmsPageViews { get; set; }
        public ICollection<CmsSiteFrontSection> CmsSiteFrontSection { get; set; }
    }
}
