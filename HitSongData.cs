using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top100_Kovács_Péter
{
    internal class HitSongData
    {
        public string Performer { get; private set; }
        public string Name { get; private set; }
        public int Rank { get; private set; }
        public int Year { get; private set; }
        public string Publisher { get; private set; }
        public int Listeners { get; private set; }

        public HitSongData(string performer, string name, int rank, int year, string publisher, int listeners)
        {
            Performer = performer ?? throw new ArgumentNullException(nameof(performer));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Rank = rank;
            Year = year;
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            Listeners = listeners;
        }

        public int GetPoint()
        {
            if (Rank < 21)
            {
                return (101 - Rank) * 2;
            }
            return 101 - Rank;
        }
    }
}
