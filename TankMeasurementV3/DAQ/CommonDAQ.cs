using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using TankMeasurementV3.Setting;

namespace TankMeasurementV3.DAQ
{
  class CommonDAQ:IDaq
  { 
    private Modbus _modbus;
    private DAQConfiguration _config;

    //TODO: Move to config
    //private const ushort CHANNEL_START_ADDRESS=2;
    //private const ushort NUM_OF_CHANNEL = 8;
    //private const ushort DAQ_ADDRESS = 1;
    //private const double CONVERSION_SCALE= 0.01955034213098729227761485826002;
    //private const double CONVERSION_OFFSET = 0.0;

    private short[] values;//= new short[NUM_OF_CHANNEL];
    private double[] retVal;//= new double[NUM_OF_CHANNEL];

    public CommonDAQ( DAQConfiguration config )
    {
      _config = config;
      _modbus = new Modbus();
      values = new short[_config.NumberOfChannel+_config.StartAddress];
      retVal = new double[_config.NumberOfChannel];
    }

    public void Enable()
    {
      if( !_modbus.Open( _config.PortName, _config.BaudRate, _config.DataBits, Parity.None, StopBits.One, _config.ReadTimeout,_config.WriteTimeout) )
      {
        throw new Exception( _modbus.modbusStatus );
      }
    }

    public void Disable()
    {
      if( !_modbus.Close() )
      {
        throw new Exception( _modbus.modbusStatus );
      }
    }

    public double[] GetAllCurrent()
    {
      if( !_modbus.SendFc3( Convert.ToByte( _config.DeviceAddress ), _config.StartAddress, (ushort)(_config.StartAddress + _config.NumberOfChannel), ref values ) )
      {
        throw new Exception( _modbus.modbusStatus );
      }

      //cannot implicitly convert short[] to double[]
      for( int i = 0; i < _config.NumberOfChannel; i++ )
      {
        retVal[i] = ToMiliAmpere( values[i] );
      }
      return retVal;
    }

    public double GetCurrent( ushort channel )
    {
      int realAddress = _config.StartAddress + channel;

      if( channel > _config.NumberOfChannel || channel < 0 )
      {
        throw new ArgumentOutOfRangeException( "DAQ Channel Out Of Range" );
      }

      if( !_modbus.SendFc3( Convert.ToByte( _config.DeviceAddress ), (ushort)( realAddress ), 1, ref values ) )
      {
        //why we throw
        throw new Exception( _modbus.modbusStatus );
      }

      return ToMiliAmpere( values[0] );
    }

    private double ToMiliAmpere(short count )
    {
      return count * _config.ConversionScale + _config.ConversionOffset;
    }
  }
}
