using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabenblatt01
{
    internal class Person
    {
        private string _name;
        private DateTime _dateOfBirth;

        public Person(string name,string dateOfBirth) 
        {
            _name = name;
            _dateOfBirth = Convert.ToDateTime(dateOfBirth);
        }

        public int GetAge() 
        {
            if(_dateOfBirth.Month==DateTime.Today.Month && _dateOfBirth.Day>=DateTime.Today.Day
                || DateTime.Today.Month > _dateOfBirth.Month)
            {
                return DateTime.Today.Year - _dateOfBirth.Year;
            }
            

            return DateTime.Today.Year - _dateOfBirth.Year - 1;
        }

        public string ToString()
        {
            return $"{_name};{_dateOfBirth.ToString("dd.MM.yyyy")}";
        }
    }
}
