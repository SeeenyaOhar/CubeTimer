using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using TimerCode.Code;
namespace ConsoleTimer
{
    class Program
    {
        static CubingTimer Timer;
        static Thread newThread;
        static void Main(string[] args)
        {
            Scramble scramble = new Scramble();
            Console.WriteLine(scramble.ToString());
            Timer = new CubingTimer();
            Timer.LoadScramble(scramble);
            Timer.Started += Timer_Started;
            Handlers.TimeChanged += CurrentTime_TimeChanged;
            Timer.TimerStoped += Timer_TimerStoped;
            newThread = new Thread(ThreadVoid);
            
            for (Int32 i = 3; i > 0; i--)
            {
                Console.WriteLine($"Timer starts in {i} sec");
                Thread.Sleep(1000);
            }
            Console.WriteLine("P.S. Pls, write something to stop timer!");
            Timer.Start();
            newThread.Start();
        }

        private static void CurrentTime_TimeChanged(object sender, TimeChangedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine(Timer.CurrentTime.ToString());
        }

        private static void Timer_TimerStoped(object sender, TimerStopedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine(Timer.LastTimeSolved.ToString());
        }

        private static void Timer_Started(object sender, TimerStartedEventArgs e)
        {
            Console.WriteLine("Timer started!");
            

        }
        private static void ThreadVoid()
        {
            bool reqstoptimer = false;
            while (!reqstoptimer)
            {
                ConsoleKeyInfo s = Console.ReadKey();
                if (!s.Equals(null))
                {
                    reqstoptimer = true;
                    Timer.Stop();
                    Console.WriteLine($"Timer stoped! Time solved -> {Timer.LastTimeSolved}");
                }
            }
            Console.WriteLine("Press enter to start timer again or press Esc to exit the timer.");
            var key = Console.ReadKey();
            if (key.Key.Equals(ConsoleKey.Enter)) { Console.Clear(); Main(null); }
            if (key.Key.Equals(ConsoleKey.Escape)) { Console.Clear(); Environment.Exit(0); }
        }
    }
}
