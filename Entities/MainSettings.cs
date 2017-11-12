using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainSettings
    {
        public int Id { get; set; }
        public Guid CGuid { get; set; }
        public bool? BDisabled { get; set; }
        public string CTitle { get; set; }
        public string CInfo { get; set; }
        public string CDesc { get; set; }
        public string CKeyw { get; set; }
        public string CMailServer { get; set; }
        public string CMailFrom { get; set; }
        public string CMailFromAlias { get; set; }
        public string CMailPass { get; set; }
        public string CMailTo { get; set; }
        public string CAdres { get; set; }
        public double? FCoordX { get; set; }
        public double? FCoordY { get; set; }
        public string CPhone { get; set; }
        public string CFax { get; set; }
        public string CMail { get; set; }
        public string CUrl { get; set; }
        public string CWorkMode { get; set; }
        public bool? BSsl { get; set; }
        public int? NMailPort { get; set; }
    }
}
