﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace KarliCards_Gui
{
    /// <summary>
    /// Interaction logic for StartGame.xaml
    /// </summary>
    public partial class StartGame : Window
    {
        private GameOptions _gameOptions;

        public StartGame()
        {
            InitializeComponent();
            DataContextChanged += StartGame_DataContextChanged;
        }

        private void ChangeListBoxOptions()
        {
            if (_gameOptions.PlayAgainstComputer)
                playerNamesListBox.SelectionMode = SelectionMode.Single;
            else
                playerNamesListBox.SelectionMode = SelectionMode.Extended;
        }

        void StartGame_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _gameOptions = DataContext as GameOptions;
            ChangeListBoxOptions();
        }

        private void playerNamesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_gameOptions.PlayAgainstComputer)
                okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == 1);
            else
                okButton.IsEnabled = (playerNamesListBox.SelectedItems.Count == _gameOptions.NumberOfPlayers);
        }

        private void addNewPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(newPlayerTextBox.Text))
                _gameOptions.AddPlayer(newPlayerTextBox.Text);
            newPlayerTextBox.Text = string.Empty;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            var gameOptions = DataContext as GameOptions;
            gameOptions.SelectedPlayers = new List<string>();
            foreach (string item in playerNamesListBox.SelectedItems)
                gameOptions.SelectedPlayers.Add(item);
            DialogResult = true;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameOptions = null;
            Close();
        }
    }
}
