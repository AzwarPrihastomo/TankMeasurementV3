using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMeasurementV3.Transmitter;

namespace TankMeasurementV3.Manager
{
  public class DataUpdatedEventArgs:EventArgs
  {
    public DateTime TimeStamp { get; set; }
    public List<TransmitterData> TransmitterData { get; set; }
  }
}
