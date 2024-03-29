﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
namespace TimerCode.Code
{
    public enum StateOfTime
    {
        Default, SEC2, DNF
    }

    public class CubingTimer
    {
        public Time LastTimeSolved { get; private set; } = null;
        private Task timertask = null;
        Scramble scramble;
        public Boolean IsTimerWorking { get; set; } = false; // thread safe property :)
        //private User user;

        // <summary
        // <param name="user">The user, who is going to solve a puzzle. </param>
        // </summary>
        public CubingTimer() //User user
        {
            //this.user = user;
            CurrentTime = new Time(new Scramble()); // , user
        }

        public Time CurrentTime { get; private set; } 
        public event EventHandler<TimerStartedEventArgs> Started; // Started means that 2 seconds after CubingTimer.Start(string)
        public event EventHandler<TimerStopedEventArgs> TimerStoped;


        public void LoadScramble(Scramble scramble)
        {
            this.scramble = scramble;
            CurrentTime = new Time(scramble); //, user
        }
        public void Start()
        {

            if (Started != null)
                Started(this, new TimerStartedEventArgs());
            IsTimerWorking = true;

            timertask =
                Task.Run(() =>
            {
                while (IsTimerWorking)
                {
                    Thread.Sleep(8); // do not work properly
                    CurrentTime.AddMiliseconds(10);

                }
            }
            );
        }
        
        public void Stop()
        {
            IsTimerWorking = false;
            
            LastTimeSolved = CurrentTime;
            CurrentTime = new Time(scramble); // , user
            LastTimeSolved.AddToHistoryThis();
            if (TimerStoped != null) TimerStoped(this, new TimerStopedEventArgs(CurrentTime));
        }
        
    }
    public class TimerStartedEventArgs : EventArgs { }
    public class TimerStopedEventArgs : EventArgs
    {
        public TimerStopedEventArgs(Time timeSolved)
        {
            TimeSolved = timeSolved ?? throw new ArgumentNullException(nameof(timeSolved));
        }

        public Time TimeSolved { get; private set; }
    }
    [Serializable] 
    public class Time
    {
        private StateOfTime sot = StateOfTime.Default;
        public StateOfTime SOT { get { return sot; } set
            {
                if (value == StateOfTime.SEC2 & sot != StateOfTime.SEC2)
                {
                    Seconds += 2;
                    sot = value;
                }
                if (sot == StateOfTime.SEC2 & value == StateOfTime.Default)
                {
                    Seconds -= 2;
                    sot = value;
                }
                sot = value;
            }
        } 
        public static List<Time> History = new List<Time>();
        //public User UserSolved { get; private set; }
        public Scramble scramble { get; private set; }
        public String Scramble { get; private set; }
        public Scramble ScrambleScramble { get; private set; }
        private short _hours = 0;
        private short _minutes = 0;
        private short _seconds = 0;
        private int _miliseconds = 0;
        public short Hours { get => _hours;
            internal set
            {
                _hours = value;

            } }
        public short Minutes { get => _minutes; internal set
            {
                _minutes = value;
                if (_minutes >= 60)
                {
                    Hours++;
                    _minutes = 0;
                }
            } }
        public short Seconds { get => _seconds; internal set
            {
                _seconds = value;
                if (_seconds >= 60)
                {
                    Minutes++;
                    _seconds = 0;
                }
            } }
        public int Miliseconds { get => _miliseconds; internal set
            {
                _miliseconds = value;
                if (_miliseconds >= 1000)
                {
                    Seconds++;
                    _miliseconds = 0;
                }
            } }
        public Time(short hours, short minutes, short seconds, int miliseconds, Scramble scramble) //, User usersolved
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.Miliseconds = miliseconds;
            this.scramble = scramble;
            
            Scramble = this.scramble.ToString();
            //UserSolved = usersolved;
            //MessageBox.Show(Scramble);
        }
        public void AddMiliseconds(short miliseconds)
        {
            Miliseconds += miliseconds;

            
            if (Miliseconds >= 1000)
            {
                Seconds++;
                miliseconds = 0;
            }
            if (Seconds >= 60)
            {
                Minutes++;
                Seconds = 0;
            }
            if (Minutes >= 60)
            {
                Hours++;
                Minutes = 0;
            }

            Handlers.TimeChangedInvoke();
            
        }
       
