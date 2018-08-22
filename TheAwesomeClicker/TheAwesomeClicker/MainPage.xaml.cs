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
        

        public MainPage()
        {
            this.InitializeComponent();
            LoadGame(null, null);
            if (game == null)
            {
                game = new Game()
                {
                    UpgradesList = new ObservableCollection<Upgrade>()
                };
                game.MakeUpgrade();
            }
            ;
            upgradesListView.ItemsSource = game.UpgradesList;
            mp.Play();

        }

        private void Up_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var selectedItemContainer = (ListViewItem)((ListView)sender).ContainerFromItem(((ListView)sender).SelectedItem);
            Upgrade selectedUpgrade = game.UpgradesList[((ListView)sender).SelectedIndex];

            game.CanAfford(selectedUpgrade);

            //if ();
            if (selectedUpgrade.IsBought)
            {
                selectedItemContainer.IsEnabled = false;
                //if (selectedUpgrade.IsBackground) 
            }

        }

        private void Clicker_Tapped(object sender, PointerRoutedEventArgs e)
        {
            game.TotalCoin += game.ClickAmount;
            Storyboard.Begin();
        }

        public async void SaveGame(object sender, RoutedEventArgs e)
        {
            StorageFile f = await def.GetFileAsync("sgd.dat");
            IRandomAccessStream iras = await f?.OpenAsync(FileAccessMode.ReadWrite);
            iras.Size = 0;
            using (Stream s = Task.Run(() => iras.AsStreamForWrite()).Result) Serializer.Serialize(s, game);
            SaveCard.Begin();
        }

        public async void LoadGame(object sender, RoutedEventArgs e)
        {
            StorageFile f;
            FileInfo fi = new FileInfo(def.Path + "\\sgd.dat");
            f = fi.Exists ? await def.GetFileAsync("sgd.dat") : await def.CreateFileAsync("sgd.dat");
            using (Stream s = await f?.OpenStreamForReadAsync()) game = Serializer.Deserialize<Game>(s);
            upgradesListView.ItemsSource = game.UpgradesList;
            if (fi.Length == 0) game = null;
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

    }

}
