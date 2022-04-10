using Businness.Services;
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
    public class QuizQuestionManager : IQuizQuestionService
    {
        IQuiz_QuestionDal _quiz_QuestionDal;
        public QuizQuestionManager(IQuiz_QuestionDal quiz_QuestionDal)
        {
            _quiz_QuestionDal=quiz_QuestionDal;
        }
        public IResult Add(Quiz_Question quiz_Question)
        {
            _quiz_QuestionDal.Add(quiz_Question);
            return new SuccessResult();
        }

        public IResult Delete(Quiz_Question quiz_Question)
        {
            _quiz_QuestionDal.Delete(quiz_Question);
            return new SuccessResult();
        }

        public IDataResult<Quiz_Question> Get(int questionId)
        {
            return new SuccessDataResult<Quiz_Question>(_quiz_QuestionDal.Get(q => q.Id == questionId));
        }

        public IDataResult<List<Quiz_Question>> GetAll(int quizId)
        {
            return new SuccessDataResult<List<Quiz_Question>>(_quiz_QuestionDal.GetAll(q=>q.Quizid == quizId));
        }
    }
}
