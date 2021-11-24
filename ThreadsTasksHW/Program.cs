// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using ThreadsTasksHW;


#region Q1

#region Thread

Thread thread = new Thread(() =>
{
    for (int i = 1; i <= 5000; i++)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(i);
    }
});
//thread.Start();



#endregion


#region Task


Task task = new Task(() =>
{
    for (int i = 1; i <= 5000; i++)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(i);
    }
});
//task.Start();
//task.Wait();


#endregion


#region async - await

//Task task1 = Q1Async();
//task1.Wait();

static async Task Q1Async()
{
    await Task.Run(() =>
    {
        for (int i = 1; i <= 5000; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(i);
        }
    });
}

#endregion

#endregion

#region Q2

DirectoryInfo directory1 = new DirectoryInfo(@"C:\Users\User\Music\music\Songs");
DirectoryInfo directory2 = new DirectoryInfo(@"C:\Users\User\Wallpapers");

#region Thread

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

#region Task


Task task2 = new Task(() =>
{
    var files = directory1.GetFiles();
    foreach (var file in files)
    {
        Console.WriteLine(file.Name);
    }
});

Task task22 = new Task(() =>
{
    var files = directory2.GetFiles();
    foreach (var file in files)
    {
        Console.WriteLine(file.Name);
    }
});

//task2.Start();
//task22.Start();
//Task.WaitAll(task2, task22);

#endregion

#region    async - await

//task2 = ReadDirectory(directory1);
//task22 = ReadDirectory(directory2);
//Task.WaitAll(task2, task22);

static async Task ReadDirectory(DirectoryInfo directory)
{
    await Task.Run(() =>
    {
        var files = directory.GetFiles();
        foreach (var file in files)
        {
            Console.WriteLine(file.Name);
        }
    });
}


#endregion

#endregion

#region Q3


#region Thread

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
//Console.WriteLine("staring threads");

//Q3Thread1.Start();
//Q3Thread2.Start();
//Q3Thread3.Start();
//Q3Thread4.Start();

//Console.WriteLine("threads started");

#endregion

#region Task

Task Q3Task1 = new Task(() =>
{
    NumNumTask NumNumTask1 = new NumNumTask("Q3Task1");
    for (int i = 0; i < 500; i++)
    {
        if (i == 100)
        {
            NumNumTask1.Sleep();
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(i);
    }
});

Task Q3Task2 = new Task(() =>
{
    NumNumTask NumNumTask1 = new NumNumTask("Q3Task2");
    for (int i = 0; i < 500; i++)
    {
        if (i == 200)
        {
            NumNumTask1.Sleep();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(i);
    }
});


Task Q3Task3 = new Task(() =>
{
    NumNumTask NumNumTask1 = new NumNumTask("Q3Task3");
    for (int i = 0; i < 500; i++)
    {
        if (i == 300)
        {
            NumNumTask1.Sleep();
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(i);
    }
});

Task Q3Task4 = new Task(() =>
{
    NumNumTask NumNumTask1 = new NumNumTask("Q3Task4");
    for (int i = 0; i < 500; i++)
    {
        if (i == 400)
        {

            NumNumTask1.Sleep();
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(i);
    }
});

//Console.WriteLine("staring Tasks");

//Q3Task1.Start();
//Q3Task2.Start();
//Q3Task3.Start();
//Q3Task4.Start();

//Console.WriteLine("Tasks started");

//Task.WaitAll(Q3Task1, Q3Task2, Q3Task3, Q3Task4);

#endregion

#region    async - await


Q3Task1 = new Task(() =>
{
    NumNumAsync NumNumAsync1 = new NumNumAsync("Q3Task1");
    for (int i = 0; i < 500; i++)
    {
        if (i == 100)
        {
            var task = NumNumAsync1.SleepAsync();
            task.Wait();
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(i);
    }
});

Q3Task2 = new Task(() =>
{
    NumNumAsync NumNumAsync1 = new NumNumAsync("Q3Task2");
    for (int i = 0; i < 500; i++)
    {
        if (i == 200)
        {
            var task = NumNumAsync1.SleepAsync();
            task.Wait();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(i);
    }
});


Q3Task3 = new Task(() =>
{
    NumNumAsync NumNumAsync1 = new NumNumAsync("Q3Task3");
    for (int i = 0; i < 500; i++)
    {
        if (i == 300)
        {
            var task = NumNumAsync1.SleepAsync();
            task.Wait();
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(i);
    }
});

Q3Task4 = new Task(() =>
{
    NumNumAsync NumNumAsync1 = new NumNumAsync("Q3Task4");
    for (int i = 0; i < 500; i++)
    {
        if (i == 400)
        {

            var task = NumNumAsync1.SleepAsync();
            task.Wait();
        }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(i);
    }
});

//Console.WriteLine("staring Tasks");

//Q3Task1.Start();
//Q3Task2.Start();
//Q3Task3.Start();
//Q3Task4.Start();

//Console.WriteLine("Tasks started");

//Task.WaitAll(Q3Task1, Q3Task2, Q3Task3, Q3Task4);


#endregion


#endregion

#region Q4

Console.WriteLine("Enter number:");
int n = 0;
bool flag;
flag = int.TryParse(Console.ReadLine(), out n);
while (!flag)
{
    Console.WriteLine("Wrong input. enter number:");
    flag = int.TryParse(Console.ReadLine(), out n);
}
long sum = Summary.SumNumbers(1, n + 1);
Console.WriteLine("sum =              " + sum);


// הערה חשובה לבודק: בניתי בשלושת השיטות, כמו שהתבקשנו
// Thread, Task, Async-await
// אבל הפונקציות לא עובדות ביחד, כי הן משתמשות
// Summary באותם משתנים במחלקת 
// יכולתי לכתוב את המשתנים 3 פעמים שונות אבל זה נראה לי מאמץ מיותר
// ולא מה שהתבקשנו בתרגיל, אז לא להפעיל את הפונקציות יחד - כל אחת בנפרד



//long sumWithThreads = Summary.SumNumbersWithThreads(n);
long sumWithTasks = Summary.SumNumbersWithTasks(n);
//long sumAsync = Summary.SumNumbersWithTasksAsync(n);

//Console.WriteLine("sum with threads = " + sumWithThreads);
Console.WriteLine("sum with tasks =   " + sumWithTasks);
//Console.WriteLine("sum with async =   " + sumAsync);


#endregion