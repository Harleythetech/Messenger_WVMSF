using Microsoft.Web.WebView2.Core;
using System.ComponentModel;

namespace Messenger
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker;
        private Messenger msg;
        private TaskCompletionSource<bool> initializationTcs;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            // Initialize Form2 and TaskCompletionSource
            msg = new Messenger();
            initializationTcs = new TaskCompletionSource<bool>();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += MessengerPreload_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void MessengerPreload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                worker.ReportProgress(25, "Initializing WebView2...");

                // Wait for the handle to be created
                while (!this.IsHandleCreated)
                {
                    Thread.Sleep(100); // Small delay to avoid busy-waiting
                }

                // Initialize WebView2 on UI thread
                this.Invoke(new Action(() => {
                    InitializeWebView();
                }));

                // Wait for initialization to complete
                Thread.Sleep(2000);
                worker.ReportProgress(50, "Loading webpage...");

                // Navigate to the webpage on UI thread
                this.Invoke(new Action(() => {
                    if (msg.Browssenger.CoreWebView2 != null)
                    {
                        msg.Browssenger.Source = new Uri("https://www.messenger.com/");
                    }
                }));

                Thread.Sleep(2000);
                worker.ReportProgress(75, "Almost there...");
                Thread.Sleep(1000);
                worker.ReportProgress(100, "Complete!");
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private async void InitializeWebView()
        {
            try
            {
                if (msg.Browssenger != null)
                {
                    var environment = await CoreWebView2Environment.CreateAsync();
                    await msg.Browssenger.EnsureCoreWebView2Async(environment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"WebView2 Initialization Error: {ex.Message}");
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = e.UserState as string;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Invoke(new Action(() =>
            {
                msg.Show();
                this.Hide();
            }));
        }
    }
}