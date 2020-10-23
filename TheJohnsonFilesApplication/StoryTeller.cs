using System;
using System.Threading;
using System.Transactions;

namespace TheJohnsonFilesApplication
{
    class StoryTeller
    {
        static void Main(string[] args)
        {
            Setup();

            // Testing Area //
            

            //Console.WriteLine("Hello World!");
            
            Introduction();
            Student student = CreateStudent();
            Speech("Mr Johnson", $"Quick {student.FirstName}! We don't have much time!", 2000);
            DeliverManuscript();
            string letter = student.Puzzles["Puzzle1"]["Seed"];
            Speech("Mr Johnson", $"Okay {student.Name}, now's your time to shine. I need you to analyse my manscript and tell me how many times the letter {letter} occurs in my manuscript.", 6000);
            Speech("Mr Johnson", $"That's ALL of them, so all of the little {letter.ToLower()}'s and all of the BIG {letter.ToUpper()}'s! ");
            Console.ReadKey();
        }

        static Student CreateStudent()
        {
            string[] studentdata = new string[] { "-1" };
            while (studentdata[0] == "-1")
            {
                studentdata = GetStudentData();
                if (studentdata[0] == "-1")
                {
                    Warning("ID not recognised. Please try again.");
                    ClearLine(1);
                }
            }
            return new Student(studentdata);
        }

        static string[] GetStudentData()
        {
            string studentID = GetUserInput("Please enter your 7-digit student ID: ");
            string[] studentdata = DataFromSheets.GetUser(studentID);
            return studentdata;
        }

