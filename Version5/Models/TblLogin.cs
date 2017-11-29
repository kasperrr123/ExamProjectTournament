using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblLogin
    {
        public TblLogin()
        {
            TblJudge = new HashSet<TblJudge>();
            TblTeam = new HashSet<TblTeam>();
        }

        public long FldLoginId { get; set; }
        public string FldUsername { get; set; }
        public string FldPassword { get; set; }
        public string FldRank { get; set; }

        public ICollection<TblJudge> TblJudge { get; set; }
        public ICollection<TblTeam> TblTeam { get; set; }
    }
}
