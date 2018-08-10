using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
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
        static Game game;
        StorageFolder folder = ApplicationData.Current.LocalFolder;
        public DataContractSerializer js = new DataContractSerializer(typeof(Game));
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

        }

        public async void SaveGame(object sender, RoutedEventArgs e)
        {
            StorageFile f = await folder.CreateFileAsync("sgd.xml", CreationCollisionOption.ReplaceExisting);
            
            //js.WriteObject(f, game);
            //FileStream f = new FileStream("../sgd.xml", FileMode.Create);

        }

        public void LoadGame(object sender, RoutedEventArgs e)
        {

            FileStream f = new FileStream("sgd.xml", FileMode.Open);
            game = (Game)js.ReadObject(f);
            f.Close();
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
