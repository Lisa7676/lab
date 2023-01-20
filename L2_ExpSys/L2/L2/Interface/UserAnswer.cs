using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2.Interface
{
    struct UserAnswer
    {
        public bool? Answer { private set; get; }

        public string SelectedAnswer {private set; get; }
        public UserAnswer(bool answer)//Ответы да/нет
        {
            Answer = answer;
            SelectedAnswer = "";
        }
        public UserAnswer (string selectedAnswer)//Ответы не да/нет
        {
            Answer = null;
            SelectedAnswer = selectedAnswer;
        }
    }
}
