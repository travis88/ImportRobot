using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainActivitiesLaws
    {
        public Guid IdActivities { get; set; }
        public Guid IdLaws { get; set; }

        public MainActivities IdActivitiesNavigation { get; set; }
        public CmsLaws IdLawsNavigation { get; set; }
    }
}
