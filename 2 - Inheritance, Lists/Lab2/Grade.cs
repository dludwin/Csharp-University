using System;

namespace Inheritance_Lists
{
    public class Grade
    {
        private string _subjectName;
        private DateTime _date;
        private double _value;

        public string SubjectName
        {
            get { return _subjectName; }
            set { _subjectName = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Grade()
        {
            _value = 0;
            _subjectName = "none";
            _date = default(DateTime);   // or  new DateTime()
        }

        public Grade(string subjectName, double value, DateTime date)
        {
            _date = date;
            _subjectName = subjectName;
            _value = value;
        }

        public override string ToString()
        {
            return $"Grade: {_value}, Subject: {_subjectName}, Date: {_date}";
        }

        public void Details()
        {
            Console.WriteLine(this);
        }
    }
}
