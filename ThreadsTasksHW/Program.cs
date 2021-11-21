// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using ThreadsTasksHW;


#region Q1

//Thread thread = new Thread(() =>
//{
//    for (int i = 1; i <= 500; i++)
//    {
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine(i);
//    }
//});

//thread.Start();
Task task = new Task( () =>
{
    for (int i = 1000; i <= 5000; i++)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(i);
    }
});

Action action = () =>
{
    for (int i = 1000; i <= 5000; i++)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(i);
    }
};
//await Task.Run(action);


//Task.Run(() =>
//{
//    for (int i = 10000; i <= 50000; i++)
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine(i);
//    }
//});

//for (int i = 0; i < 500; i++)
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine(i);
//}

#endregion

#region Q2


DirectoryInfo directory1 = new DirectoryInfo(@"C:\Users\User\Music\music\Songs");
DirectoryInfo directory2 = new DirectoryInfo(@"C:\Users\User\Wallpapers");

Thread directoryThread1 = new Thread(() =>
{
    var files = directory1.GetFiles();
    foreach (var file in files)
    {
        Console.WriteLine(file.Name);
    }
});

Thread directoryThread2 = new Thread(() =>
{
    var files = directory2.GetFiles();
    foreach (var file in files)
    {
        Console.WriteLine(file.Name);
    }
});

//directoryThread1.Start();
//directoryThread2.Start();

#endregion

#region Q3

Thread Q3Thread1 = new Thread(() =>
{
    NumNum numNum1 = new NumNum("Q3Thread1");
    for (int i = 0; i < 500; i++)
    {
        if (i == 100)
        {
            numNum1.Sleep();
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(i);
    }
});

Thread Q3Thread2 = new Thread(() =>
{
    NumNum numNum1 = new NumNum("Q3Thread2");
    for (int i = 0; i < 500; i++)
    {
        if (i == 200)
        {
            numNum1.Sleep();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(i);
    }
});


Thread Q3Thread3 = new Thread(() =>
{
    NumNum numNum1 = new NumNum("Q3Thread3");
    for (int i = 0; i < 500; i++)
    {
        if (i == 300)
        {
            numNum1.Sleep();
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(i);
    }
});

Thread Q3Thread4 = new Thread(() =>
{
    NumNum numNum1 = new NumNum("Q3Thread4");
    for (int i = 0; i < 500; i++)
    {
        if (i == 400)
        {
            numNum1.Sleep();
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(i);
    }
});

//Q3Thread1.Start();
//Q3Thread2.Start();
//Q3Thread3.Start();
//Q3Thread4.Start();


//Task Q3Thread5 = new Task(() =>
//{
//    NumNum numNum1 = new NumNum("Q3Thread4");
//    for (int i = 0; i < 500; i++)
//    {
//        if (i == 4)
//        {
//            numNum1.Sleep();
//        }
//        Console.ForegroundColor = ConsoleColor.Blue;
//        Console.WriteLine(i);
//    }
//});
//Q3Thread5.Start();

#endregion

#region Q4

//Console.WriteLine("Enter number:");
//int n = int.Parse(Console.ReadLine());
//long sum = Summary.SumNumbersThread(1, n + 1);
//long sumWithThreads = Summary.SumNumbers(n);
//Console.WriteLine("sum =              " + sum);
//Console.WriteLine("sum with threads = " + sumWithThreads);

#endregion

#region Q5

DirectoryInfo directory = new DirectoryInfo(@"C:\Users\User\Desktop\‏‏תיקיה חדשה\‏‏תיקיה חדשה");
var dir = directory.GetDirectories();

string str = "abcdefgh";
string str2 = "bcd";
Console.WriteLine(str.IndexOf(str2));
Console.WriteLine();
string s = str.Substring(str.IndexOf(str2) + str2.Length);
Console.WriteLine(s);

if (dir.Length == 0)
{
    Console.WriteLine(true);
}
Console.WriteLine(dir.Length);

#endregion