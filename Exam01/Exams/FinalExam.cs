using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Timers;

namespace Exam01.Exams
{
    internal class FinalExam:Exam
    {
        public FinalExam(int time, int noOfQuestions):base(time, noOfQuestions)
        {
            
        }

        public override void ShowExam()
        {
            Console.WriteLine("--------------------- Final Exam ---------------------");
            int totalMark = 0;
            int userMark = 0;
            List<Answer> userAnswers = new List<Answer>(Questions.Count);
            Stopwatch start = Stopwatch.StartNew();
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"{Questions[i].Header}: {Questions[i].Mark} Mark");
                Console.WriteLine($"Question {i + 1}: {Questions[i].Body}");

                for (int j = 0; j < Questions[i].AnswerList.Count; j++)
                {
                    Console.WriteLine($"{j + 1}) {Questions[i].AnswerList[j].Text}");
                }

                int answerId;
                do
                {
                    Console.WriteLine($"Enter your answer ID (From 1 To {Questions[i].AnswerList.Count})");
                    answerId = int.Parse(Console.ReadLine());
                } while (answerId >  Questions[i].AnswerList.Count || answerId < 1);

                userAnswers.Add(new Answer() { Id = answerId, Text = Questions[i].AnswerList[answerId - 1].Text });

                if (Questions[i].CorrectAnswer.Equals( userAnswers[i]))
                    userMark += Questions[i].Mark;
                totalMark += Questions[i].Mark;
            }
            Console.Clear();
            Console.WriteLine("Exam Ended");
            Console.WriteLine("Summary of your exam Below: ");
            Console.WriteLine();
            long time = start.ElapsedMilliseconds;

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}: {Questions[i].Body}");
                Console.WriteLine($"Your Answer: {userAnswers[i].Text}");
                Console.WriteLine($"Correct Answer: {Questions[i].CorrectAnswer.Text}");
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine($"Your Grade Is: {userMark} From {totalMark}");
            Console.WriteLine($"Time: {time / 1000}s");
            Console.WriteLine("Thank You.");
        }
    }
    }
