using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Model
{
    public class CompleteExamRequestMaster
    {
        public List<CompleteExamRequest> solvedList { get; set; }
        public int quizId { get; set; }
    }
    public class CompleteExamRequest
    {
        public int questionId { get; set; }
        public string optionChar { get; set; }
    }
}
