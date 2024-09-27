using System;
using System.Diagnostics;
//using System.Globalization;
//using System.Runtime.CompilerServices;

//using static System.MathF;

namespace Utility;
public struct Time {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public float Delta   { get; private set; }
    public int   Minutes { get; private set; }

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


#if false

float Time.Delta

//  2147483648              = 2147483648.0                      Seconds
//  2147483648/60           =   35791394.13333333333333333333   Minutes
//  2147483648/60/60        =     596523.23555555555555555556   Hours
//  2147483648/60/60/24     =      24855.13481481481481481481   Days
//  2147483648/60/60/24/365 =         68.09625976661593099949   Years

using System;
using System.Diagnostics;
//using System.Globalization;
//using System.Runtime.CompilerServices;

//using static System.MathF;

namespace Utility;
public struct Time {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    float LastFrame = 0.0f;
    float ThisFrame = 0.0f;
    float Delta     = 0.0f;

    int Minutes = 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public void Update() {
        this.ThisFrame = Timer();

        this.Delta = this.ThisFrame - this.LastFrame;

        //  This maintains timer precision to: ~0.000_001 Seconds (1 MicroSecond).
        if (this.ThisFrame >= 60.0f) {
            ResetTimer();
            this.LastFrame = Timer();
            this.Minutes += 1;
        } else {
            this.LastFrame = this.ThisFrame;
        }
    }

    //==========================================================================================================================================================
    public void Update(float Speed) {
        this.ThisFrame = Timer();

        this.Delta = (this.ThisFrame - this.LastFrame) * Speed;

        if (this.ThisFrame >= 60.0f) {
            ResetTimer();
            this.LastFrame = Timer();
            this.Minutes += 1;
        } else {
            this.LastFrame = this.ThisFrame;
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
#endif
