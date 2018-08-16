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
            game = new Game()
            {

            };
            upgradesListBox.ItemsSource = game.UpgradesList;
            foreach (Upgrade up in game.UpgradesList) up.Tapped += Up_Tapped;

            mp.Play();

        }

        private void Up_Tapped(object sender, TappedRoutedEventArgs e)
        {
            game.CanAfford((Upgrade)sender);
        }

        private void Clicker_Tapped(object sender, PointerRoutedEventArgs e)
        {
            game.TotalCoin += game.ClickAmount;
        }

        public async void SaveGame(object sender, RoutedEventArgs e)
        {
            StorageFile f = await def.GetFileAsync("sgd.dat");
            IRandomAccessStream iras = await f?.OpenAsync(FileAccessMode.ReadWrite);
            iras.Size = 0;
            using (Stream s = Task.Run(() => iras.AsStreamForWrite()).Result) Serializer.Serialize(s, game);
            //SaveCard.Begin();
        }

        public async void LoadGame(object sender, RoutedEventArgs e)
        {
            StorageFile f;
            FileInfo fi = new FileInfo(def.Path + "\\sgd.dat");
            f = fi.Exists ? await def.GetFileAsync("sgd.dat") : await def.CreateFileAsync("sgd.dat");
            using (Stream s = await f?.OpenStreamForReadAsync()) game = Serializer.Deserialize<Game>(s);
            upgradesListBox.ItemsSource = game;
        }

        public async void DeleteSave()
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
