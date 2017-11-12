using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainVoteAnswers
    {
        public Guid CIdVote { get; set; }
        public Guid Id { get; set; }
        public string CVariant { get; set; }
        public bool? BHisOption { get; set; }
        public short NPermit { get; set; }

        public MainVote CIdVoteNavigation { get; set; }
    }
}
