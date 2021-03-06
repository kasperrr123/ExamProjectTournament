﻿using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblProject
    {
        public TblProject()
        {
            TblTeam = new HashSet<TblTeam>();
        }

        public string FldProjectName { get; set; }
        public int? FldTournamentId { get; set; }
        public string FldProjectFilePath { get; set; }

        public TblTournament FldTournament { get; set; }
        public ICollection<TblTeam> TblTeam { get; set; }
    }
}
