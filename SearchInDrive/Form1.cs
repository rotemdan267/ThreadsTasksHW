using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace SearchInDrive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void txtSearchTerm_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchTerm.Text != String.Empty)
            {
                btnSearchInC.Enabled = true;
                btnSearchInD.Enabled = true;
            }
            else
            {
                btnSearchInC.Enabled = false;
                btnSearchInD.Enabled = false;
            }
        }

        private void btnSearchInC_Click(object sender, EventArgs e)
        {
            Search search = new Search(@"C:\Users\User\Desktop\‏‏תיקיה חדשה (3)", txtSearchTerm.Text);
            var watch = Stopwatch.StartNew();
            search.StartSearchAsync();
            //Task.WaitAll(search.Tasks);
            watch.Stop();
            MessageBox.Show($"\"{search.SearchTerm}\" appears {search.appearancesCounter} times in {search.Files.Count} files on drive C\nThe search took {watch.Elapsed.Minutes} minutes and {watch.Elapsed.Seconds} seconds");
        }

        private void btnSearchInD_Click(object sender, EventArgs e)
        {
            Search search = new Search(@"D:\", txtSearchTerm.Text);
            var watch = Stopwatch.StartNew();
            search.StartSearch();
            Task.WaitAll(search.Tasks.ToArray());
            watch.Stop();
            MessageBox.Show($"\"{search.SearchTerm}\" appears {search.appearancesCounter} times in {search.Files.Count} files on drive D\nThe search took {watch.Elapsed.Minutes} minutes and {watch.Elapsed.Seconds} seconds");

        }
    }
}