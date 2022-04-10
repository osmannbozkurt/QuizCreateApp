using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Model
{

    public class ExamModel
    {
        public int quizId { get; set; }
        public string blogTitle { get; set; }
        public string blogDescription { get; set; }
        public List<ExamQuestionListModel> questionList { get; set; }
    }
    public class ExamQuestionListModel
    {
        public int questionId { get; set; }
        public string questionText { get; set; }
        public List<Quiz_Question_Option> optionList { get; set; }
    } 
}
