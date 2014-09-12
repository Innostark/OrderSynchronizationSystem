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
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                mainForm.ApplicationStatusUpdate("Auto Synchronization started.");
                Thread.Sleep(5000);
            }            
        }
    }
}
