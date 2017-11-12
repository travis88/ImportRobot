using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainActivities
    {
        public MainActivities()
        {
            MainActivitiesLaws = new HashSet<MainActivitiesLaws>();
            MainActivitiesMaterials = new HashSet<MainActivitiesMaterials>();
        }

        public Guid Id { get; set; }
        public int NPermit { get; set; }
        public string FSite { get; set; }
        public string CPath { get; set; }
        public string CAlias { get; set; }
        public string CTitle { get; set; }
        public string CLogo { get; set; }
        public string CText { get; set; }
        public string CDesc { get; set; }
        public string CKeyw { get; set; }
        public bool? BDisabled { get; set; }
        public bool? BShowAsFilter { get; set; }

        public MainSites FSiteNavigation { get; set; }
        public ICollection<MainActivitiesLaws> MainActivitiesLaws { get; set; }
        public ICollection<MainActivitiesMaterials> MainActivitiesMaterials { get; set; }
    }
}
