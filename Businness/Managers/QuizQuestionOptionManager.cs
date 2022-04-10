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
    public class QuizQuestionOptionManager : IQuizQuestionOptionService
    {
        IQuiz_Question_OptionDal _quiz_Question_OptionDal;
        public QuizQuestionOptionManager(IQuiz_Question_OptionDal quiz_Question_OptionDal)
        {
            _quiz_Question_OptionDal = quiz_Question_OptionDal;
        }
        public IResult Add(Quiz_Question_Option quiz_Question_Option)
        {
            _quiz_Question_OptionDal.Add(quiz_Question_Option);
            return new SuccessResult();
        }

        public IResult Delete(Quiz_Question_Option quiz_Question_Option)
        {
            _quiz_Question_OptionDal.Delete(quiz_Question_Option);
            return new SuccessResult();
        }

        public IDataResult<List<Quiz_Question_Option>> GetAll(int quizQuestionId)
        {
            return new SuccessDataResult<List<Quiz_Question_Option>>(_quiz_Question_OptionDal.GetAll(q=>q.Quiz_Question_Id == quizQuestionId));
        }
    }
}
