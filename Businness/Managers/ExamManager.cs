using Businness.Model;
using Businness.Services;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Managers
{
    public class ExamManager : IExamService
    {
        IQuizQuestionService _questionService;
        IQuizQuestionOptionService _quizQuestionOptionService;
        IQuizService _quizService;
        public ExamManager(IQuizQuestionService quizQuestionService, IQuizQuestionOptionService quizQuestionOptionService,
            IQuizService quizService)
        {
            _questionService = quizQuestionService;
            _quizQuestionOptionService = quizQuestionOptionService;
            _quizService = quizService;
        }
        public IDataResult<List<CompleteExamResponse>> CompleteExam(CompleteExamRequestMaster obj)
        {
            List<CompleteExamResponse> result = new List<CompleteExamResponse>();

            foreach (var item in obj.solvedList)
            {
                bool iscorrect = false;
                var question = _questionService.Get(item.questionId).Data;
                if (question.Correcctoption == item.optionChar)
                {
                    iscorrect = true;
                }
                result.Add(new CompleteExamResponse
                {
                    correctOption = question.Correcctoption,
                    isCorrect = iscorrect,
                    questionId = item.questionId,
                    selectedOption = item.optionChar
                });
            }
            return new SuccessDataResult<List<CompleteExamResponse>>(result);
        }

        public IDataResult<List<ExamModel>> GetAll()
        {
            List<ExamModel> result = new List<ExamModel>();

            var quizList = _quizService.GetAll().Data;
            foreach (var quiz in quizList)
            {
                var questions = _questionService.GetAll(quiz.Id).Data;

                List<ExamQuestionListModel> questionsList = new List<ExamQuestionListModel>();
                foreach (var question in questions)
                {
                    var options = _quizQuestionOptionService.GetAll(question.Id).Data;
                    questionsList.Add(new ExamQuestionListModel
                    {
                        optionList = options,
                        questionId = question.Id,
                        questionText = question.Text,
                    });
                }
                result.Add(new ExamModel
                {
                    blogDescription = quiz.Description,
                    blogTitle = quiz.Title,
                    questionList = questionsList,
                    quizId = quiz.Id,
                });
            }


            return new SuccessDataResult<List<ExamModel>>(result);
        }
    }
}
