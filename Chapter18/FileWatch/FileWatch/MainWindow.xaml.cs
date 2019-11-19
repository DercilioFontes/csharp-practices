﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

namespace FileWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // File System Watcher object.
        private FileSystemWatcher watcher;

        public MainWindow()
        {
            InitializeComponent();
            watcher = new FileSystemWatcher();
            watcher.Deleted += (s, e) => AddMessage($"File: {e.FullPath} Deleted");
            watcher.Renamed += (s, e) => AddMessage($"File renamed from {e.OldName} to {e.FullPath}");
            watcher.Changed += (s, e) => AddMessage($"File: {e.FullPath} {e.ChangeType.ToString()}");
            watcher.Created += (s, e) => AddMessage($"File: {e.FullPath} Created");
        }

        private void AddMessage(string message)
        {
            Dispatcher.BeginInvoke(new Action(() => WatchOutput.Items.Insert(0, message)));
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog(this) == true)
            {
                LocationBox.Text = dialog.FileName;
            }
        }

        private void LocationBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WatchButton.IsEnabled = !string.IsNullOrEmpty(LocationBox.Text);
        }

        private void WatchButton_Click(object sender, RoutedEventArgs e)
        {
            watcher.Path = System.IO.Path.GetDirectoryName(LocationBox.Text);
            watcher.Filter = System.IO.Path.GetFileName(LocationBox.Text);
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.Size;
            AddMessage("Watching " + LocationBox.Text);

            // Begin watching
            watcher.EnableRaisingEvents = true;
        }
    }
}
