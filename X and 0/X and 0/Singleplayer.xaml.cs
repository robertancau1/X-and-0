using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Singleplayer.xaml
    /// </summary>
    public partial class Singleplayer : Window, ICoreMembers
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
        private List<Button> FreePositions { get; set; }

        public Singleplayer()
        {
            InitializeComponent();
            UpdateArray();
            SelectFirstPick();
        }
        private void One_Click(object sender, RoutedEventArgs e)
        {
            one = Check(one);
            IsGameOver(Position);
            Logic();
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            two = Check(two);
            IsGameOver(Position);
            Logic();
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            three = Check(three);
            IsGameOver(Position);
            Logic();
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            four = Check(four);
            IsGameOver(Position);
            Logic();
        }
        private void Five_Click(object sender, RoutedEventArgs e)
        {
            five = Check(five);
            IsGameOver(Position);
            Logic();
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {

            six = Check(six);
            IsGameOver(Position);
            Logic();
        }
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            seven = Check(seven);
            IsGameOver(Position);
            Logic();
        }
        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            eight = Check(eight);
            IsGameOver(Position);
            Logic();
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            nine = Check(nine);
            IsGameOver(Position);
            Logic();
        }
        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            if (IsGameFinished)
            {
                GC.Collect();
                this.PlayerName.Text = "Pick your position (X)";
                this.PlayAgain.Opacity = 0;
                this.BackToMenu.Opacity = 0;
                this.IsGameFinished = false;
                GameOver(true);
                foreach(Button btn in Position)
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
        private void Logic()
        {
            if (!IsGameFinished && !Player1)
            {
                FreeSlotsUpdate();
                if (FreePositions.Count > 0)
                {
                    this.FreePositions[GenerateNumber(FreePositions.Count)].Content = "0";
                }
                UpdateArray();
                IsGameOver(Position);
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
            this.FreePositions = new List<Button>();
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
        private void SelectFirstPick()
        {
            var rand = new Random();
            if (rand.Next(2) == 1)
            {
                Logic();
            }
        }

        public string Check (string position)
        {
            if (position == "")
            {
                this.Player1 = false;
                return "X";
            }
            else if (position == "X")
            {
                this.Player1 = true;
                return "X";
            }
            else
            {
                this.Player1 = true;
                return "0";
            }
        }
        private void FreeSlotsUpdate()
        {
            for (int i = 0; i < Position.Count; i++)
            {
                if (Position[i].Content.ToString() == "")
                {
                    FreePositions.Add(Position[i]);
                }
            }
        }
        private int GenerateNumber(int number)
        {
            var rand = new Random();
            return rand.Next(number);
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
