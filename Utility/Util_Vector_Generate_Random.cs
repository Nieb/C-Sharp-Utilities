using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Random is not ThreadSafe.
    private static readonly Random Random     = new();
  //private static readonly object ThreadLock = new();

    //  https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-9/#threading
    //  https://learn.microsoft.com/en-us/dotnet/api/system.threading.lock?view=net-9.0
  //private static readonly System.Threading.Lock ThreadLock = new();

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static float Random1(bool Signed = true) => (
        Signed ? VEC.Random.NextSingle() * 2.0f - 1.0f
               : VEC.Random.NextSingle()
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec2 Random2() =>
        normalize(
            new vec2(
                VEC.Random.NextSingle() * 2.0f - 1.0f,
                VEC.Random.NextSingle() * 2.0f - 1.0f
            )
        );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 Random3() =>
        normalize(
            new vec3(
                VEC.Random.NextSingle() * 2.0f - 1.0f,
                VEC.Random.NextSingle() * 2.0f - 1.0f,
                VEC.Random.NextSingle() * 2.0f - 1.0f
            )
        );

    //==========================================================================================================================================================
    public static vec3 Random3_() {
        // Pitch  RotX  -->   Latitude( –90  +90 South North)        MapCoord  -->  TexCoord V
        // Yaw    RotY  -->  Longitude(-180 +180 West  East )        MapCoord  -->  TexCoord U

        float Pch = (VEC.Random.NextSingle() - 0.5f) * PI;
        float Yaw = (VEC.Random.NextSingle() - 0.5f) * PI2;

        //  To get even distribution, bias away from poles:
        Pch = MathF.Asin(Pch);

        float CosPch = MathF.Cos(Pch);

        return new vec3(
              CosPch * MathF.Sin(Yaw),
                      -MathF.Sin(Pch),
             -CosPch * MathF.Cos(Yaw)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
