using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Thread_basic
{
    class ThreadPool
    {
        private int working = 0;
        private int maxSize = 2;
        private static ThreadPool pool = null;
        private Queue<ThreadWork> queueThreads;
        private ThreadPool()
        {
            queueThreads = new Queue<ThreadWork>();
        }
        public static ThreadPool GetPoolShow()
        {
            if (pool == null)
                pool = new ThreadPool();
            return pool;
        }
        public void release()
        {
            working--;
          
            if (queueThreads.Count != 0)
            {
                ThreadWork waitingThread = queueThreads.Dequeue();
                Console.WriteLine(Thread.CurrentThread.Name + " RELEASE THE MONITOR");
                Monitor.Pulse(this);
            }




        }
        public  void register(ThreadWork Thread1)
        {
            if (working < maxSize)
            {
                working++;
                Console.WriteLine(Thread.CurrentThread.Name + " Register");
                queueThreads.Enqueue(Thread1);
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " Waiting");
                Monitor.Wait(this);             
                Console.WriteLine(Thread.CurrentThread.Name + " Stop Wait");

            }
        }
    }
}
