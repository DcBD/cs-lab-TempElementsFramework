using System;
using System.IO;
using TempElementsLib.src.classes;

namespace TempElementsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program.Zad1CheckUsing();
            //Program.Zad1CheckWithTryAndCatch();

            //TestTempTxtFile();
            //TestTempDir();

            TestTempElementsList();
        }

        public static void TestTempElementsList()
        {
            TempElementsList list = new TempElementsList();

            Console.WriteLine("Adding elements: ");
            TempTxtFile tempTxtFile = list.AddElement<TempTxtFile>();
            tempTxtFile.AddText("TEST1");
            tempTxtFile.AddText("TEST12");

            TempTxtFile tempTxtFile2 = list.AddElement<TempTxtFile>();
            tempTxtFile2.AddText("TEST2");

            Console.WriteLine("Check whether elements were created");
            Console.ReadLine();

            Console.WriteLine("Check if file was moved");
            list.MoveElementTo(tempTxtFile, Path.GetTempPath() + "copied.txt");
            list.Dispose();
            Console.ReadLine(); 
        }

        static void TestTempDir()
        {
            Program.DisplayBeginTestLine("Zad 3 - TempDir");
            using (TempDir dir = new TempDir()) {
                Console.WriteLine("Check if directory is created");
                Console.ReadLine();

                Console.WriteLine("Check if directory was deleted");
                dir.Dispose();
            }
            Program.DisplayEndTestLine();
        }


        static void TestTempTxtFile()
        {
            Program.DisplayBeginTestLine("Zad 2 - TempTxtFile");

            using (TempTxtFile file = new TempTxtFile())
            {
                file.Write("Test");
                file.WriteLine("Test2");
                Console.WriteLine("Sprawdz czy dane wpisały się do pliku");

                Console.ReadLine();

                Console.WriteLine("W tym momencie plik powinien się usunąć..");

                Program.DisplayEndTestLine(); 
            }

        }

        #region USING
        static void Zad1CheckUsing()
        {

            Program.DisplayBeginTestLine("Zad 1Check using");

            using (TempFile file = new TempFile())
            {
                Console.WriteLine("Sprawdz czy plik się utworzył");
                Console.ReadLine();
                Console.WriteLine("Sprawdz czy dane wpisały się do pliku");

                file.AddText("[1]");

                Console.ReadLine();
                Console.WriteLine("W tym momencie plik powinien się usunąć..");

            }

            Program.DisplayEndTestLine();

        }
        #endregion

        static void Zad1CheckWithTryAndCatch()
        {
            Program.DisplayBeginTestLine("Zad1 Check try and catch");

            TempFile file = new TempFile();
            try
            {
                Console.WriteLine("Dodawanie tekstu do pliku, sprawdz czy tekst sie dodał");
                file.AddText("TEST");
                Console.ReadLine();
                Console.WriteLine("Usuwanie pliku, a nastepnie próba dodania tekstu do pliku");
                file.Dispose();

                file.AddText("Ten tekst nie zostanie dodany");

            }catch(ObjectDisposedException e){
                Console.WriteLine("Plik został już usunięty, nie można wpisać danych do pliku.");
            }
 
            Program.DisplayEndTestLine();

        }

        static void DisplayBeginTestLine(string testName)
        {
            Console.WriteLine($"-- {testName} --");
        }

        static void DisplayEndTestLine() { 
            Console.Write("-- ** --");
        }
    }
}