        static void LoginSuccessful()
        {

            int seed = 50;
            string line = new string('$', seed);
            string phrase = "LOGIN SUCCESSFUL";
            int padding = (seed - phrase.Length) / 2;
            string gap = new string(' ', padding - 1);
            phrase = $"${gap}{phrase}{gap}$";
            string[] box = new string[] { line, phrase, line };
            foreach (string s in box)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(s[i]);
                    Thread.Sleep(50);
                }
                Console.WriteLine();
            }

       
        }

        static void DeliverManuscript()
        {
            
            Speech("Mr Johnson", "I have written a manuscript", 2000);
            Speech("Mr Johnson", "A sacred text in which all of the answers lie", 3000);
            Speech("Mr Johnson", "I have access to your computer, give me a second, I'll send it across", 5000);
            TemporaryWarning("Unauthorised user Detected!");
            TemporaryWarning("System security overide");
            Waiting("Incoming file request from www.mrjc.co.uk - Checking Authenticity", 3, 3);
            LoadingBar("Downloading The_Manuscript.txt to My Desktop: ", '*', 25, 300);
            PuzzleFiles.WriteManuscript();
            Speech("Mr Johnson", "Check your computer's desktop - you should have a copy of my manuscript.", 5000);
            Speech("Mr Johnson", "Let me know when you've found it", 1000);
            InstructionAndConfirm("Press any key to continue: ");
            ClearLines(7);
        }

        static void InstructionAndConfirm(string message)
        {
            Instruction(message);
            Console.ReadKey();
            ClearLine();
        }

        static void Instruction(string message)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(message);
        }
   
        static void Warning(string message, int time = 1000)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"!!! {message} !!!");
            Thread.Sleep(time);
        }

        static void TemporaryWarning(string message, int time = 1000)
        {
            Warning(message, time);
            ClearLine(1);
        }

        static void Success(string message, int time = 1000)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"$$$ {message} $$$");
            Thread.Sleep(time);
        }

        static void Setup()
        {
            //Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth/2, Console.LargestWindowHeight);
            
        }

        static void Introduction()
        {

            TitleAnimation();

            PrintImage("mrjohnsonascii.txt");

            // Login PIN
            Warning("Top Secret");
            Warning("No Access to unathorised personel");
            Instruction("Please enter your 4-digit PIN to continue: \n");
            bool correctPIN = GetUserInput("PIN: ", "1414", "PIN Verified", "Unable to verify PIN");
            while (correctPIN == false)
            {
                ClearLine(1);
                correctPIN = GetUserInput("PIN: ", "1414", "PIN Verified", "Unable to verify PIN");
            }
            LoginSuccessful();
            Waiting("Loading Databases", 2);
            Waiting("Fetching more RAM", 3);
            Waiting("Threading the Mainframe", 2);
            LoadingBar("Downloading the Internet: ");
            Waiting("Deleting cache from HDD", 1);
            ClearLines(6);

        }

        private static void TitleAnimation()
        {
            Console.Clear();
            string title = "The Johnson Files";
            for (int i = 0; i <= title.Length; i++)
            {
                string border = new string('*', i);
                Console.WriteLine(border);
                Console.WriteLine(title.Substring(0, i));
                Console.WriteLine(border);
                Thread.Sleep(200);
                if (i < title.Length)
                {
                    Console.Clear();
                }
            }
            PrintBlanks(2);
        }

        static void LoadingBar(string reason, char symbol = '#', int percentage = 25, int time = 100)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(reason);
            string progress = new string('-', percentage);
            for (int i = 0; i < percentage; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.Write($"|{progress}|");
                Thread.Sleep(time);
                progress = progress.Substring(0, i) + symbol + progress.Substring(i + 1);
                ClearPartOfLine(reason.Length, progress.Length);
            }
            ClearLine(0);
        }

        static void Waiting(string reason, int loadtime = 10,  int times = 3, char bar = '.', int time = 500)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(reason);
            for (int i = 0; i < loadtime; i++)
            {
                for (int j = 0; j < times; j++)
                {
                    Console.Write(bar);
                    Thread.Sleep(time);
                }
                ClearPartOfLine(reason.Length, times);
            }
            ClearLine(0);
        }

        static bool GetUserInput(string prompt, string answer, string correct = "", string incorrect = "", int time = 1000)
        {
            Instruction(prompt);
            string userinput = Console.ReadLine().Replace(prompt, "");
            if (userinput == answer)
            {
                ClearLine(1);
                Success(correct);
                Thread.Sleep(time);
                return true;
            }
            else
            {
                ClearLine(1);
                Warning(incorrect);
                Thread.Sleep(time);
                return false;
            }
        }

        static string GetUserInput(string prompt, int time = 1000)
        {
            Console.Write(prompt);
            string userinput = Console.ReadLine().Replace(prompt, "");
            Thread.Sleep(time);
            ClearLine(1);
            return userinput;
        }

        static void ClearPartOfLine(int startposition, int length)
        {
            ResetConsoleFormatting();
            Console.SetCursorPosition(startposition, Console.CursorTop);
            Console.Write(new string(' ', length));
            Console.SetCursorPosition(startposition, Console.CursorTop);
        }

        public static void ClearLines(int numberoflines)
        {
            ClearLine(0);
            for (int i = 0; i < numberoflines-1; i++)
            {
                ClearLine(1);
            }
        }

        public static void ClearLine(int rowoffset = 0)
        {
            ResetConsoleFormatting();
            try
            {
                Console.SetCursorPosition(0, Console.CursorTop - rowoffset);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ResetConsoleFormatting()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintBlanks(int times)
        {
            ResetConsoleFormatting();
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine();
            }
        }

        static void Description(string message, int time = 1000)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Cyan;   
            Console.WriteLine($"*** {message} ***");
            Thread.Sleep(time);
        }

        static void Descriptions(string[] messages, int time = 1000)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                Description(messages[i], time);
            }
        }

        static void Speech(string person, string message, int time = 1000)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{person}: ");
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"'{message}'");
            Thread.Sleep(time);
        }

        static void PrintImage(string imagename)
        {
            string image = System.IO.File.ReadAllText(@$"{imagename}");
            int width = 101;
            for (int i = 0; i < image.Length-width; i+=width)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(image[i + j]);
                    Thread.Sleep(1);
                }
            }
        }
    }
}
