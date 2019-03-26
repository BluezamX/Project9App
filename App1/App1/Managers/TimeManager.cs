using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace App1.Managers
{
    public static class TimeManager
    {
        public static void ToAbort(int time, Thread thread)
        {
            Thread a = new Thread(() => Console.WriteLine("a"));
            a = new Thread(() => TimeOut(time, a));
            a.Start();
            thread.Abort();
        }

        public static void TimeOut(int time, Thread thread)
        {
            Thread.Sleep(time);
        }
    }
}
