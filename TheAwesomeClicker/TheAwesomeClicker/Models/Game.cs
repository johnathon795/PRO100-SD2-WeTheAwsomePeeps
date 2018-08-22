using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Media.Playback;
using Windows.Media.Core;
using System.Collections.ObjectModel;
using ProtoBuf;

namespace TheAwesomeClicker.Models
{
    [ProtoContract]
    public class Game : INotifyPropertyChanged
    {

        [ProtoIgnore]
        public List<MediaPlayer> AudioPlayers;

        [ProtoIgnore]
        private MediaPlayer boughtUpgrade;

        public event PropertyChangedEventHandler PropertyChanged;

        private ulong totalCoin = 0;

        [ProtoMember(1)]
        public ulong TotalCoin
        {
            get { return totalCoin; }
            set
            {
                totalCoin = value;
                FieldChanged();
            }
        }

        private double perSecondAmount = 0;

        [ProtoMember(2)]
        public double PerSecondAmount
        {
            get
            {
                return perSecondAmount;
            }
            set
            {
                perSecondAmount = value;
                FieldChanged();
            }
        }


        private ulong clickAmount = 1;

        [ProtoMember(3)]
        public ulong ClickAmount
        {
            get { return clickAmount; }
            set
            {
                clickAmount = value;
                FieldChanged();
            }
        }

        private ObservableCollection<Upgrade> upgradeList = new ObservableCollection<Upgrade>();

        [ProtoMember(4)]
        public ObservableCollection<Upgrade> UpgradesList
        {
            get
            {
                return upgradeList;
            }
            set
            {
                upgradeList = value;
                FieldChanged();
            }
        }

        private string background = "ms-appx:///Assets/DefaultBackground.png";

        [ProtoMember(5)]
        public string Background
        {
            get { return background; }
            set
            {
                background = value;
                FieldChanged();
            }
        }

        private string clicker = "ms-appx:///Assets/Logo.png";
        [ProtoMember(6)]
        public string Clicker
        {
            get { return clicker; }
            set
            {
                clicker = value;
                FieldChanged();
            }
        }


        public Game()
        {
            this.AudioPlayers = new List<MediaPlayer>();
            this.boughtUpgrade = new MediaPlayer()
            {
                Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Kaching.wav")),
                AudioCategory = MediaPlayerAudioCategory.GameMedia,
                Volume = 1,
                IsLoopingEnabled = false
            };
            AudioPlayers.Add(boughtUpgrade);
        }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        public void CanAfford(Upgrade toBuy)
        {
            if (toBuy.Cost <= TotalCoin && !toBuy.IsBought)
            {
                BuyUpgrade(toBuy);

                if (toBuy.IsBackground) Background = toBuy.IconPath.Substring(0, 29) + ".png";
                if (toBuy.IsAxe) Clicker = toBuy.IconPath;
            }
        }

        public void BuyUpgrade(Upgrade toBuy)
        {
            TotalCoin -= toBuy.Cost;
            toBuy.IsBought = true;
            ClickAmount += toBuy.ChangeValue;
            boughtUpgrade.Play();
        }

        public void MakeUpgrade()
        {
            UpgradesList.Add(new Upgrade("Iron Pickaxe", 100, "ms-appx:///Assets/Iron.png", 1000, isAxe: true));
            UpgradesList.Add(new Upgrade("Diamond Pickaxe", 500, "ms-appx:///Assets/Diamond.png", 100000, isAxe: true));
            UpgradesList.Add(new Upgrade("Wood MineCart", 50, "ms-appx:///Assets/MineCart.png", 100));
            UpgradesList.Add(new Upgrade("Iron MineCart", 100, "ms-appx:///Assets/MineCart2.png", 1000));
            UpgradesList.Add(new Upgrade("TNT", 1000, "ms-appx:///Assets/TnT.png", 500000));
            UpgradesList.Add(new Upgrade("TNT", 1500, "ms-appx:///Assets/TnT2.png", 5000000));
            UpgradesList.Add(new Upgrade("Drill", 1500, "ms-appx:///Assets/Drill.png", 5000000));
            UpgradesList.Add(new Upgrade("Diamond Bit Drill", 1500, "ms-appx:///Assets/Drill2.png", 5000000));
            UpgradesList.Add(new Upgrade("CoalMine", 19, "ms-appx:///Assets/Background0_Icon.png", 100, isBackground: true));
            UpgradesList.Add(new Upgrade("IronMine", 250, "ms-appx:///Assets/Background1_Icon.png", 100000, isBackground: true));
            UpgradesList.Add(new Upgrade("GoldMine", 2500, "ms-appx:///Assets/Background2_Icon.png", 1000000, isBackground: true));
        }
    }
}
