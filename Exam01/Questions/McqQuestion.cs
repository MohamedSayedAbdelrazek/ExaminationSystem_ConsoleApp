using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01.Questions
{
    internal class McqQuestion : Question
    {
        public McqQuestion(string header, string body, int mark, List<Answer> answerList, Answer correctAnswer) : base(header, body, mark, answerList, correctAnswer)
        {
        }

    }
}
