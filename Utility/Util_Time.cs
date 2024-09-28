using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public Time() {
        this.Timer = Stopwatch.StartNew(); //  https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-8.0
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() =>
        $"Time( Dlt: {this.Delta,9:0.0000000}   Sec: {this.Seconds,9:0.0000000} )"
      //$"Time( Dlt: {this.Delta,9:0.0000000}   Sec: {this.Seconds,9:0.0000000}   Cos: {this.Cos,9:0.000000}   Sin: {this.Sin,9:0.000000} )"
        + (this.TimerReset ? " ***" : "");

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public void Update(float Speed = 1.0f) {
        this.ThisFrame = this.Timer.Elapsed.TotalSeconds;
        if (this.ThisFrame >= 60.0) {   //  Maintain "Time.Delta" float-precision to: ~0.000_001 Seconds (1 MicroSecond).
            this.Timer.Restart();       //  Reset timer as soon as possible.
            this.TimerReset = true;
        } else {
            this.TimerReset = false;
        }

        this.Delta   = (float)(this.ThisFrame  - this.PrevFrame) * Speed;
        this.Seconds = (float)(this.Minutes*60 + this.ThisFrame) * Speed;

      //(this.Sin  , this.Cos  ) = ((float, float))Math.SinCos( this.ThisFrame * 0.10471975511965977462 ); //  1 hertz
      //(this.Sin10, this.Cos10) = ((float, float))Math.SinCos( this.ThisFrame * 1.04719755119659774615 ); // 10 hertz
      //(this.Sin30, this.Cos30) = ((float, float))Math.SinCos( this.ThisFrame * 3.14159265358979323846 ); // 30 hertz
      //(this.Sin60, this.Cos60) = ((float, float))Math.SinCos( this.ThisFrame * 6.28318530717958647693 ); // 60 hertz

        if (this.TimerReset) {
            this.PrevFrame = 0.0;
            this.Minutes += 1;
        } else {
            this.PrevFrame = this.ThisFrame;
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}