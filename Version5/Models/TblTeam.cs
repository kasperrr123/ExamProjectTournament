using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblTeam
    {
        public long FldTeamId { get; set; }
        public string FldProjectName { get; set; }
        public string FldUsername { get; set; }
        public string FldTeamName { get; set; }
        public string FldTopic { get; set; }
        public int? FldMembers { get; set; }
        public string FldLeaderName { get; set; }

        public TblProject FldProjectNameNavigation { get; set; }
        public TblLogin FldUsernameNavigation { get; set; }
    }
}
