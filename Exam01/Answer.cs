using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01
{
    internal class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public override bool Equals(object? obj)
        {
            if(obj is Answer other)
                return Text == other.Text;
            return false;
        }

        public override string ToString() => $"{Id}. {Text}";
        public override int GetHashCode() => Text?.GetHashCode() ?? 0;
    }
}
