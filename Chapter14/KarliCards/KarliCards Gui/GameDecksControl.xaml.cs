using Ch13CardLib;
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

namespace KarliCards_Gui
{
    /// <summary>
    /// Interaction logic for GameDecksControl.xaml
    /// </summary>
    public partial class GameDecksControl : UserControl
    {
        public GameDecksControl()
        {
            InitializeComponent();
        }

        public bool GameStarted
        {
            get { return (bool)GetValue(GameStartedProperty); }
            set { SetValue(GameStartedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GameStarted.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameStartedProperty =
            DependencyProperty.Register("GameStarted", typeof(bool), typeof(GameDecksControl), new PropertyMetadata(false));

        public Player CurrentPlayer
        {
            get { return (Player)GetValue(CurrentPlayerProperty); }
            set { SetValue(CurrentPlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPlayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPlayerProperty =
            DependencyProperty.Register("CurrentPlayer", typeof(Player), typeof(GameDecksControl), new PropertyMetadata(null));

        public Deck Deck
        {
            get { return (Deck)GetValue(DeckProperty); }
            set { SetValue(DeckProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Deck.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeckProperty =
            DependencyProperty.Register("Deck", typeof(Deck), typeof(GameDecksControl), new PropertyMetadata(null));

        public Card AvailableCard
        {
            get { return (Card)GetValue(AvailableCardProperty); }
            set { SetValue(AvailableCardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AvailableCard.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AvailableCardProperty =
            DependencyProperty.Register("AvailableCard", typeof(Card), typeof(GameDecksControl), new PropertyMetadata(null));

    }
}
