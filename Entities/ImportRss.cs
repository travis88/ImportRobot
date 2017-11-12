using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class ImportRss
    {
        public Guid Id { get; set; }
        public string CTitle { get; set; }
        public string CUrl { get; set; }
        public DateTime DDateCreated { get; set; }
        public string FSite { get; set; }
    }
}
