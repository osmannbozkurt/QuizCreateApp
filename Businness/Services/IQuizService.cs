using Businness.Model;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public interface IQuizService
    {

        IResult SaveQuiz(QuizRequestModel quizRequestModel, int userId);
        IResult Add(Quiz quiz);
        IResult Delete(Quiz quiz); 
        IDataResult<List<Quiz>> GetAllFromUser(int userId); 
        IDataResult<List<Quiz>> GetAll(); 

    }
}
