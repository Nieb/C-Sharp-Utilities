using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float deg(float Radians) => (Radians * TO_DEGREES);

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float rad(float Degrees) => (Degrees * TO_RADIANS);

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

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
