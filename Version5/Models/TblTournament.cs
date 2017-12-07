using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblTournament
    {
        public TblTournament()
        {
            TblJudge = new HashSet<TblJudge>();
            TblProject = new HashSet<TblProject>();
            TblQuestionnaire = new HashSet<TblQuestionnaire>();
        }

        public int FldTournamentId { get; set; }
        public string FldTournamentName { get; set; }
        public DateTime? FldStartDate { get; set; }
        public DateTime? FldEndDate { get; set; }
        public string FldAddress { get; set; }

        public ICollection<TblJudge> TblJudge { get; set; }
        public ICollection<TblProject> TblProject { get; set; }
        public ICollection<TblQuestionnaire> TblQuestionnaire { get; set; }
    }
}
