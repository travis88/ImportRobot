using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainTenders
    {
        public Guid Id { get; set; }
        public string CTitle { get; set; }
        public string FSite { get; set; }
        public string CText { get; set; }
        public DateTime DDateCreate { get; set; }
        public DateTime DDateStart { get; set; }
        public DateTime DDateEnd { get; set; }
        public string CNumber { get; set; }
        public string FStage { get; set; }
        public string FType { get; set; }
        public string CKeyw { get; set; }
        public string CDesc { get; set; }
        public bool? BDisabled { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
