using System;
using System.Collections.Generic;

namespace Inheritance_Lists
{
    public class Student : Person
    {
        private int _year;
        private int _group;
        private int _indexId;
        private IList<Grade> _grades;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public int IndexId
        {
            get { return _indexId; }
            set { _indexId = value; }
        }

        public IList<Grade> Grades       // Grades is getter for the List
        {
            get { return _grades; }
        }

        public Student() : base()   // call Person default constructor
        {
            _year = 0;
            _group = 0;
            _indexId = 0;
            _grades = new List<Grade>();    // Implementation of IList
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth,
                        int year, int group, int indexId)
            : base(firstName, lastName, dateOfBirth)       // call Person Constructor
        {
            _year = year;
            _group = group;
            _indexId = indexId;
            _grades = new List<Grade>();
        }

        public override string ToString()    // Implementation of IList
        {
            string str = base.ToString() + $" Year: {_year}, group: {_group}, indexId: {_indexId} \r\n Grades:";

            foreach (var grade in Grades)
                str += grade + "\r\n";           // Grade's ToString() method will be called
            return str;
        }
        public override void Details()
        {
            Console.WriteLine(this);
        }

        public void AddGrade(string subjectName, double value, DateTime date)
        {
            Grade grade = new Grade(subjectName, value, date);
            _grades.Add(grade);
        }

        public void AddGrade(Grade grade)
        {
            AddGrade(grade.SubjectName, grade.Value, grade.Date);    // Get values from grade and pass to AddGrade above with matching parameters
        }

        public void DisplayGrades()
        {
            string str = "Grades: \r\n";
            foreach (var grade in Grades)
                str += grade + "\r\n";
        }

        public void DisplayGrades(string subjectName)
        {
            Grade grade = null;                  // temporary grade, container for matched subjectName grade
            foreach (var gr in Grades)
                if (String.Compare(gr.SubjectName, subjectName, StringComparison.Ordinal) == 0)   // for every grade we compare with that one subjectName 
                    grade = gr;
            if (grade != null)
                grade.Details();                                                 // if grade isn't null after that we display it.
            else
                Console.WriteLine("There is no grade with given subject.");
        }

        public void DeleteGrade(string subjectName, double value, DateTime date)
        {
            Grade grade = null;
            foreach (var gr in _grades)           // Can be _grades or Grades. Because Grades is just property that returns _grades List
                if (gr.SubjectName == subjectName && gr.Value == value && gr.Date.Date == date.Date)
                    grade = gr;

            if (grade != null)
                _grades.Remove(grade);
            Console.WriteLine("There is no such grade.");
        }

        public void DeleteGrade(Grade grade)          // This is to delete grade directly.
        {
            DeleteGrade(grade.SubjectName, grade.Value, grade.Date);
        }

        public void DeleteGrades(string subjectName)
        {
            for (int i = 0; i < Grades.Count; i++)           // Grades.Count is length of the List
            if (_grades[i].SubjectName == subjectName)       // Again it can be Grades or _grades
                    _grades.RemoveAt(i);
        }

        public void DeleteGrades()
        {
            _grades.Clear();       // deletes the whole list
        }
    }
}
