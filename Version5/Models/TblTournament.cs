﻿using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblTournament
    {
        public TblTournament()
        {
            TblJudge = new HashSet<TblJudge>();
            TblProject = new HashSet<TblProject>();
            TblQuestionaire = new HashSet<TblQuestionaire>();
        }

        public long FldTournamentId { get; set; }
        public string FldTournamentName { get; set; }
        public int? FldYear { get; set; }
        public DateTime? FldStartDate { get; set; }
        public DateTime? FldEndDate { get; set; }
        public string FldStartTime { get; set; }
        public string FldAddress { get; set; }

        public ICollection<TblJudge> TblJudge { get; set; }
        public ICollection<TblProject> TblProject { get; set; }
        public ICollection<TblQuestionaire> TblQuestionaire { get; set; }
    }
}