using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float BitDec(float A) => MathF.BitDecrement(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float BitInc(float A) => MathF.BitIncrement(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #if USE_QUOTE_CONSTRUCTORS_UNQUOTE || false
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ivec2 ivec2(int X, int Y) => new ivec2(X, Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ivec2 ivec2(int XY      ) => new ivec2(XY, XY);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static  vec2  vec2(float X, float Y) => new vec2(X, Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static  vec2  vec2(float XY        ) => new vec2(XY, XY);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ivec3 ivec3(int X, int Y, int Z) => new ivec3(X, Y, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ivec3 ivec3(int XYZ            ) => new ivec3(XYZ, XYZ, XYZ);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static  vec3  vec3(float X, float Y, float Z) => new vec3(X, Y, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static  vec3  vec3(float XYZ                ) => new vec3(XYZ, XYZ, XYZ);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ivec4 ivec4(int X, int Y, int Z, int W) => new ivec4(X, Y, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ivec4 ivec4(ivec3 XYZ          , int W) => new ivec4(XYZ.x, XYZ.y, XYZ.z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ivec4 ivec4(int XYZ            , int W) => new ivec4(XYZ, XYZ, XYZ, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ivec4 ivec4(int XYZW                  ) => new ivec4(XYZW, XYZW, XYZW, XYZW);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static  vec4  vec4(float X, float Y, float Z, float W) => new vec4(X, Y, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static  vec4  vec4(vec3 XYZ                 , float W) => new vec4(XYZ.x, XYZ.y, XYZ.z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static  vec4  vec4(float XYZ                , float W) => new vec4(XYZ, XYZ, XYZ, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static  vec4  vec4(float XYZW                        ) => new vec4(XYZW, XYZW, XYZW, XYZW);
    #endif
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #if DEBUG
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsApproximatelyZero(this float A) => (A > -EPSILON && A < EPSILON);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsApproximatelyZero(this vec2  A) => (A > -EPSILON && A < EPSILON);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsApproximatelyZero(this vec3  A) => (A > -EPSILON && A < EPSILON);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsApproximatelyZero(this vec4  A) => (A > -EPSILON && A < EPSILON);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsApproximately(this float A, float B) => abs(A-B) < EPSILON;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsApproximately(this vec2  A, vec2  B) => abs(A-B) < EPSILON;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsApproximately(this vec3  A, vec3  B) => abs(A-B) < EPSILON;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsApproximately(this vec4  A, vec4  B) => abs(A-B) < EPSILON;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsRoughly(this float A, float B) => abs(A-B) < EPSILISH;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsRoughly(this vec2  A, vec2  B) => abs(A-B) < EPSILISH;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsRoughly(this vec3  A, vec3  B) => abs(A-B) < EPSILISH;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsRoughly(this vec4  A, vec4  B) => abs(A-B) < EPSILISH;
    #endif
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
