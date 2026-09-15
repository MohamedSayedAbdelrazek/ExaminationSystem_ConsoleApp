using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Exam01.Exams
{
    internal class PracticalExam:Exam
    {
        public PracticalExam(int time,int noOfQuestions):base(time,noOfQuestions)
        {
            
        }

        public override void ShowExam()
        {
            Console.WriteLine("--------------------- Practical Exam ---------------------");
            Stopwatch start = Stopwatch.StartNew();
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"{Questions[i].Header}: {Questions[i].Mark} Mark");
                Console.WriteLine($"Question {i+1}: {Questions[i].Body}");

                for(int j = 0; j < Questions[i].AnswerList.Count; j++)
                {
                    Console.WriteLine($"{j+1}) {Questions[i].AnswerList[j].Text}");
                }
                
                int answerId;
                do
                {
                    Console.WriteLine("Enter your answer ID (From 1 To 4)");
                    answerId = int.Parse(Console.ReadLine());
                } while (answerId > 4 || answerId < 1);

            }
            Console.Clear();
            Console.WriteLine("Exam Ended");
            Console.WriteLine("Summary of your exam Below: ");
            Console.WriteLine();
            long time =start.ElapsedMilliseconds;

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {Questions[i].Body}");
                Console.WriteLine($"Right Answer: {Questions[i].CorrectAnswer.Text}");
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine($"Time: {time / 1000}s");
            Console.WriteLine("Thank You.");
        }
    }
}
