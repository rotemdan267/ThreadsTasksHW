using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsTasksHW
{
    #region Thread

    internal class NumNum
    {
        public int SleepTime { get; set; }
        public string ThreadName { get; set; }
        public NumNum(string name)
        {
            Random random = new Random();
            SleepTime = random.Next(0, 5000);
            ThreadName = name;
            Console.WriteLine($"Thread '{ThreadName}'; Sleep time {SleepTime / 1000d} seconds");
        }
        public void Sleep()
        {
            Console.WriteLine($"{ThreadName} is going to sleep");
            Thread.Sleep(SleepTime);
            Console.WriteLine($"{ThreadName} woke up");

        }
    }

    #endregion

    #region Task

    internal class NumNumTask
    {
        public int SleepTime { get; set; }
        public string TaskName { get; set; }
        public NumNumTask(string name)
        {
            Random random = new Random();
            SleepTime = random.Next(0, 5000);
            TaskName = name;
            Console.WriteLine($"Task '{TaskName}'; Sleep time {SleepTime / 1000d} seconds");
        }
        public void Sleep()
        {
            Console.WriteLine($"{TaskName} is going to sleep");
            //Task.Delay(SleepTime);
            Thread.Sleep(SleepTime);
            Console.WriteLine($"{TaskName} woke up");

        }
    }

    #endregion

    #region async - await

    internal class NumNumAsync
    {
        public int SleepTime { get; set; }
        public string TaskName { get; set; }
        public NumNumAsync(string name)
        {
            Random random = new Random();
            SleepTime = random.Next(0, 5000);
            TaskName = name;
            Console.WriteLine($"Task '{TaskName}'; Sleep time {SleepTime / 1000d} seconds");
        }
        public async Task SleepAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"{TaskName} is going to sleep");
                //Task.Delay(SleepTime);
                Thread.Sleep(SleepTime);
                Console.WriteLine($"{TaskName} woke up");
            });
        }
    }

#endregion
}
