using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01.Questions
{
    internal abstract class Question: ICloneable, IComparable<Question>
    {
        public Question(string header, string body, int mark, List<Answer> answerList,Answer correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            CorrectAnswer = correctAnswer;
        }

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }

        public Answer CorrectAnswer { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(Question? other)
        {
            if (other is null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public override string ToString()
        {
            return $"{Header}\tMark: {Mark}\n{Body}";
        }
    }
}
