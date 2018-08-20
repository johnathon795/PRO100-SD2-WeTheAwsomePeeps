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
    public class Upgrade : Button
    {
        public Upgrade(string name, int changeValue, string iconPath, double cost, bool isBought = false)
        {
            Name = name;
            ChangeValue = changeValue;
            IconPath = iconPath;
            Cost = cost;
            this.IsBought = isBought;
            StackPanel panel = new StackPanel();
            Image image = new Image()
            {
                Source = new BitmapImage(new Uri(IconPath))
                {
                    DecodePixelWidth = 100
                }
            };
            TextBlock text = new TextBlock()
            {
                Text = $"{Name} Price: {Cost}"
            };
            panel.Children.Add(image);
            panel.Children.Add(text);
            Content = panel;
        }

        public Upgrade()
        {
            
            this.Content = $"{Name} Price: {Cost}";
        }
        
        private int changeValue;
        [ProtoMember(1)]
        public int ChangeValue
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

        private double cost;
        [ProtoMember(5)]
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        
    }
}