using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainDocuments
    {
        public Guid Id { get; set; }
        public string CTitle { get; set; }
        public string CFilePath { get; set; }
        public DateTime DDateCreate { get; set; }
        public Guid IdPage { get; set; }
        public int NPermit { get; set; }
    }
}
