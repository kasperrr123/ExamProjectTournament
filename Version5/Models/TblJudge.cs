using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblJudge
    {
        public TblJudge()
        {
            TblAnswer = new HashSet<TblAnswer>();
        }

        public long FldJudgeId { get; set; }
        public int? FldTournamentId { get; set; }
        public string FldJudgeLetter { get; set; }
        public string FldUsername { get; set; }

        public TblTournament FldTournament { get; set; }
        public TblLogin FldUsernameNavigation { get; set; }
        public ICollection<TblAnswer> TblAnswer { get; set; }
    }
}
