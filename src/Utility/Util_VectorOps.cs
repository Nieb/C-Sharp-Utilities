namespace Utility;
using v1 = float;
using v2 = vec2;
using v3 = vec3;
using v4 = vec4;

internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Absolute" Value
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 abs(v1 A) => (A >= 0f) ? A : -A;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 abs(v2 A) => new v2(abs(A.x), abs(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 abs(v3 A) => new v3(abs(A.x), abs(A.y), abs(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 abs(v4 A) => new v4(abs(A.x), abs(A.y), abs(A.z), abs(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   "Average" of 2
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 avg(v1 A, v1 B) => (A+B) * 0.5f;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 avg(v2 A, v2 B) => (A+B) * 0.5f;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 avg(v3 A, v3 B) => (A+B) * 0.5f;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 avg(v4 A, v4 B) => (A+B) * 0.5f;

    //==========================================================================================================================================================
    //                                                                   "Average" of 3
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 avg(v1 A, v1 B, v1 C) => (A+B+C) * ONETHIRD;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 avg(v2 A, v2 B, v2 C) => (A+B+C) * ONETHIRD;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 avg(v3 A, v3 B, v3 C) => (A+B+C) * ONETHIRD;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 avg(v4 A, v4 B, v4 C) => (A+B+C) * ONETHIRD;

    //==========================================================================================================================================================
    //                                                                   "Average" of 4
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 avg(v1 A, v1 B, v1 C, v1 D) => (A+B+C+D) * 0.25f;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 avg(v2 A, v2 B, v2 C, v2 D) => (A+B+C+D) * 0.25f;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 avg(v3 A, v3 B, v3 C, v3 D) => (A+B+C+D) * 0.25f;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 avg(v4 A, v4 B, v4 C, v4 D) => (A+B+C+D) * 0.25f;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Clamp"
    //            *Inclusive*  *Inclusive*
    //  clamp( A, LowerBounds, UpperBounds )
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 clamp(v1 A, v1 L = 0f, v1 U = 1f) => (A <= L) ? L : (A >= U) ? U : A;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 clamp(v2 A, v1 L = 0f, v1 U = 1f) => new v2(clamp(A.x, L, U), clamp(A.y, L, U));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 clamp(v3 A, v1 L = 0f, v1 U = 1f) => new v3(clamp(A.x, L, U), clamp(A.y, L, U), clamp(A.z, L, U));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 clamp(v4 A, v1 L = 0f, v1 U = 1f) => new v4(clamp(A.x, L, U), clamp(A.y, L, U), clamp(A.z, L, U), clamp(A.w, L, U));

    //==========================================================================================================================================================
    //                                                                       "Wrap"
    //           *Inclusive*  *Exclusive*
    //  wrap( A, LowerBounds, UpperBounds )
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 wrap(v1 A, v1 L, v1 U) { v1 Domain = U-L; A = (A-L) % Domain; return A+L + ((A < 0f) ? Domain : 0f); }
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 wrap(v2 A, v1 L, v1 U) { v1 Domain = U-L; A = (A-L) % Domain; return A+L + ((A < 0f) ? Domain : 0f); }
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 wrap(v3 A, v1 L, v1 U) { v1 Domain = U-L; A = (A-L) % Domain; return A+L + ((A < 0f) ? Domain : 0f); }
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 wrap(v4 A, v1 L, v1 U) { v1 Domain = U-L; A = (A-L) % Domain; return A+L + ((A < 0f) ? Domain : 0f); }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Cross" Product
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 cross(v2 A, v2 B) => (A.x*B.y - A.y*B.x);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 cross(v3 A, v3 B) => new v3((A.y*B.z - A.z*B.y),  (A.z*B.x - A.x*B.z),  (A.x*B.y - A.y*B.x));

    //==========================================================================================================================================================
    //                                                                   "Dot" Product
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 dot(v2 A      ) => (A.x*A.x + A.y*A.y);           //  dot(A) == dot(A,A) == Squared-Length of A.
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 dot(v2 A, v2 B) => (A.x*B.x + A.y*B.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 dot(v3 A      ) => (A.x*A.x + A.y*A.y + A.z*A.z); //  dot(A) == dot(A,A) == Squared-Length of A.
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 dot(v3 A, v3 B) => (A.x*B.x + A.y*B.y + A.z*B.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Distance"
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 distance(v1 A, v1 B) =>      abs(B - A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 distance(v2 A, v2 B) => sqrt(dot(B - A));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 distance(v3 A, v3 B) => sqrt(dot(B - A));

    //==========================================================================================================================================================
    //                                                                      "Length"
    #if USE_METHOD_LENGTH || false
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 length(v1 A) => abs(A);
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 length(v2 A) => sqrt(A.x*A.x + A.y*A.y);
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 length(v3 A) => sqrt(A.x*A.x + A.y*A.y + A.z*A.z);
    #endif

    //==========================================================================================================================================================
    //                                                                    "Normalize"
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 normalize(v2 A) => (A == 0f) ? A : A/sqrt(A.x*A.x + A.y*A.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 normalize(v3 A) => (A == 0f) ? A : A/sqrt(A.x*A.x + A.y*A.y + A.z*A.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                "Fused Multiply Add"
    //
    //  A * B + C
    //
    //      https://registry.khronos.org/OpenGL-Refpages/gl4/html/fma.xhtml
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 fma(v1 A, v1 B, v1 C) => System.MathF.FusedMultiplyAdd(A, B, C);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 fma(v2 A, v2 B, v2 C) => new v2(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 fma(v3 A, v3 B, v3 C) => new v3(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y), fma(A.z, B.z, C.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 fma(v4 A, v4 B, v4 C) => new v4(fma(A.x, B.x, C.x), fma(A.y, B.y, C.y), fma(A.z, B.z, C.z), fma(A.w, B.w, C.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Invert"                Additive Inverse

    //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 inv(v2 A) => new vec2(-A.x, -A.y);

    //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 inv(v3 A) => new vec3(-A.x, -A.y, -A.z);

    //==========================================================================================================================================================
    //                                                                    "Complement"              Complimentary Inverse

    //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 cmp(v2 A) => new vec2(1f-A.x, 1f-A.y);

    //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 cmp(v3 A) => new vec3(1f-A.x, 1f-A.y, 1f-A.z);

    //==========================================================================================================================================================
    //                                                                    "Reciprocal"              Multiplicative Inverse

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 rcp(v1 A) => (A > -EPSILON && A < EPSILON) ? 0f : 1f/A;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 rcp(v2 A) => new v2(rcp(A.x), rcp(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 rcp(v3 A) => new v3(rcp(A.x), rcp(A.y), rcp(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 rcp(v4 A) => new v4(rcp(A.x), rcp(A.y), rcp(A.z), rcp(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                  "Minimum" Value
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 min(v1 A, v1 B)             => (A < B) ? A : B;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 min(v1 A, v1 B, v1 C)       => (A < B) ? ((A < C) ? A : C)
                                                                                                                : ((B < C) ? B : C);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 min(v1 A, v1 B, v1 C, v1 D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                                                                           : ((C < D) ? C : D))
                                                                                                                : ((B < C) ? ((B < D) ? B : D)
                                                                                                                           : ((C < D) ? C : D));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 min(v2 A, v1 B)             => new v2(min(A.x,B          ), min(A.y,B          ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 min(v2 A, v2 B)             => new v2(min(A.x,B.x        ), min(A.y,B.y        ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 min(v2 A, v2 B, v2 C)       => new v2(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 min(v2 A, v2 B, v2 C, v2 D) => new v2(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 min(v3 A, v1 B)             => new v3(min(A.x,B          ), min(A.y,B          ), min(A.z,B          ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 min(v3 A, v3 B)             => new v3(min(A.x,B.x        ), min(A.y,B.y        ), min(A.z,B.z        ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 min(v3 A, v3 B, v3 C)       => new v3(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ), min(A.z,B.z,C.z    ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 min(v3 A, v3 B, v3 C, v3 D) => new v3(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 min(v4 A, v1 B)             => new v4(min(A.x,B          ), min(A.y,B          ), min(A.z,B          ), min(A.w,B          ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 min(v4 A, v4 B)             => new v4(min(A.x,B.x        ), min(A.y,B.y        ), min(A.z,B.z        ), min(A.w,B.w        ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 min(v4 A, v4 B, v4 C)       => new v4(min(A.x,B.x,C.x    ), min(A.y,B.y,C.y    ), min(A.z,B.z,C.z    ), min(A.w,B.w,C.w    ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 min(v4 A, v4 B, v4 C, v4 D) => new v4(min(A.x,B.x,C.x,D.x), min(A.y,B.y,C.y,D.y), min(A.z,B.z,C.z,D.z), min(A.w,B.w,C.w,D.w));

    //==========================================================================================================================================================
    //                                                                  "Maximum" Value
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 max(v1 A, v1 B)             => (A > B) ? A : B;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 max(v1 A, v1 B, v1 C)       => (A > B) ? ((A > C) ? A : C)
                                                                                                                : ((B > C) ? B : C);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 max(v1 A, v1 B, v1 C, v1 D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                                                                           : ((C > D) ? C : D))
                                                                                                                : ((B > C) ? ((B > D) ? B : D)
                                                                                                                           : ((C > D) ? C : D));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 max(v2 A, v1 B)             => new v2(max(A.x,B          ), max(A.y,B          ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 max(v2 A, v2 B)             => new v2(max(A.x,B.x        ), max(A.y,B.y        ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 max(v2 A, v2 B, v2 C)       => new v2(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 max(v2 A, v2 B, v2 C, v2 D) => new v2(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 max(v3 A, v1 B)             => new v3(max(A.x,B          ), max(A.y,B          ), max(A.z,B          ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 max(v3 A, v3 B)             => new v3(max(A.x,B.x        ), max(A.y,B.y        ), max(A.z,B.z        ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 max(v3 A, v3 B, v3 C)       => new v3(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ), max(A.z,B.z,C.z    ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 max(v3 A, v3 B, v3 C, v3 D) => new v3(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 max(v4 A, v1 B)             => new v4(max(A.x,B          ), max(A.y,B          ), max(A.z,B          ), max(A.w,B          ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 max(v4 A, v4 B)             => new v4(max(A.x,B.x        ), max(A.y,B.y        ), max(A.z,B.z        ), max(A.w,B.w        ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 max(v4 A, v4 B, v4 C)       => new v4(max(A.x,B.x,C.x    ), max(A.y,B.y,C.y    ), max(A.z,B.z,C.z    ), max(A.w,B.w,C.w    ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 max(v4 A, v4 B, v4 C, v4 D) => new v4(max(A.x,B.x,C.x,D.x), max(A.y,B.y,C.y,D.y), max(A.z,B.z,C.z,D.z), max(A.w,B.w,C.w,D.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float MinOf(v2 A) => min(A.x,A.y        );
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float MinOf(v3 A) => min(A.x,A.y,A.z    );
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float MinOf(v4 A) => min(A.x,A.y,A.z,A.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float MaxOf(v2 A) => max(A.x,A.y        );
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float MaxOf(v3 A) => max(A.x,A.y,A.z    );
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float MaxOf(v4 A) => max(A.x,A.y,A.z,A.w);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                 "Minimum" Magnitude
    //
    //  minmag(A, B) == min(abs(A), abs(B))
    //
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 minmag(v1 A, v1 B) => System.MathF.MinMagnitude(A, B);

    //==========================================================================================================================================================
    //                                                                 "Maximum" Magnitude
    //
    //  maxmag(A, B) == max(abs(A), abs(B))
    //
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 maxmag(v1 A, v1 B) => System.MathF.MaxMagnitude(A, B);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Modulo"
    #if USE_METHOD_MOD || false
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 mod(v1 A, v1 B) => (A % B);

        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 mod(v2 A, v1 B) => new v2(A.x%B  , A.y%B  );
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 mod(v2 A, v2 B) => new v2(A.x%B.x, A.y%B.y);

        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 mod(v3 A, v1 B) => new v3(A.x%B  , A.y%B  , A.z%B  );
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 mod(v3 A, v3 B) => new v3(A.x%B.x, A.y%B.y, A.z%B.z);

        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 mod(v4 A, v1 B) => new v4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
        [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 mod(v4 A, v4 B) => new v4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    #endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Power"
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 pow(v1 A, v1 Exp) => System.MathF.Pow(A, Exp);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 pow(v2 A, v1 Exp) => new v2(pow(A.x, Exp  ), pow(A.y, Exp  ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 pow(v2 A, v2 Exp) => new v2(pow(A.x, Exp.x), pow(A.y, Exp.y));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 pow(v3 A, v1 Exp) => new v3(pow(A.x, Exp  ), pow(A.y, Exp  ), pow(A.z, Exp  ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 pow(v3 A, v3 Exp) => new v3(pow(A.x, Exp.x), pow(A.y, Exp.y), pow(A.z, Exp.z));

    //==========================================================================================================================================================
    //                                                                   "Exponential"
    //
    //      exp(x)  ==  pow(e, x)  ==  pow(2.718~, x)
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float exp(float A) => System.MathF.Exp(A);

    //==========================================================================================================================================================
    //                                                                    "Logarithm"
    //
    //  Inverse Pow/Exp.
    //
    //        log(x)  ==  x=pow( e, y)
    //       log2(x)  ==  x=pow( 2, y)    result is "y"
    //      log10(x)  ==  x=pow(10, y)
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float log  (float A) => System.MathF.Log(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float log2 (float A) => System.MathF.Log2(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float log10(float A) => System.MathF.Log10(A);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float log(float A, float InBase) => System.MathF.Log(A, InBase);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Projection"
    //
    //  Get Nearest-Point-On-Line from Point.
    //
    //      project(  Point,  Line-Position,  Line-Normal  )
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 project(v2 P, v2 Lp, v2 Ln) => Lp + Ln*dot(P-Lp, Ln);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 project(v3 P, v3 Lp, v3 Ln) => Lp + Ln*dot(P-Lp, Ln);

    //==========================================================================================================================================================
    //
    //  Arbitrary Line version.
    //
    //  Does not tell you if point is inbetween A & B.
    //      SEE: PointVsLine()
    //
    //  dot(P-La, dAB) / dot(dAB, dAB)  ==  Distance from LinePointA to NearestPointOnLine as multiple of dAB.
    //
    //      project_(  Point,  Line-PointA,  Line-PointB  )
    //
    [Impl(AggressiveOptimization)] internal static v2 project_(v2 P, v2 La, v2 Lb) { v2 dAB = Lb-La;  return La + dAB*( dot(P-La,dAB)/dot(dAB) ); }
    [Impl(AggressiveOptimization)] internal static v3 project_(v3 P, v3 La, v3 Lb) { v3 dAB = Lb-La;  return La + dAB*( dot(P-La,dAB)/dot(dAB) ); }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Reflect"
    //
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/reflect.xhtml
    //
    //      reflect( Vector-Normal, Surface-Normal )
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 reflect(v2 Vn, v2 Sn) => Vn - Sn*(2f * dot(Vn, Sn));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 reflect(v3 Vn, v3 Sn) => Vn - Sn*(2f * dot(Vn, Sn));

    //==========================================================================================================================================================
    //                                                                     "Refract"
    //
    //  https://www.desmos.com/calculator/eb0c0f77c7
    //
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/refract.xhtml
    //
    //  IndexOfRefraction:  The ratio of the speed-of-light in a vacuum to the speed-of-light in a medium.
    //                      Or, from one medium to another medium.
    //
    //      refract( Vector-Normal, Surface-Normal, Index-of-Refraction )
    //
    [Impl(AggressiveOptimization)]
    internal static vec2 refract(vec2 Vn, vec2 Sn, float Ratio) {
        float Dot = dot(Vn, Sn);

        float K = 1f - Ratio*Ratio*(1f - Dot*Dot);

        float Sqrt_K = sqrt(K);

        return (K < 0f) ? new vec2(0f) :  Vn*Ratio  -  Sn*(Ratio*Dot + Sqrt_K);
    }

    [Impl(AggressiveOptimization)]
    internal static vec3 refract(vec3 Vn, vec3 Sn, float Ratio) {
        float Dot = dot(Vn, Sn);

        float K = 1f - Ratio*Ratio*(1f - Dot*Dot);

        float Sqrt_K = sqrt(K);

        return (K < 0f) ? new vec3(0f) :  Vn*Ratio  -  Sn*(Ratio*Dot + Sqrt_K);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Round"                                     Each component rounded to nearest integer.
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 round(v1 A) => System.MathF.Round(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 round(v2 A) => new v2(round(A.x), round(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 round(v3 A) => new v3(round(A.x), round(A.y), round(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 round(v4 A) => new v4(round(A.x), round(A.y), round(A.z), round(A.w));

    //==========================================================================================================================================================
    //                                                                     "Round" To                                   Each component rounded to nearest 'RoundTo'.
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 round(v1 A, v1 RoundTo) => (RoundTo == 0f || RoundTo == 1f) ? round(A) : RoundTo*round(A/RoundTo);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 round(v2 A, v1 RoundTo) => (RoundTo == 0f || RoundTo == 1f) ? round(A) : RoundTo*round(A/RoundTo);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 round(v3 A, v1 RoundTo) => (RoundTo == 0f || RoundTo == 1f) ? round(A) : RoundTo*round(A/RoundTo);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 round(v4 A, v1 RoundTo) => (RoundTo == 0f || RoundTo == 1f) ? round(A) : RoundTo*round(A/RoundTo);

    //==========================================================================================================================================================
    //                                                                      "Floor"                                     Each component rounded down to nearest integer.
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 floor(v1 A) => System.MathF.Floor(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 floor(v2 A) => new v2(floor(A.x), floor(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 floor(v3 A) => new v3(floor(A.x), floor(A.y), floor(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 floor(v4 A) => new v4(floor(A.x), floor(A.y), floor(A.z), floor(A.w));

    //==========================================================================================================================================================
    //                                                                      "Ceiling"                                   Each component rounded up to nearest integer.
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 ceil(v1 A) => System.MathF.Ceiling(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 ceil(v2 A) => new v2(ceil(A.x), ceil(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 ceil(v3 A) => new v3(ceil(A.x), ceil(A.y), ceil(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 ceil(v4 A) => new v4(ceil(A.x), ceil(A.y), ceil(A.z), ceil(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                       "Sign"
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 sign(v1 A) => System.MathF.Sign(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 sign(v2 A) => new v2(sign(A.x), sign(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 sign(v3 A) => new v3(sign(A.x), sign(A.y), sign(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 sign(v4 A) => new v4(sign(A.x), sign(A.y), sign(A.z), sign(A.w));

    //==========================================================================================================================================================
    //                                                                     Copy "Sign"
    //
    //      sign(ThisValue, WithThisSign)
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 sign(v1 V, v1 S) => System.MathF.CopySign(V, S);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 sign(v2 V, v1 S) => new v2(sign(V.x, S  ), sign(V.y, S  ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 sign(v2 V, v2 S) => new v2(sign(V.x, S.x), sign(V.y, S.y));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 sign(v3 V, v1 S) => new v3(sign(V.x, S  ), sign(V.y, S  ), sign(V.z, S  ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 sign(v3 V, v3 S) => new v3(sign(V.x, S.x), sign(V.y, S.y), sign(V.z, S.z));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 sign(v4 V, v1 S) => new v4(sign(V.x, S  ), sign(V.y, S  ), sign(V.z, S  ), sign(V.w, S  ));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 sign(v4 V, v4 S) => new v4(sign(V.x, S.x), sign(V.y, S.y), sign(V.z, S.z), sign(V.w, S.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                      "Square"
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 square(v1 A) => (A * A);
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 square(v2 A) => new v2( (A.x*A.x),  (A.y*A.y) );
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 square(v3 A) => new v3( (A.x*A.x),  (A.y*A.y),  (A.z*A.z) );
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 square(v4 A) => new v4( (A.x*A.x),  (A.y*A.y),  (A.z*A.z),  (A.w*A.w) );

    //==========================================================================================================================================================
    //                                                                   "Square Root"
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 sqrt(v1 A) =>        System.MathF.Sqrt(A);
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 sqrt(v2 A) => new v2(System.MathF.Sqrt(A.x), System.MathF.Sqrt(A.y));
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 sqrt(v3 A) => new v3(System.MathF.Sqrt(A.x), System.MathF.Sqrt(A.y), System.MathF.Sqrt(A.z));
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 sqrt(v4 A) => new v4(System.MathF.Sqrt(A.x), System.MathF.Sqrt(A.y), System.MathF.Sqrt(A.z), System.MathF.Sqrt(A.w));

    //==========================================================================================================================================================
    //                                                                    "Cube Root"
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 cbrt(v1 A) =>        System.MathF.Cbrt(A);
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 cbrt(v2 A) => new v2(System.MathF.Cbrt(A.x), System.MathF.Cbrt(A.y));
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 cbrt(v3 A) => new v3(System.MathF.Cbrt(A.x), System.MathF.Cbrt(A.y), System.MathF.Cbrt(A.z));
  //[Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 cbrt(v4 A) => new v4(System.MathF.Cbrt(A.x), System.MathF.Cbrt(A.y), System.MathF.Cbrt(A.z), System.MathF.Cbrt(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                              "Truncate" or Integer Part
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 trunc(v1 A) =>        System.MathF.Truncate(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 trunc(v2 A) => new v2(System.MathF.Truncate(A.x), System.MathF.Truncate(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 trunc(v3 A) => new v3(System.MathF.Truncate(A.x), System.MathF.Truncate(A.y), System.MathF.Truncate(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 trunc(v4 A) => new v4(System.MathF.Truncate(A.x), System.MathF.Truncate(A.y), System.MathF.Truncate(A.z), System.MathF.Truncate(A.w));

    //==========================================================================================================================================================
    //                                                                 "Fractional" Part
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 fract(v1 A) =>       (A   - System.MathF.Truncate(A));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 fract(v2 A) => new v2(A.x - System.MathF.Truncate(A.x), A.y - System.MathF.Truncate(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 fract(v3 A) => new v3(A.x - System.MathF.Truncate(A.x), A.y - System.MathF.Truncate(A.y), A.z - System.MathF.Truncate(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 fract(v4 A) => new v4(A.x - System.MathF.Truncate(A.x), A.y - System.MathF.Truncate(A.y), A.z - System.MathF.Truncate(A.z), A.w - System.MathF.Truncate(A.w));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   Trigonometric
    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1  cos(v1 A) => System.MathF.Cos(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2  cos(v2 A) => new v2(cos(A.x), cos(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3  cos(v3 A) => new v3(cos(A.x), cos(A.y), cos(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4  cos(v4 A) => new v4(cos(A.x), cos(A.y), cos(A.z), cos(A.w));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 acos(v1 A) => System.MathF.Acos(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 acos(v2 A) => new v2(acos(A.x), acos(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 acos(v3 A) => new v3(acos(A.x), acos(A.y), acos(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 acos(v4 A) => new v4(acos(A.x), acos(A.y), acos(A.z), acos(A.w));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1  sin(v1 A) => System.MathF.Sin(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2  sin(v2 A) => new v2(sin(A.x), sin(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3  sin(v3 A) => new v3(sin(A.x), sin(A.y), sin(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4  sin(v4 A) => new v4(sin(A.x), sin(A.y), sin(A.z), sin(A.w));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 asin(v1 A) => System.MathF.Asin(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 asin(v2 A) => new v2(asin(A.x), asin(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 asin(v3 A) => new v3(asin(A.x), asin(A.y), asin(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 asin(v4 A) => new v4(asin(A.x), asin(A.y), asin(A.z), asin(A.w));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static (v1 Sin, v1 Cos) sincos(v1 A) => System.MathF.SinCos(A);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1  tan(v1 A) => System.MathF.Tan(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2  tan(v2 A) => new v2(tan(A.x), tan(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3  tan(v3 A) => new v3(tan(A.x), tan(A.y), tan(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4  tan(v4 A) => new v4(tan(A.x), tan(A.y), tan(A.z), tan(A.w));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 atan(v1 A) => System.MathF.Atan(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v2 atan(v2 A) => new v2(atan(A.x), atan(A.y));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v3 atan(v3 A) => new v3(atan(A.x), atan(A.y), atan(A.z));
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v4 atan(v4 A) => new v4(atan(A.x), atan(A.y), atan(A.z), atan(A.w));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 atan2(v1 A, v1 B) => System.MathF.Atan2(A, B);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     Hyperbolic
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1  cosh(v1 A) => System.MathF.Cosh(A);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 acosh(v1 A) => System.MathF.Acosh(A);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1  sinh(v1 A) => System.MathF.Sinh(A);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 asinh(v1 A) => System.MathF.Asinh(A);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1  tanh(v1 A) => System.MathF.Tanh(A);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static v1 atanh(v1 A) => System.MathF.Atanh(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  For a more precise conversion.
    //
    //  For a quick conversion, use:  Var * TO_DEG
    //                                Var * TO_RAD
    //
    internal static v1 ToDeg(v1 Radians) =>        (float)((double)Radians   * (180.0 / 3.14159265358979323846264338327950288419716939937511));

    internal static v2 ToDeg(v2 Radians) => new v2((float)((double)Radians.x * (180.0 / 3.14159265358979323846264338327950288419716939937511)),
                                                   (float)((double)Radians.y * (180.0 / 3.14159265358979323846264338327950288419716939937511)));

    internal static v3 ToDeg(v3 Radians) => new v3((float)((double)Radians.x * (180.0 / 3.14159265358979323846264338327950288419716939937511)),
                                                   (float)((double)Radians.y * (180.0 / 3.14159265358979323846264338327950288419716939937511)),
                                                   (float)((double)Radians.z * (180.0 / 3.14159265358979323846264338327950288419716939937511)));

    //==========================================================================================================================================================
    internal static v1 ToRad(v1 Degrees) =>        (float)((double)Degrees   * (3.14159265358979323846264338327950288419716939937511 / 180.0));

    internal static v2 ToRad(v2 Degrees) => new v2((float)((double)Degrees.x * (3.14159265358979323846264338327950288419716939937511 / 180.0)),
                                                   (float)((double)Degrees.y * (3.14159265358979323846264338327950288419716939937511 / 180.0)));

    internal static v3 ToRad(v3 Degrees) => new v3((float)((double)Degrees.x * (3.14159265358979323846264338327950288419716939937511 / 180.0)),
                                                   (float)((double)Degrees.y * (3.14159265358979323846264338327950288419716939937511 / 180.0)),
                                                   (float)((double)Degrees.z * (3.14159265358979323846264338327950288419716939937511 / 180.0)));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
