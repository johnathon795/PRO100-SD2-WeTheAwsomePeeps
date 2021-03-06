using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace TheAwesomeClicker.Models
{
    
    public class Upgrade
    {
        public Upgrade(string name, ulong changeValue, string iconPath, ulong cost, bool isBought = false, bool isBackground = false, bool isAxe = false, bool isPerSecond = false)
        {
            this.Title = name;
            this.ChangeValue = changeValue;
            this.IconPath = iconPath;
            this.Cost = cost;
            this.IsBought = isBought;
            this.IsBackground = isBackground;
            this.IsAxe = isAxe;
            this.IsPerSecond = isPerSecond;
        }

        public Upgrade()
        {
            
        }
        
        private ulong changeValue;
        [XmlElement("ChangeValue")]
        public ulong ChangeValue
        {
            get { return changeValue; }
            set { changeValue = value; }
        }

        private bool isBought;
        [XmlElement("IsBought")]
        public bool IsBought
        {
            get { return isBought; }
            set { isBought = value; }
        }

        private string title;
        [XmlElement("Title")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string iconPath;
        [XmlElement("IconPath")]
        public string IconPath
        {
            get { return iconPath; }
            set { iconPath = value; }
        }

        private ulong cost;
        [XmlElement("Cost")]
        public ulong Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        private bool isBackground;
        [XmlElement("IsBackgound")]
        public bool IsBackground
        {
            get { return isBackground; }
            set { isBackground = value; }
        }

        private bool isAxe;
        [XmlElement("IsAxe")]
        public bool IsAxe
        {
            get { return isAxe; }
            set { isAxe = value; }
        }

        private bool isPerSecond;
        [XmlElement("IsPerSecond")]
        public bool IsPerSecond
        {
            get { return isPerSecond; }
            set { isPerSecond = value; }
        }
    }
}