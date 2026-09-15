using Exam01.Exams;
using Exam01.Questions;

namespace Exam01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1,"C# Programming");
            subject.CreateExam();
        }
    }
}
