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
            for (int i = 0; i < arr.Length; i++)
            {
                Thread thread = new Thread(() =>
                {
                    AddToSum(arr[IndexPlusOne()]);
                });
                thread.Start();
                thread.Join();
            }

            return sum;
        }
    }
}
