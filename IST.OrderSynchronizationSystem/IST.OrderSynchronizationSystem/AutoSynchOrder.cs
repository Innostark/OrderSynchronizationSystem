using System.Threading;
using System.Windows.Forms;

namespace IST.OrderSynchronizationSystem
{
    public class AutoSynchOrder
    {
        public readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public void Process(Form mainWindow, int frequency)
        {
            MainWindow mainForm = (MainWindow)mainWindow;
            mainForm.ApplicationStatusUpdate("Auto Synchronization started.");
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                MessageBox.Show("Started");
                Thread.Sleep(5000);
            }
            MessageBox.Show("Stopped");
        }
    }
}
