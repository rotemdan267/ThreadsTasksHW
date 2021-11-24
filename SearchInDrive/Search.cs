using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInDrive
{
    internal class Search
    {
        public string Drive { get; set; }
        public string SearchTerm { get; set; }
        public List<string> Extensions { get; set; }
        public int appearancesCounter;
        public List<FileInfo> Files { get; set; }
        public List<FileInfo> FilesToRead { get; set; }
        public Task[] Tasks { get; set; }
        public int index, index2;
        static object lockObject1 = new object();
        static object lockObject2 = new object();
        static object lockObject3 = new object();
        static object lockObject4 = new object();
        static object lockObject5 = new object();


        public Search()
        {
            Extensions = new List<string>();
            Extensions.Add(".txt");
            appearancesCounter = 0;
            Files = new List<FileInfo>();
            FilesToRead = new List<FileInfo>();
            Tasks = new Task[16];
            index = -1;
            index2 = -1;
        }

        public Search(string drive, string searchTerm) : this()
        {
            Drive = drive;
            SearchTerm = searchTerm;
        }
        public int GetIndex()
        {
            lock (lockObject5)
            {
                index2++;
            }
            return index2;
        }
        public void AddFile(FileInfo file)
        {
            lock (lockObject1)
            {
                Files.Add(file);
            }
        }
        public void AppearanceFound()
        {
            lock (lockObject2)
            {
                appearancesCounter++;
            }
        }
        //public void AddAndRunTask(Task task)
        //{
        //    lock (lockObject3)
        //    {
        //        Tasks.Add(task);
        //        Tasks[Tasks.Count - 1].Start();
        //    }
        //}
        public void AddTask(Task task)
        {
            lock (lockObject4)
            {
                index++;
                Tasks[index] = task;
            }
        }
        public void AddExtension(string extension)
        {
            Extensions.Add(extension);
        }
        public void StartSearch()
        {
            DirectoryInfo drive = new DirectoryInfo(Drive);
            var directories = drive.GetDirectories();
            var files = drive.GetFiles();
            SearchInDirectory(files);
            SearchInDirectories(directories);
        }
        public void SearchInDirectories(DirectoryInfo[] directories)
        {
            Task tast = new Task(() =>
            {
                foreach (var item in directories)
                {
                    try
                    {
                        var files = item.GetFiles();
                        SearchInDirectory(files);
                    }
                    catch (Exception uae)
                    {

                    }
                    try
                    {
                        var newDirectories = item.GetDirectories();
                        SearchInDirectories(newDirectories);
                    }
                    catch (Exception uae)
                    {

                    }
                }
            });
            //AddAndRunTask(tast);
        }
        public void SearchInDirectory(FileInfo[] files)
        {
            Task task;
            string str;
            foreach (var file in files)
            {
                foreach (var extension in Extensions)
                {
                    if (file.Extension == extension)
                    {
                        task = new Task(() =>
                        {
                            try
                            {
                                str = File.ReadAllText(file.FullName);
                                if (str.Contains(SearchTerm))
                                {
                                    AppearanceFound();
                                    AddFile(file);

                                    while (str != string.Empty)
                                    {
                                        str = str.Substring(str.IndexOf(SearchTerm) + SearchTerm.Length);
                                        if (str.Contains(SearchTerm))
                                        {
                                            AppearanceFound();
                                        }
                                        else str = string.Empty;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        });
                        //AddAndRunTask(task);
                    }
                }
            }
        }


        public void StartSearchAsync()
        {
            DirectoryInfo drive = new DirectoryInfo(Drive);
            var directories = drive.GetDirectories();
            var files = drive.GetFiles();
            //await Task.Run(() =>
            //{
            SearchInDirectoriesAsync(directories);
            //});
            SearchInDirectoryAsync(files);
            //Task task = 
            //AddTask(task);
            //Task.WaitAll(task, task1);
        }
        public void SearchInDirectoriesAsync(DirectoryInfo[] directories)
        {
            //await Task.Run(() =>
            //{
            foreach (var item in directories)
            {

                try
                {
                    var files = item.GetFiles();
                    SearchInDirectoryAsync(files);
                }
                catch (UnauthorizedAccessException uae)
                {

                }
                try
                {
                    var newDirectories = item.GetDirectories();
                    //Task task = 
                    SearchInDirectoriesAsync(newDirectories);
                    //AddTask(task);
                    //Task.WaitAll(task);

                }
                catch (UnauthorizedAccessException uae)
                {

                }


            }
            //});
        }
        public void SearchInDirectoryAsync(FileInfo[] files)
        {
            foreach (var file in files)
            {
                foreach (var extension in Extensions)
                {
                    if (file.Extension == extension)
                    {
                        FilesToRead.Add(file);
                        Task task = ReadFileAsync();
                        task.Wait();
                    }
                }
            }
        }
        public async Task ReadFileAsync()
        {
            //try
            //{
            await Task.Run(() =>
            {
                int fileIndex = GetIndex();
                StreamReader streamReader = new StreamReader(FilesToRead[fileIndex].FullName);
                string str = streamReader.ReadToEnd();
                if (str.Contains(SearchTerm))
                {
                    AppearanceFound();
                    AddFile(FilesToRead[fileIndex]);

                    while (str != string.Empty)
                    {
                        str = str.Substring(str.IndexOf(SearchTerm) + SearchTerm.Length);
                        if (str.Contains(SearchTerm))
                        {
                            AppearanceFound();
                        }
                        else str = string.Empty;
                    }
                }
            });
            //}
            //catch (UnauthorizedAccessException ex)
            //{

            //}
        }
    }
}

