using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Model
{
    public class QuizRequestModel
    {
        public string blogTitle { get; set; }
        public string blogDescription { get; set; }
        public List<QuizQuestionListModel> questionList { get; set; }
    }
    public class QuizQuestionListModel
    {
        public string correctOption { get; set; }
        public string questionText { get; set; }
        public List<QuizQuestionOptionListModel> optionList { get; set; }
    }
    public class QuizQuestionOptionListModel
    {
        public string optionChar { get; set; }
        public string optionText { get; set; }
    }
}
