using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace DataParallelismWithForEach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // New Window-level variable.
        private CancellationTokenSource _cancelToken;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            // This will be used to tell all the worker threads to stop!
            _cancelToken.Cancel();
        }
        private void cmdProcess_Click(object sender, EventArgs e)
        {
            _cancelToken = new CancellationTokenSource();
            // Start a new "task" to process the files.
            Task.Factory.StartNew(() => ProcessFiles());
            //Can also be written this way
            //Task.Factory.StartNew(ProcessFiles);
        }
        private void ProcessFiles()
        {
            // Use ParallelOptions instance to store the CancellationToken.
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = _cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
            // Load up all *.jpg files, and make a new folder for the modified data.
            string[] files = Directory.GetFiles(@".\TestPictures", "*.jpg", SearchOption.AllDirectories);
            string outputDirectory = @".\ModifiedPictures";
            Directory.CreateDirectory(outputDirectory);
            try
            {
                // Process the image data in a parallel manner!
                Parallel.ForEach(files, parOpts, currentFile =>
                {
                    parOpts.CancellationToken.ThrowIfCancellationRequested();
                    string filename = Path.GetFileName(currentFile);
                    Dispatcher?.Invoke(() =>
                    {
                        this.Title =
                        $"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}";
                    });
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(outputDirectory, filename));
                    }
                });
                Dispatcher?.Invoke(() => this.Title = "Done!");
            }
            catch (OperationCanceledException ex)
            {
                Dispatcher?.Invoke(() => this.Title = ex.Message);
            }
        }
    }
}
