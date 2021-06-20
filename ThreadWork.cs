using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Thread_basic
{
    class ThreadWork
    {
        private ThreadPool pool = ThreadPool.GetPoolShow();
        private SharedInteger box = SharedInteger.GetShow();
        private static bool runing = true;


        public void runFunc()
        {
            lock (pool)
                pool.register(this);

            run();

            lock (pool)
                pool.release();
        }
        public void run()
        {
            while (runing)
            {
                lock (box)
                {
                    if (box.GetInt() < 200)
                    {
                        box.incInt();
                        if (box.is7Boom())
                            Console.WriteLine("Thread Name:" + Thread.CurrentThread.Name + ",Number: " + box.GetInt());

                    }
                    else
                        runing = false;
                }
            }


        }


    }
}
