using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static float ToDeg(float Radians) => (float)((double)Radians * (180.0 / 3.14159265358979323846264338327950288419716939937511));

    //==========================================================================================================================================================
    public static float ToRad(float Degrees) => (float)((double)Degrees * (3.14159265358979323846264338327950288419716939937511 / 180.0));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float cos(float A)  => MathF.Cos(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float acos(float A) => MathF.Acos(A);

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float sin(float A)  => MathF.Sin(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float asin(float A) => MathF.Asin(A);

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float tan(float A)  => MathF.Tan(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float atan(float A) => MathF.Atan(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float atan2(float A, float B) => MathF.Atan2(A, B);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
