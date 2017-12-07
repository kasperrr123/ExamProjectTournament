using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblTeam
    {
        public TblTeam()
        {
            TblAnswer = new HashSet<TblAnswer>();
        }

        public string FldTeamName { get; set; }
        public string FldProjectName { get; set; }
        public string FldUsername { get; set; }
        public long? FldTopicId { get; set; }
        public string FldLeaderName { get; set; }

        public TblProject FldProjectNameNavigation { get; set; }
        public TblTopic FldTopic { get; set; }
        public TblLogin FldUsernameNavigation { get; set; }
        public ICollection<TblAnswer> TblAnswer { get; set; }
    }
}
