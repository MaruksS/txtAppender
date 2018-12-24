using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace txtAppender
{

    public partial class Form1 : Form
    {
        /*
         * On launch prepare default settings
         */ 
        string directory = Properties.Settings.Default.directory;
        string file1 = Properties.Settings.Default.file1;
        string file2 = Properties.Settings.Default.file2;
        string outputPath = Properties.Settings.Default.outputFile;
        string filename1 = Properties.Settings.Default.filename1;
        string filename2 = Properties.Settings.Default.filename2;

        /*
         * Define if watcher is running
         */
        bool running = false;

        /*
         * Watcher instances
         */
        FileSystemWatcher watcher;
        FileSystemWatcher watcher2;

        /*
         * For init method
         */
        public Form1()
        {
            InitializeComponent();

            /*
             * Update labels on launch
             */
            updateLabels();
        }

        /*
         * Run watcher for file 1
         */
        private void watchDirectory1()
        {
            watcher = new FileSystemWatcher();
            watcher.Path = directory;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = filename1;
            watcher.Changed += new FileSystemEventHandler(fileSystemWatcher_Changed);
            watcher.EnableRaisingEvents = true;
        }

        /*
         * Run watcher for file 2
         */
        private void watchDirectory2()
        {
            watcher2 = new FileSystemWatcher();
            watcher2.Path = directory;
            watcher2.NotifyFilter = NotifyFilters.LastWrite;
            watcher2.Filter = filename2;
            watcher2.Changed += new FileSystemEventHandler(fileSystemWatcher_Changed);
            watcher2.EnableRaisingEvents = true;
        }

        /*
         * Watcher on file change
         */
        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
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

        /*
         * Read input files and write output file
         */
        public void readWrite()
        {
            List<string> lines1 = new List<string>();
            List<string> lines2 = new List<string>();

            try
            {
                /*
                 * Read file 1
                 */
                using (var reader = new StreamReader(file1))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines1.Add(line);
                    }
                    reader.Close();
                }

                /*
                 * Read file 2
                 */
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

                /*
                 * Write output
                 */
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

        /*
         * Concat arrays
         */
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

        /*
         * Update label text
         */
        public void updateLabels()
        {
            lbl_directory.Text = directory;
            lbl_file1.Text = filename1;
            lbl_file2.Text = filename2;
            lbl_output.Text = outputPath;
        }

        /*
         * Start button click
         */
        private void startButtonClick(object sender, EventArgs e)
        {
            /*
             * If watcher is running - stop and enable select directory buttons
             */
            if (running)
            {
                watcher.EnableRaisingEvents = false;
                watcher2.EnableRaisingEvents = false;
                running = false;
                btn_start.Text = "START";

                btn_dir.Enabled = true;
                btn_file1.Enabled = true;
                btn_file2.Enabled = true;
                btn_output.Enabled = true;
            }

            /*
             * If watcher is waiting - start and disable select directory buttons
             */
            else
            {
                watchDirectory1();
                watchDirectory2();
                running = true;
                btn_start.Text = "STOP";

                btn_dir.Enabled = false;
                btn_file1.Enabled = false;
                btn_file2.Enabled = false;
                btn_output.Enabled = false;

                readWrite();
            }
            
        }

        /*
         * Select directory button
         */
        private void button1_Click_1(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    directory = fbd.SelectedPath;
                    Properties.Settings.Default.directory = directory;
                    Properties.Settings.Default.Save();
                    updateLabels();
                }
            }
        }


        /*
         * select file 1 button
         */
        private void btn_file1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename1 = openFileDialog1.SafeFileName;
                file1 = openFileDialog1.FileName;
                Properties.Settings.Default.file1 = file1;
                Properties.Settings.Default.filename1 = filename1;
                Properties.Settings.Default.Save();
                updateLabels();
            }
        }


        /*
         * select file 2 button
         */
        private void btn_file2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename2 = openFileDialog1.SafeFileName;
                file2 = openFileDialog1.FileName;
                Properties.Settings.Default.file2 = file2;
                Properties.Settings.Default.filename2 = filename2;
                Properties.Settings.Default.Save();
                updateLabels();
            }
        }


        /*
         * select output file button
         */
        private void btn_output_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputPath = openFileDialog1.FileName;
                Properties.Settings.Default.outputFile = outputPath;
                Properties.Settings.Default.Save();
                updateLabels();
            }
        }
    }
}
