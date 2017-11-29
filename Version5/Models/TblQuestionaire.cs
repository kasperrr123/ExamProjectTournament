using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblQuestionaire
    {
        public TblQuestionaire()
        {
            TblAnswer = new HashSet<TblAnswer>();
        }

        public long FldQuestionaireId { get; set; }
        public long? FldTournamentId { get; set; }
        public string FldFirstQuestion { get; set; }
        public string FldSecondQuestion { get; set; }
        public string FldThirdQuestion { get; set; }
        public string FldFourthQuestion { get; set; }

        public TblTournament FldTournament { get; set; }
        public ICollection<TblAnswer> TblAnswer { get; set; }
    }
}
