using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TheAwesomeClicker.Models
{
    public class Upgrade : Button
    {
        public Upgrade(string name, int changeValue, string path, double cost, bool IsBought = false)
        {
            Name = name;
            ChangeValue = changeValue;
            IconPath = path;
            Cost = cost;
            this.IsBought = IsBought;
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

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
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
