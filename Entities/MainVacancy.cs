using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainVacancy
    {
        public string CProfession { get; set; }
        public string CPosition { get; set; }
        public string CEducation { get; set; }
        public string CExperience { get; set; }
        public string CPay { get; set; }
        public string CDescription { get; set; }
        public DateTime DPublicationDate { get; set; }
        public Guid Id { get; set; }
        public bool? BDisabled { get; set; }
        public string FSite { get; set; }
        public DateTime DKonkursDate { get; set; }
        public int? NOldId { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
