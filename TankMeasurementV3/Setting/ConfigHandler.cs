using System;
using System.IO;
using Newtonsoft.Json;

namespace TankMeasurementV3.Setting
{
  public static class ConfigHandler
  {
    static public void SaveConfig( object data, string filename )
    {
      try
      {
        string json = JsonConvert.SerializeObject( data, Formatting.Indented );
        File.WriteAllText( filename, json );
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    static public object LoadConfig( ConfigType type, string filename )
    {
      object retVal = null;
      try
      {
        switch( type )
        {
          case ConfigType.DAQConfig:
            retVal = (DAQConfiguration)JsonConvert.DeserializeObject<DAQConfiguration>( File.ReadAllText( filename ) );
            break;
          case ConfigType.TransmitterConfig:
            retVal = (TransmitterArrayConfiguration)JsonConvert.DeserializeObject<TransmitterArrayConfiguration>( File.ReadAllText( filename ) );
            break;
        }
      }
      catch (Exception e)
      {
        throw e;
      }
      return retVal;
    }
  }
}
