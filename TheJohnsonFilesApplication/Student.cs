using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
            Puzzles = GetPuzzles(data);
        }
        
        public string FirstName;
        public string Surname;
        public string Name;
        public string ID;
        internal Dictionary<string, Dictionary<string, string>> Puzzles;

        private Dictionary<string, Dictionary<string, string>> GetPuzzles(string[] data)
        {
            Dictionary<string, Dictionary<string, string>> puzzles = new Dictionary<string, Dictionary<string, string>> 
            {
                { "Puzzle1", GetPuzzle(data[3], data[4]) },
                { "Puzzle2", GetPuzzle(data[5], data[6]) },
            };
            return puzzles;
        }

        private Dictionary<string, string> GetPuzzle(string seed, string answer)
        {
            Dictionary<string, string> puzzle = new Dictionary<string, string>
            {
                { "Seed", seed },
                { "Answer", answer },
            };
            return puzzle;
        }
    }
}
