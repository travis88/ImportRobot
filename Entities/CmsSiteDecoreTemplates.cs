using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class CmsSiteDecoreTemplates
    {
        public Guid Id { get; set; }
        public Guid TemplateId { get; set; }
        public string CKey { get; set; }
        public string CValue { get; set; }

        public CmsSiteTemplates Template { get; set; }
    }
}
