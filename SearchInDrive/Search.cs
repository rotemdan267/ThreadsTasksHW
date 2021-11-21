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
        public List<Task> Tasks { get; set; }
        static object lockObject1 = new object();
        static object lockObject2 = new object();
        static object lockObject3 = new object();


        public Search()
        {
            Extensions = new List<string>();
            Extensions.Add(".txt");
            appearancesCounter = 0;
            Files = new List<FileInfo>();
            Tasks = new List<Task>();
        }

        public Search(string drive, string searchTerm) : this()
        {
            Drive = drive;
            SearchTerm = searchTerm;
        }

        public void AddFile(FileInfo file)
        {
            lock (lockObject1)
            {
                Files.Add(file);
            }
        }
        public void AppearceFound()
        {
            lock (lockObject2)
            {
                appearancesCounter++;
            }
        }
        public void AddTask(Task task)
        {
            lock (lockObject3)
            {
                Tasks.Add(task);
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
            //Task tast = new Task(() =>
            //{
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
            //});
            //AddTask(tast);
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
                        //task = new Task(() =>
                        //{
                            str = File.ReadAllText(file.FullName);
                            if (str.Contains(SearchTerm))
                            {
                                AppearceFound();
                                AddFile(file);

                                while (str != string.Empty)
                                {
                                    str = str.Substring(str.IndexOf(SearchTerm) + SearchTerm.Length);
                                    if (str.Contains(SearchTerm))
                                    {
                                        AppearceFound();
                                    }
                                    else str = string.Empty;
                                }
                            }
                        //});
                        //AddTask(task);
                    }
                }
            }
        }
    }
}

