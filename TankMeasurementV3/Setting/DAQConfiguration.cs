using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMeasurementV3.Setting
{
  public class DAQConfiguration
  {
    public string PortName { get; set; }
    public int BaudRate { get; set; }
    public ushort NumberOfChannel { get; set; }
    public ushort DeviceAddress { get; set; }
    public ushort StartAddress { get; set; }
    public double ConversionScale { get; set; }
    public double ConversionOffset { get; set; }
    public int DataBits { get; set; }
    public int ReadTimeout { get; set; }
    public int WriteTimeout { get; set; }
  }
}
