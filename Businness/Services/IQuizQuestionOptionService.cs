using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public interface IQuizQuestionOptionService
    {
        IResult Add(Quiz_Question_Option quiz_Question_Option);
        IResult Delete(Quiz_Question_Option quiz_Question_Option);
        IDataResult<List<Quiz_Question_Option>> GetAll(int quizQuestionId);
    }
}
