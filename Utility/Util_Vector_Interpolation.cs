using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/uehxy1vkau
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //   INPUT: V 0..1
    //          A ANY
    //          B ANY
    //  OUTPUT: A..B
    //
    //    GLSL: mix(X, Y, A)
    //              Linear interpolation between X & Y, using A to weight between them.
    //
    //          https://registry.khronos.org/OpenGL-Refpages/gl4/html/mix.xhtml
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Mix(float V, float A, float B) => A*(1f-V) + B*V;

    public static vec2 Mix(float V, vec2 A, vec2 B) => new vec2(A.x*(1f-V  ) + B.x*V  ,  A.y*(1f-V  ) + B.y*V  );
    public static vec2 Mix(vec2  V, vec2 A, vec2 B) => new vec2(A.x*(1f-V.x) + B.x*V.x,  A.y*(1f-V.y) + B.y*V.y);

    public static vec3 Mix(float V, vec3 A, vec3 B) => new vec3(A.x*(1f-V  ) + B.x*V  ,  A.y*(1f-V  ) + B.y*V  ,  A.z*(1f-V  ) + B.z*V  );
    public static vec3 Mix(vec3  V, vec3 A, vec3 B) => new vec3(A.x*(1f-V.x) + B.x*V.x,  A.y*(1f-V.y) + B.y*V.y,  A.z*(1f-V.z) + B.z*V.z);

    public static vec4 Mix(float V, vec4 A, vec4 B) => new vec4(A.x*(1f-V  ) + B.x*V  ,  A.y*(1f-V  ) + B.y*V  ,  A.z*(1f-V  ) + B.z*V  ,  A.w*(1f-V  ) + B.w*V  );
    public static vec4 Mix(vec4  V, vec4 A, vec4 B) => new vec4(A.x*(1f-V.x) + B.x*V.x,  A.y*(1f-V.y) + B.y*V.y,  A.z*(1f-V.z) + B.z*V.z,  A.w*(1f-V.w) + B.w*V.w);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //   INPUT: (0..1, ANY, ANY, ANY, ANY)
    //  OUTPUT: v00..v10..v01..v11
    public static float BiMix(vec2 P, float v00, float v10,
                                      float v01, float v11) {
        vec2 iP = (1f - P);
        return (v00 * iP.x * iP.y) + (v10 * P.x * iP.y) +
               (v01 * iP.x *  P.y) + (v11 * P.x *  P.y);
    }
    public static vec2 BiMix(vec2 P, vec2 v00, vec2 v10,
                                     vec2 v01, vec2 v11) {
        vec2 iP = (1f - P);
        return (v00 * iP.x * iP.y) + (v10 * P.x * iP.y) +
               (v01 * iP.x *  P.y) + (v11 * P.x *  P.y);
    }
    public static vec3 BiMix(vec2 P, vec3 v00, vec3 v10,
                                     vec3 v01, vec3 v11) {
        vec2 iP = (1f - P);
        return (v00 * iP.x * iP.y) + (v10 * P.x * iP.y) +
               (v01 * iP.x *  P.y) + (v11 * P.x *  P.y);
    }
    public static vec4 BiMix(vec2 P, vec4 v00, vec4 v10,
                                     vec4 v01, vec4 v11) {
        vec2 iP = (1f - P);
        return (v00 * iP.x * iP.y) + (v10 * P.x * iP.y) +
               (v01 * iP.x *  P.y) + (v11 * P.x *  P.y);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //   INPUT: (0..1, ANY, ANY)
    //  OUTPUT: A..B
    public static float SmoothMix(float V, float A, float B) {
        float DltAB = B-A;
        float LinStep = clamp((V*DltAB)/DltAB, 0f, 1f);
        float SmoStep = (LinStep*LinStep) * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    public static vec2 SmoothMix(float V, vec2 A, vec2 B) {
        vec2 DltAB = B-A;
        vec2 LinStep = clamp((V*DltAB)/DltAB, 0f, 1f);
        vec2 SmoStep = (LinStep*LinStep) * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    public static vec3 SmoothMix(float V, vec3 A, vec3 B) {
        vec3 DltAB = B-A;
        vec3 LinStep = clamp((V*DltAB)/DltAB, 0f, 1f);
        vec3 SmoStep = (LinStep*LinStep) * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    public static vec4 SmoothMix(float V, vec4 A, vec4 B) {
        vec4 DltAB = B-A;
        vec4 LinStep = clamp((V*DltAB)/DltAB, 0f, 1f);
        vec4 SmoStep = (LinStep*LinStep) * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //   INPUT: (ANY ANY)
    //  OUTPUT: 0|1
    //
    //    GLSL: step(Edge, X);
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Step(float V, float T) => (V < T) ? 0f : 1f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 Step(vec2 V, float T) => new vec2( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 Step(vec2 V, vec2  T) => new vec2( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 Step(vec3 V, float T) => new vec3( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f,  (V.z < T  ) ? 0f : 1f );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 Step(vec3 V, vec3  T) => new vec3( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f,  (V.z < T.z) ? 0f : 1f );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 Step(vec4 V, float T) => new vec4( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f,  (V.z < T  ) ? 0f : 1f,  (V.w < T  ) ? 0f : 1f );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 Step(vec4 V, vec4  T) => new vec4( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f,  (V.z < T.z) ? 0f : 1f,  (V.w < T.w) ? 0f : 1f );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //   INPUT: (ANY, ANY, ANY)
    //  OUTPUT: 0..1    Representing posititon between A & B.
    //
    //    GLSL: -
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float LinearStep(float V, float A, float B) => clamp((V-A) / (B-A), 0f, 1f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 LinearStep(float V, vec2 A, vec2 B) => clamp((V-A) / (B-A), 0f, 1f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 LinearStep(float V, vec3 A, vec3 B) => clamp((V-A) / (B-A), 0f, 1f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //   INPUT: (ANY, ANY, ANY)
    //  OUTPUT: 0..1
    //
    //    GLSL: smoothstep(Edge0, Edge1, X)
    //              Smooth Hermite-interpolation between 0 & 1 when Edge0 < X < Edge1.
    //
    //          https://registry.khronos.org/OpenGL-Refpages/gl4/html/smoothstep.xhtml
    //
    public static float SmoothStep(float V, float A, float B) {
        float LinStep = clamp((V-A) / (B-A), 0f, 1f);
        return LinStep*LinStep * (3f - 2f*LinStep);
    }

    public static vec2 SmoothStep(float V, vec2 A, vec2 B) {
        vec2 LinStep = clamp((V-A) / (B-A), 0f, 1f);
        return LinStep*LinStep * (3f - 2f*LinStep);
    }

    public static vec3 SmoothStep(float V, vec3 A, vec3 B) {
        vec3 LinStep = clamp((V-A) / (B-A), 0f, 1f);
        return LinStep*LinStep * (3f - 2f*LinStep);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
