using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblTeam
    {
        public long FldTeamId { get; set; }
        public long? FldProjectId { get; set; }
        public long? FldLoginId { get; set; }
        public string FldTeamName { get; set; }
        public string FldTopic { get; set; }
        public int? FldMembers { get; set; }
        public string FldLeaderName { get; set; }

        public TblLogin FldLogin { get; set; }
        public TblProject FldProject { get; set; }
    }
}
