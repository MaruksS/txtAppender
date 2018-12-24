using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace txtAppender
{
    public partial class Form1 : Form
    {
        string directory = @"C:\directory";
        string file1 = @"C:\directory\text.txt";
        string file2 = @"C:\directory\text2.txt";
        string outputPath = @"C:\output.txt";

        bool running = false;


        FileSystemWatcher watcher;
        FileSystemWatcher watcher2;

        string filename1 = "text*";
        string filename2 = "text*";

        public Form1()
        {
            InitializeComponent();
        }

        private void watchDirectory1()
        {
            watcher = new FileSystemWatcher();
            watcher.Path = directory;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = filename1 + ".txt";
            watcher.Changed += new FileSystemEventHandler(fileSystemWatcher_Changed);
            watcher.EnableRaisingEvents = true;
        }

        private void watchDirectory2()
        {
            watcher2 = new FileSystemWatcher();
            watcher2.Path = directory;
            watcher2.NotifyFilter = NotifyFilters.LastWrite;
            watcher2.Filter = filename2 + ".txt";
            watcher2.Changed += new FileSystemEventHandler(fileSystemWatcher_Changed);
            watcher2.EnableRaisingEvents = true;
        }

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show(sender.ToString());
            var task = Task.Run(() => readWrite());
            if (task.Wait(TimeSpan.FromSeconds(20)))
            {
                return;
            }
            else
            {
                throw new Exception("Timed out");
            }

        }

        public void readWrite()
        {
            List<string> lines1 = new List<string>();
            List<string> lines2 = new List<string>();

            try
            {
                using (var reader = new StreamReader(file1))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines1.Add(line);
                    }
                    reader.Close();
                }
                using (var reader = new StreamReader(file2))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines2.Add(line);
                    }
                    reader.Close();
                }

                var output = lines1.Concat(lines2);

                using (var writer = new StreamWriter(outputPath))
                {
                    foreach (var line in output)
                    {
                        writer.WriteLine(line);
                    }
                    writer.Close();
                }
            }
            catch
            {

            }
        }

        public static T[] ConcatArrays<T>(params T[][] list)
        {
            var result = new T[list.Sum(a => a.Length)];
            int offset = 0;
            for (int x = 0; x < list.Length; x++)
            {
                list[x].CopyTo(result, offset);
                offset += list[x].Length;
            }
            return result;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    directory = fbd.SelectedPath;
                    MessageBox.Show(directory);
                }
            }
        }

        private void startButtonClick(object sender, EventArgs e)
        {
            if (running)
            {
                watcher.EnableRaisingEvents = false;
                watcher2.EnableRaisingEvents = false;
                running = false;
            }
            else
            {
                watchDirectory1();
                watchDirectory2();
                running = true;
            }
            
        }
    }
}
