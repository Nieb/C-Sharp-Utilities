using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// For more precise conversion.
    ///
    /// For quick, use:  Var * TO_DEG
    ///                  Var * TO_RAD
    ///
    //==========================================================================================================================================================
    public static float ToDeg(float Radians) => (float)((double)Radians * (180.0 / 3.14159265358979323846264338327950288419716939937511));

    public static vec2 ToDeg(vec2 Radians) => new vec2( (float)((double)Radians.x * (180.0 / 3.14159265358979323846264338327950288419716939937511)),
                                                        (float)((double)Radians.y * (180.0 / 3.14159265358979323846264338327950288419716939937511)) );

    public static vec3 ToDeg(vec3 Radians) => new vec3( (float)((double)Radians.x * (180.0 / 3.14159265358979323846264338327950288419716939937511)),
                                                        (float)((double)Radians.y * (180.0 / 3.14159265358979323846264338327950288419716939937511)),
                                                        (float)((double)Radians.z * (180.0 / 3.14159265358979323846264338327950288419716939937511)) );

    //==========================================================================================================================================================
    public static float ToRad(float Degrees) => (float)((double)Degrees * (3.14159265358979323846264338327950288419716939937511 / 180.0));

    public static vec2 ToRad(vec2 Degrees) => new vec2( (float)((double)Degrees.x * (3.14159265358979323846264338327950288419716939937511 / 180.0)),
                                                        (float)((double)Degrees.y * (3.14159265358979323846264338327950288419716939937511 / 180.0)) );

    public static vec3 ToRad(vec3 Degrees) => new vec3( (float)((double)Degrees.x * (3.14159265358979323846264338327950288419716939937511 / 180.0)),
                                                        (float)((double)Degrees.y * (3.14159265358979323846264338327950288419716939937511 / 180.0)),
                                                        (float)((double)Degrees.z * (3.14159265358979323846264338327950288419716939937511 / 180.0)) );

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
