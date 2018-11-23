﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace WPFTests
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _systemInformation;

        private bool is64BitSystem = (IntPtr.Size == 8);

        private string sysdrive = "YOLO\\:";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += DoItButDontInterruptMeDuh;
            bw.RunWorkerAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string SystemInformation { get => _systemInformation; set => _systemInformation = value; }

        //Stub
        public string getCPU()
        {
            return "Fancy CPU";
        }

        //Stub
        public string getRAMsize()
        {
            return "1 PB";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Stub
        private string av()
        {
            return "Whatever av means.";
        }

        private void DoItButDontInterruptMeDuh(object sender, DoWorkEventArgs e)
        {
            // Simulate loading time
            Thread.Sleep(5000);

            SystemInformation = getCPU();
            SystemInformation += "Memory:  " + getRAMsize() + Environment.NewLine;
            SystemInformation += "Free Space:  " + GetTotalFreeSpace(sysdrive) + " GB" + Environment.NewLine;
            if (is64BitSystem)
            {
                SystemInformation += getOS() + " 64bit" + Environment.NewLine;
            }
            else
            {
                SystemInformation += getOS() + " 32 Bit" + Environment.NewLine;
            }
            SystemInformation += "MAC Address : " + System.Text.RegularExpressions.Regex.Replace(GetMacAddress().ToString(), ".{2}", "$0 ") + Environment.NewLine;
            SystemInformation += av();
            OnPropertyChanged("SystemInformation");
        }

        //Stub
        private object GetMacAddress()
        {
            return "Macintoshstreet 1234";
        }

        //Stub
        private string getOS()
        {
            return "Cool OS";
        }

        //Stub
        private string GetTotalFreeSpace(object sysdrive)
        {
            return "0";
        }
    }
}