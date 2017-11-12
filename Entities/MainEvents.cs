using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainEvents
    {
        public MainEvents()
        {
            MainMaterials = new HashSet<MainMaterials>();
        }

        public Guid Id { get; set; }
        public string FSite { get; set; }
        public string CTitle { get; set; }
        public string CAlias { get; set; }
        public string CKeyw { get; set; }
        public string CDesc { get; set; }
        public DateTime DDate { get; set; }
        public char NYear { get; set; }
        public char NMonth { get; set; }
        public char NDay { get; set; }
        public string CText { get; set; }
        public string CPreview { get; set; }
        public string CType { get; set; }
        public bool? BDisabled { get; set; }

        public MainSites FSiteNavigation { get; set; }
        public ICollection<MainMaterials> MainMaterials { get; set; }
    }
}
