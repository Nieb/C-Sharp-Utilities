using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
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
    public static vec3 Barycentric(vec2 P, vec2 A, vec2 B, vec2 C) {
        float dAB_x = B.x - A.x;
        float dAB_y = B.y - A.y;
        float dAC_x = C.x - A.x;
        float dAC_y = C.y - A.y;
        float dAP_x = P.x - A.x;
        float dAP_y = P.y - A.y;

        float Scaler = 1f / (dAB_x*dAC_y - dAC_x*dAB_y);

        float Bw = (dAP_x*dAC_y - dAC_x*dAP_y) * Scaler;
        float Cw = (dAP_y*dAB_x - dAB_y*dAP_x) * Scaler;
        float Aw = 1f - Bw - Cw;

        return new vec3(Aw, Bw, Cw);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Delaunay"
    ///
    /// Test if a Point is inside of a Triangle's CircumCircle.
    ///
    public static bool Delaunay(vec2 P, vec2 A, vec2 B, vec2 C) {
        float dAB_x = B.x - A.x;
        float dAB_y = B.y - A.y;

        float dBC_x = C.x - B.x;
        float dBC_y = C.y - B.y;

        float Determinant = 2f * (dAB_x*dBC_y - dAB_y*dBC_x);

        float d_x, d_y;
        float CCp_x, CCp_y; //  CircumCircle Position.
        if (MathF.Abs(Determinant) < EPSILON) {
            float Min_x = MathF.Min(MathF.Min(A.x, B.x), C.x);
            float Min_y = MathF.Min(MathF.Min(A.y, B.y), C.y);

            float Max_x = MathF.Max(MathF.Max(A.x, B.x), C.x);
            float Max_y = MathF.Max(MathF.Max(A.y, B.y), C.y);

            CCp_x = (Min_x + Max_x)*0.5f;
            CCp_y = (Min_y + Max_y)*0.5f;

            d_x = CCp_x - Min_x;
            d_y = CCp_y - Min_y;
        } else {
            float dAC_x = C.x - A.x;
            float dAC_y = C.y - A.y;

            float AB_AB = dAB_x*(A.x + B.x) + dAB_y*(A.y + B.y);
            float AC_AC = dAC_x*(A.x + C.x) + dAC_y*(A.y + C.y);

            CCp_x = (dAC_y*AB_AB - dAB_y*AC_AC) / Determinant;
            CCp_y = (dAB_x*AC_AC - dAC_x*AB_AB) / Determinant;

            d_x = CCp_x - A.x;
            d_y = CCp_y - A.y;
        }

        float Tri_RdsSqrd = d_x*d_x + d_y*d_y;

        d_x = CCp_x - P.x;
        d_y = CCp_y - P.y;

        return ((d_x*d_x + d_y*d_y) < Tri_RdsSqrd);
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
    public static vec2 Project(vec2 P, vec2 Lp, vec2 Ln) {

        //  Distance from LinePosition to NearestPointOnLine:
        float DotAP_AB =
            ((P.x - Lp.x) * Ln.x) +
            ((P.y - Lp.y) * Ln.y);

        return new vec2(
            Lp.x + (Ln.x * DotAP_AB),
            Lp.y + (Ln.y * DotAP_AB)
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 Project(vec3 P, vec3 Lp, vec3 Ln) {

        //  Distance from LinePosition to NearestPointOnLine:
        float DotAP_AB =
            ((P.x - Lp.x) * Ln.x) +
            ((P.y - Lp.y) * Ln.y) +
            ((P.z - Lp.z) * Ln.z);

        return new vec3(
            Lp.x + (Ln.x * DotAP_AB),
            Lp.y + (Ln.y * DotAP_AB),
            Lp.z + (Ln.z * DotAP_AB)
        );
    }

    //==========================================================================================================================================================
    ///
    ///     Project_(  Point,  Line-Point-A,  Line-Point-B  )
    ///
    public static vec2 Project_(vec2 P, vec2 La, vec2 Lb) {
        float dAP_x = P.x  - La.x;
        float dAP_y = P.y  - La.y;

        float dAB_x = Lb.x - La.x;
        float dAB_y = Lb.y - La.y;

        float DotAP_AB       = (dAP_x * dAB_x) + (dAP_y * dAB_y);
        float dAB_LengthSqrd = (dAB_x * dAB_x) + (dAB_y * dAB_y);

        //  Distance from LinePointA to NearestPointOnLine as multiple of DeltaAB.Length:
        float Scaler = DotAP_AB / dAB_LengthSqrd; //  (LengthNew / LengthOld).

        return new vec2(
            La.x + (dAB_x * Scaler),
            La.y + (dAB_y * Scaler)
        );
    }

    public static vec3 Project_(vec3 P, vec3 La, vec3 Lb) {
        float dAP_x = P.x - La.x;
        float dAP_y = P.y - La.y;
        float dAP_z = P.z - La.z;

        float dAB_x = Lb.x - La.x;
        float dAB_y = Lb.y - La.y;
        float dAB_z = Lb.z - La.z;

        float DotAP_AB       = (dAP_x * dAB_x) + (dAP_y * dAB_y) + (dAP_z * dAB_z);
        float dAB_LengthSqrd = (dAB_x * dAB_x) + (dAB_y * dAB_y) + (dAB_z * dAB_z);

        //  Distance from LinePointA to NearestPointOnLine as multiple of DeltaAB.Length:
        float Scaler = DotAP_AB / dAB_LengthSqrd; //  (LengthNew / LengthOld)

        return new vec3(
            La.x + (dAB_x * Scaler),
            La.y + (dAB_y * Scaler),
            La.z + (dAB_z * Scaler)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
