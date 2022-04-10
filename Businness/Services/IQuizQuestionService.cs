using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public interface IQuizQuestionService
    {
        IResult Add(Quiz_Question quiz_Question);
        IResult Delete(Quiz_Question quiz_Question);
        IDataResult<List<Quiz_Question>> GetAll(int quizId);
        IDataResult<Quiz_Question> Get(int questionId);
    }
}
