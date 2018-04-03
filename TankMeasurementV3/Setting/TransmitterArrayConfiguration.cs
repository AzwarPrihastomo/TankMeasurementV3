using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMeasurementV3.Setting
{
  public class TransmitterArrayConfiguration
  {
    public List<TransmitterConfiguration> Transmitters { get; set; }// = new List<TransmitterConfiguration>();
  }

  public struct TransmitterConfiguration
  {
    public string Name { get; set; }
    public int ID { get; set; }
    public ushort ChannelAddress { get; set; }
    public string Equation { get; set; }
    public string EngineeringUnit { get; set; }
  }
}
