using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Version5.Models;

namespace Version5.Controllers
{
    [Produces("application/json")]

    public class GetScoreDependingOnTeamNameController : Controller
    {
        private readonly db_examprojecttournamentContext _context;

        public GetScoreDependingOnTeamNameController(db_examprojecttournamentContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/GetScoreDependingOnTeamName/{teamname}")]
        public ScoreStruct GetScore(string teamname)
        {
            double interviewScore = 0;
            double totalScore = 0;
            double reportScore = 0;
            var topicid = _context.TblTeam.Find(teamname).FldTopicId;
            var QuestionairesforTeam = _context.TblQuestionnaire.Where(n => n.FldTopicId == topicid);
            var InterviewQuestionaireId = QuestionairesforTeam.Where(n => n.FldType == "interview").First().FldQuestionnaireId;
            var reportQuestionaireId = QuestionairesforTeam.Where(n => n.FldType == "report").First().FldQuestionnaireId;
            var InterviewQuestions = _context.TblQuestions.Where(n => n.FldQuestionnaireId == InterviewQuestionaireId);
            var reportQuestions = _context.TblQuestions.Where(n => n.FldQuestionnaireId == reportQuestionaireId);

            try
            {
                foreach (var item in InterviewQuestions)
                {

                    interviewScore += double.Parse(_context.TblAnswer.Where(n => n.FldQuestionsId == item.FldQuestionsId && n.FldTeamName == teamname).First().FldPoint) * (double)item.FldModifier;

                }
            }
            catch (Exception)
            {
                interviewScore = 0;
            }
            try
            {
                foreach (var item in reportQuestions)
                {
                    reportScore += double.Parse(_context.TblAnswer.Where(n => n.FldQuestionsId == item.FldQuestionsId && n.FldTeamName == teamname).First().FldPoint) * (double)item.FldModifier;
                }
            }
            catch (Exception)
            {
                reportScore = 0;
            }


            totalScore = interviewScore + reportScore;

            var returnStruct = new ScoreStruct
            {
                InterviewScore = interviewScore,
                ReportScore = reportScore,
                totalscore = totalScore
            };

            return returnStruct;
        }
        [HttpGet]
        [Route("api/GetScoreDependingOnLogin/{email}")]
        public ScoreStruct GetScoreFromEmail(string email)
        {
            double interviewScore = 0;
            double totalScore = 0;
            double reportScore = 0;
            var teamname = _context.TblTeam.Where(n => n.FldUsername == email).First().FldTeamName;
            var topicid = _context.TblTeam.Find(teamname).FldTopicId;
            var QuestionairesforTeam = _context.TblQuestionnaire.Where(n => n.FldTopicId == topicid);
            var InterviewQuestionaireId = QuestionairesforTeam.Where(n => n.FldType == "interview").First().FldQuestionnaireId;
            var reportQuestionaireId = QuestionairesforTeam.Where(n => n.FldType == "report").First().FldQuestionnaireId;
            var InterviewQuestions = _context.TblQuestions.Where(n => n.FldQuestionnaireId == InterviewQuestionaireId);
            var reportQuestions = _context.TblQuestions.Where(n => n.FldQuestionnaireId == reportQuestionaireId);

            try
            {
                foreach (var item in InterviewQuestions)
                {

                    interviewScore += double.Parse(_context.TblAnswer.Where(n => n.FldQuestionsId == item.FldQuestionsId && n.FldTeamName == teamname).First().FldPoint) * (double)item.FldModifier;

                }
            }
            catch (Exception)
            {
                interviewScore = 0;
            }
            try
            {
                foreach (var item in reportQuestions)
                {
                    reportScore += double.Parse(_context.TblAnswer.Where(n => n.FldQuestionsId == item.FldQuestionsId && n.FldTeamName == teamname).First().FldPoint) * (double)item.FldModifier;
                }
            }
            catch (Exception)
            {
                reportScore = 0;
            }


            totalScore = interviewScore + reportScore;

            var returnStruct = new ScoreStruct
            {
                InterviewScore = interviewScore,
                ReportScore = reportScore,
                totalscore = totalScore
            };

            return returnStruct;
        }
    }
    public struct ScoreStruct
    {
        public double InterviewScore;
        public double ReportScore;
        public double totalscore;

    }
}