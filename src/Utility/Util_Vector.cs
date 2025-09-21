

namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #if DEBUG
        internal static bool IsApproximatelyZero(this float A) => abs(A) < EPSILON;
        internal static bool IsApproximatelyZero(this vec2  A) => abs(A) < EPSILON;
        internal static bool IsApproximatelyZero(this vec3  A) => abs(A) < EPSILON;
        internal static bool IsApproximatelyZero(this vec4  A) => abs(A) < EPSILON;

        internal static bool IsApproximately(this float A, float B) => abs(B-A) < EPSILON;
        internal static bool IsApproximately(this vec2  A, vec2  B) => abs(B-A) < EPSILON;
        internal static bool IsApproximately(this vec3  A, vec3  B) => abs(B-A) < EPSILON;
        internal static bool IsApproximately(this vec4  A, vec4  B) => abs(B-A) < EPSILON;

        internal static bool IsRoughly(this float A, float B) => abs(B-A) < EPSILISH;
        internal static bool IsRoughly(this vec2  A, vec2  B) => abs(B-A) < EPSILISH;
        internal static bool IsRoughly(this vec3  A, vec3  B) => abs(B-A) < EPSILISH;
        internal static bool IsRoughly(this vec4  A, vec4  B) => abs(B-A) < EPSILISH;
    #endif
    //##########################################################################################################################################################
    /*##########################################################################################################################################################

                        |
                        o
                        | (B >= A) == true
                        |
                        |     o
                        |      (B > A) == true
                        |
                        o-----------o-------
                       A             (B > A) == false

                o
                 (B > A) == false


    //########################################################################################################################################################*/
    //##########################################################################################################################################################
}
