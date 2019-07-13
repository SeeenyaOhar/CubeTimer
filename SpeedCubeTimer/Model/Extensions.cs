using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerCode.Code;
using System.Windows.Media;
using System.Windows.Controls;
using SpeedCubeTimer.Model;

namespace SpeedCubeTimer
{
    internal static class Extensions
    {
        internal static Brush ConvertToBrush(this CEC c)
        {
            switch (c)
            {
                case CEC.Blue: return Brushes.Blue;
                case CEC.Green: return Brushes.Green;
                case CEC.Orange: return Brushes.Orange;
                case CEC.Red: return Brushes.Red;
                case CEC.White: return Brushes.White;
                case CEC.Yellow: return Brushes.Yellow;
                default: return null;
            }
        }

        internal static async Task SendToDBAsync(this Time time)
        {
            //await Task.Run(()=> { DBControl.InsertSolved(time); });
        }
        public static Scramble ToString(this String parsestring)
        {
            var v = parsestring.Split(' ');
            var se = new List<ScrambleElements>();
            for(int i = 0; i < v.Length; i++)
            {
                se.Add(Scramble.Replace(v[1]));
            }
            return new Scramble(se.ToArray());
        }
        public static Time ToTime(this String str, Scramble scramble, User user)
        {
            StateOfTime sot = StateOfTime.Default;
            int milliseconds = 0;
            short seconds = 0;
            short minutes = 0;
            short hours = 0;
            
            if (str.Contains("DNF"))
            {
                sot = StateOfTime.DNF;
                var inthebrackets = str.Split('(');
                inthebrackets = str.Split(new[] { ')' },StringSplitOptions.RemoveEmptyEntries);
                str = inthebrackets[0];
            }
            if (str.Contains("+"))
            {
                sot = StateOfTime.SEC2;
            }
            var split = str.Split(':');

            if (split.Count() == 1) // "2.2" - there are no ':'
            {
                String secs = split[0]; // getting seconds
                split = secs.Split('.');
                milliseconds = Convert.ToInt32(split[1]); // getting seconds - "2.2" - seconds 2 means milliseconds
                seconds = Convert.ToInt16(split[0]);
            }
            else if (split.Count() == 2)
            {
                String secs = split[1]; // getting seconds
                String s_minutes = split[0];
                minutes = Int16.Parse(s_minutes);

                split = secs.Split('.');
                milliseconds = Convert.ToInt32(split[1]); // getting seconds - "2.2" - seconds 2 means milliseconds
                seconds = Convert.ToInt16(split[0]);
            }
            else if(split.Count() == 3)
            {
                String secs = split[2]; // getting seconds
                String s_minutes = split[1];
                minutes = Int16.Parse(s_minutes);

                String s_hours = split[0];
                hours = Int16.Parse(s_hours);

                split = secs.Split('.');
                milliseconds = Convert.ToInt32(split[1]); // getting seconds - "2.2" - seconds 2 means milliseconds
                seconds = Convert.ToInt16(split[0]);
            }
            Time time = new Time(hours, minutes, seconds, milliseconds, scramble); //, user
            time.SOT = sot;
            return time;
        }
    }
    
}
