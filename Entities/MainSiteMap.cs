using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainSiteMap
    {
        public Guid Id { get; set; }
        public Guid? FViewId { get; set; }
        public int NPermit { get; set; }
        public string FSite { get; set; }
        public string CPath { get; set; }
        public string CAlias { get; set; }
        public string FMenu { get; set; }
        public string CTitle { get; set; }
        public string CLogo { get; set; }
        public string CFile { get; set; }
        public string CUrl { get; set; }
        public string CText { get; set; }
        public string CDesc { get; set; }
        public string CKeyw { get; set; }
        public bool? BDisabled { get; set; }
        public string CViewName { get; set; }
        public bool? BDeleteble { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
