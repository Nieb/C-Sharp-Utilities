using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximatelyZero(this float A) => (A > -EPSILON && A < EPSILON);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximatelyZero(this vec2  A) => (A > -EPSILON && A < EPSILON);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximatelyZero(this vec3  A) => (A > -EPSILON && A < EPSILON);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximatelyZero(this vec4  A) => (A > -EPSILON && A < EPSILON);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximately(this float A, float B) => abs(A-B) < EPSILON;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximately(this vec2  A, vec2  B) => abs(A-B) < EPSILON;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximately(this vec3  A, vec3  B) => abs(A-B) < EPSILON;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsApproximately(this vec4  A, vec4  B) => abs(A-B) < EPSILON;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRoughly(this float A, float B) => abs(A-B) < EPSILISH;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRoughly(this vec2  A, vec2  B) => abs(A-B) < EPSILISH;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRoughly(this vec3  A, vec3  B) => abs(A-B) < EPSILISH;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRoughly(this vec4  A, vec4  B) => abs(A-B) < EPSILISH;
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Wrap CoreLib Vector?
    //
    //      DotNet 8+ will use vector acceleration if available for "Vector" types:
    //          https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector.ishardwareaccelerated?view=net-8.0#system-numerics-vector-ishardwareaccelerated
    //
    //          https://learn.microsoft.com/en-us/dotnet/api/system.numerics.vector3?view=net-8.0
    //              https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Numerics/Vector3.cs
    //
    //          https://learn.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.wasm.packedsimd.dot?view=net-8.0
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
