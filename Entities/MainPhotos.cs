using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainPhotos
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public string CTitle { get; set; }
        public DateTime DDate { get; set; }
        public string CPreview { get; set; }
        public string CPhoto { get; set; }
        public int NPermit { get; set; }

        public MainPhotoAlbums Album { get; set; }
    }
}
