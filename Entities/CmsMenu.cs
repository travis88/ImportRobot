using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsMenu
    {
        public CmsMenu()
        {
            CmsResolutions = new HashSet<CmsResolutions>();
            CmsResolutionsTemplates = new HashSet<CmsResolutionsTemplates>();
        }

        public Guid Id { get; set; }
        public short NPermit { get; set; }
        public string CAlias { get; set; }
        public string CUrl { get; set; }
        public string CTitle { get; set; }
        public string CDesc { get; set; }
        public DateTime DDate { get; set; }
        public string CClass { get; set; }
        public string CGroup { get; set; }

        public ICollection<CmsResolutions> CmsResolutions { get; set; }
        public ICollection<CmsResolutionsTemplates> CmsResolutionsTemplates { get; set; }
    }
}
