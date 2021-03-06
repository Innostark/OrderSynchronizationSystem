﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IST.OrderSynchronizationSystem
{
    public partial class OrderSynchronizerTHubToMoldingBoxForm : Form
    {
        private bool Play = true;
        public OrderSynchronizerTHubToMoldingBoxForm()
        {
            InitializeComponent();
        }

        private void SynchronizeButton_Click(object sender, EventArgs e)
        {
            if (this.Play)
            {
                this.SynchronizeButton.ForeColor = Color.Red;
                this.SynchronizeButton.Text = "Stop";
                this.SynchronizeButton.Image = Properties.Resources.StopImage;
                this.Play = false;
            }
            else 
            {
                this.SynchronizeButton.ForeColor = Color.Green;
                this.SynchronizeButton.Text = "Start";
                this.SynchronizeButton.Image = Properties.Resources.PlayImage;
                this.Play = true;
            }
        }
    }
}
