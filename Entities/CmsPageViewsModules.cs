using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsPageViewsModules
    {
        public Guid Id { get; set; }
        public string FSiteId { get; set; }
        public Guid FModuleId { get; set; }

        public MainSites FSite { get; set; }
    }
}
