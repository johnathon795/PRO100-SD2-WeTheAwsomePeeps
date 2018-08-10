using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TheAwesomeClicker.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TheAwesomeClicker
{
    public sealed partial class MainPage : Page
    {
        Game game;
        //BinaryFormatter bf = new BinaryFormatter();
        public MainPage()
        {
            this.InitializeComponent();
            game = new Game()
            {
                
            };
            upgradesListBox.ItemsSource = game.UpgradesList;
        }

        private void Clicker_Tapped(object sender, TappedRoutedEventArgs e)
        {
            game.TotalCoin += game.ClickAmount;
        }

        public void SaveGame()
        {
            //FileStream f = new FileStream("sgd.dat", FileMode.Create);
            //bf.Serialize(f, game);
            //f.Close();
        }

        public void LoadGame()
        {
            //FileStream f = new FileStream("sgd.dat", FileMode.Open);
            //game = (Game)bf.Deserialize(f);
            //f.Close();
        }
    }
}
