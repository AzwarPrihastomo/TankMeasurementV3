using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using TankMeasurementV3.Setting;
using TankMeasurementV3.DAQ;
using TankMeasurementV3.Transmitter;
using TankMeasurementV3.Manager;

namespace TankMeasurementV3
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main( string[] args )
    {
      //Load Config
      DAQConfiguration _daqConfig = (DAQConfiguration)ConfigHandler.LoadConfig( ConfigType.DAQConfig, "DAQConfig.json" );
      TransmitterArrayConfiguration _transmitterArrayConfig = (TransmitterArrayConfiguration)ConfigHandler.LoadConfig( ConfigType.TransmitterConfig, "TransmitterConfig.json" );

      //DAQ
      IDaq _daq = new CommonDAQ( _daqConfig );

      //transmitter array
      TransmitterArray _transmitterArray = new TransmitterArray( _transmitterArrayConfig, _daq );
      
      //or poller
      Poller _poller = new Poller( _transmitterArray );

      _poller.SetSamplingRate( 1000 );

      _poller.Start();

      _poller.OnDataUpdated += _poller_OnDataUpdated1;
      
      while( true )
      {
        //Tuple<DateTime, List<TransmitterData>> dataPacket = _transmitterArray.PollAll();
        //Console.WriteLine( "Data: " + dataPacket.Item1.ToString( "yyyy-mm-dd HH:mm:ffff" ) );

        //foreach( TransmitterData a in dataPacket.Item2 )
        //{
        //  Console.WriteLine( a.ID + " " + a.Value );
        //}

        Console.ReadLine();
      }
    }

    private static void _poller_OnDataUpdated1( object sender, DataUpdatedEventArgs e )
    {
      //Console.WriteLine(sender.)
      //throw new NotImplementedException();
    }

  }
}
