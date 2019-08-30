using System.Windows;
using System.Windows.Input;

namespace KarliCards_Gui
{
    /// <summary>
    /// Interaction logic for GameClient.xaml
    /// </summary>
    public partial class GameClient : Window
    {
        public GameClient()
        {
            InitializeComponent();
        }

        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			if (e.Command == ApplicationCommands.Close)
				e.CanExecute = true;
			if (e.Command == ApplicationCommands.Save)
				e.CanExecute = false;
            if (e.Command == GameViewModel.StartGameCommand)
                e.CanExecute = true;
            if (e.Command == GameOptions.OptionsCommand)
                e.CanExecute = true;
            if (e.Command == GameViewModel.ShowAboutCommand)
                e.CanExecute = true;
			e.Handled = true;
		}

        private void CommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Command == ApplicationCommands.Close)
                Close();
            if(e.Command == GameViewModel.StartGameCommand)
            {
                var model = new GameViewModel();
                StartGame startGameDialog = new StartGame();
                var options = GameOptions.Create();
                startGameDialog.DataContext = options;
                var result = startGameDialog.ShowDialog();
                if(result.HasValue && result.Value == true)
                {
                    options.Save();
                    model.StartNewGame();
                    DataContext = model;
                }
            }
            if(e.Command == GameOptions.OptionsCommand)
            {
                var dialog = new Options();
                var result = dialog.ShowDialog();
                if (result.HasValue && result.Value == true)
                    DataContext = new GameViewModel();
            }
            if(e.Command == GameViewModel.ShowAboutCommand)
            {
                var dialog = new About();
                dialog.ShowDialog();
            }
			e.Handled = true;
		}
    }
}
