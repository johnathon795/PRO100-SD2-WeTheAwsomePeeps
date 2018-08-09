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

        public double IdleAmount { get; set; }
        
        public List<Upgrade> UpgradesList { get; set; }

    }
}
