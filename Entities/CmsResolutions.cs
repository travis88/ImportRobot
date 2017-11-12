using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsResolutions
    {
        public int Id { get; set; }
        public Guid CMenuId { get; set; }
        public Guid CUserId { get; set; }
        public bool? BRead { get; set; }
        public bool? BWrite { get; set; }
        public bool? BChange { get; set; }
        public bool? BDelete { get; set; }
        public bool? BImportent { get; set; }

        public CmsMenu CMenu { get; set; }
        public CmsUsers CUser { get; set; }
    }
}
