using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsUsersSiteLink
    {
        public string FSiteId { get; set; }
        public Guid FUserId { get; set; }

        public MainSites FSite { get; set; }
        public CmsUsers FUser { get; set; }
    }
}
