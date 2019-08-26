using Ch13CardLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using System.Xml.Serialization;

namespace KarliCards_Gui
{
    [Serializable]
    public class GameOptions : INotifyPropertyChanged
    {
        private ObservableCollection<string> _playerNames = new ObservableCollection<string>();
        public List<string> SelectedPlayers { get; set; }
        private bool _playAgainstComputer = true;
        private int _numberOfPlayers = 2;
        private ComputerSkillLevel _computerSkill = ComputerSkillLevel.Dumb;
        public static RoutedCommand OptionsCommand = new RoutedCommand("Show Options", typeof(GameOptions), new InputGestureCollection(new List<InputGesture> { new KeyGesture(Key.O, ModifierKeys.Control) }));
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set
            {
                _numberOfPlayers = value;
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }
        public bool PlayAgainstComputer
        {
            get { return _playAgainstComputer; }
            set
            {
                _playAgainstComputer = value;
                OnPropertyChanged(nameof(PlayAgainstComputer));
            }
        }
        public ComputerSkillLevel ComputerSkill
        {
            get { return _computerSkill; }
            set
            {
                _computerSkill = value;
                OnPropertyChanged(nameof(ComputerSkill));
            }
        }

        public GameOptions()
        {
            SelectedPlayers = new List<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> PlayerNames
        {
            get
            {
                return _playerNames;
            }
            set
            {
                _playerNames = value;
                OnPropertyChanged("PlayerNames");
            }
        }

        public void AddPlayer(string playerName)
        {
            if (_playerNames.Contains(playerName))
                return;
            _playerNames.Add(playerName);
            OnPropertyChanged("PlayerNames");
        }

        public void Save()
        {
            using(var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, this);
            }
        }

        public static GameOptions Create()
        {
            if (File.Exists("GameOptions.xml"))
            {
                using (var stream = File.OpenRead("GameOptions.xml"))
                {
                    var serializer = new XmlSerializer(typeof(GameOptions));
                    return serializer.Deserialize(stream) as GameOptions;
                }
            }
            else
                return new GameOptions();
        }

    }

}
