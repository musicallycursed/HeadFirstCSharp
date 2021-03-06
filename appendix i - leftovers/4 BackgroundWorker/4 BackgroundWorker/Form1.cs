﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4_BackgroundWorker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Waste CPU cycles causing the program to slow down by doing calculations for 100ms
        /// </summary>
        private void WasteCPUCycles()
        {
            DateTime startTime = DateTime.Now;
            double value = Math.E;
            while (DateTime.Now<startTime.AddMilliseconds(100))
            {
                value /= Math.PI;
                value *= Math.Sqrt(2);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Value = 10;
            // The e.Argument property returns the argument that was passed to RunWorkerAsync()
            Console.WriteLine("Background worker argument: " + (e.Argument ?? "null"));

            // Start wasting CPU cycles
            for (int i = 1; i <= 100; i++)
            {
                WasteCPUCycles();
                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker1.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker1.CancellationPending)
                {
                    Console.WriteLine("Cancelled");
                    break;
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            goButton.Enabled = true;
            cancelButton.Enabled = false;
        }

        /// <summary>
        /// Clicking the Go button starts wasting CPU cycles for 10 seconds
        /// </summary>
        private void goButton_Click(object sender, EventArgs e)
        {
            goButton.Enabled = false;
            if (!useBackgroundWorkerCheckbox.Checked)
            {
                // If we're not using the background worker, just start wasting CPU cycles
                for (int i = 1; i <= 100; i++)
                {
                    WasteCPUCycles();
                    progressBar1.Value = i;
                }
                goButton.Enabled = true;
            }
            else
            {
                cancelButton.Enabled = true;

                // If we are using the background worker, use its RunWorkerAsync()
                // to tell it to start its work
                backgroundWorker1.RunWorkerAsync(new Guy("Bob", 37, 146));
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }
}
