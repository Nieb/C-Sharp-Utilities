using System;
using System.Diagnostics;

namespace Utility;
public struct Time {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public float Delta   { get; private set; }
    public int   Minutes { get; private set; }
    //  2,147,483,648 / 60        =  35,791,394.133~  Hours
    //  2,147,483,648 / 60 /  24  =   1,491,308.088~  Days
    //  2,147,483,648 / 60 / 365  =      98,058.614~  Years

    //==========================================================================================================================================================
    private double LastFrame;
    private double ThisFrame;

    private Stopwatch Timer; //  https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-8.0

    //==========================================================================================================================================================
    public Time() {
        this.Delta   = 0.0f;
        this.Minutes = 0;

        this.Timer = Stopwatch.StartNew();
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public void Update() {
        this.ThisFrame = this.Timer.Elapsed.TotalSeconds;

        this.Delta = (float)(this.ThisFrame - this.LastFrame);

        //  This maintains 'Time.Delta' precision to: ~0.000_001 Seconds (1 MicroSecond).
        if (this.ThisFrame >= 60.0) {
            this.Timer.Restart();
            this.LastFrame = this.Timer.Elapsed.TotalSeconds;
            this.Minutes += 1;
        } else {
            this.LastFrame = this.ThisFrame;
        }
    }

    //==========================================================================================================================================================
    public void Update(double Speed) {
        this.ThisFrame = this.Timer.Elapsed.TotalSeconds;

        this.Delta = (float)((this.ThisFrame - this.LastFrame) * Speed);

        if (this.ThisFrame >= 60.0) {
            this.Timer.Restart();
            this.LastFrame = this.Timer.Elapsed.TotalSeconds;
            this.Minutes += 1;
        } else {
            this.LastFrame = this.ThisFrame;
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
