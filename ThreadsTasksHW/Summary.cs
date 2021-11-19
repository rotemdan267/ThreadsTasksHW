using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsTasksHW
{
    internal static class Summary
    {
        public static long SumNumbersThread(int startNumber, int endNumber)
        {
            long sum = 0;
            for (int i = startNumber; i < endNumber; i++)
            {
                sum += i;
            }
            return sum;
        }

        public static long SumNumbers(int endNumber)
        {
            long sum = endNumber;
            int numForThread = 200000;
            int numOfThreads = endNumber / 200000;
            int count = -1;
            if (endNumber % 200000 > 0)
            {
                numOfThreads++;
            }
            if (numOfThreads < 5)
            {
                numOfThreads = 5;
                numForThread = endNumber / 5;
                sum += SumNumbersThread(1, endNumber % 5);
            }
            List<Thread> threads = new List<Thread>();
            List<long> midSums = new List<long>();
            Task[] tasks = new Task[numOfThreads];
            int[] tempEnd = new int[numOfThreads];
            tempEnd[0] = endNumber;
            int[] tempStart = new int[numOfThreads];
            tempStart[0] = endNumber;
            Thread thread;
            for (int i = 0; i < numOfThreads; i++)
            {
                if (i != 0)
                {
                    tempEnd[i] = tempEnd[i - 1] - numForThread;
                }
                tempStart[i] = tempEnd[i] - numForThread;
                if (tempStart[i] < 0) tempStart[i] = 0;
                Func<int, int, long> sumDel = SumNumbersThread;
                thread = new Thread(() =>
                {
                    count++;
                    long midSum = sumDel(tempStart[count], tempEnd[count]);
                    midSums.Add(midSum);
                });
                thread.Name = "thread " + i;
                threads.Add(thread);
                threads[i].Start();
                //tasks[i] = new Task(() =>
                //{
                //    long midSum = sumDel(tempStart[midSums.Count], tempEnd[midSums.Count]);
                //    midSums.Add(midSum);
                //});
                //tasks[i].Start();
                //thread.Start();
                //Console.WriteLine(thread.ThreadState);
                //thread.Join();
                //Console.WriteLine(thread.ThreadState);
                //threads.Add(thread);
                //Console.WriteLine($"{threads[i].Name} {threads[i].ThreadState}");
            }

            for (int i = 0; i < numOfThreads; i++)
            {
                //threads[i].Start();
                //Console.WriteLine($"{threads[i].Name} {threads[i].ThreadState}");
                threads[i].Join();
                //Console.WriteLine($"{threads[i].Name} {threads[i].ThreadState}");

            }

            for (int i = 0; i < numOfThreads; i++)
            {
                sum += midSums[i];
            }
            return sum;
        }
    }
}
