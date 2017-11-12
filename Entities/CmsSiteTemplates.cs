using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsSiteTemplates
    {
        public CmsSiteTemplates()
        {
            CmsSiteDecoreTemplates = new HashSet<CmsSiteDecoreTemplates>();
            MainSites = new HashSet<MainSites>();
        }

        public Guid Id { get; set; }
        public string CTitle { get; set; }
        public string CAlias { get; set; }
        public string CCssMain { get; set; }
        public string CCssAdd { get; set; }
        public string CJsMain { get; set; }
        public string CPreview { get; set; }
        public string CPageView { get; set; }
        public string CContactsView { get; set; }
        public string CNewsListView { get; set; }

        public ICollection<CmsSiteDecoreTemplates> CmsSiteDecoreTemplates { get; set; }
        public ICollection<MainSites> MainSites { get; set; }
    }
}
