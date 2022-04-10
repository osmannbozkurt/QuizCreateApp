using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IQuiz_Question_OptionDal : IEntityRepository<Quiz_Question_Option>
    {
    }
}
