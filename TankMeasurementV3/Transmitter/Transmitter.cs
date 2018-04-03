using System;
using TankMeasurementV3.Setting;
using TankMeasurementV3.Util;

namespace TankMeasurementV3.Transmitter
{
  class Transmitter
  {
    TransmitterConfiguration _config;
    public int DaqChannel { get; set; }
    public string EngineeringUnit { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }
    /// <summary>
    /// Construct sensor using linear map
    /// </summary>
    public Transmitter( TransmitterConfiguration config  )
    {
      _config = config;
      this.DaqChannel = _config.ChannelAddress;
      this.EngineeringUnit = _config.EngineeringUnit;
      this.Name = _config.Name;
      this.ID = _config.ID;
    }

    public double GetValue( double current )
    {
      return CalculateEquation( _config.Equation, current );
    }

    private double CalculateEquation( string equation, double XValue )
    {return 0.0;
      //StringToFormula myFormula = new StringToFormula();
     // string finalEqu = equation.Replace( "X", Convert.ToString( XValue ) );
      //return myFormula.Eval( finalEqu );
    }
    
  }
}
