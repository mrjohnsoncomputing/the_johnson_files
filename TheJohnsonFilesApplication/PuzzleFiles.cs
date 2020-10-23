using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TheJohnsonFilesApplication
{
    class PuzzleFiles
    {
        

        public static void WriteFileToDesktop(string filename, string content)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string path = Path.Combine(desktop, filename);
            System.IO.File.WriteAllText(path, content);
        }
    }
}
