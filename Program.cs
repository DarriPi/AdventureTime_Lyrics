using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;
using MusicPlayerLib;

namespace Just_a_random_for_a_song
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            // make tv and play
            MusicPlayer player = new MusicPlayer();
            TV tv = new TV();

            // Display the title
            tv.Play("Adventure", "Time", 3);

            player.Play("Music/Island Song (Come Along with Me) (feat. Ashley Eriksson).mp3");
            tv.SetDelayTime(150);
            tv.Play(MakeLines());
            player.Stop();


            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
        //static List<string> ReadTextScenes(string path) 
        //{
        //    List<string> result = new List<string>();
        //    string text = "";
        //    foreach (string line in File.ReadLines(path))
        //    {
        //        if (line != "===")
        //        {
        //            text += "\n" + line;
        //        }// then add line
        //        else
        //        {
        //            result.Add(text);
        //            text = "";
        //        } // add to the list
        //    } // read lines
        //    return result;
        //}

        private static List<Tuple<string, string, int>> MakeLines() 
        {
            List<Tuple<string, string, int>> result = new List<Tuple<string, string, int>>();

            result.Add(new Tuple<string, string, int>("Come along", "with me", 4500));
            result.Add(new Tuple<string, string, int>("And the", "butterflies", 2500));
            result.Add(new Tuple<string, string, int>("and BEES", "<(||)''", 2500));
            result.Add(new Tuple<string, string, int>("We can wander", "through the", 2000));
            result.Add(new Tuple<string, string, int>("   FOREST", "*************", 1750));
            result.Add(new Tuple<string, string, int>("And do so", "as we please", 3500));
            result.Add(new Tuple<string, string, int>("Come along", "with me", 4000));
            result.Add(new Tuple<string, string, int>("To a cliff", "under a tree", 3500));
            result.Add(new Tuple<string, string, int>("Where we can", "gaze upon", 2000));
            result.Add(new Tuple<string, string, int>("THE WATER", "~~~~~~~~~~~~~", 2000));
            result.Add(new Tuple<string, string, int>("As an", "everlasting", 1750));
            result.Add(new Tuple<string, string, int>("   DREAM", "*.*.*.*.*.*.*", 3000));
            result.Add(new Tuple<string, string, int>("All of my", "collections", 3000));
            result.Add(new Tuple<string, string, int>("I'll share", "them all", 2000));
            result.Add(new Tuple<string, string, int>("   WITH YOU", "<3<3<3", 2200));
            result.Add(new Tuple<string, string, int>("Maybe by", "next summer", 3000));
            result.Add(new Tuple<string, string, int>("We won't", "have changed", 3000));
            result.Add(new Tuple<string, string, int>("  OUR TUNES", "\\(OcO)/", 2000));
            result.Add(new Tuple<string, string, int>("We'll still", "want to be", 3000));
            result.Add(new Tuple<string, string, int>("With the", "butterflies", 2500));
            result.Add(new Tuple<string, string, int>("and BEES", "<(||)''", 1500));
            result.Add(new Tuple<string, string, int>("Making up", "new numbers", 3000));
            result.Add(new Tuple<string, string, int>("And living", "so merrily", 4500));
            result.Add(new Tuple<string, string, int>("All of my", "collections", 4500));
            result.Add(new Tuple<string, string, int>("I'll share", "them all", 2750));
            result.Add(new Tuple<string, string, int>("  WITH YOU", "<3<3<3)", 1500));
            result.Add(new Tuple<string, string, int>("I'll be here", "for you", 2750));
            result.Add(new Tuple<string, string, int>("ALWAYS", "(INFINITY)", 2000));
            result.Add(new Tuple<string, string, int>("And always", "be with you", 4000));
            result.Add(new Tuple<string, string, int>("Come along", "with me", 3500));
            result.Add(new Tuple<string, string, int>("And the", "butterflies", 1700));
            result.Add(new Tuple<string, string, int>("and BEES", "<(||)''", 1700));
            result.Add(new Tuple<string, string, int>("We can wander", "through the", 1700));
            result.Add(new Tuple<string, string, int>("  FOREST", "*************", 1700));
            result.Add(new Tuple<string, string, int>("And do so", "as we please", 2000));
            result.Add(new Tuple<string, string, int>("And living", "so merrily", 10000));

            return result;
        } // will add the lines of the song I wish to play
    }
}
