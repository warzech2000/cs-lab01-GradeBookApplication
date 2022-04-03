using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name,bool IsWeighted) : base(name, IsWeighted)
        {
            base.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentCount = Students.Count;
            int gradeTop = 0;
            if(studentCount < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {
                studentCount = studentCount / 5;

                foreach(Student student in Students)
                {
                    foreach(double grade in student.Grades)
                    {
                        if (grade > averageGrade) gradeTop++;
                    }
                }
            }
            if(gradeTop/studentCount < 1)
            {
                return 'A';
            }
            else if (gradeTop/studentCount < 2)
            {
                return 'B';
            }
            else if (gradeTop/studentCount < 3)
            {
                return 'C';
            }
            else if (gradeTop/studentCount < 4)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {

            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
    
}
