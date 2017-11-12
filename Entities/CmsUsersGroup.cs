using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsUsersGroup
    {
        public CmsUsersGroup()
        {
            CmsResolutionsTemplates = new HashSet<CmsResolutionsTemplates>();
            CmsUsers = new HashSet<CmsUsers>();
        }

        public string CAlias { get; set; }
        public string CGroupName { get; set; }
        public Guid Id { get; set; }

        public ICollection<CmsResolutionsTemplates> CmsResolutionsTemplates { get; set; }
        public ICollection<CmsUsers> CmsUsers { get; set; }
    }
}
