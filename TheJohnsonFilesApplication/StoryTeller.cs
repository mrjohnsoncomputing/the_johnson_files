using System;
using System.Threading;
using System.Transactions;

namespace TheJohnsonFilesApplication
{
    class StoryTeller
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Setup();
            //Introduction();
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
            Student student = new Student(studentdata);
            Speech("Mr Johnson", $"Quick {student.FirstName}! We don't have much time!");
        }

        static string[] GetStudentData()
        {
            string studentID = GetUserInput("Please enter your 7-digit student ID: ");
            string[] studentdata = DataFromSheets.GetUser(studentID);
            return studentdata;
        }

        static void Warning(string message, int time = 1000)
        {
            Console.WriteLine($"!!! {message} !!!");
            Thread.Sleep(time);
        }

        static void Setup()
        {
            //Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth/2, Console.LargestWindowHeight/2);
            
        }

        static void Introduction()
        {

            TitleAnimation();

            // Login PIN
            Descriptions(new string[] { "Top Secret", "No Access to unathorised personel", "Please enter your 4-digit PIN to continue"});
            bool correctPIN = GetUserInput("PIN: ", "1414", "PIN Verified", "Unable to verify PIN");
            while (correctPIN == false)
            {
                ClearLine(1);
                correctPIN = GetUserInput("PIN: ", "1414", "PIN Verified", "Unable to verify PIN");
            }
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
            PrintBlanks(5);
        }

        static void LoadingBar(string reason, int percentage = 25, int time = 100)
        {
            Console.Write(reason);
            string progress = new string('-', percentage);
            for (int i = 0; i < percentage; i++)
            {
                Console.Write($"|{progress}|");
                Thread.Sleep(time);
                progress = progress.Substring(0, i) + "#" + progress.Substring(i + 1);
                ClearPartOfLine(reason.Length, progress.Length);
            }
            ClearLine(0);
        }

        static void Waiting(string reason, int loadtime = 10,  int times = 3, char bar = '.', int time = 500)
        {
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
            Console.Write(prompt);
            string userinput = Console.ReadLine().Replace(prompt, "");
            if (userinput == answer)
            {
                ClearLine(1);
                Console.WriteLine(correct);
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

        static void PrintBlanks(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine();
            }
        }

        static void Description(string message, int time = 1000)
        {
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
            Console.WriteLine($"{person}: '{message}'");
            Thread.Sleep(time);
        }
    }
}
