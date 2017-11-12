using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsSectionsGroup
    {
        public CmsSectionsGroup()
        {
            CmsSectionsGroupItems = new HashSet<CmsSectionsGroupItems>();
            MainReviews = new HashSet<MainReviews>();
        }

        public Guid Id { get; set; }
        public string CSectionId { get; set; }
        public string CAlias { get; set; }
        public string CTitle { get; set; }
        public short NPermit { get; set; }
        public bool? BReadonly { get; set; }
        public bool? BFiltr { get; set; }

        public ICollection<CmsSectionsGroupItems> CmsSectionsGroupItems { get; set; }
        public ICollection<MainReviews> MainReviews { get; set; }
    }
}
