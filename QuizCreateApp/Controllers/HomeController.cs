using Businness.Model;
using Businness.Services;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizCreateApp.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace QuizCreateApp.Controllers
{

    [Authorize]
    public class HomeController : Controller
    { 

        IBlogSelectService _blogSelectService;
        IQuizService _quizService;
        IUserService _userService;
        public HomeController(IBlogSelectService blogSelectService, IQuizService quizService, IUserService userService)
        {
            _blogSelectService = blogSelectService;
            _quizService = quizService;
            _userService = userService;
        } 
        public IActionResult QuizList()
        {
            int userid = int.Parse(User.Claims.Where(c => c.Type == "userid").Select(c => c.Value).SingleOrDefault());
            var quizList = _quizService.GetAllFromUser(userid);

            return View(quizList.Data);
        }

        [Route("createquiz")]
        public IActionResult CreateQuiz()
        {
 
            return View();
        }


        [Route("deletequiz")]
        [HttpPost]
        public Core.Utilities.Results.IResult DeleteQuiz(int quizId)
        {
            var quizObj = new Quiz
            {
                Id = quizId,
            };
            _quizService.Delete(quizObj);
            return new SuccessResult();
        }
        [HttpGet]
        public IDataResult<List<NewsContentModel>> getItems()
        {
            var latestPosts = _blogSelectService.GetLatestNews();

            return latestPosts;
        }

        [HttpPost]
        public Core.Utilities.Results.IResult InsertNewQuiz(QuizRequestModel quiz)
        {
            int userid = int.Parse(User.Claims.Where(c => c.Type == "userid").Select(c => c.Value).SingleOrDefault());
             
            _quizService.SaveQuiz(quiz, userid);
            return new SuccessResult();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}