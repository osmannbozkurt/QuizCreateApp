using Businness.Model;
using Businness.Services;
using Core.Aspects.AutoFac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Managers
{
    public class QuizManager : IQuizService
    {
        IQuizDal _quizDal;
        IUserService _userService;
        IQuizQuestionService _quizQuestionService;
        IQuizQuestionOptionService _quizQuestionOptionService;
        public QuizManager(IQuizDal quizDal, IUserService userService, IQuizQuestionService quizQuestionService,
            IQuizQuestionOptionService quizQuestionOptionService)
        {
            _quizDal = quizDal;
            _userService = userService;
            _quizQuestionService = quizQuestionService;
            _quizQuestionOptionService = quizQuestionOptionService;
        }

        //[TransactionScopeAspect]
        public IResult SaveQuiz(QuizRequestModel quizRequestModel, int userId)
        {


            var quiz = new Quiz
            {
                Description = quizRequestModel.blogDescription,
                Title = quizRequestModel.blogTitle,
                Userid = userId,
                Creatindate = DateTime.Now
            };
            Add(quiz);
            foreach (var item in quizRequestModel.questionList)
            {
                var quizQuestion = new Quiz_Question
                {
                    Correcctoption = item.correctOption,
                    Quizid = quiz.Id,
                    Text = item.questionText
                };
                _quizQuestionService.Add(quizQuestion);

                foreach (var option in item.optionList)
                {
                    var question_option = new Quiz_Question_Option
                    {
                        Optionchar = option.optionChar,
                        Quiz_Question_Id = quizQuestion.Id,
                        Text = option.optionText
                    };
                    _quizQuestionOptionService.Add(question_option);
                }
            }



            return new SuccessResult();
        }

        public IResult Add(Quiz quiz)
        {
            _quizDal.Add(quiz);
            return new SuccessResult();
        }

        public IResult Delete(Quiz quiz)
        {
            _quizDal.Delete(quiz);
            return new SuccessResult();
        }

        public IDataResult<List<Quiz>> GetAllFromUser(int userId)
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll(q => q.Userid == userId));
        }

        public IDataResult<List<Quiz>> GetAll()
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll());
        }
    }
}
