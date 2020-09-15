using System;
using System.Threading;

namespace AlarmClock
{
    public class Timer
    {
        public delegate void TickFunc(DateTime date);
        public delegate void AlarmFunc(int sec);
        public Timer()
        {
            bRunning = true;
            TotalSeconds = 0;
        }
        public void Run()
        {
            while (bRunning)
            {
                int nowSecond = DateTime.Now.Second;
                if(nowSecond != lastSecond)
                {
                    if(TickEvent != null)
                    {
                        TotalSeconds++;
                        TickEvent(DateTime.Now);
                        if (TotalSeconds == AlarmTime)
                        {
                            AlarmEvent(TotalSeconds);
                        }
                    }
                    lastSecond = nowSecond;
                }
            }
        }
        public void Shutdown()
        {
            bRunning = false;
        }
        public void AddTickDelegate(TickFunc func)
        {
            TickEvent += func;
        }
        public void AddAlarmDelegate(AlarmFunc func)
        {
            AlarmEvent += func;
        }
        private bool bRunning;
        private int lastSecond;
        private int TotalSeconds;
        public int AlarmTime {
            get; set;
        }
        private event TickFunc TickEvent;
        private event AlarmFunc AlarmEvent;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            timer.AddTickDelegate((DateTime dateTime) =>
            {
                Console.WriteLine($"{dateTime.ToString()}");
            });
            int alarmSec = 10;
            timer.AlarmTime = alarmSec;

            timer.AddAlarmDelegate((int sec) =>
            {
                Console.WriteLine($"Alarm at {sec}");
            });
            
            Thread thread = new Thread(() => timer.Run());
            thread.Start();
        }
    }
}
