using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblQuestionnaire
    {
        public TblQuestionnaire()
        {
            TblQuestions = new HashSet<TblQuestions>();
        }

        public long FldQuestionnaireId { get; set; }
        public int? FldTournamentId { get; set; }
        public long? FldTopicId { get; set; }

        public TblTopic FldTopic { get; set; }
        public TblTournament FldTournament { get; set; }
        public ICollection<TblQuestions> TblQuestions { get; set; }
    }
}
