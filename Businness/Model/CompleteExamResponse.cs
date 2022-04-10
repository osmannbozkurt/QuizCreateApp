using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businness.Model
{
    public class CompleteExamResponse
    {
        public int questionId { get; set; }
        public bool isCorrect { get; set; }
        public string correctOption { get; set; }
        public string selectedOption { get; set; }
    }
}
