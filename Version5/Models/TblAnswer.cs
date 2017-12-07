using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblAnswer
    {
        public long FldAnswerId { get; set; }
        public string FldTeamName { get; set; }
        public long? FldQuestionsId { get; set; }
        public long? FldJudgeId { get; set; }
        public string FldAnswer { get; set; }

        public TblJudge FldJudge { get; set; }
        public TblQuestions FldQuestions { get; set; }
        public TblTeam FldTeamNameNavigation { get; set; }
    }
}
