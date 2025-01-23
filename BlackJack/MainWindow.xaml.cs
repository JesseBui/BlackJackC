using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlackJack.Engine;


namespace BlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BjEngine engine;
        String path = "Image\\PNG-cards-1.3\\";
        public MainWindow()
        {
            InitializeComponent();
            engine = new BjEngine();
            engine.Start();
            RefreshCardsOnScreen();
        }

        public void RefreshCardsOnScreen()
        {
            DealerPanel.Children.Clear();
            PlayerPanel.Children.Clear();
            foreach (Card c in engine.getDealerCard())
            {
                ShowCard(c, DealerPanel);
            }
            foreach (Card c in engine.getPlayerCard())
            {
                ShowCard(c, PlayerPanel);
            }
        }

        public void restart()
        {
            engine.ResetPlayerScore();
            engine.ResetDealerScore();
            DealerPanel.Children.Clear();
            PlayerPanel.Children.Clear();
            HitButton.IsEnabled = true;
            StandButton.IsEnabled = true;
            engine.Start();
            RefreshCardsOnScreen();
        }

        private void ShowCard(Card card, WrapPanel panel)
        {

            ImageSource imageSource = new BitmapImage(new Uri(path + card.GetImageFileName()));

            Image image = new Image();
            image.Source = imageSource;
            image.Margin = new Thickness(5);

            panel.Children.Add(image);
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = engine.Hit();

            if (!result)
            {
                MessageBox.Show("Busted");
                HitButton.IsEnabled = false;
                StandButton.IsEnabled = false;
            }

            RefreshCardsOnScreen();
        }

        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stand");
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            restart();

        }


    }
}