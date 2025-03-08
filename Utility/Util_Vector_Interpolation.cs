using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Mix" functions use a Weight to return an interpolation of A and B.
    //
    //  "Step" functions return an interpolated-Weight reflecting V's position between A and B.
    //
    //      https://www.desmos.com/calculator/uehxy1vkau
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Linear Interpolation"
    //  Mix(
    //      V: 0..1,    Weighted position between A and B.
    //      A: any,     Values to be mixed.
    //      B: any      Values to be mixed.
    //  )
    //
    //  OUTPUT: A..B
    //
    //    GLSL: mix(X, Y, A)
    //              Linear interpolation between X & Y, using A to weight between them.
    //
    //          https://registry.khronos.org/OpenGL-Refpages/gl4/html/mix.xhtml
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float Mix(float V, float A, float B) => A*(1f-V) + B*V;

    internal static vec2  Mix(float V, vec2  A, vec2  B) => A*(1f-V) + B*V;
    internal static vec2  Mix(vec2  V, vec2  A, vec2  B) => A*(1f-V) + B*V;

    internal static vec3  Mix(float V, vec3  A, vec3  B) => A*(1f-V) + B*V;
    internal static vec3  Mix(vec3  V, vec3  A, vec3  B) => A*(1f-V) + B*V;

    internal static vec4  Mix(float V, vec4  A, vec4  B) => A*(1f-V) + B*V;
    internal static vec4  Mix(vec4  V, vec4  A, vec4  B) => A*(1f-V) + B*V;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                              "Bilinear Interpolation"
    //  BiMix(
    //      V: (0..1, 0..1),    Weighted position for axis X and Y.
    //      A: any,             Values to be mixed.
    //      B: any,             Values to be mixed.
    //      C: any,             Values to be mixed.
    //      D: any              Values to be mixed.
    //  )
    //
    //  OUTPUT: A..B
    //          :  :
    //          C..D
    //
    //    GLSL: -
    //
    internal static float BiMix(vec2 V, float A, float B, float C, float D) {
        vec2 iV = 1f - V;
        return (A * iV.x*iV.y) + (B * V.x*iV.y)
             + (C * iV.x* V.y) + (D * V.x* V.y);
    }

    internal static vec2 BiMix(vec2 V, vec2 A, vec2 B, vec2 C, vec2 D) {
        vec2 iV = 1f - V;
        return (A * iV.x*iV.y) + (B * V.x*iV.y)
             + (C * iV.x* V.y) + (D * V.x* V.y);
    }

    internal static vec3 BiMix(vec2 V, vec3 A, vec3 B, vec3 C, vec3 D) {
        vec2 iV = 1f - V;
        return (A * iV.x*iV.y) + (B * V.x*iV.y)
             + (C * iV.x* V.y) + (D * V.x* V.y);
    }

    internal static vec4 BiMix(vec2 V, vec4 A, vec4 B, vec4 C, vec4 D) {
        vec2 iV = 1f - V;
        return (A * iV.x*iV.y) + (B * V.x*iV.y)
             + (C * iV.x* V.y) + (D * V.x* V.y);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Hermite Interpolation"
    //  SmoothMix(
    //      V: 0..1,    Weighted position between A and B.
    //      A: any,     Values to be mixed.
    //      B: any      Values to be mixed.
    //  )
    //
    //  OUTPUT: A..B
    //
    //    GLSL: -
    //
    internal static float SmoothMix(float V, float A, float B) {
        float dAB = B - A;
        float LinStep = clamp((V*dAB) / dAB);
        float SmoStep = LinStep*LinStep * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    internal static vec2 SmoothMix(float V, vec2 A, vec2 B) {
        vec2 dAB = B - A;
        vec2 LinStep = clamp((V*dAB) / dAB);
        vec2 SmoStep = LinStep*LinStep * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    internal static vec3 SmoothMix(float V, vec3 A, vec3 B) {
        vec3 dAB = B - A;
        vec3 LinStep = clamp((V*dAB) / dAB);
        vec3 SmoStep = LinStep*LinStep * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    internal static vec4 SmoothMix(float V, vec4 A, vec4 B) {
        vec4 dAB = B - A;
        vec4 LinStep = clamp((V*dAB) / dAB);
        vec4 SmoStep = LinStep*LinStep * (3f - 2f*LinStep);
        return A*(1f-SmoStep) + B*SmoStep;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                          "Spherical Linear Interpolation"
    //  Slerp(
    //      V: 0..1,    Weighted position between A and B.
    //      A: any,     ...
    //      B: any      ...
    //  )
    //
    //      V: 0..1,
    //      A: any,
    //      B: any
    //
    internal static vec2 Slerp(float V, vec2 A, vec2 B) {
        float ThetaAB = acos( dot(A,B) );
        float SinT = sin(ThetaAB);
        float iV = (1f - V);

        A *= sin(ThetaAB * iV) / SinT;
        B *= sin(ThetaAB *  V) / SinT;

        return A + B;
    }

    internal static vec3 Slerp(float V, vec3 A, vec3 B) {
        float ThetaAB = acos( dot(A,B) );
        float SinT = sin(ThetaAB);
        float iV = (1f - V);

        A *= sin(ThetaAB * iV) / SinT;
        B *= sin(ThetaAB *  V) / SinT;

        return A + B;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Threshold"               In the same spirit as "Nearest Neighbor Interpolation".
    //  Step(
    //      V: any,     Value
    //      T: any      Threshold
    //  )
    //
    //  OUTPUT: 0|1
    //
    //    GLSL: step(Edge, X);
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float Step(float V, float T) => (V < T) ? 0f : 1f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 Step(vec2 V, float T) => new vec2( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 Step(vec2 V, vec2  T) => new vec2( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 Step(vec3 V, float T) => new vec3( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f,  (V.z < T  ) ? 0f : 1f );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 Step(vec3 V, vec3  T) => new vec3( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f,  (V.z < T.z) ? 0f : 1f );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 Step(vec4 V, float T) => new vec4( (V.x < T  ) ? 0f : 1f,  (V.y < T  ) ? 0f : 1f,  (V.z < T  ) ? 0f : 1f,  (V.w < T  ) ? 0f : 1f );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 Step(vec4 V, vec4  T) => new vec4( (V.x < T.x) ? 0f : 1f,  (V.y < T.y) ? 0f : 1f,  (V.z < T.z) ? 0f : 1f,  (V.w < T.w) ? 0f : 1f );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Linear Interpolation"
    //  LinearStep(
    //      V: any,     Value to weight between A and B.
    //      A: any,     ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: 0..1
    //
    //    GLSL: -
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float LinearStep(float V, float A, float B) => clamp((V-A) / (B-A));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2  LinearStep(float V, vec2  A, vec2  B) => clamp((V-A) / (B-A));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2  LinearStep(vec2  V, vec2  A, vec2  B) => clamp((V-A) / (B-A));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3  LinearStep(float V, vec3  A, vec3  B) => clamp((V-A) / (B-A));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3  LinearStep(vec3  V, vec3  A, vec3  B) => clamp((V-A) / (B-A));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                               "Hermite Interpolation"
    //  SmoothStep(
    //      V: any,     Value to weight between A and B.
    //      A: any,     ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: 0..1
    //
    //    GLSL: smoothstep(Edge0, Edge1, X)
    //              Smooth Hermite-interpolation between 0 & 1 when Edge0 < X < Edge1.
    //
    //          https://registry.khronos.org/OpenGL-Refpages/gl4/html/smoothstep.xhtml
    //
    internal static float SmoothStep(float V)                   {  V = clamp(V);              return V*V * (3f - 2f*V);  }
    internal static float SmoothStep(float V, float A, float B) {  V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);  }

    internal static vec2  SmoothStep(vec2  V)                   {  V = clamp(V);              return V*V * (3f - 2f*V);  }
    internal static vec2  SmoothStep(vec2  V, vec2  A, vec2  B) {  V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);  }
    internal static vec2  SmoothStep(vec2  V, float A, float B) {  V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);  }
  //internal static vec2  SmoothStep(float V, vec2  A, vec2  B) {  V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);  }

    internal static vec3  SmoothStep(vec3  V)                   {  V = clamp(V);              return V*V * (3f - 2f*V);  }
    internal static vec3  SmoothStep(vec3  V, vec3  A, vec3  B) {  V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);  }
    internal static vec3  SmoothStep(vec3  V, float A, float B) {  V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);  }
  //internal static vec3  SmoothStep(float V, vec3  A, vec3  B) {  V = clamp((V-A) / (B-A));  return V*V * (3f - 2f*V);  }

    //==========================================================================================================================================================
    //
    //  SharpStep(
    //      V: any,     Value to weight between A and B.
    //      A: any,     ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: 0..1
    //
    //  AKA: "SmootherStep()"
    //      Not actually "Smoother".
    //          The sharper/tighter bends bring this more inline with Step.
    //
    //          Or, in a way, more inline with the sharp/abrupt bends of LinearStep,
    //          albeit with a shorter middle transition than LinearStep (the part around 0.5).
    //
    internal static float SharpStep(float V)                   {  V = clamp(V);              return V*V*V * ((6f*V - 15f)*V + 10f);  }
    internal static float SharpStep(float V, float A, float B) {  V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);  }

    internal static vec2  SharpStep(vec2  V)                   {  V = clamp(V);              return V*V*V * ((6f*V - 15f)*V + 10f);  }
    internal static vec2  SharpStep(vec2  V, vec2  A, vec2  B) {  V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);  }
    internal static vec2  SharpStep(vec2  V, float A, float B) {  V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);  }

    internal static vec3  SharpStep(vec3  V)                   {  V = clamp(V);              return V*V*V * ((6f*V - 15f)*V + 10f);  }
    internal static vec3  SharpStep(vec3  V, vec3  A, vec3  B) {  V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);  }
    internal static vec3  SharpStep(vec3  V, float A, float B) {  V = clamp((V-A) / (B-A));  return V*V*V * ((6f*V - 15f)*V + 10f);  }

    //==========================================================================================================================================================
    //
    //  SharperStep(
    //      V: any,     Value to weight between A and B.
    //      A: any,     ...
    //      B: any      ...
    //  )
    //
    //  OUTPUT: 0..1
    //
    //  AKA: "SmoothestStep()"
    //
    internal static float SharperStep(float V, float A, float B) {
        if (B == A)
            return (V > B) ? 1f : 0f;

        V = clamp((V-A) / (B-A));

        float V2 = V  * V;
        float V3 = V2 * V;
        float V4 = V3 * V;

        return V4 * (-20f*V3 + 70f*V2 - 84f*V + 35f);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
