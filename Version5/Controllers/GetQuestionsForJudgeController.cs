using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Version5.Models;

namespace Version5.Controllers
{

    //i have Teamname
    //type
    //need to return a list of questions.
    [Produces("application/json")]
   
    public class GetQuestionsForJudgeController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public GetQuestionsForJudgeController(db_examprojecttournamentContext context)
        {
            _context = context;
        }
        [Route("api/GetQuestionsForJudge/{teamName}/{type}")]
        [HttpGet]
        public List<Object> GET(string teamName, string type)
        {
            try
            {
                List<object> returnlist = new List<object>();
                var topicid = _context.TblTeam.Find(teamName).FldTopicId;

                var questionnaireID = _context.TblQuestionnaire.Where(n => n.FldTopicId == topicid && n.FldType == type).First().FldQuestionnaireId;
                var questions = _context.TblQuestions.Where(n => n.FldQuestionnaireId == questionnaireID).ToList();
                foreach (var item in questions)
                {
                    returnlist.Add(new TblQuestions { FldQuestionsId =item.FldQuestionsId, FldQuestion= item.FldQuestion,FldModifier= item.FldModifier, FldQuestionnaireId = questionnaireID});
                }

                return returnlist;
            }
            catch (Exception e)
            {
                List<object> gotcalled = new List<object>();
                gotcalled.Add(new TblQuestions(){ FldQuestion = "got called"});

                return gotcalled;
            }
        
        }
        [Route("api/GetQuestionsForJudge/{username}")]
        public TblJudge GET(string username)
        {
            string judgeletter = _context.TblJudge.Where(n => n.FldUsername == username).First().FldJudgeLetter;
            var returnletter = new TblJudge
            {
                FldJudgeLetter = judgeletter
            };
            return returnletter;

        }
    }
}