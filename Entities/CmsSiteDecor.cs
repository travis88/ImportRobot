using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsSiteDecor
    {
        public Guid Id { get; set; }
        public string FSiteId { get; set; }
        public string CKey { get; set; }
        public string CValue { get; set; }

        public MainSites FSite { get; set; }
    }
}
