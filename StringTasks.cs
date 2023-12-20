using MySchoolUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top100_Kovács_Péter
{
    internal class StringTasks
    {
        static Random random = new Random();
        public char[] musicStyles = {'A', 'B', 'C', 'D', 'E'};
        public void Task1()
        {
            Utils.Printl("\n--- STRING FELADATOK ---\n", ConsoleColor.Blue);
            Utils.Printl("-- 1.Feladat --", ConsoleColor.Green);
            Utils.Print("Írd be, hány óra zenei stílusát szeretéd legenerálni: ");
            int hours = Convert.ToInt16(Utils.GetInputString());
            string styles = "";
            for (int i = 0; i < hours; i++)
            { 
                for (int j = 0; j < 4; j++)
                {
                    styles += $"{musicStyles[random.Next(0, musicStyles.Length)]}";
                }
                styles += "\n";
            }
            Utils.Print(styles, ConsoleColor.DarkBlue);
            Utils.Printl($"");
        }


        public void Task2()
        {
            Utils.Printl("-- 2.Feladat --", ConsoleColor.Green);
            Utils.Print("Írj be egy zeneszám címet: ");
            string name = Utils.GetInputString();
            int charNum = name.Length;
            int accaptedChars = 0;
            foreach (char c in name)
            {
                if (char.IsUpper(c) || char.IsNumber(c) || c == '-')
                {
                    accaptedChars++;
                }
            }

            if (accaptedChars < charNum)
            {
                Utils.Printl($"HIBA {accaptedChars}", ConsoleColor.Red);
                double percentage = Math.Round(100.0 * accaptedChars / charNum, 2);
                Utils.Printl($"Hibás karakterek aránya a bevitt karakterekhez képest: {percentage}%");
            }
            else
            {
                Utils.Printl($"Helyes formátumú cím!", ConsoleColor.Green);
            }
        }
    }
}
