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
    ///
    /// https://www.desmos.com/calculator/ct29koavbu
    ///
    public static vec2[] Phyllotaxis2(int Count, float CircleCoverage = 1f, bool CenterPoint = true) {
        int iStart = (CenterPoint) ? 0 : 1;

        vec2[] Result = new vec2[Count];

        for (int i = iStart; i < Count; ++i) {
            float Ang = i * PHI_RAD;
            float Rds = CircleCoverage * sqrt((float)i / (float)Count);
            Result[i].x = Rds * cos(Ang);
            Result[i].y = Rds * sin(Ang);
        }
        return Result;
    }

    //==========================================================================================================================================================
    ///
    /// https://www.desmos.com/3d/nrzvi76avc
    ///
    public static vec3[] Phyllotaxis3(int Count, float SphereCoverage = 1f, bool Poles = true) {
        SphereCoverage = 1f - cos(SphereCoverage*PI);

        int iStart = (Poles) ?       0 :     1;
        int iEnd   = (Poles) ? Count+1 : Count;

        vec3[] Result = new vec3[iEnd];

        for (int i = iStart; i < iEnd; ++i) {
            float Pch = asin(1f - (SphereCoverage*(float)i / (float)Count));
            float Yaw = i * PI2_PHI;
            float CosPch = cos(Pch);
            Result[i].x = sin(Yaw) *  CosPch;
            Result[i].y = sin(Pch);
            Result[i].z = cos(Yaw) * -CosPch;
        }
        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
