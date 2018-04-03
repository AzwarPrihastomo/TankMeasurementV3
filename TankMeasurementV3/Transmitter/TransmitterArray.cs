using System;
using System.Collections.Generic;
using TankMeasurementV3.Setting;
using TankMeasurementV3.DAQ;

namespace TankMeasurementV3.Transmitter
{
  public class TransmitterArray
  {
    List<Transmitter> _transmitters;
    IDaq _daq;

    public TransmitterArray(TransmitterArrayConfiguration config, IDaq daq )
    {
      _daq = daq;
      _transmitters = new List<Transmitter>( config.Transmitters.Capacity );

      foreach(TransmitterConfiguration transmitterConfig in config.Transmitters )
      {
        _transmitters.Add( new Transmitter( transmitterConfig ) );
      }
      _daq.Enable();
    }
    
    public Tuple<DateTime,List<TransmitterData>> PollAll()
    {
      List<TransmitterData> senseData = new List<TransmitterData>();
      double[] currentAll = _daq.GetAllCurrent();
      DateTime TimeStamp = DateTime.Now;

      foreach(Transmitter transmitter in _transmitters )
      {
        double value = transmitter.GetValue( currentAll[transmitter.DaqChannel] );
        senseData.Add( new TransmitterData() { ID = transmitter.ID, Value = value } );
      }

      Tuple<DateTime, List<TransmitterData>> retVal = new Tuple<DateTime, List<TransmitterData>>( TimeStamp, senseData );
      return retVal;
    } 
  }
}
