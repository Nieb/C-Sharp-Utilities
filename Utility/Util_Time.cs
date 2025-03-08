using System;
using System.Diagnostics;

namespace Utility;
internal struct Time {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal float Delta   { get; private set; }
    internal float Seconds { get; private set; }

  //internal vec4 Cos { get; private set; }
  //internal float Cos   { get; private set; } //   1 hertz
  //internal float Cos10 { get; private set; } //  10 hertz
  //internal float Cos30 { get; private set; } //  30 hertz
  //internal float Cos60 { get; private set; } //  60 hertz

  //internal vec4 Sin { get; private set; }
  //internal float Sin   { get; private set; } //  https://www.desmos.com/calculator/okelxyt5uy
  //internal float Sin10 { get; private set; }
  //internal float Sin30 { get; private set; }
  //internal float Sin60 { get; private set; }

    //==========================================================================================================================================================
    private double PrevFrame;
    private double ThisFrame;

    private ulong Minutes;
    private ulong Hours;

    private Stopwatch Timer;
    private bool TimerReset;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public Time() {
        this.Delta   = 0f;
        this.Seconds = 0f;

      //this.Cos = new vec4();
      //this.Sin = new vec4();

        this.PrevFrame = 0d;
        this.ThisFrame = 0d;

        this.Minutes = 0;
        this.Hours   = 0;

        this.Timer      = Stopwatch.StartNew(); //  https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-8.0
        this.TimerReset = false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public override string ToString() =>
        $"Time(  Delta: {Delta,9:0.0000000}    Seconds: {Seconds,11:0.0000000}    HhMmSs: {Hours:00}:{Minutes:00}:{(Seconds % 60f):00.0000000}  )"
      //$"Time(  Delta: {Delta,9:0.0000000}    Seconds: {Seconds,9:0.0000000}    Cos: {Cos,9:0.000000}   Sin: {Sin,9:0.000000}  )"
        + (TimerReset ? " ***" : "");

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal void Update(double Speed = 1d) {
        this.ThisFrame = this.Timer.Elapsed.TotalSeconds;

        if (this.ThisFrame >= 60d) {    //  Maintain "Time.Delta" float-precision to: ~0.000_001 Seconds (1 MicroSecond).
            this.Timer.Restart();       //  Reset timer as soon as possible.
            this.TimerReset = true;
        } else {
            this.TimerReset = false;
        }

        this.Delta   = (float)((this.ThisFrame  - this.PrevFrame) * Speed);
        this.Seconds = (float)(((double)(this.Hours*3600 + this.Minutes*60) + this.ThisFrame) * Speed);

      //(Sin  , Cos  ) = ((float, float))Math.SinCos( this.ThisFrame * 0.10471975511965977462 ); //  1 hertz
      //(Sin10, Cos10) = ((float, float))Math.SinCos( this.ThisFrame * 1.04719755119659774615 ); // 10 hertz
      //(Sin30, Cos30) = ((float, float))Math.SinCos( this.ThisFrame * 3.14159265358979323846 ); // 30 hertz
      //(Sin60, Cos60) = ((float, float))Math.SinCos( this.ThisFrame * 6.28318530717958647693 ); // 60 hertz

        if (this.TimerReset) {
            this.PrevFrame = 0d;
            this.Minutes += 1;
            if (this.Minutes >= 60) {
                this.Minutes  = 0;
                this.Hours   += 1;
            }
        } else {
            this.PrevFrame = this.ThisFrame;
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
