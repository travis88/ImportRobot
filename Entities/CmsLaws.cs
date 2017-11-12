using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsLaws
    {
        public CmsLaws()
        {
            MainActivitiesLaws = new HashSet<MainActivitiesLaws>();
        }

        public Guid Id { get; set; }
        public bool? BDisabled { get; set; }
        public string CTitle { get; set; }
        public string CDesc { get; set; }
        public string CKeyw { get; set; }
        public string CLogo { get; set; }
        public string CText { get; set; }
        public string CDopText { get; set; }
        public string CUrl { get; set; }
        public string CNumber { get; set; }
        public DateTime DDate { get; set; }
        public string CNumberMinust { get; set; }
        public DateTime? DDateMinust { get; set; }
        public string FGroup { get; set; }
        public string CSource { get; set; }
        public string FSite { get; set; }
        public string NYear { get; set; }
        public string NMonth { get; set; }
        public string NDay { get; set; }
        public string CAlias { get; set; }
        public int? NOldId { get; set; }
        public string CGrLaw { get; set; }
        public DateTime CDatePubl { get; set; }

        public MainSites FSiteNavigation { get; set; }
        public ICollection<MainActivitiesLaws> MainActivitiesLaws { get; set; }
    }
}
