using MySchoolUtils;

namespace Top100_Kovács_Péter
{
    internal class Program
    {
        public static HitSongData[] songs;

        static void Main(string[] args)
        {
            songs = ReadFromFile("slager.txt");
            Tasks tasks = new Tasks();
            tasks.Task3();
            tasks.Task4();
            tasks.Task5("Universal Music");
            tasks.Task7();
            tasks.Task8();

            StringTasks stringTasks = new StringTasks();
            stringTasks.Task1();
            stringTasks.Task2();
        }

        static HitSongData[] ReadFromFile(string path)
        {
            List<HitSongData> list = new List<HitSongData>();

            using(FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fileStream))
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    { 
                        var dataList = line.TrimEnd().Split(';');
                        list.Add(new HitSongData(dataList[0], dataList[1], Convert.ToInt16(dataList[2]), Convert.ToInt16(dataList[3]), dataList[4], Convert.ToInt32(dataList[5])));
                    }
                }
            }
            return list.ToArray();
        }
    }
}
