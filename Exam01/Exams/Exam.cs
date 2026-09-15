using Exam01.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01.Exams
{
    internal abstract class Exam
    {
        public Exam(int time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
        }

        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }
       public List<Question> Questions { get; set; }

        public abstract void ShowExam();
    }
}
