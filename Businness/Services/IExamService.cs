using Businness.Model;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Services
{
    public interface IExamService
    {
        IDataResult<List<ExamModel>> GetAll();
        IDataResult<List<CompleteExamResponse>> CompleteExam(CompleteExamRequestMaster obj);
    }
}
