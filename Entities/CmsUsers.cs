using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsUsers
    {
        public CmsUsers()
        {
            CmsResolutions = new HashSet<CmsResolutions>();
            CmsUsersSiteLink = new HashSet<CmsUsersSiteLink>();
        }

        public Guid Id { get; set; }
        public string CEmail { get; set; }
        public string CSalt { get; set; }
        public string CHash { get; set; }
        public string FGroup { get; set; }
        public string CPost { get; set; }
        public string CDesc { get; set; }
        public string CKeyw { get; set; }
        public string CSurname { get; set; }
        public string CName { get; set; }
        public string CPatronymic { get; set; }
        public DateTime? DBirthday { get; set; }
        public bool? BSex { get; set; }
        public string CPhoto { get; set; }
        public string CAdres { get; set; }
        public string CPhone { get; set; }
        public string CMobile { get; set; }
        public string CContacts { get; set; }
        public bool? BDisabled { get; set; }
        public bool? BDeleted { get; set; }

        public CmsUsersGroup FGroupNavigation { get; set; }
        public ICollection<CmsResolutions> CmsResolutions { get; set; }
        public ICollection<CmsUsersSiteLink> CmsUsersSiteLink { get; set; }
    }
}
