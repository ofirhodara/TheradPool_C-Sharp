using System;
using System.Threading;

namespace Thread_basic
{
    class Program
    {

        static void Main(string[] args)
        {
            ThreadWork thread1 = new ThreadWork();
            ThreadWork thread2 = new ThreadWork();
            ThreadWork thread3 = new ThreadWork();
            ThreadWork thread4 = new ThreadWork();

            Thread thr = new Thread(new ThreadStart(thread1.runFunc));
            Thread thr2 = new Thread(new ThreadStart(thread2.runFunc));
            Thread thr3 = new Thread(new ThreadStart(thread3.runFunc));
            Thread thr4 = new Thread(new ThreadStart(thread4.runFunc));

            thr.Name = "thread 1";
            thr2.Name = "thread 2";
            thr3.Name = "thread 3";
            thr4.Name = "thread 4";

            DateTime now = DateTime.Now;

            thr.Start();
            thr2.Start();
            thr3.Start();
            thr4.Start();


            thr.Join();
            thr2.Join();
            thr3.Join();
            thr4.Join();

            DateTime after = DateTime.Now;
            TimeSpan interval = after - now;

            Console.WriteLine("Time in Miliseconds: " + interval.TotalMilliseconds);
        }
    }
}
