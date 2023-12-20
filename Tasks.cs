using MySchoolUtils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top100_Kovács_Péter
{
    internal class Tasks
    {
        public void Task3()
        {
            ConcurrentStack<HitSongData> hits = new(); 
            Utils.Printl($"-- 3.Feladat --", ConsoleColor.Green);
            Utils.Printl($"Az eltárolt zenék száma: {Program.songs.Length}");
            Parallel.ForEach(Program.songs, (song) => {
            if (song.Listeners > 200000)
            {
                hits.Push(song);
            }
            });
            Utils.Printl($"200 000 feletti hallgatószámú zenék: {hits.Count} db");
            Utils.Printl("");
        }

        public void Task4()
        {
            Utils.Printl($"-- 4.Feladat --", ConsoleColor.Green);
            ConcurrentStack<HitSongData> hits = new();
            int firstYear = Program.songs.Min(song => song.Year);
            Parallel.ForEach(Program.songs, (song) =>
            {
                if (song.Year == firstYear)
                {
                    hits.Push(song);
                }
            });
            Utils.Printl($"Első év: {firstYear}");
            Utils.Printl($"Ezen évben megjelent számok:");
            foreach (var song in hits)
            {
                Utils.Printl($"\t{song.Performer}: {song.Name}");
            }
            Utils.Printl("");
        }

        public void Task5(string publisher)
        {
            Utils.Printl($"-- 5.Feladat --", ConsoleColor.Green);
            var avgRank = Math.Round(Program.songs.Where(song => song.Publisher == publisher).Average(song => song.Rank));
            var avgListeners = Math.Round(Program.songs.Where(song => song.Publisher == publisher).Average(song => song.Listeners));
            Utils.Printl($"A(z) {publisher} kiadó számainak:");
            Utils.Printl($"\tátlagos helyezése: {avgRank}");
            Utils.Printl($"\tátlagos hallagtószáma: {avgListeners}");
            Utils.Printl("");
        }

        public void Task7()
        {
            Utils.Printl($"-- 7.Feladat --", ConsoleColor.Green);
            var orderedList = Program.songs.OrderByDescending(song => song.Listeners);
            HitSongData mostListened = orderedList.First();
            HitSongData leastListened = orderedList.Last();
            double averageListeners = Program.songs.Average(song => song.Listeners);
            double mostListenedDifference = Math.Round((100.0 * mostListened.Listeners / averageListeners) - 100);
            double leastListenedDifference = Math.Round((100.0 * leastListened.Listeners / averageListeners) - 100);
            Utils.Printl($"A legtöbbet hallgatott szám: {mostListened.Name}, átlagtól való eltérés százalékban: +{mostListenedDifference}%");
            Utils.Printl($"A legkevesebbet hallgatott szám: {leastListened.Name}, átlagtól való eltérés százalékban: {leastListenedDifference}%");
            Utils.Printl("");

        }

        public void Task8()
        {
            Utils.Printl($"-- 8.Feladat --", ConsoleColor.Green);
            Utils.Print("Írd be az egyik előadó nevét: ");
            string performer = Utils.GetInputString();
            try
            {
                HitSongData[] byPerformer = Program.songs.Where(song => song.Performer == performer).ToArray();
                if ( byPerformer.Length > 0 )
                {
                    List<int> points = new List<int>();
                    using (FileStream fileStream = new FileStream($"{performer}.txt", FileMode.OpenOrCreate))
                    {
                        using (StreamWriter writer = new StreamWriter(fileStream))
                        {
                            foreach (HitSongData song in byPerformer)
                            {
                                int point = song.GetPoint();
                                points.Add(point);
                                writer.WriteLine($"{song.Performer};{song.Name};{song.Rank};{song.Year};{song.Publisher};{song.Listeners};{point}");
                            }

                            writer.WriteLine($"{byPerformer.Length}, {Math.Round(points.Average())}");

                        }
                    }
                    Utils.Printl("Sikeres fájlbaírás!", ConsoleColor.Green);
                }
            }
            catch (Exception e)
            {

                Utils.Printl($"Sikertelen fájlbaírás! ({e.Message})", ConsoleColor.Red);
            }
        }
    }
}
