using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblAnswer
    {
        public long FldAnswerId { get; set; }
        public long? FldQuestionaireId { get; set; }
        public long? FldJudgeId { get; set; }
        public int FldFirstQuestionScore { get; set; }
        public int FldSecondQuestionScore { get; set; }
        public int FldThirdQuestionScore { get; set; }
        public int FldFourthQuestionScore { get; set; }

        public TblJudge FldJudge { get; set; }
        public TblQuestionaire FldQuestionaire { get; set; }
    }
}
