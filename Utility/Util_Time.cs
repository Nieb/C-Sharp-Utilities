using System;
using System.Diagnostics;

namespace Utility;
public struct Time {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public float Delta   { get; private set; } = 0f;
    public float Seconds { get; private set; } = 0f;

  //public float Cos   { get; private set; } = 0f; //   1 hertz
  //public float Cos10 { get; private set; } = 0f; //  10 hertz
  //public float Cos30 { get; private set; } = 0f; //  30 hertz
  //public float Cos60 { get; private set; } = 0f; //  60 hertz

  //public float Sin   { get; private set; } = 0f; //  https://www.desmos.com/calculator/okelxyt5uy
  //public float Sin10 { get; private set; } = 0f;
  //public float Sin30 { get; private set; } = 0f;
  //public float Sin60 { get; private set; } = 0f;

    //==========================================================================================================================================================
    private double PrevFrame = 0.0;
    private double ThisFrame = 0.0;

    private ulong Minutes = 0;

    private Stopwatch Timer;
    private bool TimerReset = false;

    //==========================================================================================================================================================
    public Time() {
        this.Timer = Stopwatch.StartNew(); //  https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-8.0
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public override string ToString() =>
        $"Time( Delta: {Delta,9:0.0000000}   Seconds: {Seconds,9:0.0000000} )"
      //$"Time( Delta: {Delta,9:0.0000000}   Seconds: {Seconds,9:0.0000000}   Cos: {Cos,9:0.000000}   Sin: {Sin,9:0.000000} )"
        + (TimerReset ? " ***" : "");

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public void Update(float Speed = 1.0f) {
        ThisFrame = Timer.Elapsed.TotalSeconds;
        if (ThisFrame >= 60.0) {   //  Maintain "Time.Delta" float-precision to: ~0.000_001 Seconds (1 MicroSecond).
            Timer.Restart();       //  Reset timer as soon as possible.
            TimerReset = true;
        } else {
            TimerReset = false;
        }

        Delta   = (float)(ThisFrame  - PrevFrame) * Speed;
        Seconds = (float)(Minutes*60 + ThisFrame) * Speed;

      //(Sin  , Cos  ) = ((float, float))Math.SinCos( ThisFrame * 0.10471975511965977462 ); //  1 hertz
      //(Sin10, Cos10) = ((float, float))Math.SinCos( ThisFrame * 1.04719755119659774615 ); // 10 hertz
      //(Sin30, Cos30) = ((float, float))Math.SinCos( ThisFrame * 3.14159265358979323846 ); // 30 hertz
      //(Sin60, Cos60) = ((float, float))Math.SinCos( ThisFrame * 6.28318530717958647693 ); // 60 hertz

        if (TimerReset) {
            PrevFrame = 0.0;
            Minutes += 1;
        } else {
            PrevFrame = ThisFrame;
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
