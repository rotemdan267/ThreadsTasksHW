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
            int numForThread = 200000; // כמות המספרים שתהליך יעבוד עליהם
            int numOfThreads = endNumber / 200000;
            int count = -1;
            if (endNumber % 200000 > 0)
            {
                numOfThreads++; // תהליך נוסף שיחבר את המספרים הנותרים
            }
            if (numOfThreads < 5)
            { // השאלה ביקשה שיהיו לפחות 5 תהליכים...
                numOfThreads = 5;
                numForThread = endNumber / 5;
                sum += SumNumbersThread(1, endNumber % 5);
            }
            List<Thread> threads = new List<Thread>(); // רשימה של כל התהליכים
            List<long> midSums = new List<long>(); // רשימה של כל הסכומים שיחזרו מהתהליכים
            //Task[] tasks = new Task[numOfThreads];
            int[] tempEnd = new int[numOfThreads]; // רשימה של מס' סופי שיישלח לתהליך
                               // (כששלחתי משתנה לתהליך, הוא הספיק להשתנות לפני שהתהליך החל לפעול,
                                                   // לכן צריך רשימה שתכיל משתנים שלא ישתנו)
            tempEnd[0] = endNumber;   // מס' סופי הראשון
            int[] tempStart = new int[numOfThreads]; // רשימה של מס' התחלתי לכל תהליך
            tempStart[0] = endNumber; // מס' התחלתי ראשון (ישתנה בתחילת הלולאה)
            Thread thread;
            Func<int, int, long> sumDel = SumNumbersThread;
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
                { // i-כשהשתמשתי ב
                  // בתור אינדקס הוא הספיק להשתנות לפני שהתהליך התחיל לפעול ונזרקתי מחוץ
                  // למערך ו/או התכנית דילגה על חלק מהאיברים
                  // במערך, לכן היה צריך למצוא דרך לגרום שכל פעם שתהליך
                  // יפעל, הבא אחריו יעבוד עם האיבר הבא במערך, לכן
                  // count
                    long midSum = sumDel(tempStart[count++], tempEnd[count]);
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
