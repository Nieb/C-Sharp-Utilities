using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static class VEC_Miscellaneous {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Barycentric"
    ///
    /// https://www.desmos.com/calculator/8jfeiiyuap
    ///
    /// Returns 3 weights corresponding to a position relative to the 3 points of a triangle.
    ///     Center = (1/3, 1/3, 1/3)
    ///
    internal static vec3 Barycentric(vec2 P, vec2 A, vec2 B, vec2 C) {
        vec2 dAB = B-A;
        vec2 dAC = C-A;
        vec2 dAP = P-A;

        float Scaler = 1f / (dAB.x*dAC.y - dAC.x*dAB.y);

        float Bw = (dAP.x*dAC.y - dAC.x*dAP.y) * Scaler;
        float Cw = (dAP.y*dAB.x - dAB.y*dAP.x) * Scaler;
        float Aw = 1f - Bw - Cw;

        return new vec3(Aw, Bw, Cw);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Delaunay"
    ///
    /// Test if a Point is inside of a Triangle's CircumCircle.
    ///
    internal static bool Delaunay(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        vec2 dAB = Tb-Ta;
        vec2 dBC = Tc-Tb;

        float Determinant = 2f * (dAB.x*dBC.y - dAB.y*dBC.x);

        vec2 d;
        vec2 CCp; //  CircumCircle Position.

        if (abs(Determinant) < EPSILON) {
            //  Triangle points are Collinear, define CircumCircle by delta between furthest points.
            vec2 Min = min(Ta, Tb, Tc);
            vec2 Max = max(Ta, Tb, Tc);

            CCp = (Min+Max) * 0.5f;

            d = CCp - Min;

        } else {
            vec2 dAC = Tc-Ta;

            float AB_AB = dot(dAB, Ta+Tb); //dAB.x*(Ta.x + Tb.x) + dAB.y*(Ta.y + Tb.y);
            float AC_AC = dot(dAC, Ta+Tc); //dAC.x*(Ta.x + Tc.x) + dAC.y*(Ta.y + Tc.y);

            CCp = new vec2(
                (dAC.y*AB_AB - dAB.y*AC_AC) / Determinant,
                (dAB.x*AC_AC - dAC.x*AB_AB) / Determinant
            );

            d = CCp - Ta;
        }

        float CC_RdsSqrd = dot(d,d); //d.x*d.x + d.y*d.y;

        d = CCp - P;

        return (dot(d,d) < CC_RdsSqrd);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Projection"
    ///
    /// Get Nearest-Point-On-Line from Point.
    ///
    ///     Project(  Point,  Line-Position,  Line-Normal  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec2 Project(vec2 P, vec2 Lp, vec2 Ln) => Lp + Ln*dot(P-Lp, Ln);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 Project(vec3 P, vec3 Lp, vec3 Ln) => Lp + Ln*dot(P-Lp, Ln);

    //==========================================================================================================================================================
    ///
    ///     Project_(  Point,  Line-Point-A,  Line-Point-B  )
    ///
    internal static vec2 Project_(vec2 P, vec2 La, vec2 Lb) {
        vec2 dAB = Lb - La;

        //  Distance from LinePointA to NearestPointOnLine as multiple of dAB.Length:
        float Scaler = dot(P-La, dAB) / dot(dAB, dAB);

        return La + (dAB * Scaler);
    }

    internal static vec3 Project_(vec3 P, vec3 La, vec3 Lb) {
        vec3 dAB = Lb - La;

        //  Distance from LinePointA to NearestPointOnLine as multiple of dAB.Length:
        float Scaler = dot(P-La, dAB) / dot(dAB, dAB);

        return La + (dAB * Scaler);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}

//  https://www.google.com/search?q=haversine+distance
//  https://en.wikipedia.org/wiki/Haversine_formula
