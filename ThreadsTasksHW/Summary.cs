using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsTasksHW
{
    internal static class Summary
    {
        public static List<long> MidSums { get; set; }
        public static object lockObject;
        public static object lockObject2;
        public static int count;

        static Summary()
        {
            MidSums = new List<long>();
            lockObject = new object();
            lockObject2 = new object();
            count = -1;
        }
        public static void AddToList(long midSum)
        {
            lock(lockObject)
            {
                MidSums.Add(midSum);
            }
        }
        public static int AddToCount()
        {
            lock (lockObject2)
            {
                count++;
            }
            return count;
        }

        public static long SumNumbers(int startNumber, int endNumber)
        {
            long sum = 0;
            for (int i = startNumber; i < endNumber; i++)
            {
                sum += i;
            }
            return sum;
        }


        public static long SumNumbersWithThreads(int endNumber)
        {
            long sum = endNumber;
            int numForThread = 200000; // כמות המספרים שתהליך יעבוד עליהם
            int numOfThreads = endNumber / 200000;
            if (endNumber % 200000 > 0)
            {
                numOfThreads++; // תהליך נוסף שיחבר את המספרים הנותרים
            }
            if (numOfThreads < 5)
            { // השאלה ביקשה שיהיו לפחות 5 תהליכים...
                numOfThreads = 5;
                numForThread = endNumber / 5;
                sum += SumNumbers(1, endNumber % 5);
            }
            List<Thread> threads = new List<Thread>(); // רשימה של כל התהליכים
            int[] tempEnd = new int[numOfThreads]; // רשימה של מס' סופי שיישלח לתהליך
                                                   // (כששלחתי משתנה לתהליך, הוא הספיק להשתנות לפני שהתהליך החל לפעול,
                                                   // לכן צריך רשימה שתכיל משתנים שלא ישתנו)
            tempEnd[0] = endNumber;   // מס' סופי הראשון
            int[] tempStart = new int[numOfThreads]; // רשימה של מס' התחלתי לכל תהליך
            tempStart[0] = endNumber; // מס' התחלתי ראשון (ישתנה בתחילת הלולאה)
            Thread thread;
            for (int i = 0; i < numOfThreads; i++)
            {
                if (i != 0)
                { // חישוב המס' הסופי לכל תהליך. בריצה הראשונה אי אפשר כי אין אינדקס 
                  // -1
                    tempEnd[i] = tempEnd[i - 1] - numForThread;
                }
                tempStart[i] = tempEnd[i] - numForThread; // חישוב מס' התחלתי לכל תהליך
                if (tempStart[i] < 0) tempStart[i] = 0;
                thread = new Thread(() =>
                { 
                    int currentIndex = AddToCount();
                    long midSum = SumNumbers(tempStart[currentIndex], tempEnd[currentIndex]);
                    AddToList(midSum);
                });
                thread.Name = "thread " + i;
                threads.Add(thread);
                threads[i].Start();
                //threads[i].Join();

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
                sum += MidSums[i];
            }
            return sum;
        }

        public static long SumNumbersWithTasks(int endNumber)
        {
            long sum = endNumber;
            int numForThread = 200000; // כמות המספרים שתהליך יעבוד עליהם
            int numOfThreads = endNumber / 200000;
            
            if (endNumber % 200000 > 0)
            {
                numOfThreads++; // תהליך נוסף שיחבר את המספרים הנותרים
            }
            if (numOfThreads < 5)
            { // השאלה ביקשה שיהיו לפחות 5 תהליכים...
                numOfThreads = 5;
                numForThread = endNumber / 5;
                sum += SumNumbers(1, endNumber % 5);
            }
          
            Task[] tasks = new Task[numOfThreads];
            int[] tempEnd = new int[numOfThreads]; // רשימה של מס' סופי שיישלח לתהליך
                                                   // (כששלחתי משתנה לתהליך, הוא הספיק להשתנות לפני שהתהליך החל לפעול,
                                                   // לכן צריך רשימה שתכיל משתנים שלא ישתנו)
            tempEnd[0] = endNumber;   // מס' סופי הראשון
            int[] tempStart = new int[numOfThreads]; // רשימה של מס' התחלתי לכל תהליך
            tempStart[0] = endNumber; // מס' התחלתי ראשון (ישתנה בתחילת הלולאה)
            Task task;
            for (int i = 0; i < numOfThreads; i++)
            {
                if (i != 0)
                { // חישוב המס' הסופי לכל תהליך. בריצה הראשונה אי אפשר כי אין אינדקס 
                  // -1
                    tempEnd[i] = tempEnd[i - 1] - numForThread;
                }
                tempStart[i] = tempEnd[i] - numForThread; // חישוב מס' התחלתי לכל תהליך
                if (tempStart[i] < 0) tempStart[i] = 0;
                task = new Task(() =>
                { 
                    int currentIndex = AddToCount();
                    long midSum = SumNumbers(tempStart[currentIndex], tempEnd[currentIndex]);
                    AddToList(midSum);
                });
                tasks[i] = task;
                tasks[i].Start();
            }

            Task.WaitAll(tasks);

            for (int i = 0; i < numOfThreads; i++)
            {
                sum += MidSums[i];
            }
            return sum;
        }

        public static long SumNumbersWithTasksAsync(int endNumber)
        {
            long sum = endNumber;
            int numForThread = 200000; // כמות המספרים שתהליך יעבוד עליהם
            int numOfThreads = endNumber / 200000;

            if (endNumber % 200000 > 0)
            {
                numOfThreads++; // תהליך נוסף שיחבר את המספרים הנותרים
            }
            if (numOfThreads < 5)
            { // השאלה ביקשה שיהיו לפחות 5 תהליכים...
                numOfThreads = 5;
                numForThread = endNumber / 5;
                sum += SumNumbers(1, endNumber % 5);
            }
            Task[] tasks = new Task[numOfThreads];
            int[] tempEnd = new int[numOfThreads]; // רשימה של מס' סופי שיישלח לתהליך
                                                   // (כששלחתי משתנה לתהליך, הוא הספיק להשתנות לפני שהתהליך החל לפעול,
                                                   // לכן צריך רשימה שתכיל משתנים שלא ישתנו)
            tempEnd[0] = endNumber;   // מס' סופי הראשון
            int[] tempStart = new int[numOfThreads]; // רשימה של מס' התחלתי לכל תהליך
            tempStart[0] = endNumber; // מס' התחלתי ראשון (ישתנה בתחילת הלולאה)
            Task task;
            for (int i = 0; i < numOfThreads; i++)
            {
                if (i != 0)
                { // חישוב המס' הסופי לכל תהליך. בריצה הראשונה אי אפשר כי אין אינדקס 
                  // -1
                    tempEnd[i] = tempEnd[i - 1] - numForThread;
                }
                tempStart[i] = tempEnd[i] - numForThread; // חישוב מס' התחלתי לכל תהליך
                if (tempStart[i] < 0) tempStart[i] = 0;
                task = SumNumbersAsync(tempStart, tempEnd);
                tasks[i] = task;
            }

            Task.WaitAll(tasks);

            for (int i = 0; i < numOfThreads; i++)
            {
                sum += MidSums[i];
            }
            return sum;
        }

        public static async Task SumNumbersAsync(int[] tempStart, int[] tempEnd)
        {
            await Task.Run(() =>
            {
                int currentIndex = AddToCount();
                long midSum = SumNumbers(tempStart[currentIndex], tempEnd[currentIndex]);
                AddToList(midSum);
            });
        }

    }
}
