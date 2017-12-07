using System;
using System.Collections.Generic;

namespace Version5.Models
{
    public partial class TblTopic
    {
        public TblTopic()
        {
            TblQuestionnaire = new HashSet<TblQuestionnaire>();
            TblTeam = new HashSet<TblTeam>();
        }

        public long FldTopicId { get; set; }
        public string FldTopic { get; set; }

        public ICollection<TblQuestionnaire> TblQuestionnaire { get; set; }
        public ICollection<TblTeam> TblTeam { get; set; }
    }
}
