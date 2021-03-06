﻿using CrozzleApp.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrozzleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog openFile = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler from Open file menu
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            openFile.Filter = "Text file (*.txt) | *.txt";
            if (openFile.ShowDialog() == true)
            {
                string file = openFile.FileName;
                fileName.Text = file;
                Crozzle crozzle = new Crozzle(file);
            }
            else
            {
                fileName.Text = "Felipe";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Log.WriteLogs();
            this.Close();
        }
    }
}
