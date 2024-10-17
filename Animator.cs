using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Just_a_random_for_a_song
{
    class TV
    {
        // class members
        Stopwatch watch;
        List<string> tv;
        List<string> MessageTv;
        int Delay = 175;

        // Constructor
        public TV()
        {
            watch = new Stopwatch();
            MessageTv = ReadTextScenes("Text_Art\\Tv_Static\\Static_Slide_1.txt");

            this.tv = new List<string>();
            foreach (var item in MessageTv)
            {
                this.tv.Add(Regex.Replace(item, "~~~~~~~~~~~~~|#############", "             "));
            }
        } //tv

        public void Play() 
        {
            int index = 0;
            while (true)
            {
                Console.Clear();
                // sleep one second
                
                if (index < tv.Count)
                {
                    Console.WriteLine(tv[index]);
                }
                else
                {
                    index = 0;
                    Console.WriteLine(tv[index]);
                }
                index++;
                Thread.Sleep(Delay);
            } /// animate forever
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg">Message must be 13 or less characters long.</param>
        public void Play(string msg) 
        {
            int index = 0;
            while (true)
            {
                Console.Clear();
                // sleep one second
                if (index < tv.Count)
                {
                    DisplayMessageOnScreen(msg, index);
                }
                else
                {
                    index = 0;
                    DisplayMessageOnScreen(msg, index);
                }
                index++;
                Thread.Sleep(Delay);
            } /// animate forever
        }
        // helper method for playing a message
        private void DisplayMessageOnScreen(string msg, int index) 
        {
            msg = CheckString(msg);
            msg = InsertTVOne(msg, index);
            msg = InsertTVTwo("             ", msg, index);
            Console.WriteLine(msg);
        } // display msg on screen

        // play for two lines
        public void Play(string line1, string line2, int time) 
        {
            Console.CursorVisible = false;
            int index = 0;

            watch.Start();
            while (watch.ElapsedMilliseconds < time)
            {
                Console.Clear();
                // sleep one second
                if (index < tv.Count)
                {
                    DisplayOnBothLines(line1, line2, index);
                }
                else
                {
                    index = 0;
                    DisplayOnBothLines(line1, line2, index);
                }
                index++;
                Thread.Sleep(Delay);
            } /// animate forever
            watch.Stop();
            watch.Reset();
            Console.CursorVisible = true;
        } // write on both lines
        private void DisplayOnBothLines(string msg1, string msg2, int index) 
        {
            string result = "";
            msg1 = CheckString(msg1);
            msg2 = CheckString(msg2);
            result = InsertTVOne(msg1, index);
            result = InsertTVTwo(msg2, result, index);
            Console.WriteLine(result);
        } // will display on both lines

        /// <summary>
        /// Will allow you to play lines and lines of songs using 
        /// a list of tuples Item1, is the line and item2 the time to display
        /// </summary>
        /// <param name="lines">Provide a lit of tuples with the line and length to play in miliseconds</param>
        public void Play(List<Tuple<string, string, int>> lines) 
        {
            Console.CursorVisible = false; // make cursor temporary hidden
            int index = 0;
            int linesIndex = 0;
            while (linesIndex < lines.Count)
            {
                watch.Start();
                Console.Clear();
                // sleep one second
                if (watch.ElapsedMilliseconds < lines[linesIndex].Item3)
                {
                    if (index < tv.Count)
                    {
                        DisplayOnBothLines(lines[linesIndex].Item1, lines[linesIndex].Item2, index);
                    }
                    else
                    {
                        index = 0;
                        DisplayOnBothLines(lines[linesIndex].Item1, lines[linesIndex].Item2, index);
                    }
                    index++;
                } // only display and increment if the time elapsed
                else
                {
                    if (index < tv.Count)
                    {
                        DisplayOnBothLines(lines[linesIndex].Item1, lines[linesIndex].Item2, index);
                    }
                    else
                    {
                        index = 0;
                        DisplayOnBothLines(lines[linesIndex].Item1, lines[linesIndex].Item2, index);
                    }
                    watch.Stop();
                    watch.Reset();
                    linesIndex++;
                    index++;
                }  // increment the linesIndex as while
                Thread.Sleep(Delay); // make cursor visible
            } /// animate forever
            Console.CursorVisible = true;
        } // will play with the message 


        // will simply set display time
        public void SetDelayTime(int time) 
        {
            Delay = time;
        } // set delay time

        // private helper methods
        private string InsertTVTwo(string msg, string tv, int index)
        {
            string result = tv;
            result = Regex.Replace(result, "#############", msg);
            return result;
        }//  will insert the messages in the right
        private string InsertTVOne(string msg, int index) 
        {
            string result = MessageTv[index];
            result = Regex.Replace(result, "~~~~~~~~~~~~~", msg);
            return result;
        }//  will insert the messages in the right
        private string CheckString(string msg) 
        {
            if (msg.Length == 13)
            {
                return msg;
            } // return if correct length

            if (msg.Length > 13) 
            {
                return "Invalid...";
            } // invalid string

            int count = msg.Length;
            while (count < 13)
            {
                msg += " ";
                count++;
            } // add the other characters to fulfill 13 rule

            return msg;
        }// make sure it has 13 characters
        private List<string> ReadTextScenes(string path)
        {
            List<string> result = new List<string>();
            string text = "";
            foreach (string line in File.ReadLines(path))
            {
                if (line != "===")
                {
                    text += "\t\t\t\t" + line + "\n";
                }// then add line
                else
                {
                    result.Add(text);
                    text = "";
                } // add to the list
            } // read lines
            return result;
        }
    } // will simply loop through a string of 
}
