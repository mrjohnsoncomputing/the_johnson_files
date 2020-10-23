using System;
using System.Collections.Generic;
using System.Text;

namespace TheJohnsonFilesApplication
{
    class Student
    {
        public Student(string[] data)
        {
            ID = data[0];
            FirstName = data[1];
            Surname = data[2];
            Name = FirstName + " " + Surname;
        }
        public string FirstName;
        public string Surname;
        public string Name;
        public string ID;
    }
}
