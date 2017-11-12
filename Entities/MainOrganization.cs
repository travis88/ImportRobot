using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainOrganization
    {
        public Guid Id { get; set; }
        public string CTitle { get; set; }
        public string CAlias { get; set; }
        public string FSite { get; set; }
        public string FType { get; set; }
        public string FDistrict { get; set; }
        public string CAddres { get; set; }
        public string CPhone { get; set; }
        public string CEmail { get; set; }
        public string CWeb { get; set; }
        public string CWork { get; set; }
        public double? CCoordX { get; set; }
        public double? CCoordY { get; set; }
        public bool? BDisabled { get; set; }
        public string CFax { get; set; }
        public string CText { get; set; }
        public int NPermit { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
