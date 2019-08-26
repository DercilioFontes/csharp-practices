using Ch13CardLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarliCards_Gui
{
    class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private Player _currentPlayer;
        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        private List<Player> _players;
        public List<Player> Players
        {
            get { return _players; }
            set
            {
                _players = value;
            }
        }

        private Card _availableCard;
        public Card CurrentAvailableCard
        {
            get { return _availableCard; }
            set
            {
                _availableCard = value;
            }
        }

        private Card _deck;
        public Card GameDeck
        {
            get { return _deck; }
            set
            {
                _deck = value;
            }
        }

        private bool _gameStarted;
        public bool GameStarted
        {
            get { return _gameStarted; }
            set
            {
                _gameStarted = value;
            }
        }

        private GameOptions _gameOptions;
    }
}
