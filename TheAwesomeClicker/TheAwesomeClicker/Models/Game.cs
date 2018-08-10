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

        public double TotalCoin { get; set; }

        public double PerSecondAmount { get; set; }


        private double clickAmount;

        public double ClickAmount
        {
            get { return clickAmount; }
            set { clickAmount = value; }
        }

        public List<Upgrade> UpgradesList { get; set; }

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
