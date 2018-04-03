using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TankMeasurementV3.Transmitter;
using TankMeasurementV3.Database;

namespace TankMeasurementV3.Manager
{
  public class Poller
  {
    private int _samplingRate;
    private Thread _pollThread;
    private TransmitterArray _transmitterArray;
    private bool _isPollEnabled;
    private Stopwatch _timer;
    private Tuple<DateTime, List<TransmitterData>> _actualValue;
    public event EventHandler<DataUpdatedEventArgs> OnDataUpdated;

    public Poller( TransmitterArray transmitterArray )
    {
      _transmitterArray = transmitterArray;
      _samplingRate = 5000;
      _isPollEnabled = false;
      _timer = new Stopwatch();
    }

    public void SetSamplingRate( int samplingRate )
    {
      _samplingRate = samplingRate;
    }

    public void Stop()
    {
      _isPollEnabled = false;
      if( _pollThread.IsAlive )
      {
        _pollThread = null;
      }
    }

    public void Start()
    {
      _pollThread = new Thread( () => PollThread() );
      _isPollEnabled = true;
      _pollThread.Start();
    }

    private void PollThread()
    {
      while( _isPollEnabled )
      {
        _timer.Restart();
        _actualValue = _transmitterArray.PollAll();
        OnDataUpdated( this, new DataUpdatedEventArgs() { TimeStamp = _actualValue.Item1, TransmitterData = _actualValue.Item2 } );

#if DEBUG
        Console.WriteLine( "Time Stamp : " + _actualValue.Item1.ToString( "yyyy-mm-dd HH:mm:ffff" ) );
        foreach( TransmitterData a in _actualValue.Item2 )
        {
          Console.WriteLine( a.ID + " " + a.Value );
        }
        Console.WriteLine( " " );
#endif

        while( _timer.Elapsed.TotalMilliseconds < _samplingRate )
        {
          Thread.Sleep( 1 );
        }
      }
    }
  }
}
