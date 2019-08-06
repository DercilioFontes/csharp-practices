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
    /// Interaction logic for CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        public static DependencyProperty SuitProperty = DependencyProperty.Register(
            "Suit",
            typeof(Ch13CardLib.Suit),
            typeof(CardControl),
            new PropertyMetadata(Ch13CardLib.Suit.Club,
                new PropertyChangedCallback(OnSuitChanged)));
        public static DependencyProperty RankProperty = DependencyProperty.Register(
            "Rank",
            typeof(Ch13CardLib.Rank),
            typeof(CardControl),
            new PropertyMetadata(Ch13CardLib.Rank.Ace));
        public static DependencyProperty IsFaceUpProperty = DependencyProperty.Register(
            "IsFaceUp",
            typeof(bool),
            typeof(CardControl),
            new PropertyMetadata(true, new PropertyChangedCallback(OnIsFaceUpChanged)));

        public bool IsFaceUp
        {
            get { return (bool)GetValue(IsFaceUpProperty); }
            set { SetValue(IsFaceUpProperty, value); }
        }
        public Ch13CardLib.Suit Suit
        {
            get { return (Ch13CardLib.Suit)GetValue(SuitProperty); }
            set { SetValue(SuitProperty, value); }
        }

        public Ch13CardLib.Rank Rank
        {
            get { return (Ch13CardLib.Rank)GetValue(RankProperty); }
            set { SetValue(RankProperty, value); }
        }
        public CardControl()
        {
            InitializeComponent();
        }
    }
}
