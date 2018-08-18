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

        private double totalCoin = 0;

        [ProtoMember(1)]
        public double TotalCoin
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


        private double clickAmount = 1;

        [ProtoMember(3)]
        public double ClickAmount
        {
            get { return clickAmount; }
            set
            {
                clickAmount = value;
                FieldChanged();
            }
        }

        private ObservableCollection<Upgrade> upgradeList = new ObservableCollection<Upgrade>();

        [ProtoMember(4)] public ObservableCollection<Upgrade> UpgradesList
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
            if(toBuy.Cost <= TotalCoin && !toBuy.IsBought)
            {
                BuyUpgrade(toBuy);
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
            UpgradesList.Add(new Upgrade("CoalMine", 15, "", 100) { Name="test"});
            UpgradesList.Add(new Upgrade("MineCart", 50, "", 10000));
            UpgradesList.Add(new Upgrade("IronMine", 200, "", 100000));
            UpgradesList.Add(new Upgrade("TNT", 1000, "", 500000));
            UpgradesList.Add(new Upgrade("GoldMine", 2500, "", 1000000));
        }
    }
}
