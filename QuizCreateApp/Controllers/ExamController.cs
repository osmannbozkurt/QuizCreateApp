using Businness.Model;
using Businness.Services;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace QuizCreateApp.Controllers
{
    public class ExamController : Controller
    { 
        IExamService _examService;
        public ExamController(IExamService examService)
        { 
            _examService = examService;
        }

        [Route("test")]
        public IActionResult Index()
        { 
            return View();
        }

        [HttpGet]
        public List<ExamModel> SelectAllExam()
        {
            var allExam = _examService.GetAll().Data;

            return allExam;
        }

        [HttpPost]
        public IDataResult<List<CompleteExamResponse>> CompleteExam(CompleteExamRequestMaster obj)
        {
            return _examService.CompleteExam(obj);
        }
    }
}
