using Microsoft.AspNetCore.Mvc;

namespace QuizCreateApp.ViewComponents
{
    public class CommonImport : ViewComponent
    {



        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
