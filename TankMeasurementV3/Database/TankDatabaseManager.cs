using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankMeasurementV3.Transmitter;


namespace TankMeasurementV3.Database
{
  public class TankDatabaseManager
  {
    CMySQL _sql;
    public TankDatabaseManager(CMySQL sql)
    {
      _sql = sql;
    }

    public void Begin()
    {
      
    }

    public void SaveData(Tuple<DateTime,List<TransmitterData>> data)
    {

    }

    public List<Tuple<DateTime, List<TransmitterData>>> LoadData(string sensorName, TimeSpan time )
    {
      return null; 
    }
  }
}
