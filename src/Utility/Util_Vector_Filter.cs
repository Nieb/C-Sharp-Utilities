

namespace Utility;
internal static partial class VEC_Filter {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// "Hard-Limiter"
    ///
    ///     V: 0 to INF
    ///     T: 0 to 1
    ///
    ///   out: 0 to 1
    ///
    internal static float Limiter_Clip(float V, float T) {
        return (V > T) ? T : V;
    }

    //==========================================================================================================================================================
    ///
    /// "Rational-Decay based Soft-Limiter"
    ///
    ///     https://www.desmos.com/calculator/cs73ninsvh
    ///
    ///     V: 0 to INF
    ///     T: 0 to 1
    ///
    ///   out: 0 to 1
    ///
    internal static float Limiter_RatDec(float V, float T) {
        if (V <= T) {
            return V;
        } else {
            float  TT = T * T;
            float iTT = 1f - T;  iTT *= iTT;

            return 1f - iTT/(iTT + V - TT);
        }
    }

    //==========================================================================================================================================================
    ///
    /// "Sigmoid based Soft-Limiter"
    ///
    ///     V: 0 to INF
    ///     T: 0 to 1
    ///
    ///   out: 0 to 1
    ///
    internal static float Limiter_Sigmoid(float V, float T) {
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
    ///
    /// Scale values that exceed a threshold...
    ///
    ///     "Localized Limiter" ?
    ///     "Localized Amp" ?
    /// Δ
    ///
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
    ///
    /// https://www.desmos.com/calculator/ff9bdz0qui
    ///
    ///     Dlt -> "Delta"
    ///     Pos -> "Position"
    ///     Rds -> "Radius"
    ///     Fal -> "Falloff"
    ///
    internal static float Notch(float V, float Dlt, float Pos, float Rds, float Fal) {
        float Result;

        Result = abs(V - Pos) / Rds;

        Result = pow(Result, Fal);

        Result = 1f + Dlt * pow(Rds, -Result);

        return Result;
    }

    //==========================================================================================================================================================
    ///
    /// With wrapping.
    ///
    internal static float Notch(float V, float Dlt, float Pos, float Rds, float Fal, float Domain) {
        float Result;

        Result = abs(V - Pos) / Rds;

        //  Wrap:
        float m1 = Domain/Rds;
        float m2 = m1 * 0.5f;
        Result = ((Result + m2) % m1) - m2;
        Result = abs(Result);

        Result = pow(Result, Fal);

        Result = 1f + Dlt*pow(Rds, -Result);

        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
