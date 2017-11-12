using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsSiteGeneral
    {
        public Guid Id { get; set; }
        public string FSite { get; set; }
        public int NPermit { get; set; }
        public int NColumn { get; set; }
        public string CTitle { get; set; }
        public string CText { get; set; }
        public string CPartial { get; set; }
        public string CPreview { get; set; }
        public int CNumber { get; set; }
        public string CRubric { get; set; }
        public string CSize { get; set; }
        public string CType { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
