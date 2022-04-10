using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Quiz_Question : IEntity
    {
        public int Id { get; set; }
        public int Quizid { get; set; }
        public string Text { get; set; }
        public string Correcctoption { get; set; }
    }
}
