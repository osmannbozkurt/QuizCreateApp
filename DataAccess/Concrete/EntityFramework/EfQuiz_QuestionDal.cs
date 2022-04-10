using Core.DataAccess.SqlLite;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuiz_QuestionDal : EfEntityRepositoryBase<Quiz_Question, QuizCreateAppContext>, IQuiz_QuestionDal
    {
    }
}
