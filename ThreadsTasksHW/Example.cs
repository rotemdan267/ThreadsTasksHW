using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsTasksHW
{
    internal static class Example
    {
        static object lockObject = new object();
        static object lockObject1 = new object();
        static int index = -1;
        public static int sum = 0;
        public static int IndexPlusOne()
        {
            lock (lockObject)
            {
                index++;
            }
            return index;
        }
        public static void AddToSum(int x)
        {
            lock (lockObject1)
            {
                sum += x;
            }
        }
        public static int SumArrayWithThreads(int[] arr)
        {
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 200; i++)
                {
                    AddToSum(arr[IndexPlusOne()]);
                }
            });
            Thread thread2 = new Thread(() =>
            {
                for (int i = 200; i < 400; i++)
                {
                    AddToSum(arr[IndexPlusOne()]);
                }
            });
            Thread thread3 = new Thread(() =>
            {
                for (int i = 400; i < 600; i++)
                {
                    AddToSum(arr[IndexPlusOne()]);
                }
            });
            Thread thread4 = new Thread(() =>
            {
                for (int i = 600; i < 800; i++)
                {
                    AddToSum(arr[IndexPlusOne()]);
                }
            });
            Thread thread5 = new Thread(() =>
            {
                for (int i = 800; i < 1000; i++)
                {
                    AddToSum(arr[IndexPlusOne()]);
                }
            });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();

            return sum;


        }
    }
}
