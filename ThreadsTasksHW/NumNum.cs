using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsTasksHW
{
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
}