        public Time(Scramble scramble)  // User usersolved
        {
            this.scramble = scramble;
            //UserSolved = usersolved;
            Scramble = this.scramble.ToString();
            
        }
        public void AddToHistoryThis()
        {
              History.Add(this);
        }
        public override string ToString()
        {
            if(sot == StateOfTime.DNF)
            {
                String str = "DNF(";
                if (Hours == 0 & Minutes != 0)
                {
                    str = str + $"{Minutes}:{Seconds}.{Miliseconds})";
                    return str;
                }
                if (Hours == 0 & Minutes == 0)
                {
                    str = str + $"{Seconds}.{Miliseconds})";
                    return str;
                }
            }
            if (sot == StateOfTime.SEC2)
            {
                if (Hours == 0 & Minutes != 0)
                {
                    return $"{Minutes}:{Seconds}.{Miliseconds}+";
                }
                if (Hours == 0 & Minutes == 0)
                {
                    return $"{Seconds}.{Miliseconds}+";
                }
                return $"{Hours}:{Minutes}:{Seconds}.{Miliseconds}+";
            }
            if (Hours == 0 & Minutes != 0)
            {
                return $"{Minutes}:{Seconds}.{Miliseconds}";
            }
            if (Hours == 0 & Minutes == 0)
            {
                return $"{Seconds}.{Miliseconds}";
            }
            return $"{Hours}:{Minutes}:{Seconds}.{Miliseconds}";
        }
        
        

        public static async Task<Time> AverageAsync(List<Time> ar, int countofaverage)
        {
            List<Time> newar = new List<Time>();
            ar.Reverse();
            if (ar.Count >= countofaverage)
            {
                Boolean isdnf = false;
                await Task.Run(() =>
                {
                    for (Int32 i = 0; i < countofaverage; i++)
                    {
                        if (ar[i].SOT == StateOfTime.DNF)
                        {
                            isdnf = true;
                        }
                        newar.Add(ar[i]);
                    }
                });
                Time sum = Add(newar);
                
                return Division(sum, countofaverage, isdnf);
            }
            else throw new ArgumentException($"Argument \"ar\" don't care enough values to get average of {countofaverage}");
            
        }

        private static Time Add(List<Time> ar)
        {
            Time sum = new Time(new Scramble()); // , new User() // TODO: check whether we need User() or User("args")
            foreach (var v in ar)
            {
                sum.Hours += v.Hours;
                sum.Minutes += v.Minutes;
                sum.Seconds += v.Seconds;
                sum.Miliseconds += v.Miliseconds;
            }
            return sum;
        }
        private static Time Division(Time t, int divisor, Boolean IsDNF)
        {
            
            double ml = (t.Hours * 60 * 60 * 1000) + (t.Minutes * 60 * 1000) + (t.Seconds * 1000) + t.Miliseconds;
            ml = (Int32)ml / divisor;
            ml = ml / 60 / 60 / 1000;
            double hoursaftdp;
            short hours = GetNumberDown(ml, out hoursaftdp);
            ml = hoursaftdp * 60;
            double minutesaftdp;
            short minutes = GetNumberDown(ml, out minutesaftdp);
            ml = minutesaftdp * 60;
            double secondsaftdp;
            short seconds = GetNumberDown(ml, out secondsaftdp);
            ml = secondsaftdp * 1000;
            int miliseconds = (int)GetNumberDown(ml, out ml);
            // check whether we need "new User()" or "User("args")"
            var division = new Time(hours, minutes, seconds, miliseconds, new Scramble()); // , new User() 
            if (IsDNF)
            {
                division.SOT = StateOfTime.DNF;
            }
            return division;
        }
        private static short GetNumberDown(double d, out double afterdp)
        {
            String str = d.ToString();
            var v = str.Split(new[] { '.' });
            Double a;
            if (v.Count() == 2)
            {
                a = Convert.ToDouble("0" + "." + v[1]);
            }
            else
            {
                a = default(double);
            }
            afterdp = a;
            return Convert.ToInt16(v[0]);
        }
    }
    public static class Handlers
    {
        public static void TimeChangedInvoke()
        {
            TimeChanged?.Invoke(new object(), new TimeChangedEventArgs());
        }
        public static event EventHandler<TimeChangedEventArgs> TimeChanged;
    }
    public class TimeChangedEventArgs : EventArgs 
        {
        
        }
    
}
