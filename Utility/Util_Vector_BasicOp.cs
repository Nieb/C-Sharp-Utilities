using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Absolute" Value
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float abs(float A) => (A >= 0f) ? A : -A;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 abs(vec2 A) => new vec2( (A.x >= 0f) ? A.x : -A.x,  (A.y >= 0f) ? A.y : -A.y );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 abs(vec3 A) => new vec3( (A.x >= 0f) ? A.x : -A.x,  (A.y >= 0f) ? A.y : -A.y,  (A.z >= 0f) ? A.z : -A.z );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 abs(vec4 A) => new vec4( (A.x >= 0f) ? A.x : -A.x,  (A.y >= 0f) ? A.y : -A.y,  (A.z >= 0f) ? A.z : -A.z,  (A.w >= 0f) ? A.w : -A.w );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Average" of 2
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float avg(float A, float B) => (A + B) * 0.5f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 avg(vec2 A, vec2 B) => new vec2( (A.x+B.x) * 0.5f,  (A.y+B.y) * 0.5f );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 avg(vec3 A, vec3 B) => new vec3( (A.x+B.x) * 0.5f,  (A.y+B.y) * 0.5f,  (A.z+B.z) * 0.5f );

    //==========================================================================================================================================================
    //                                                                  "Average" of 3
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float avg(float A, float B, float C) => (A + B + C) * ONETHIRD;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 avg(vec2 A, vec2 B, vec2 C) => new vec2( (A.x+B.x+C.x) * ONETHIRD,  (A.y+B.y+C.y) * ONETHIRD );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 avg(vec3 A, vec3 B, vec3 C) => new vec3( (A.x+B.x+C.x) * ONETHIRD,  (A.y+B.y+C.y) * ONETHIRD,  (A.z+B.z+C.z) * ONETHIRD );

    //==========================================================================================================================================================
    //                                                                  "Average" of 4
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float avg(float A, float B, float C, float D) => (A + B + C + D) * 0.25f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 avg(vec2 A, vec2 B, vec2 C, vec2 D) => new vec2( (A.x+B.x+C.x+D.x) * 0.25f,  (A.y+B.y+C.y+D.y) * 0.25f );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 avg(vec3 A, vec3 B, vec3 C, vec3 D) => new vec3( (A.x+B.x+C.x+D.x) * 0.25f,  (A.y+B.y+C.y+D.y) * 0.25f,  (A.z+B.z+C.z+D.z) * 0.25f );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Clamp"
    ///
    /// clamp(x, *Inclusive*, *Inclusive*)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float clamp(float A, float Min = 0f, float Max = 1f) => (A <= Min) ? Min : (A >= Max) ? Max : A;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 clamp(vec2 A, float Min = 0f, float Max = 1f) => new vec2( (A.x <= Min) ? Min : (A.x >= Max) ? Max : A.x,
                                                                                    (A.y <= Min) ? Min : (A.y >= Max) ? Max : A.y );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 clamp(vec3 A, float Min = 0f, float Max = 1f) => new vec3( (A.x <= Min) ? Min : (A.x >= Max) ? Max : A.x,
                                                                                    (A.y <= Min) ? Min : (A.y >= Max) ? Max : A.y,
                                                                                    (A.z <= Min) ? Min : (A.z >= Max) ? Max : A.z );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 clamp(vec4 A, float Min = 0f, float Max = 1f) => new vec4( (A.x <= Min) ? Min : (A.x >= Max) ? Max : A.x,
                                                                                    (A.y <= Min) ? Min : (A.y >= Max) ? Max : A.y,
                                                                                    (A.z <= Min) ? Min : (A.z >= Max) ? Max : A.z,
                                                                                    (A.w <= Min) ? Min : (A.w >= Max) ? Max : A.w );

    //==========================================================================================================================================================
    //                                                                       "Wrap"
    ///
    /// wrap(x, *Inclusive*, *Exclusive*)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float wrap(float A, float Min, float Max) {
        #if DEBUG
            if (Max <= Min) throw new ArgumentException("Max must be greater than Min.");
        #endif

        float Domain = Max - Min;
        float Result = (A - Min) % Domain;

        return (Result < 0f) ? Result + Min + Domain
                             : Result + Min;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 wrap(vec2 A, float Min, float Max) {
        #if DEBUG
            if (Max <= Min) throw new ArgumentException("Max must be greater than Min.");
        #endif

        float Domain = Max - Min;
        vec2  Result = (A - Min) % Domain;

        return (Result < 0f) ? Result + Min + Domain
                             : Result + Min;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 wrap(vec3 A, float Min, float Max) {
        #if DEBUG
            if (Max <= Min) throw new ArgumentException("Max must be greater than Min.");
        #endif

        float Domain = Max - Min;
        vec3  Result = (A - Min) % Domain;

        return (Result < 0f) ? Result + Min + Domain
                             : Result + Min;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 wrap(vec4 A, float Min, float Max) {
        #if DEBUG
            if (Max <= Min) throw new ArgumentException("Max must be greater than Min.");
        #endif

        float Domain = Max - Min;
        vec4  Result = (A - Min) % Domain;

        return (Result < 0f) ? Result + Min + Domain
                             : Result + Min;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Cross" Product
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float cross(vec2 A, vec2 B) => (A.x*B.y - A.y*B.x);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 cross(vec3 A, vec3 B) => new vec3((A.y*B.z - A.z*B.y),  (A.z*B.x - A.x*B.z),  (A.x*B.y - A.y*B.x));

    //==========================================================================================================================================================
    //                                                                   "Dot" Product
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float dot(vec2 A, vec2 B) => (A.x*B.x + A.y*B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float dot(vec3 A, vec3 B) => (A.x*B.x + A.y*B.y + A.z*B.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Distance"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float distance(float A, float B) => (B - A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float distance(vec2 A, vec2 B) {
        float dAB_x = B.x - A.x;
        float dAB_y = B.y - A.y;
        return MathF.Sqrt(dAB_x*dAB_x + dAB_y*dAB_y);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float distance(vec3 A, vec3 B) {
        float dAB_x = B.x - A.x;
        float dAB_y = B.y - A.y;
        float dAB_z = B.z - A.z;
        return MathF.Sqrt(dAB_x*dAB_x + dAB_y*dAB_y + dAB_z*dAB_z);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 "Fractional" Part
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float fract(float A) => (A - MathF.Truncate(A));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 fract(vec2 A) => new vec2( A.x-MathF.Truncate(A.x),  A.y-MathF.Truncate(A.y) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 fract(vec3 A) => new vec3( A.x-MathF.Truncate(A.x),  A.y-MathF.Truncate(A.y),  A.z-MathF.Truncate(A.z) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 fract(vec4 A) => new vec4( A.x-MathF.Truncate(A.x),  A.y-MathF.Truncate(A.y),  A.z-MathF.Truncate(A.z),  A.w-MathF.Truncate(A.w) );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                "Fused Multiply Add"
    ///
    ///
    /// A * B + C
    ///
    /// https://registry.khronos.org/OpenGL-Refpages/gl4/html/fma.xhtml
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float fma(float A, float B, float C) => MathF.FusedMultiplyAdd(A, B, C);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static vec2 fma(vec2 A, vec2 B, vec2 C) =>
    //    new vec2(
    //        MathF.FusedMultiplyAdd(A.x, B.x, C.x),
    //        MathF.FusedMultiplyAdd(A.y, B.y, C.y)
    //    );

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static vec3 fma(vec3 A, vec3 B, vec3 C) =>
    //    new vec3(
    //        MathF.FusedMultiplyAdd(A.x, B.x, C.x),
    //        MathF.FusedMultiplyAdd(A.y, B.y, C.y),
    //        MathF.FusedMultiplyAdd(A.z, B.z, C.z)
    //    );

    ////[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static vec4 fma(vec4 A, vec4 B, vec4 C) =>
    //    new vec4(
    //        MathF.FusedMultiplyAdd(A.x, B.x, C.x),
    //        MathF.FusedMultiplyAdd(A.y, B.y, C.y),
    //        MathF.FusedMultiplyAdd(A.z, B.z, C.z),
    //        MathF.FusedMultiplyAdd(A.w, B.w, C.w)
    //    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Invert"                Additive Inverse
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static vec2 inv(vec2 A) => new vec2(-A.x, -A.y      );
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static vec3 inv(vec3 A) => new vec3(-A.x, -A.y, -A.z);

    //==========================================================================================================================================================
    //                                                                    "Complement"              Complimentary Inverse
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static vec2 cmp(vec2 A) => new vec2(1f-A.x, 1f-A.y        );
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static vec3 cmp(vec3 A) => new vec3(1f-A.x, 1f-A.y, 1f-A.z);

    //==========================================================================================================================================================
    //                                                                    "Reciprocal"              Multiplicative Inverse
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 rcp(vec2 A) =>
        new vec2(
            (A.x > -EPSILON && A.x < EPSILON) ? 0f : 1f/A.x,
            (A.y > -EPSILON && A.y < EPSILON) ? 0f : 1f/A.y
        );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 rcp(vec3 A) =>
        new vec3(
            (A.x > -EPSILON && A.x < EPSILON) ? 0f : 1f/A.x,
            (A.y > -EPSILON && A.y < EPSILON) ? 0f : 1f/A.y,
            (A.z > -EPSILON && A.z < EPSILON) ? 0f : 1f/A.z
        );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Minimum" Value
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float min(float A, float B) => (A < B) ? A : B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float min(float A, float B, float C) => (A < B) ? ((A < C) ? A : C)
                                                                  : ((B < C) ? B : C);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float min(float A, float B, float C, float D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                                      : ((C < D) ? C : D))
                                                                           : ((B < C) ? ((B < D) ? B : D)
                                                                                      : ((C < D) ? C : D));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 min(vec2 A, float B) => new vec2( (A.x < B  ) ? A.x : B  ,  (A.y < B  ) ? A.y : B   );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 min(vec2 A, vec2  B) => new vec2( (A.x < B.x) ? A.x : B.x,  (A.y < B.y) ? A.y : B.y );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 min(vec2 A, vec2  B, vec2 C)         => new vec2( min(A.x, B.x, C.x),      min(A.y, B.y, C.y)      );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 min(vec2 A, vec2  B, vec2 C, vec2 D) => new vec2( min(A.x, B.x, C.x, D.x), min(A.y, B.y, C.y, D.y) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 min(vec3 A, float B) => new vec3( (A.x < B  ) ? A.x : B  ,  (A.y < B  ) ? A.y : B  ,  (A.z < B  ) ? A.z : B   );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 min(vec3 A, vec3  B) => new vec3( (A.x < B.x) ? A.x : B.x,  (A.y < B.y) ? A.y : B.y,  (A.z < B.z) ? A.z : B.z );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 min(vec3 A, vec3  B, vec3 C)         => new vec3( min(A.x, B.x, C.x),      min(A.y, B.y, C.y),      min(A.z, B.z, C.z)      );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 min(vec3 A, vec3  B, vec3 C, vec3 D) => new vec3( min(A.x, B.x, C.x, D.x), min(A.y, B.y, C.y, D.y), min(A.z, B.z, C.z, D.z) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 min(vec4 A, float B) => new vec4( (A.x < B  ) ? A.x : B  ,  (A.y < B  ) ? A.y : B  ,  (A.z < B  ) ? A.z : B  ,  (A.w < B  ) ? A.w : B   );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 min(vec4 A, vec4  B) => new vec4( (A.x < B.x) ? A.x : B.x,  (A.y < B.y) ? A.y : B.y,  (A.z < B.z) ? A.z : B.z,  (A.w < B.w) ? A.w : B.w );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 min(vec4 A, vec4  B, vec4 C)         => new vec4( min(A.x, B.x, C.x),      min(A.y, B.y, C.y),      min(A.z, B.z, C.z),      min(A.w, B.w, C.w)      );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 min(vec4 A, vec4  B, vec4 C, vec4 D) => new vec4( min(A.x, B.x, C.x, D.x), min(A.y, B.y, C.y, D.y), min(A.z, B.z, C.z, D.z), min(A.w, B.w, C.w, D.w) );

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float max(float A, float B) => (A > B) ? A : B;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float max(float A, float B, float C) => (A > B) ? ((A > C) ? A : C)
                                                                  : ((B > C) ? B : C);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float max(float A, float B, float C, float D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                      : ((C > D) ? C : D))
                                                                           : ((B > C) ? ((B > D) ? B : D)
                                                                                      : ((C > D) ? C : D));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 max(vec2 A, float B) => new vec2( (A.x > B  ) ? A.x : B  ,  (A.y > B  ) ? A.y : B   );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 max(vec2 A, vec2  B) => new vec2( (A.x > B.x) ? A.x : B.x,  (A.y > B.y) ? A.y : B.y );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 max(vec2 A, vec2  B, vec2 C)         => new vec2( max(A.x, B.x, C.x),      max(A.y, B.y, C.y)      );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 max(vec2 A, vec2  B, vec2 C, vec2 D) => new vec2( max(A.x, B.x, C.x, D.x), max(A.y, B.y, C.y, D.y) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 max(vec3 A, float B) => new vec3( (A.x > B  ) ? A.x : B  ,  (A.y > B  ) ? A.y : B  ,  (A.z > B  ) ? A.z : B   );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 max(vec3 A, vec3  B) => new vec3( (A.x > B.x) ? A.x : B.x,  (A.y > B.y) ? A.y : B.y,  (A.z > B.z) ? A.z : B.z );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 max(vec3 A, vec3  B, vec3 C)         => new vec3( max(A.x, B.x, C.x),      max(A.y, B.y, C.y),      max(A.z, B.z, C.z)      );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 max(vec3 A, vec3  B, vec3 C, vec3 D) => new vec3( max(A.x, B.x, C.x, D.x), max(A.y, B.y, C.y, D.y), max(A.z, B.z, C.z, D.z) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 max(vec4 A, float B) => new vec4( (A.x > B  ) ? A.x : B  ,  (A.y > B  ) ? A.y : B  ,  (A.z > B  ) ? A.z : B  ,  (A.w > B  ) ? A.w : B   );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 max(vec4 A, vec4  B) => new vec4( (A.x > B.x) ? A.x : B.x,  (A.y > B.y) ? A.y : B.y,  (A.z > B.z) ? A.z : B.z,  (A.w > B.w) ? A.w : B.w );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 max(vec4 A, vec4  B, vec4 C)         => new vec4( max(A.x, B.x, C.x),      max(A.y, B.y, C.y),      max(A.z, B.z, C.z),      max(A.w, B.w, C.w)      );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 max(vec4 A, vec4  B, vec4 C, vec4 D) => new vec4( max(A.x, B.x, C.x, D.x), max(A.y, B.y, C.y, D.y), max(A.z, B.z, C.z, D.z), max(A.w, B.w, C.w, D.w) );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Modulo"
#if USE_METHOD_MOD
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float mod(float A, float B) => (A % B);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 mod(vec2 A, vec2  B) => new vec2(A.x%B.x, A.y%B.y);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 mod(vec2 A, float B) => new vec2(A.x%B  , A.y%B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 mod(vec3 A, vec3  B) => new vec3(A.x%B.x, A.y%B.y, A.z%B.z);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 mod(vec3 A, float B) => new vec3(A.x%B  , A.y%B  , A.z%B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 mod(vec4 A, vec4  B) => new vec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 mod(vec4 A, float B) => new vec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
#endif
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Normalize"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 normalize(vec2 A) {
        if (A.x == 0f && A.y == 0f) //  Avoid DivByZero.
            return A;

        float Scaler = 1f / MathF.Sqrt(A.x*A.x + A.y*A.y); //  (LengthNew / LengthOld).

        return new vec2(A.x*Scaler, A.y*Scaler);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 normalize(vec3 A) {
        if (A.x == 0f && A.y == 0f && A.z == 0f) //  Avoid DivByZero.
            return A;

        float Scaler = 1f / MathF.Sqrt(A.x*A.x + A.y*A.y + A.z*A.z); //  (LengthNew / LengthOld).

        return new vec3(A.x*Scaler, A.y*Scaler, A.z*Scaler);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Power"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float pow(float A, float Exp) => MathF.Pow(A, Exp);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2  pow(vec2  A, float Exp) => new vec2(MathF.Pow(A.x, Exp  ), MathF.Pow(A.y, Exp  ));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2  pow(vec2  A, vec2  Exp) => new vec2(MathF.Pow(A.x, Exp.x), MathF.Pow(A.y, Exp.y));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3  pow(vec3  A, float Exp) => new vec3(MathF.Pow(A.x, Exp  ), MathF.Pow(A.y, Exp  ), MathF.Pow(A.z, Exp  ));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3  pow(vec3  A, vec3  Exp) => new vec3(MathF.Pow(A.x, Exp.x), MathF.Pow(A.y, Exp.y), MathF.Pow(A.z, Exp.z));

    //==========================================================================================================================================================
    //                                                                   "Exponential"
    //
    //  exp(x) == e^x
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float exp(float A) => MathF.Exp(A);

    //==========================================================================================================================================================
    //                                                                    "Logarithm"
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static float log() => MathF.Log();

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Reflect"
    ///
    /// https://registry.khronos.org/OpenGL-Refpages/gl4/html/reflect.xhtml
    ///
    ///     reflect( Vector-Normal, Surface-Normal )
    ///
    internal static vec2 reflect(vec2 Vn, vec2 Sn) {
        float Dot = (Vn.x * Sn.x) + (Vn.y * Sn.y);
        return new vec2(
            Vn.x - (2f * Dot) * Sn.x,
            Vn.y - (2f * Dot) * Sn.y
        );
    }

    internal static vec3 reflect(vec3 Vn, vec3 Sn) {
        float Dot = (Vn.x * Sn.x) + (Vn.y * Sn.y) + (Vn.z * Sn.z);
        return new vec3(
            Vn.x - (2f * Dot) * Sn.x,
            Vn.y - (2f * Dot) * Sn.y,
            Vn.z - (2f * Dot) * Sn.z
        );
    }

    //==========================================================================================================================================================
    //                                                                     "Refract"
    ///
    /// https://registry.khronos.org/OpenGL-Refpages/gl4/html/refract.xhtml
    /// https://www.desmos.com/calculator/mjieymtttc
    ///
    ///     refract( Vector-Normal, Surface-Normal, Index-of-Refraction )
    ///
    ///         IndexOfRefraction:  The ratio of the speed of light in a vacuum, to the speed of light in a medium.
    ///                             Or, from one medium to another medium.
    ///
    internal static vec2 refract(vec2 Vn, vec2 Sn, float Ratio) {
        float Dot = (Vn.x * Sn.x) + (Vn.y * Sn.y);

        float K = 1f - Ratio*Ratio * (1f - Dot*Dot);

        float Sqrt_K = MathF.Sqrt(K);

        return (K < 0f) ? new vec2(0f)
                        : new vec2( Ratio*Vn.x - (Ratio*Dot + Sqrt_K) * Sn.x,
                                    Ratio*Vn.y - (Ratio*Dot + Sqrt_K) * Sn.y );
    }

    internal static vec3 refract(vec3 Vn, vec3 Sn, float Ratio) {
        float Dot = (Vn.x * Sn.x) + (Vn.y * Sn.y) + (Vn.z * Sn.z);

        float K = 1f - Ratio*Ratio * (1f - Dot*Dot);

        float Sqrt_K = MathF.Sqrt(K);

        return (K < 0f) ? new vec3(0f)
                        : new vec3( Ratio*Vn.x - (Ratio*Dot + Sqrt_K) * Sn.x,
                                    Ratio*Vn.y - (Ratio*Dot + Sqrt_K) * Sn.y,
                                    Ratio*Vn.z - (Ratio*Dot + Sqrt_K) * Sn.z );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Round"                                     Each component rounded to nearest integer.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float round(float A) => MathF.Round(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 round(vec2 A) => new vec2( MathF.Round(A.x), MathF.Round(A.y) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 round(vec3 A) => new vec3( MathF.Round(A.x), MathF.Round(A.y),  MathF.Round(A.z) );

    //==========================================================================================================================================================
    //                                                                     "Round" To                                   Each component rounded to nearest 'RoundTo'.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float round(float A, float RoundTo) =>
        (RoundTo == 0f || RoundTo == 1f) ? MathF.Round(A)
                                         : MathF.Round(A/RoundTo)*RoundTo;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 round(vec2 A, float RoundTo) =>
        (RoundTo == 0f || RoundTo == 1f) ? new vec2(  MathF.Round(A.x)                ,  MathF.Round(A.y)                  )
                                         : new vec2(  MathF.Round(A.x/RoundTo)*RoundTo,  MathF.Round(A.y/RoundTo)*RoundTo  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 round(vec3 A, float RoundTo) =>
        (RoundTo == 0f || RoundTo == 1f) ? new vec3(  MathF.Round(A.x)                ,  MathF.Round(A.y)                ,  MathF.Round(A.z)                  )
                                         : new vec3(  MathF.Round(A.x/RoundTo)*RoundTo,  MathF.Round(A.y/RoundTo)*RoundTo,  MathF.Round(A.z/RoundTo)*RoundTo  );

    //==========================================================================================================================================================
    //                                                                      "Floor"                                     Each component rounded down.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float floor(float A) => MathF.Floor(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 floor(vec2 A) => new vec2( MathF.Floor(A.x),  MathF.Floor(A.y) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 floor(vec3 A) => new vec3( MathF.Floor(A.x),  MathF.Floor(A.y),  MathF.Floor(A.z));

    //==========================================================================================================================================================
    //                                                                      "Ceiling"                                   Each component rounded up.
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float ceil(float A) => MathF.Ceiling(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 ceil(vec2 A) => new vec2( MathF.Ceiling(A.x),  MathF.Ceiling(A.y) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 ceil(vec3 A) => new vec3( MathF.Ceiling(A.x),  MathF.Ceiling(A.y),  MathF.Ceiling(A.z) );

    //==========================================================================================================================================================
    //                                                                     "Truncate"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float trunc(float A) => MathF.Truncate(A);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 trunc(vec2 A) => new vec2( MathF.Truncate(A.x),  MathF.Truncate(A.y) );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 trunc(vec3 A) => new vec3( MathF.Truncate(A.x),  MathF.Truncate(A.y),  MathF.Truncate(A.z) );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Square"
  //[MethodImpl(MethodImplOptions.AggressiveInlining)]
  //internal static float square(float A) => (A * A);
  //
  //[MethodImpl(MethodImplOptions.AggressiveInlining)]
  //internal static vec2 square(vec2 A) => new vec2( (A.x * A.x),  (A.y * A.y) );
  //
  //[MethodImpl(MethodImplOptions.AggressiveInlining)]
  //internal static vec3 square(vec3 A) => new vec3( (A.x * A.x),  (A.y * A.y),  (A.z * A.z) );
  //
  //[MethodImpl(MethodImplOptions.AggressiveInlining)]
  //internal static vec4 square(vec4 A) => new vec4( (A.x * A.x),  (A.y * A.y),  (A.z * A.z),  (A.w * A.w) );

    //==========================================================================================================================================================
    //                                                                   "Square Root"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float sqrt(float A) => MathF.Sqrt(A);

  //[MethodImpl(MethodImplOptions.AggressiveInlining)]
  //internal static vec2 sqrt(vec2 A) => new vec2( MathF.Sqrt(A.x),  MathF.Sqrt(A.y) );
  //
  //[MethodImpl(MethodImplOptions.AggressiveInlining)]
  //internal static vec3 sqrt(vec3 A) => new vec3( MathF.Sqrt(A.x),  MathF.Sqrt(A.y),  MathF.Sqrt(A.z) );
  //
  //[MethodImpl(MethodImplOptions.AggressiveInlining)]
  //internal static vec4 sqrt(vec4 A) => new vec4( MathF.Sqrt(A.x),  MathF.Sqrt(A.y),  MathF.Sqrt(A.z),  MathF.Sqrt(A.w) );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
