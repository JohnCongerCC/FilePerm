using System;
using System.IO;
using System.Security.AccessControl;

namespace FilePerm
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderPath = @"c:\Search";
            foreach (string f in Directory.GetFiles(folderPath))
            {
               FilePerm(f);
            }
            
            //DirSearch(folderPath);
            
        }

        static void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        FilePerm(f);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }

        static void FilePerm(string FilePath)
        {
            var security = new FileSecurity(FilePath, AccessControlSections.Owner | AccessControlSections.Group | AccessControlSections.Access);
        }
    }
}
