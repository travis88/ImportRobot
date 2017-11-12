using System;
using System.Collections.Generic;

namespace ImportRobot.Entities
{
    public partial class MainVote
    {
        public MainVote()
        {
            MainVoteAnswers = new HashSet<MainVoteAnswers>();
        }

        public Guid Id { get; set; }
        public string FSite { get; set; }
        public bool? BType { get; set; }
        public string CHeader { get; set; }
        public string CText { get; set; }
        public bool? BDisabled { get; set; }
        public bool? BHisAnswer { get; set; }
        public DateTime DDateStart { get; set; }
        public DateTime? DDateEnd { get; set; }

        public MainSites FSiteNavigation { get; set; }
        public ICollection<MainVoteAnswers> MainVoteAnswers { get; set; }
    }
}
