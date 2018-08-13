using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TheAwesomeClicker.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playback;
using Windows.Media.Core;

namespace TheAwesomeClicker
{
    public sealed partial class MainPage : Page
    {
        Game game;
        MediaPlayer mp = new MediaPlayer
        {
            Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Theme.wav")),
            AudioCategory = MediaPlayerAudioCategory.GameMedia,
            Volume = 1,
            IsLoopingEnabled = true
        };
        public MainPage()
        {

            this.InitializeComponent();
            game = new Game()
            {

            };
            upgradesListBox.ItemsSource = game.UpgradesList;
            //game.PropertyChanged += Update_Coin;
            foreach (Upgrade up in game.UpgradesList) up.Tapped += Up_Tapped;

            mp.Play();

        }

        //private void Update_Coin(object sender, PropertyChangedEventArgs e)
        //{
        //    //if (e.PropertyName.Equals("TotalCoin"))
        //    //{
        //        //pointsBox.Text = game.TotalCoin.ToString();
        //    //}
        //}

        private void Up_Tapped(object sender, TappedRoutedEventArgs e)
        {
            game.CanAfford((Upgrade)sender);
        }

        private void Clicker_Tapped(object sender, TappedRoutedEventArgs e)
        {
            game.TotalCoin += game.ClickAmount;
        }

        public async void SaveGame(object sender, RoutedEventArgs e)
        {

        }

        public async void LoadGame(object sender, RoutedEventArgs e)
        {

        }

        private void MuteAudio(object sender, RoutedEventArgs e)
        {
            mp.IsMuted = !mp.IsMuted;
        }
    }

}
