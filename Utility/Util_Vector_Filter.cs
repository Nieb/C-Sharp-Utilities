

namespace Utility;
internal static partial class VEC {
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
    ///     https://www.desmos.com/calculator/xqd7xruqk5
    ///
    ///     V: 0 to INF
    ///     T: 0 to 1
    ///
    ///   out: 0 to 1
    ///
    internal static float Limiter_RD(float V, float T) {
        if (V <= T) {
            return V;
        } else {
            float  Tsq = T * T;
            float iTsq = 1f - T;
                  iTsq *= iTsq;

            return 1f - iTsq/(iTsq + V - Tsq);
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
    ///
    ///
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    const float Filter_BlendScale = 256f;
    const float ViewMaxY = 256f;

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    internal static float AmpThresh(float x, float ThresholdY, float Multiplier) {
        float dX = x - ThresholdY;

        float blend = 1f/(1f + pow(2f, -dX * Filter_BlendScale));

        return (dX > 0f) ? ThresholdY + Mix(blend, dX, dX*Multiplier)
                         : x;
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    internal static float AmpThresh_v2(float x, float ThresholdY, float Multiplier) {
        float dX = x - ThresholdY;

        float blend = 1f/(1f + pow(2f,-dX*Filter_BlendScale));
        blend = max(0f, blend*2f - 1f);

        return ThresholdY + Mix(blend, dX, dX*Multiplier);
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    internal static float AmpThresh_v1(float x, float ThresholdY, float Multiplier) {
        float dX = x - ThresholdY;

        float blend = dX / abs(ThresholdY-ViewMaxY);

        return ((dX > 0f) ? ThresholdY + dX*Multiplier*blend : x);
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    internal static float AmpThresh_v0(float x, float ThresholdY, float Multiplier) {
        float dX = x - ThresholdY;

        return ((dX > 0f) ? ThresholdY + dX*Multiplier : x);
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
