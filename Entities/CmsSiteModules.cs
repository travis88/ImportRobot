using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsSiteModules
    {
        public Guid Id { get; set; }
        public string CName { get; set; }
        public string CAlias { get; set; }
        public string CPreview { get; set; }
        public bool? BFull { get; set; }
        public bool? BHalf { get; set; }
        public bool? BThird { get; set; }
        public bool? BTwoThird { get; set; }
        public bool? BFourth { get; set; }
        public bool? BThreeFourth { get; set; }
        public string CTypeModul { get; set; }
    }
}
