using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TheAwesomeClicker.Models
{
    [DataContract]
    public class Upgrade : Button, IExtensibleDataObject
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

        }

       [IgnoreDataMember] private int changeValue;

        [DataMember] public int ChangeValue
        {
            get { return changeValue; }
            set { changeValue = value; }
        }

        [IgnoreDataMember] private bool isBought;

        [DataMember] public bool IsBought
        {
            get { return isBought; }
            set { isBought = value; }
        }

        [IgnoreDataMember] private string title;

        [DataMember] public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [IgnoreDataMember] private string iconPath;

        public string IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }

        [IgnoreDataMember] private double cost;

        [DataMember] public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public ExtensionDataObject ExtensionData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
