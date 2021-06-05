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

namespace X_and_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Multiplayer_Click(object sender, RoutedEventArgs e)
        {
            Multiplayer objMultiplayer = new Multiplayer();
            this.Close();
            objMultiplayer.Show();
        }

        private void Singleplayer_Click(object sender, RoutedEventArgs e)
        {
            Singleplayer objSingleplayer = new Singleplayer();
            this.Close();
            objSingleplayer.Show();
        }
    }
}
