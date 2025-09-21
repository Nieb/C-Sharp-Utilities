using System.Runtime.CompilerServices;

namespace Utility;
internal static partial class VEC_Filter {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Hard-Limiter"
    //
    //      V: 0 to ∞
    //      T: 0 to 1
    //
    //    out: 0 to 1
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float HardLimit(float V, float T) {
        return (V > T) ? T : V;
    }

    //==========================================================================================================================================================
    //
    //  "Rational-Decay based Soft-Limiter"
    //
    //      https://www.desmos.com/calculator/cs73ninsvh
    //
    //      V: 0 to ∞
    //      T: 0 to 1
    //
    //    out: 0 to 1
    //
    internal static float SoftLimit(float V, float T) {
        if (V <= T) {
            return V;
        } else {
            float  TT = T * T;
            float iTT = 1f - T;  iTT *= iTT;

            return 1f - iTT/(iTT + V - TT);
        }
    }

    //==========================================================================================================================================================
    //
    //  "Sigmoid based Soft-Limiter"
    //
    //      V: 0 to ∞
    //      T: 0 to 1
    //
    //    out: 0 to 1
    //
    internal static float SoftLimit_Sigmoid(float V, float T) {
        if (V <= T) {
            return V;
        } else {
            float iT = 1f - T;

            float A =             2f * iT;
            //         ------------------------------
            float B =  1f + exp((-V + T) * (2f / iT));

            return T - iT + (A / B);
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Scale values that exceed a threshold...
    //
    //      "Localized Limiter" ?
    //      "Localized Amp" ?
    //  Δ
    //
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private const float Filter_BlendScale = 256f;
    private const float ViewMaxY = 256f;

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    internal static float AmpThresh_v3(float V, float T, float M) {
        float d = V - T;

        float blend = 1f/(1f + pow(2f, -d * Filter_BlendScale));

        return (d > 0f) ? T + Mix(blend, d, d*M)
                        : V;
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    internal static float AmpThresh_v2(float V, float T, float M) {
        float d = V - T;

        float blend = 1f/(1f + pow(2f,-d*Filter_BlendScale));
        blend = max(0f, blend*2f - 1f);

        return T + Mix(blend, d, d*M);
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    internal static float AmpThresh_v1(float V, float T, float M) {
        float d = V - T;

        float blend = d / abs(T-ViewMaxY);

        return (d > 0f) ? T + d*M*blend
                        : V;
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    internal static float AmpThresh_v0(float V, float T, float M) {
        float d = V - T;

        return (d > 0f) ? T + d*M
                        : V;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //              |- - - - - - - F - - - - - - -|  R
    //      |                                        |
    //  Y=1 +--------____                            V
    //      |            ----
    //                       ---
    //      |                   --
    //                            -
    //      |                      -
    //                              --
    //      |                         ---
    //                                   ----____
    //  Y=0 +                                    ------------------------
    //    X=0
    //
    //  R^(-(x/R)^F);
    //
    internal static float Notch(float x, float R, float F) => pow(R,-pow(x/R,F));

    //==========================================================================================================================================================
    //
    //  https://www.desmos.com/calculator/ff9bdz0qui
    //
    //      Notch(  x,  Delta, Position, Radius, Falloff  )
    //
    internal static float Notch(float x, float d, float P, float R, float F) {
        float Result;

        Result = abs(x - P) / R;

        Result = pow(Result, F);

        Result = 1f + d * pow(R, -Result);

        return Result;
    }

    //==========================================================================================================================================================
    //
    //  With wrapping.
    //
    //      Notch(  x,  Delta, Position, Radius, Falloff, Domain  )
    //
    internal static float Notch(float x, float d, float P, float R, float F, float D) {
        float Result;

        Result = abs(x - P) / R;

        /* Wrap */ {
            float m  = D/R;
            float mh = m * 0.5f;
            Result = ((Result + mh) % m) - mh;
            Result = abs(Result);
        }

        Result = pow(Result, F);

        Result = 1f + d * pow(R, -Result);

        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
