using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainActivitiesMaterials
    {
        public Guid IdActivities { get; set; }
        public Guid IdMaterials { get; set; }

        public MainActivities IdActivitiesNavigation { get; set; }
        public MainMaterials IdMaterialsNavigation { get; set; }
    }
}
