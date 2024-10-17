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
    public static float Random1(bool Signed = true) =>
        Signed ? VEC.Random.NextSingle()*2f - 1f : VEC.Random.NextSingle();

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec2 Random2(bool Signed = true) =>
        normalize(
            new vec2(
                Signed ? VEC.Random.NextSingle()*2f - 1f : VEC.Random.NextSingle(),
                Signed ? VEC.Random.NextSingle()*2f - 1f : VEC.Random.NextSingle()
            )
        );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 Random3(bool Signed = true) =>
        normalize(
            new vec3(
                Signed ? VEC.Random.NextSingle()*2f - 1f : VEC.Random.NextSingle(),
                Signed ? VEC.Random.NextSingle()*2f - 1f : VEC.Random.NextSingle(),
                Signed ? VEC.Random.NextSingle()*2f - 1f : VEC.Random.NextSingle()
            )
        );

    //==========================================================================================================================================================
    public static vec3 Random3_() {
        //  Pitch  RotX  -->   Latitude(South –90  +90 North)  -->  Position|Texture Coord  Y|V
        //  Yaw    RotY  -->  Longitude(West -180 +180 East )  -->  Position|Texture Coord  X|U

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
    public static vec3[] EvenDistro(int Count, float Spread = 2f) {
        vec3[] Result = new vec3[Count];

        Spread = 1f - cos(Spread*Pi);

        float Pch;
        float Yaw;
        float CosPch;

        for (int i = 1; i < Count; ++i) {
            Pch = asin(1f - (Spread*i / Count));
            Yaw = i * PHIRCP_PI2;
            CosPch = cos(Pch);
            Result[i].x = sin(Yaw) *  CosPch;
            Result[i].y = sin(Pch);
            Result[i].z = cos(Yaw) * -CosPch;
        }
        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
