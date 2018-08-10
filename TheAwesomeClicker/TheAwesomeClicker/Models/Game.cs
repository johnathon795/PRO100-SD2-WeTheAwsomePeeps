using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TheAwesomeClicker.Models
{
    [Serializable]
    public class Game
    {

        public double TotalCoin { get; set; }

        public double PerSecondAmount { get; set; }

        public double ClickAmount { get; set; }
        
        public List<Upgrade> UpgradesList { get; set; }

        public void CanAfford(Upgrade toBuy)
        {
            if(toBuy.Cost < TotalCoin)
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
