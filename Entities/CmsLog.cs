using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsLog
    {
        public Guid Id { get; set; }
        public Guid FPageId { get; set; }
        public Guid FUserId { get; set; }
        public DateTime DDate { get; set; }
        public string CAction { get; set; }
        public string CIp { get; set; }
    }
}
