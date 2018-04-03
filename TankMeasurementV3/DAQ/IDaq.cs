using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankMeasurementV3.DAQ
{
  public interface IDaq
  {
    double GetCurrent( ushort channel );
    double[] GetAllCurrent();
    void Enable();
    void Disable();
  }
}
