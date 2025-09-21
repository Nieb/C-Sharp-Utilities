

namespace Utility;
internal struct Time {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal float Delta      { get; private set; }

    internal float SinceStart { get; private set; }

    //
    //  vec4( 1 hertz, 10 hertz, 30 hertz, 60 hertz )
    //
  //internal vec4 Cos { get; private set; }
  //internal vec4 Sin { get; private set; }

    //==========================================================================================================================================================
    private double PrevFrame;
    private double ThisFrame;

    private double Seconds;
    private ulong  Minutes;
    private ulong  Hours;

    private System.Diagnostics.Stopwatch Timer; //  https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-8.0
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

        this.Timer      = System.Diagnostics.Stopwatch.StartNew();
        this.TimerReset = false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public override string ToString() =>
        $"Time(  Delta: {Delta,9:0.0000000}    Seconds: {Seconds,11:0.0000000}    HhMmSs: {Hours:00}:{Minutes:00}:{Seconds:00.000000}  )"
      //$"Time(  Delta: {Delta,9:0.0000000}    Seconds: {Seconds,9:0.0000000}    Cos: {Cos,9:0.000000}   Sin: {Sin,9:0.000000}  )"
        + (TimerReset ? " ***" : "");

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //internal void Update(double Speed = 1d) {
    internal void Update() {
        this.ThisFrame = this.Timer.Elapsed.TotalSeconds;

        if (this.ThisFrame >= 60d) {    //  Maintain "Time.Delta" float32-precision to: ~0.000_001 Seconds (1 MicroSecond)
            this.Timer.Restart();       //  Reset timer as soon as possible.
            this.TimerReset = true;
        } else {
            this.TimerReset = false;
        }

        this.Delta      = (float)(this.ThisFrame - this.PrevFrame);
      //this.Delta      = (float)((this.ThisFrame - this.PrevFrame) * Speed);

        this.SinceStart = (float)( (double)(this.Hours*3600 + this.Minutes*60) + this.ThisFrame );
      //this.SinceStart = (float)(((double)(this.Hours*3600 + this.Minutes*60) + this.ThisFrame) * Speed);

      //(this.Sin.x, this.Cos.x) = ((float, float))Math.SinCos( this.ThisFrame * 0.10471975511965977462 ); //  1 hertz
      //(this.Sin.y, this.Cos.y) = ((float, float))Math.SinCos( this.ThisFrame * 1.04719755119659774615 ); // 10 hertz  https://www.desmos.com/calculator/e4f49ebeb2
      //(this.Sin.z, this.Cos.z) = ((float, float))Math.SinCos( this.ThisFrame * 3.14159265358979323846 ); // 30 hertz
      //(this.Sin.w, this.Cos.w) = ((float, float))Math.SinCos( this.ThisFrame * 6.28318530717958647693 ); // 60 hertz

        if (this.TimerReset) {
            this.Seconds   = 0d;
            this.PrevFrame = 0d;

            this.Minutes += 1;
            if (this.Minutes >= 60) {
                this.Minutes  = 0;
                this.Hours   += 1;
            }
        } else {
            this.Seconds   = this.ThisFrame;
            this.PrevFrame = this.ThisFrame;
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
