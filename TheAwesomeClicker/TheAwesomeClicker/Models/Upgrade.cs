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
        public Upgrade(string name, ulong changeValue, string iconPath, ulong cost, bool isBought = false, bool isBackground = false, bool isAxe = false)
        {
            this.Title = name;
            this.ChangeValue = changeValue;
            this.IconPath = iconPath;
            this.Cost = cost;
            this.IsBought = isBought;
            this.IsBackground = isBackground;
            this.IsAxe = isAxe;
        }

        public Upgrade()
        {
            
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

        private bool isBackground;
        [ProtoMember(6)]
        public bool IsBackground
        {
            get { return isBackground; }
            set { isBackground = value; }
        }

        private bool isAxe;
        [ProtoMember(7)]
        public bool IsAxe
        {
            get { return isAxe; }
            set { isAxe = value; }
        }

    }
}