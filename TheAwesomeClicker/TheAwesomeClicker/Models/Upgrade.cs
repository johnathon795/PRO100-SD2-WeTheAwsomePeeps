using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace TheAwesomeClicker.Models
{
    [ProtoContract]
    public class Upgrade
    {
        public Upgrade(string name, ulong changeValue, string iconPath, ulong cost, bool isBought = false)
        {
            Title = name;
            ChangeValue = changeValue;
            IconPath = iconPath;
            Cost = cost;
            IsBought = isBought;
            //StackPanel panel = new StackPanel();
            //Image image = new Image()
            //{
            //    Source = new BitmapImage(new Uri(IconPath)),
            //    Stretch = Windows.UI.Xaml.Media.Stretch.UniformToFill
            //};
            //TextBlock text = new TextBlock()
            //{
            //    Text = $"{Title} Price: {Cost}"

            //};
            //panel.Children.Add(image);
            //panel.Children.Add(text);
            //Width = 150;
            //Height = 150;
            //Content = panel;
        }

        public Upgrade()
        {
            
            //this.Content = $"{Name} Price: {Cost}";
        }
        
        private ulong changeValue;
        [ProtoMember(1)]
        public ulong ChangeValue
        {
            get { return changeValue; }
            set { changeValue = value; }
        }

        private bool isBought;
        [ProtoMember(2)]
        public bool IsBought
        {
            get { return isBought; }
            set { isBought = value; }
        }

        private string title;
        [ProtoMember(3)]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string iconPath;
        [ProtoMember(4)]
        public string IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }

        private ulong cost;
        [ProtoMember(5)]
        public ulong Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        
    }
}