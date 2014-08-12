using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using IST.OrderSynchronizationSystem.Properties;

namespace IST.OrderSynchronizationSystem
{
    public partial class MainWindow : Form
    {
        private bool autoSyncActive;
        private int autoSyncFrequency;
        private readonly AutoSynchOrder autoSyncOrder;
        delegate void SetTextCallback(string text);

        private OSSDatabase OrderSyncronizationDatabase;

        private OSSConnection sourceConnectionVariables;
        private OSSConnection stagingConnectionVariables;
        public MainWindow(bool programState)
        {            
            autoSyncActive = programState;
            autoSyncFrequency = 0;
            InitializeComponent();
            autoSyncOrder = new AutoSynchOrder();            
        }

        private void InitializeDatabaseParameters()
        {
            sourceConnectionVariables = new OSSConnection
            {
                ServerName = SourceServerTextBox.Text,
                DatabaseName = SourceDatabaseTextBox.Text,
                UserName = SourceUsernameTextBox.Text,
                Password = SourcePasswordTextBox.Text
            };
            stagingConnectionVariables = new OSSConnection
            {
                ServerName = StagingServerTextBox.Text,
                DatabaseName = StagingDatabaseTextBox.Text,
                UserName = StagingUserNameTextBox.Text,
                Password = StagingPasswordTextBox.Text
            };
            OrderSyncronizationDatabase = new OSSDatabase(sourceConnectionVariables, stagingConnectionVariables);
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SynchronizeButton_Click(object sender, EventArgs e)
        {
            if (!autoSyncActive)
            {
                StartAutoSychronization();
            }
            else
            {
                PauseAutoSychronization();
            }

        }

        private void StartPauseToggleButton(bool startSychronization)
        {
            if (startSychronization)
            {
                SynchronizeButton.Image = Resources.PauseImage;
                SynchronizeButton.Text = Resources.MainWindow_StartPauseToggle_Pause;
                autoSyncActive = true;
            }
            else
            {
                SynchronizeButton.Image = Resources.PlayImage;
                autoSyncActive = false;
                SynchronizeButton.Text = Resources.MainWindow_StartPauseToggle_Start;
            }
        }

        private void StartAutoSychronization()
        {
            if (!ValidateInput())
                return;
            InitializeDatabaseParameters();

            if (!VarifySourceDatabase())
            {
                toolStripStatus.Text = Resources.MainWindow_UnableToConnection_SourceDatabase;
                return;
            }
            if (!VarifyStagingDatabase())
            {
                toolStripStatus.Text = Resources.MainWindow_UnableToConnection_StagingDatabase;
                return;
            }
            StartPauseToggleButton(true);
            autoSyncFrequency = int.Parse(maskedTextBox1.Text);

            StartThread();

        }

        private void PauseAutoSychronization()
        {
            StartPauseToggleButton(false);
            StopThread();
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(SourceServerTextBox.Text))
            {
                errorProvider.SetError(SourceServerTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourceDatabaseTextBox.Text))
            {
                errorProvider.SetError(SourceDatabaseTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourceUsernameTextBox.Text))
            {
                errorProvider.SetError(SourceUsernameTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourcePasswordTextBox.Text))
            {
                errorProvider.SetError(SourcePasswordTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourcePasswordTextBox.Text))
            {
                errorProvider.SetError(SourcePasswordTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }

            if (string.IsNullOrEmpty(StagingServerTextBox.Text))
            {
                errorProvider.SetError(StagingServerTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(StagingDatabaseTextBox.Text))
            {
                errorProvider.SetError(StagingDatabaseTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(StagingUserNameTextBox.Text))
            {
                errorProvider.SetError(StagingUserNameTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(SourcePasswordTextBox.Text))
            {
                errorProvider.SetError(SourcePasswordTextBox, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                errorProvider.SetError(maskedTextBox1, Resources.MainWindow_Required_Field);
                isValid = false;
            }
            int minutes;
            if (!string.IsNullOrEmpty(maskedTextBox1.Text) && int.TryParse(maskedTextBox1.Text, out minutes))
            {
                if (minutes > 999 || minutes < 5)
                {
                    errorProvider.SetError(maskedTextBox1, Resources.MainWindow_MinutesRange);
                    isValid = false;
                }                
            }
            if (isValid)
            {
                errorProvider.Clear();
            }

            return isValid;
        }

        private void StartThread()
        {
            Task.Factory.StartNew(() => autoSyncOrder.Process(this, autoSyncFrequency));
        }
        private void StopThread()
        {
            autoSyncOrder.cancellationTokenSource.Cancel();
        }
        public void ApplicationStatusUpdate(string text)
        {
            SetApplicationStatusText(text);
        }
        private void SetApplicationStatusText(string text)
        {
            if (ApplicationStatusStrip.InvokeRequired)
            {
                SetTextCallback d = SetApplicationStatusText;
                Invoke(d, new object[] {text});
            }
            else
                toolStripStatus.Text = text;
        }

        private bool VarifySourceDatabase()
        {
            toolStripStatus.Text = Resources.MainWindow_VarifySourceDatabase_Checking_source_database;
            return OrderSyncronizationDatabase.VarifySourceDatabase();
        }
        private bool VarifyStagingDatabase()
        {
            toolStripStatus.Text = Resources.MainWindow_VarifySourceDatabase_Checking_Staging_database;
            return OrderSyncronizationDatabase.VarifySourceDatabase();
        }
    }
}
