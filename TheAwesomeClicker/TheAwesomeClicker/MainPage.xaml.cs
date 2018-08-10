using System;
using System.Collections.Generic;
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
            foreach (Upgrade up in game.UpgradesList) up.Tapped += Up_Tapped;
        }

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
            //FileStream f = new FileStream("sgd.dat", FileMode.Create);
            //bf.Serialize(f, game);
            //f.Close();
        }

        public void LoadGame(object sender, RoutedEventArgs e)
        {
            //FileStream f = new FileStream("sgd.dat", FileMode.Open);
            //game = (Game)bf.Deserialize(f);
            //f.Close();
        }

        //public async void LoadGame(object sender, RoutedEventArgs e)
        //{
        //    // this reads XML content from a file ("filename") and returns an object from the XML
        //    Game objectFromXml = default(Game);
        //    var serializer = new XmlSerializer(typeof(Game));
        //    StorageFolder folder = ApplicationData.Current.LocalFolder;
        //    StorageFile file = await folder.GetFileAsync("sgd.xml");
        //    Stream stream = await file.OpenStreamForReadAsync();
        //    objectFromXml = (Game)serializer.Deserialize(stream);
        //    stream.Dispose();
        //    game = objectFromXml;
        //}

        //public async void SaveGame(object sender, RoutedEventArgs e)
        //{
        //    // stores an object in XML format in file called 'filename'
        //    XmlSerializer serializer = new XmlSerializer(typeof(Game));
        //    StorageFolder folder = ApplicationData.Current.LocalFolder;
        //    StorageFile file = await folder.CreateFileAsync("sgd.xml", CreationCollisionOption.ReplaceExisting);
        //    Stream stream = await file.OpenStreamForWriteAsync();

        //    using (stream)
        //    {
        //        serializer.Serialize(stream, game);
        //    }
        //}

    }

}
