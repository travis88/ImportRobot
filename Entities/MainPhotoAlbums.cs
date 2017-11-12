using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainPhotoAlbums
    {
        public MainPhotoAlbums()
        {
            MainPhotos = new HashSet<MainPhotos>();
        }

        public Guid Id { get; set; }
        public string FSite { get; set; }
        public string CTitle { get; set; }
        public string CDesc { get; set; }
        public DateTime DDate { get; set; }
        public string CAuthor { get; set; }
        public string CPreview { get; set; }
        public bool? BGallery { get; set; }
        public int? NOldId { get; set; }
        public string COldUrl { get; set; }

        public MainSites FSiteNavigation { get; set; }
        public ICollection<MainPhotos> MainPhotos { get; set; }
    }
}
