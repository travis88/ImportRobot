using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsPageViews
    {
        public CmsPageViews()
        {
            CmsFrontSection = new HashSet<CmsFrontSection>();
            CmsSiteFrontSection = new HashSet<CmsSiteFrontSection>();
        }

        public Guid Id { get; set; }
        public int NPermit { get; set; }
        public string FSiteId { get; set; }
        public string CTitle { get; set; }
        public string CUrl { get; set; }
        public bool? BReadOnly { get; set; }
        public string CAlias { get; set; }
        public string FPageType { get; set; }
        public string CMarkupType { get; set; }
        public string CLayout { get; set; }

        public CmsFrontSection FPageTypeNavigation { get; set; }
        public MainSites FSite { get; set; }
        public ICollection<CmsFrontSection> CmsFrontSection { get; set; }
        public ICollection<CmsSiteFrontSection> CmsSiteFrontSection { get; set; }
    }
}
