using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsResolutionsTemplates
    {
        public int Id { get; set; }
        public Guid FMenuId { get; set; }
        public string FUserGroupId { get; set; }
        public bool? BRead { get; set; }
        public bool? BWrite { get; set; }
        public bool? BChange { get; set; }
        public bool? BDelete { get; set; }

        public CmsMenu FMenu { get; set; }
        public CmsUsersGroup FUserGroup { get; set; }
    }
}
