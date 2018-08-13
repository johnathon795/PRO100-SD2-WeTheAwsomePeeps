using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheAwesomeClicker.Models
{
    
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private double totalCoin = 0;

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

        public double ClickAmount
        {
            get { return clickAmount; }
            set
            {
                clickAmount = value;
                FieldChanged();
            }
        }

        private List<Upgrade> upgradeList = new List<Upgrade>() { new Upgrade("test upgrade", 10, "", 10), new Upgrade("test upgrade 2", 10, "", 10) };

        public List<Upgrade> UpgradesList
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

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        public void CanAfford(Upgrade toBuy)
        {
            if(toBuy.Cost < TotalCoin && !toBuy.IsBought)
            {
                BuyUpgrade(toBuy);
            }
        }

        public void BuyUpgrade(Upgrade toBuy)
        {
            TotalCoin -= toBuy.Cost;
            toBuy.IsBought = true;
            ClickAmount += toBuy.ChangeValue;
        }
    }
}
