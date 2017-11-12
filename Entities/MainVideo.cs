using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainVideo
    {
        public Guid Id { get; set; }
        public string FSite { get; set; }
        public DateTime DDate { get; set; }
        public string CTitle { get; set; }
        public string CDesc { get; set; }
        public string COriginal { get; set; }
        public string CVideo { get; set; }
        public string CDopVideo { get; set; }
        public string CPreview { get; set; }
        public string CLogConvert { get; set; }
        public bool? BFinal { get; set; }
        public int? NWidth { get; set; }
        public int? NHeight { get; set; }
        public bool? BMediaGallery { get; set; }
        public string CSecondsProcessed { get; set; }
        public int? NOldId { get; set; }
        public string CVideoOgv { get; set; }

        public MainSites FSiteNavigation { get; set; }
    }
}
