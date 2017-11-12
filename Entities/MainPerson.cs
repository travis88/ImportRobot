using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainPerson
    {
        public Guid Id { get; set; }
        public string FSite { get; set; }
        public string CName { get; set; }
        public string CPhoto { get; set; }
        public string CAdres { get; set; }
        public string CPhone { get; set; }
        public string CEmail { get; set; }
        public string CPost { get; set; }
        public short NPermit { get; set; }
        public bool? BDisabled { get; set; }
        public string CEducation { get; set; }
        public string CCareer { get; set; }
        public string CAward { get; set; }
        public string CHistory { get; set; }
        public Guid? FStructure { get; set; }
        public string CKeyw { get; set; }
        public string CDesc { get; set; }
        public string CPhoneIntern { get; set; }
        public string CPhoneMobile { get; set; }
        public string CPhoneHome { get; set; }
        public string CRegulations { get; set; }
        public bool? BLeader { get; set; }
        public bool? BHeadOfDepart { get; set; }
        public string CQuote { get; set; }
        public string CAuthor { get; set; }
        public DateTime? DBirthDay { get; set; }
        public int? NOldId { get; set; }
        public DateTime? DInauguration { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
