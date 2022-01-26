using System;
using System.Linq;
using System.Collections.Generic;

namespace Probe2
{
    class Personal_Library
    {
        public static void Startmenu()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Bitte geben Sie einen der folgenden Befehle ein:");
            Console.WriteLine("exit                     um das Programm zu schliessen");
            Console.WriteLine("new todo                 um ein neues ToDo zu erstellen");
            Console.WriteLine("print                    um Ihre aktiven ToDos nach der Fälligkeit zu ordnen");
            Console.WriteLine("description              um die Beschreibung ToDos abzurufen");
            Console.WriteLine("archive                  um ToDo abzuschliessen und zu archivieren");
            Console.WriteLine("rm                       um ToDo zu entfernen");
            Console.WriteLine("edit                     um Edit-Menu abzurufen");
            Console.WriteLine("print archive            um Archiv auszugeben");
            Console.WriteLine("save                     um alles zu speichern");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Geben Sie hier Ihren Befehl ein: ");
        }

        public static void Editmenu()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Was wollen Sie bearbeiten?");
            Console.WriteLine("Geben Sie Titel, Beschreibung, Fälligkeit, Prioritäten oder done ein: ");
            Console.WriteLine("---------------------------------------------------------------------------------------");
        }

        public static string NewToDo(string wort)
        {
            Console.WriteLine($"Bitte geben Sie {wort} Ihres neuen Todos ein: ");
            string todo = Console.ReadLine();
            return todo;
        }

        public static void PressToContinue()
        {
            Console.WriteLine("Drücken Sie einen beliebigen Knopf um fortzufahren...");
            Console.ReadKey();
        }

        public static int FindTitle(Array arr)
        {
            Console.WriteLine("Bitte geben Sie den Titel des ToDos ein:");
            int index;
            while (true)
            {
                try
                {
                    index = Array.IndexOf(arr, Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Fehlerhafte Eingabe. Bitte geben Sie einen gültigen Titel ein.");
                }
            }
            return index;
        }

        public static string[] RemoveStringItem(string[] arr, int[] numArray, int numArrayIndex)
        {
            // folgendes Codesnippet wurde kopiert  und angepasst
            // quelle: https://www.techiedelight.com/remove-specified-element-from-array-csharp///

            List<string> arrList = new List<string>(arr);
            arrList.RemoveAt(arrList.IndexOf(arr[numArray[numArrayIndex]]));
            arr = arrList.ToArray();
            return arr;
        }

        public static DateTime[] RemoveDateTimeItem(DateTime[] arr, int[] numArray, int numArrayIndex)
        {
            // folgendes Codesnippet wurde kopiert  und angepasst
            // quelle: https://www.techiedelight.com/remove-specified-element-from-array-csharp///

            List<DateTime> arrList = new List<DateTime>(arr);
            arrList.RemoveAt(arrList.IndexOf(arr[numArray[numArrayIndex]]));
            arr = arrList.ToArray();
            return arr;
        }

        public static int[] RemoveIntItem(int[] arr, int[] numArray, int numArrayIndex)
        {
            // folgendes Codesnippet wurde kopiert  und angepasst
            // quelle: https://www.techiedelight.com/remove-specified-element-from-array-csharp///

            List<int> arrList = new List<int>(arr);
            arrList.RemoveAt(arrList.IndexOf(arr[numArray[numArrayIndex]]));
            arr = arrList.ToArray();
            return arr;
        }

        // folgende Funktion wurde kopiert
        // quelle: https://www.codeproject.com/Questions/577703/Howplustopluscheckplusduplicatesplusinplusstringpl
        public static bool CheckForDuplicates(string[] array)
        {
            var duplicates = array
             .GroupBy(p => p)
             .Where(g => g.Count() > 1)
             .Select(g => g.Key);


            return (duplicates.Count() > 0);
        }

        public static bool CheckForValuePresence(string[] arr)
        {
            if (arr.All(y => y == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}