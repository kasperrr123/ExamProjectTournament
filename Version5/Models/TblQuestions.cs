using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblQuestions
    {
        public TblQuestions()
        {
            TblAnswer = new HashSet<TblAnswer>();
        }

        public long FldQuestionsId { get; set; }
        public long? FldQuestionnaireId { get; set; }
        public string FldQuestion { get; set; }

        public TblQuestionnaire FldQuestionnaire { get; set; }
        public ICollection<TblAnswer> TblAnswer { get; set; }
    }
}
