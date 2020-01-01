using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Student : IComparable<Student>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string ParentName { get; }
        public string TestName { get; }
        public double TestResult { get; set; }
        public DateTime Date { get; set; }

        public Student(string firstName, string lastName, string parentName, string testName, double testResult,
            DateTime date)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ParentName = parentName;
            this.TestName = testName;
            this.TestResult = testResult;
            this.Date = date;
        }

        public override string ToString()
        {
            return $"Test - {TestName}.\n Student - {LastName} {FirstName} {ParentName}. \n Result - {TestResult}. " +
                $"\n Date - {Date}";
        }

        public int CompareTo(Student student)
        {
            if (student == null)
            {
                return 1;
            }
            if (TestResult >= student.TestResult)
            {
                return 1;
            }

            return -1;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Student student = obj as Student;
            return student.TestResult == this.TestResult;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
