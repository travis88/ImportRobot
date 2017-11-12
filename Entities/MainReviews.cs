using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainReviews
    {
        public Guid Id { get; set; }
        public string FSite { get; set; }
        public string CText { get; set; }
        public DateTime DDate { get; set; }
        public bool? BDisable { get; set; }
        public string CIp { get; set; }
        public bool? BNew { get; set; }
        public string CEmail { get; set; }
        public string CAnswer { get; set; }
        public string CType { get; set; }
        public string CQuestioner { get; set; }
        public string CAnswerType { get; set; }
        public string CName { get; set; }
        public string CFile { get; set; }
        public string CDopAdres { get; set; }
        public string CDopContacts { get; set; }
        public string CCategory { get; set; }
        public Guid? FGroup { get; set; }
        public Guid? FType { get; set; }

        public CmsSectionsGroup FGroupNavigation { get; set; }
        public MainSites FSiteNavigation { get; set; }
        public CmsSectionsGroupItems FTypeNavigation { get; set; }
    }
}
