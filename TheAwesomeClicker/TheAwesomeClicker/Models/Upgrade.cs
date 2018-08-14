using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;

namespace TheAwesomeClicker.Models
{
    
    public class Upgrade : Button
    {
        public Upgrade(string name, int changeValue, string iconPath, double cost, bool IsBought = false)
        {
            Name = name;
            ChangeValue = changeValue;
            IconPath = iconPath;
            Cost = cost;
            this.IsBought = IsBought;
            this.Content = $"{Name} Price: {Cost}";
        }
        
        private int changeValue;

        public int ChangeValue
        {
            get { return changeValue; }
            set { changeValue = value; }
        }

        private bool isBought;

        public bool IsBought
        {
            get { return isBought; }
            set { isBought = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string iconPath;

        public string IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }

        private double cost;

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        
    }
}