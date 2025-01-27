﻿using System.Text;
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
    public partial class MainWindow : Window
    {
        BjEngine engine;
        String path = "D:\\C#\\BlackJackC\\Image\\PNG-cards-1.3\\";

        public MainWindow()
        {
            InitializeComponent();
            engine = new BjEngine();
            engine.Start();
            RefreshCardsOnScreen();
            UpdateChipsDisplay();
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
        //fix
        public void NewRound()
        {
            engine.ResetPlayerScore();
            engine.ResetDealerScore();
            DealerPanel.Children.Clear();
            PlayerPanel.Children.Clear();
            HitButton.IsEnabled = true;
            StandButton.IsEnabled = true;
            DecreaseButton.IsEnabled = true;
            IncreaseButton.IsEnabled = true;
            BetButton.IsEnabled = true;
            engine.Start();
            RefreshCardsOnScreen();
            UpdateChipsDisplay();
        }
        //fix
        public void NewGame()
        {
            engine.NewGame();
            DealerPanel.Children.Clear();
            PlayerPanel.Children.Clear();
            HitButton.IsEnabled = true;
            StandButton.IsEnabled = true;
            engine.Start();
            RefreshCardsOnScreen();
            UpdateChipsDisplay();
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
                engine.Playerlose();
            }
            RefreshCardsOnScreen();
        }

        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            engine.Stand();
            RefreshCardsOnScreen();
            UpdateChipsDisplay();
            HitButton.IsEnabled = false;
            StandButton.IsEnabled = false;
            if (engine.GetPlayerScore() > engine.GetDealerScore())
            {
                MessageBox.Show("Player Wins!");
                engine.PlayerWin();
                UpdateChipsDisplay();
            }
            else
            {
                MessageBox.Show("Dealer Wins!");
                engine.Playerlose();
                UpdateChipsDisplay();
            }
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            NewRound();
        }
        private void UpdateChipsDisplay()
        {
            PlayerChipsText.Text = engine.PlayerChips.ToString();
            CurrentBetText.Text = engine.CurrentBet.ToString();
        }
        private void IncreaseBetButton_Click(object sender, RoutedEventArgs e)
        {
            engine.IncreaseBet();
            UpdateChipsDisplay();
        }

        private void DecreaseBetButton_Click(object sender, RoutedEventArgs e)
        {
            engine.DecreaseBet();
            UpdateChipsDisplay();
        }
        private void BetButton_Click(object sender, RoutedEventArgs e)
        {
            if (engine.CurrentBet > engine.PlayerChips)
            {
                MessageBox.Show("Bet exceeds player's available chips.");
            }
            else
            {
                engine.PlaceBet(engine.CurrentBet);
                UpdateChipsDisplay();
                MessageBox.Show($"Bet placed: ${engine.CurrentBet}");
                BetButton.IsEnabled = false;
                DecreaseButton.IsEnabled = false;
                IncreaseButton.IsEnabled = false;
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }


    }
}