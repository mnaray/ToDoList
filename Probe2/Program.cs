using System;

namespace Probe2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ToDo-Liste";
            Console.WriteLine("Willkommen in Ihrem persönlichen ToDo-Planer.");
            Personal_Library.Startmenu();

            int todoMenge = -1;
            int archGrösse = -1;
            int rmMenge = 0;
            string zwischenspeicher;
            string[] titel = new string[0];
            string[] beschreibung = new string[0];
            DateTime[] fälligkeit = new DateTime[0];
            int[] prioritäten = new int[0];
            int[] archiviertIndex = new int[0];
            string[] archiviertTitel = new string[0];
            int[] rmIndex = new int[1];

            string command;


            bool exit = false;
            while (exit == false)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "exit":
                        exit = true;
                        break;

                    case "new todo":
                        todoMenge++;
                        Array.Resize(ref titel, todoMenge + 1);
                        Array.Resize(ref beschreibung, todoMenge + 1);
                        Array.Resize(ref fälligkeit, todoMenge + 1);
                        Array.Resize(ref prioritäten, todoMenge + 1);

                        while (true)
                        {
                            try
                            {
                                titel[todoMenge] = Personal_Library.NewToDo("den Titel (max. 25 Char.)");
                                if (Personal_Library.CheckForDuplicates(titel) || titel[todoMenge].Length > 25)
                                {
                                    titel[todoMenge] = null;
                                    throw new Exception();
                                }
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Dieser Titel ist nicht verfügbar oder zu lang.");
                            }
                        }

                        while (true)
                        {
                            try
                            {
                                beschreibung[todoMenge] = Personal_Library.NewToDo("die Beschreibung (max. 200 Char.)");
                                if (beschreibung[todoMenge].Length > 200)
                                {
                                    beschreibung[todoMenge] = null;
                                    throw new Exception();
                                }
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Diese Beschreibung ist zu lang.");
                            }
                        }

                        while (true)
                        {
                            try
                            {
                                fälligkeit[todoMenge] = DateTime.Parse(Personal_Library.NewToDo("die Fälligkeit (TT.MM.JJJJ)"));
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Fehlerhafte Eingabe. Bitte geben Sie ein korrektes Datum ein.");
                            }
                        }

                        while (true)
                        {
                            try
                            {
                                prioritäten[todoMenge] = Int32.Parse(Personal_Library.NewToDo("die Priorität (1, 2 oder 3)"));
                                if (prioritäten[todoMenge] < 1 || prioritäten[todoMenge] > 3)
                                {
                                    throw new Exception();
                                }
                                break;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Fehlerhafte Eingabe. Bitte geben Sie entweder 1, 2 oder 3 ein.");
                            }
                        }

                        Console.WriteLine("ToDo erfolgreich hinzugefügt.");
                        Personal_Library.PressToContinue();
                        break;

                    case "print":
                        if (Personal_Library.CheckForValuePresence(titel))
                        {
                            string[] titelNeu = new string[titel.Length];
                            string[] beschreibungNeu = new string[beschreibung.Length];
                            DateTime[] fälligkeitNeu = new DateTime[fälligkeit.Length];
                            int[] prioritätenNeu = new int[prioritäten.Length];

                            for (int i = 0; i < fälligkeit.Length; i++)
                            {
                                fälligkeitNeu[i] = fälligkeit[i];
                            }

                            Array.Sort(fälligkeitNeu);

                            for (int i = 0; i < fälligkeit.Length; i++)
                            {
                                titelNeu[i] = titel[Array.IndexOf(fälligkeitNeu, fälligkeit[i])];
                                beschreibungNeu[i] = beschreibung[Array.IndexOf(fälligkeitNeu, fälligkeit[i])];
                                prioritätenNeu[i] = prioritäten[Array.IndexOf(fälligkeitNeu, fälligkeit[i])];
                            }

                            Console.WriteLine("**********************************************");
                            for (int i = 0; i < titelNeu.Length; i++)
                            {
                                Console.WriteLine(titelNeu[i] + "\n" + beschreibungNeu[i] + "\n" + fälligkeitNeu[i] + "\n" + prioritätenNeu[i]);
                                Console.WriteLine("**********************************************");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Es sind noch keine ToDos vorhanden.");
                        }

                        Personal_Library.PressToContinue();
                        break;

                    case "description":
                        if (Personal_Library.CheckForValuePresence(titel))
                        {
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(beschreibung[Personal_Library.FindTitle(titel)]);
                            Console.WriteLine("**********************************************");
                        }
                        else
                        {
                            Console.WriteLine("Es sind noch keine ToDos vorhanden.");
                        }

                        Personal_Library.PressToContinue();
                        break;

                    case "archive":
                        if (Personal_Library.CheckForValuePresence(titel))
                        {
                            archGrösse++;
                            Array.Resize(ref archiviertIndex, archiviertIndex.Length + 1);
                            Array.Resize(ref archiviertTitel, archiviertTitel.Length + 1);
                            archiviertIndex[archGrösse] = Personal_Library.FindTitle(titel);
                            archiviertTitel[archGrösse] = titel[archiviertIndex[archGrösse]];

                            titel = Personal_Library.RemoveStringItem(titel, archiviertIndex, archGrösse);
                            beschreibung = Personal_Library.RemoveStringItem(beschreibung, archiviertIndex, archGrösse);
                            fälligkeit = Personal_Library.RemoveDateTimeItem(fälligkeit, archiviertIndex, archGrösse);
                            prioritäten = Personal_Library.RemoveIntItem(prioritäten, archiviertIndex, archGrösse);

                            Console.WriteLine("ToDo wurde archiviert.");
                        }
                        else
                        {
                            Console.WriteLine("Es sind noch keine ToDos vorhanden.");
                        }

                        Personal_Library.PressToContinue();
                        break;

                    case "rm":
                        if (Personal_Library.CheckForValuePresence(titel))
                        {
                            Array.Resize(ref rmIndex, rmMenge + 1);
                            rmIndex[rmMenge] = Personal_Library.FindTitle(titel);

                            titel = Personal_Library.RemoveStringItem(titel, rmIndex, rmMenge);
                            beschreibung = Personal_Library.RemoveStringItem(beschreibung, rmIndex, rmMenge);
                            fälligkeit = Personal_Library.RemoveDateTimeItem(fälligkeit, rmIndex, rmMenge);
                            prioritäten = Personal_Library.RemoveIntItem(prioritäten, rmIndex, rmMenge);

                            todoMenge--;

                            Console.WriteLine("ToDo wurde gelöscht.");
                        }
                        else
                        {
                            Console.WriteLine("Es sind noch keine ToDos vorhanden.");
                        }
                        Personal_Library.PressToContinue();
                        break;

                    case "edit": //todo
                        if (Personal_Library.CheckForValuePresence(titel))
                        {
                            Console.WriteLine("Geben Sie den Titel des ToDos ein, welches Sie bearbeiten möchten: ");
                            int zuBearbeiten = Personal_Library.FindTitle(titel);

                            bool editModeOn = true;
                            while (editModeOn)
                            {
                                Personal_Library.Editmenu();
                                string editWahl = Console.ReadLine().ToLower();

                                switch (editWahl)
                                {
                                    case "titel":
                                        Console.WriteLine($"Titel alt:\n{titel[zuBearbeiten]}\nTitel neu:");
                                        while (true)
                                        {
                                            try
                                            {
                                                zwischenspeicher = titel[zuBearbeiten];
                                                titel[zuBearbeiten] = Console.ReadLine();
                                                if (Personal_Library.CheckForDuplicates(titel) || titel[zuBearbeiten].Length > 25)
                                                {
                                                    titel[todoMenge] = zwischenspeicher;
                                                    throw new Exception();
                                                }
                                                Console.WriteLine("Titel wurde erfolgreich geändert.");
                                                break;
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Dieser Titel ist nicht verfügbar oder zu lang.");
                                                Console.WriteLine("Titel neu:");
                                            }
                                        }

                                        Personal_Library.PressToContinue();
                                        break;

                                    case "beschreibung":
                                        Console.WriteLine($"Die alte Beschreibung von {titel[zuBearbeiten]} wird für immer gelöscht, wenn Sie jetzt fortfahren!!!");

                                        while (true)
                                        {
                                            Console.WriteLine("Wollen Sie fortfahren? [y|n]");
                                            try
                                            {
                                                char uInput = char.Parse(Console.ReadLine());
                                                if (uInput == 'y')
                                                {
                                                    Console.WriteLine("**********************************************");
                                                    Console.WriteLine("Geben Sie hier Ihre neue Beschreibung ein: ");
                                                    while (true)
                                                    {
                                                        try
                                                        {
                                                            zwischenspeicher = beschreibung[zuBearbeiten];
                                                            beschreibung[zuBearbeiten] = Console.ReadLine();
                                                            if (beschreibung[zuBearbeiten].Length > 200)
                                                            {
                                                                beschreibung[zuBearbeiten] = zwischenspeicher;
                                                                throw new Exception();
                                                            }
                                                            break;
                                                        }
                                                        catch (Exception)
                                                        {
                                                            Console.WriteLine("Diese Beschreibung ist zu lang.");
                                                            Console.WriteLine("Geben Sie hier Ihre neue Beschreibung ein: ");
                                                        }
                                                    }
                                                    Console.WriteLine("Beschreibung wurde erfolgreich geändert.");
                                                    Console.WriteLine("**********************************************");
                                                    break;
                                                }
                                                if (uInput == 'n')
                                                {
                                                    Console.WriteLine("Beschreibung wurde nicht geändert.");
                                                    break;
                                                }
                                                else
                                                {
                                                    throw new Exception();
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Fehlerhafte Eingabe.");
                                            }
                                        }

                                        Personal_Library.PressToContinue();
                                        break;

                                    case "fälligkeit":
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Geben Sie hier die neue Fälligkeit ein:");
                                                fälligkeit[zuBearbeiten] = DateTime.Parse(Console.ReadLine());
                                                Console.WriteLine("Fälligkeit wurde erfolgreich geändert.");
                                                break;
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Fehlerhafte Eingabe. Bitte geben Sie ein korrektes Datum ein.");
                                            }
                                        }

                                        Personal_Library.PressToContinue();
                                        break;

                                    case "prioritäten":
                                        while (true)
                                        {
                                            try
                                            {
                                                Console.WriteLine("Geben Sie hier die neue Priorität ein:");
                                                prioritäten[zuBearbeiten] = Int32.Parse(Console.ReadLine());
                                                if (prioritäten[zuBearbeiten] < 1 || prioritäten[zuBearbeiten] > 3)
                                                {
                                                    throw new Exception();
                                                }
                                                Console.WriteLine("Priorität wurde erfolgreich geändert.");
                                                break;
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Fehlerhafte Eingabe. Bitte geben Sie entweder 1, 2 oder 3 ein.");
                                            }
                                        }

                                        Personal_Library.PressToContinue();
                                        break;

                                    case "done":
                                        editModeOn = false;
                                        break;


                                    default:
                                        Console.WriteLine("Fehlerhafte Eingabe. Bitte nur Titel, Beschreibung, Fälligkeit oder Prioritäten eingeben.");
                                        Personal_Library.PressToContinue();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Es sind noch keine ToDos vorhanden.");
                        }

                        Personal_Library.PressToContinue();
                        break;

                    case "print archive":
                        if (Personal_Library.CheckForValuePresence(archiviertTitel))
                        {
                            Console.WriteLine("**********************************************");
                            foreach (var item in archiviertTitel)
                            {
                                Console.WriteLine("- " + item);
                            }
                            Console.WriteLine("**********************************************");
                        }
                        else
                        {
                            Console.WriteLine("Es sind noch keine ToDos im Archiv.");
                        }

                        Personal_Library.PressToContinue();
                        break;

                    case "save": //todo
                        Console.WriteLine("Dieser Befehl ist noch in Bearbeitung!!!\nHoffentlich wird 'save' in der nächsten Version (Falls es eine gibt...) funktionieren :)");

                        Personal_Library.PressToContinue();
                        break;


                    default:
                        Console.WriteLine("Fehlerhafte Eingabe. Bitte verwenden Sie nur die obigen Befehle.");
                        Personal_Library.PressToContinue();
                        break;
                }

                if (command != "exit")
                {
                    Personal_Library.Startmenu();
                }
            }
        }
    }
}