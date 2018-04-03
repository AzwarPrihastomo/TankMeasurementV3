using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMeasurementV3.Setting;

namespace TestField
{
  class Program
  {
    static void Main( string[] args )
    {
      DAQConfiguration _daqConfig = new DAQConfiguration();
      _daqConfig.BaudRate = 100;
      TransmitterArrayConfiguration _transmitterConfig = new TransmitterArrayConfiguration();
      _transmitterConfig.Transmitters.Add( new TransmitterConfiguration() { ChannelAddress = 1, EngineeringUnit="celcius", Name="tempSensor", Equation="10*X" } );
      _transmitterConfig.Transmitters.Add( new TransmitterConfiguration() { ChannelAddress = 2, EngineeringUnit = "bar", Name = "pressSensor", Equation = "12*X" } );

      ConfigHandler.SaveConfig( _transmitterConfig, "testconfigSensor.json" );
    }
  }
}
