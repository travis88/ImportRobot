using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainCalendar
    {
        public Guid Id { get; set; }
        public string CTitle { get; set; }
        public string CAlias { get; set; }
        public string FSite { get; set; }
        public string CKeyw { get; set; }
        public string CDesc { get; set; }
        public DateTime DDateStart { get; set; }
        public DateTime DDateEnd { get; set; }
        public string NYear { get; set; }
        public string NMonth { get; set; }
        public string NDay { get; set; }
        public string CText { get; set; }
        public string CPlace { get; set; }
        public string CUrl { get; set; }
        public Guid? FEvent { get; set; }
        public bool? BDisabled { get; set; }
        public int? NOldId { get; set; }
        public string COrganizer { get; set; }
        public string CPhoto { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
