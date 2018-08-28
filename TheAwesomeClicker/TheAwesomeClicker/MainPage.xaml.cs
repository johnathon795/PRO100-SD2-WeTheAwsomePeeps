using System;
using System.IO;
using System.Linq;
using TheAwesomeClicker.Models;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.Storage.AccessCache;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using ProtoBuf;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Windows.UI.Xaml.Data;

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

        StorageFolder def = ApplicationData.Current.LocalFolder;

        XmlSerializer serializer = new XmlSerializer(typeof(Game));
        private bool loadingFile = false;
        public MainPage()
        {
            this.InitializeComponent();

            //if (game == null)
            //{
            game = new Game();
            game.MakeUpgrade();
            upgradesListView.ItemsSource = game.UpgradesList;
            //}
            //;
            mp.Play();

            this.Loaded += new RoutedEventHandler(Page_Loaded);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGame(null, null);
        }

        private void Up_Tapped(object sender, TappedRoutedEventArgs e)
        {

            var selectedItemContainer = (ListViewItem)((ListView)sender).ContainerFromItem(((ListView)sender).SelectedItem);
            Upgrade selectedUpgrade = game.UpgradesList[((ListView)sender).SelectedIndex];

            game.CanAfford(selectedUpgrade);


            if (selectedUpgrade.IsBought) selectedItemContainer.IsEnabled = false;

        }

        private void Clicker_Tapped(object sender, PointerRoutedEventArgs e)
        {
            game.TotalCoin += game.ClickAmount;
            Storyboard.Begin();
            Random r = new Random();
            int x = r.Next(0, 1000);
            if (x == 500) game.TotalCoin += 1000;
            rateBox.Text = game.TotalCoin.ToString();
            pointsBox.Text = game.ClickAmount.ToString();
        }

        public async void SaveGame(object sender, RoutedEventArgs e)
        {
            StorageFile f = await def.GetFileAsync("sgd.dat");
            IRandomAccessStream iras = await f?.OpenAsync(FileAccessMode.ReadWrite);
            iras.Size = 0;
            //using (Stream s = Task.Run(() => iras.AsStreamForWrite()).Result) Serializer.Serialize(s, game);
            using (Stream s = Task.Run(() => iras.AsStreamForWrite()).Result) serializer.Serialize(s, game);
            SaveCard.Begin();
        }

        public async void LoadGame(object sender, RoutedEventArgs e)
        {
            StorageFile f;
            FileInfo fi = new FileInfo(def.Path + "\\sgd.dat");
            f = fi.Exists ? await def.GetFileAsync("sgd.dat") : await def.CreateFileAsync("sgd.dat");

            if (fi.Length == 0) game = null;
            else
            {
                using (Stream s = await f?.OpenStreamForReadAsync()) game = (Game)serializer.Deserialize(s);
                upgradesListView.ItemsSource = game.UpgradesList;
                loadingFile = true;
                UpdateLayout();
                for (int i = 0; i < game.UpgradesList.Count; i++)
                {
                    upgradesListView.SelectedIndex = i;
                }
                loadingFile = false;

            }
            rateBox.Text = game.TotalCoin.ToString();
            pointsBox.Text = game.ClickAmount.ToString();

        }

        public async void DeleteSave(object sender, RoutedEventArgs e)
        {
            await (await def.GetFileAsync("sgd.dat")).DeleteAsync();
        }

        private void MuteAudio(object sender, RoutedEventArgs e)
        {
            mp.IsMuted = !mp.IsMuted;
            foreach (MediaPlayer gmp in game.AudioPlayers)
            {
                gmp.IsMuted = !gmp.IsMuted;
            }
        }

        private void upgradesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!loadingFile) return;
            ListView x = upgradesListView;

            var y = x.SelectedItem;

            var selected = (ListViewItem)x.ContainerFromItem(y);
            Upgrade selectedUpgrade = game.UpgradesList[((ListView)sender).SelectedIndex];

            if (selectedUpgrade.IsBought) selected.IsEnabled = false;
        }
    }
}
