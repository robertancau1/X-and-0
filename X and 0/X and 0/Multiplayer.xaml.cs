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
using System.Windows.Shapes;

namespace X_and_0
{
    /// <summary>
    /// Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : Window, ICoreMembers
    {
        public string one { get => this.One.Content.ToString(); set => this.One.Content = value; }
        public string two { get => this.Two.Content.ToString(); set => this.Two.Content = value; }
        public string three { get => this.Three.Content.ToString(); set => this.Three.Content = value; }
        public string four { get => this.Four.Content.ToString(); set => this.Four.Content = value; }
        public string five { get => this.Five.Content.ToString(); set => this.Five.Content = value; }
        public string six { get => this.Six.Content.ToString(); set => this.Six.Content = value; }
        public string seven { get => this.Seven.Content.ToString(); set => this.Seven.Content = value; }
        public string eight { get => this.Eight.Content.ToString(); set => this.Eight.Content = value; }
        public string nine { get => this.Nine.Content.ToString(); set => this.Nine.Content = value; }
        public bool Player1 { get; set; }
        private bool IsGameFinished { get; set; }
        public List<Button> Position { get; set; }

        public Multiplayer()
        {
            InitializeComponent();
            this.Player1 = true;
            UpdateArray();
        }
        private void One_Click(object sender, RoutedEventArgs e)
        {
            one = Check(Player1,one);
            UpdateArray();
            IsGameOver(Position);
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            two = Check(Player1,two);
            UpdateArray();
            IsGameOver(Position);
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            three = Check(Player1,three);
            UpdateArray();
            IsGameOver(Position);
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            four = Check(Player1,four);
            UpdateArray();
            IsGameOver(Position);
        }
        private void Five_Click(object sender, RoutedEventArgs e)
        {
            five = Check(Player1,five);
            UpdateArray();
            IsGameOver(Position);
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {
            six = Check(Player1,six);
            UpdateArray();
            IsGameOver(Position);
        }
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            seven = Check(Player1,seven);
            UpdateArray();
            IsGameOver(Position);
        }
        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            eight = Check(Player1,eight);
            UpdateArray();
            IsGameOver(Position);
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            nine = Check(Player1,nine);
            UpdateArray();
            IsGameOver(Position);
        }
        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            if (IsGameFinished)
            {
                GameOver(true);
                GC.Collect();
                this.PlayerName.Text = "Pick your position (X)";
                this.PlayAgain.Opacity = 0;
                this.BackToMenu.Opacity = 0;
                foreach (Button btn in Position)
                {
                    btn.Content = "";
                }
            }
        }
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            MainWindow objMainWindow = new MainWindow();
            this.Close();
            objMainWindow.Show();
        }
        public string Check(bool isPlayer1, string position)
        {
            if (isPlayer1)
            {
                if (position == "")
                {
                    this.PlayerName.Text = "0 is choosing";
                    this.Player1 = false;
                    return "X";
                }
                else if (position == "X")
                {
                    this.PlayerName.Text = "X is choosing";
                    this.Player1 = true;
                    return "X";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                if (position == "")
                {
                    this.PlayerName.Text = "X is choosing";
                    this.Player1 = true;
                    return "0";
                }
                else if (position == "0")
                {
                    this.PlayerName.Text = "0 is choosing";
                    Player1 = false;
                    return "0";
                }
                else
                {
                    return "X";
                }
            }
        }
        public void GameOver(bool ok)
        {
            this.One.IsEnabled = ok;
            this.Two.IsEnabled = ok;
            this.Three.IsEnabled = ok;
            this.Four.IsEnabled = ok;
            this.Five.IsEnabled = ok;
            this.Six.IsEnabled = ok;
            this.Seven.IsEnabled = ok;
            this.Eight.IsEnabled = ok;
            this.Nine.IsEnabled = ok;
        }
        public void UpdateArray()
        {
            this.Position = new List<Button>();
            Position.Add(One);
            Position.Add(Two);
            Position.Add(Three);
            Position.Add(Four);
            Position.Add(Five);
            Position.Add(Six);
            Position.Add(Seven);
            Position.Add(Eight);
            Position.Add(Nine);
        }
        public void IsGameOver(List<Button> array)
        {
            void Checkwin(int i)
            {
                if (array[i].Content.ToString() == "X")
                {
                    this.PlayerName.Text = "X has Won the game!";
                }
                else
                {
                    this.PlayerName.Text = "0 has Won the game!";
                }
            }
            void EnableButton()
            {
                GC.Collect();
                GameOver(false);
                this.IsGameFinished = true;
                this.PlayAgain.Opacity = 1;
                this.BackToMenu.Opacity = 1;
            }
            int counter = 0;
            for (int i = 0; i < 9; i++)
            {
                // equal
                if (array[i].Content.ToString() != "")
                {
                    counter++;
                }
            }
            // end game
            if (counter == 9)
            {
                EnableButton();
                this.PlayerName.Text = "Ended in a draw!";
            }
            // 123
            if (array[0].Content.ToString() != string.Empty && array[0].Content.ToString() == array[1].Content.ToString() && array[1].Content.ToString() == array[2].Content.ToString())
            {
                EnableButton();
                Checkwin(0);
            }
            // 456
            if (array[3].Content.ToString() != string.Empty && array[3].Content.ToString() == array[4].Content.ToString() && array[4].Content.ToString() == array[5].Content.ToString())
            {
                EnableButton();
                Checkwin(3);
            }
            // 789
            if (array[6].Content.ToString() != string.Empty && array[6].Content.ToString() == array[7].Content.ToString() && array[7].Content.ToString() == array[8].Content.ToString())
            {
                EnableButton();
                Checkwin(6);
            }
            // 147
            if (array[0].Content.ToString() != string.Empty && array[0].Content.ToString() == array[3].Content.ToString() && array[3].Content.ToString() == array[6].Content.ToString())
            {
                EnableButton();
                Checkwin(0);
            }
            // 258
            if (array[1].Content.ToString() != string.Empty && array[1].Content.ToString() == array[4].Content.ToString() && array[4].Content.ToString() == array[7].Content.ToString())
            {
                EnableButton();
                Checkwin(1);
            }
            // 369
            if (array[2].Content.ToString() != string.Empty && array[2].Content.ToString() == array[5].Content.ToString() && array[5].Content.ToString() == array[8].Content.ToString())
            {
                EnableButton();
                Checkwin(2);
            }
            // 159
            if (array[0].Content.ToString() != string.Empty && array[0].Content.ToString() == array[4].Content.ToString() && array[4].Content.ToString() == array[8].Content.ToString())
            {
                EnableButton();
                Checkwin(0);
            }
            // 357
            if (array[2].Content.ToString() != string.Empty && array[2].Content.ToString() == array[4].Content.ToString() && array[4].Content.ToString() == array[6].Content.ToString())
            {
                EnableButton();
                Checkwin(2);
            }
        }
    }
}
