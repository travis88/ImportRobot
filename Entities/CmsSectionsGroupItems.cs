using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsSectionsGroupItems
    {
        public CmsSectionsGroupItems()
        {
            MainBanners = new HashSet<MainBanners>();
            MainReviews = new HashSet<MainReviews>();
        }

        public Guid Id { get; set; }
        public short NPermit { get; set; }
        public string CTitle { get; set; }
        public string CDesc { get; set; }
        public string CLogo { get; set; }
        public string FSiteId { get; set; }
        public string FSectionId { get; set; }
        public string FGroupId { get; set; }
        public string CAlias { get; set; }

        public CmsSectionsGroup F { get; set; }
        public MainSites FSite { get; set; }
        public ICollection<MainBanners> MainBanners { get; set; }
        public ICollection<MainReviews> MainReviews { get; set; }
    }
}
