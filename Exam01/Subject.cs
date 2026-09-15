using Exam01.Exams;
using Exam01.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01
{
    internal class Subject
    {
        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Exam exam { get; set; }

        public void CreateExam() 
        {
            int choice;
            do
            {
                Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final): ");
                choice = int.Parse(Console.ReadLine());
            } while (choice != 1 && choice != 2);

            int time;
            do
            {
                Console.WriteLine("Please enter the time for the exam (30 to 180 minutes): ");
                time = int.Parse(Console.ReadLine());
            } while (time < 30 || time > 180);

            Console.WriteLine("Please enter the number of questions: ");
            int noQuestions = int.Parse(Console.ReadLine());

            List<Question> questions = new List<Question>(noQuestions);

            if (choice == 1) // Practical exam
            {
                PracticalExam practicalExam = new PracticalExam(time, noQuestions);
                this.exam = practicalExam;
                for (int i = 0; i < noQuestions; i++)
                {
                    Console.WriteLine($"\n-----------Question{i + 1}-----------");
                    Console.WriteLine("Please enter the question Head: ");
                    string header = Console.ReadLine();

                    Console.WriteLine("Please enter the question Body: ");
                    string body = Console.ReadLine();

                    Console.WriteLine("Please enter the question Mark: ");
                    int mark = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Choices of Question ({i + 1}): ");
                    List<Answer> answers = new List<Answer>(4);
                    for (int j = 0; j < 4; j++)
                    {
                        Console.WriteLine($"Please enter choice number {j + 1}:");
                        string choiceText = Console.ReadLine();

                        answers.Add(new Answer { Id = j + 1, Text = choiceText });
                    }

                    int userAnswerId;
                    do
                    {
                        Console.WriteLine("Please enter the ID of the correct answer (1 to 4)");
                        userAnswerId = int.Parse(Console.ReadLine());
                    } while (userAnswerId > 4 || userAnswerId < 1);

                    questions.Add(new McqQuestion(header, body, mark, answers, answers[userAnswerId - 1]));
                    Console.WriteLine("Question created successfully.\n");
                }
                Console.WriteLine("Do You Want To Start Exam? ( Y | N )");
                char ch = Char.Parse(Console.ReadLine());
                switch (Char.ToLower(ch))
                {
                    case 'y':
                        Console.Clear();
                        practicalExam.Questions = questions;
                        practicalExam.ShowExam();
                        break;
                    case 'n':
                        return;
                }
                
            }
            else // Final exam
            {
                FinalExam finalExam = new FinalExam(time,noQuestions);
                this.exam = finalExam;
                for (int i = 0; i < noQuestions; i++)
                {
                    int questionType;
                    do
                    {
                        Console.WriteLine($"Enter details for question {i + 1}");
                        Console.WriteLine($"Choose question {i + 1} Type: 1 for MCQ, 2 for True/False:");
                        questionType = int.Parse(Console.ReadLine());
                    } while (questionType != 1 && questionType != 2);

                    if (questionType == 1)
                    {
                        Console.WriteLine($"\n-----------Question{i + 1}-----------");
                        Console.WriteLine("Please enter the question Head: ");
                        string header = Console.ReadLine();

                        Console.WriteLine("Please enter the question Body: ");
                        string body = Console.ReadLine();

                        Console.WriteLine("Please enter the question Mark: ");
                        int mark = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Choices of Question ({i + 1}): ");
                        List<Answer> answers = new List<Answer>(4);
                        for (int j = 0; j < 4; j++)
                        {
                            Console.WriteLine($"Please enter choice number {j + 1}:");
                            string choiceText = Console.ReadLine();

                            answers.Add(new Answer { Id = j + 1, Text = choiceText });
                        }

                        int userAnswerId;
                        do
                        {
                            Console.WriteLine("Please enter the ID of the correct answer (1 to 4)");
                            userAnswerId = int.Parse(Console.ReadLine());
                        } while (userAnswerId > 4 || userAnswerId < 1);

                        questions.Add(new McqQuestion(header, body, mark, answers, answers[userAnswerId - 1]));
                        Console.WriteLine("Question created successfully.");
                    }
                    else 
                    {
                        Console.WriteLine($"\n-----------Question{i + 1}-----------");
                        Console.WriteLine("Please enter the question Head: ");
                        string header = Console.ReadLine();

                        Console.WriteLine("Please enter the question Body: ");
                        string body = Console.ReadLine();

                        Console.WriteLine("Please enter the question Mark: ");
                        int mark = int.Parse(Console.ReadLine());

                        int userAnswerId;
                        do
                        {
                            Console.WriteLine("Please enter the ID of the correct answer ( 1 for True, 2 for False )");
                            userAnswerId = int.Parse(Console.ReadLine());
                        } while (userAnswerId!=1 && userAnswerId != 2);

                        List<Answer> answers = new List<Answer>(2) {
                            new Answer() { Id=1,Text="True" },
                            new Answer(){Id=2,Text="False" }
                        };
                        questions.Add(new TrueFalseQuestion(header, body, mark, answers, answers[userAnswerId-1]));
                        Console.WriteLine("Question created successfully.");
                    }

                }
                Console.WriteLine("Do You Want To Start Exam? ( Y | N )");
                char ch = Char.Parse(Console.ReadLine());
                switch (Char.ToLower(ch))
                {
                    case 'y':
                        Console.Clear();
                        finalExam.Questions = questions;
                        finalExam.ShowExam();
                        break;
                    case 'n':
                        return;
                }
                
            }

        }
    }
}
