using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TheAwesomeClicker.Models
{
    [DataContract]
    public class Game : IExtensibleDataObject
    {

        [DataMember] public double TotalCoin { get; set; }

        [DataMember] public double PerSecondAmount { get; set; }

        [DataMember] public double IdleAmount { get; set; }
        
        [DataMember] public List<Upgrade> UpgradesList { get; set; }
        public ExtensionDataObject ExtensionData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
