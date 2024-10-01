using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 Barycentric(vec2 P, vec2 A, vec2 B, vec2 C) {
        float DltAB_x = B.x - A.x;
        float DltAB_y = B.y - A.y;
        float DltAC_x = C.x - A.x;
        float DltAC_y = C.y - A.y;
        float DltAP_x = P.x - A.x;
        float DltAP_y = P.y - A.y;

        float Scaler = 1.0f / (DltAB_x*DltAC_y - DltAC_x*DltAB_y);

        float WeightB = (DltAP_x*DltAC_y - DltAC_x*DltAP_y) * Scaler;
        float WeightC = (DltAP_y*DltAB_x - DltAB_y*DltAP_x) * Scaler;
        float WeightA = 1.0f - WeightB - WeightC;

        return new vec3(WeightA, WeightB, WeightC);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Delaunay"
    ///
    /// Test if a Point is inside of a Triangle's Circumcircle.
    ///
    public static bool Delaunay(vec2 P, vec2 A, vec2 B, vec2 C) {
        float DltAB_x = B.x - A.x;
        float DltAB_y = B.y - A.y;

        float DltBC_x = C.x - B.x;
        float DltBC_y = C.y - B.y;

        float Determinant = 2.0f * (DltAB_x*DltBC_y - DltAB_y*DltBC_x);

        float DltX;
        float DltY;
        float TriCntr_x;
        float TriCntr_y;
        if (MathF.Abs(Determinant) < EPSILON) {
            float MinX = MathF.Min(MathF.Min(A.x, B.x), C.x);
            float MaxX = MathF.Max(MathF.Max(A.x, B.x), C.x);

            float MinY = MathF.Min(MathF.Min(A.y, B.y), C.y);
            float MaxY = MathF.Max(MathF.Max(A.y, B.y), C.y);

            TriCntr_x = (MinX + MaxX)*0.5f;
            TriCntr_y = (MinY + MaxY)*0.5f;

            DltX = TriCntr_x - MinX;
            DltY = TriCntr_y - MinY;
        } else {
            float DltAC_x = C.x - A.x;
            float DltAC_y = C.y - A.y;

            float AB_AB = DltAB_x*(A.x + B.x) + DltAB_y*(A.y + B.y);
            float AC_AC = DltAC_x*(A.x + C.x) + DltAC_y*(A.y + C.y);

            TriCntr_x = (DltAC_y*AB_AB - DltAB_y*AC_AC) / Determinant;
            TriCntr_y = (DltAB_x*AC_AC - DltAC_x*AB_AB) / Determinant;

            DltX = TriCntr_x - A.x;
            DltY = TriCntr_y - A.y;
        }

        float Tri_RdsSqrd = DltX*DltX + DltY*DltY;

        DltX = TriCntr_x - P.x;
        DltY = TriCntr_y - P.y;

        return ((DltX*DltX + DltY*DltY) < Tri_RdsSqrd);
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
        float DotAP_AB = ((P.x - Lp.x) * Ln.x) + ((P.y - Lp.y) * Ln.y);

        return new vec2(
            Lp.x + (Ln.x * DotAP_AB),
            Lp.y + (Ln.y * DotAP_AB)
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 Project(vec3 P, vec3 Lp, vec3 Ln) {

        //  Distance from LinePosition to NearestPointOnLine:
        float DotAP_AB = ((P.x - Lp.x) * Ln.x) + ((P.y - Lp.y) * Ln.y) + ((P.z - Lp.z) * Ln.z);

        return new vec3(
            Lp.x + (Ln.x * DotAP_AB),
            Lp.y + (Ln.y * DotAP_AB),
            Lp.z + (Ln.z * DotAP_AB)
        );
    }

    //==========================================================================================================================================================
    ///
    ///     Project_(  Point,  Line-Point-A (start),  Line-Point-B (end)  )
    ///
    public static vec2 Project_(vec2 P, vec2 La, vec2 Lb) {
        float DltAP_x = P.x  - La.x;
        float DltAP_y = P.y  - La.y;

        float DltAB_x = Lb.x - La.x;
        float DltAB_y = Lb.y - La.y;

        float DotAP_AB         = (DltAP_x * DltAB_x) + (DltAP_y * DltAB_y);
        float DltAB_LengthSqrd = (DltAB_x * DltAB_x) + (DltAB_y * DltAB_y);

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DltAB:
        float Scaler = DotAP_AB / DltAB_LengthSqrd;        //  (LengthNew / LengthOld).

        return new vec2(
            La.x + (DltAB_x * Scaler),
            La.y + (DltAB_y * Scaler)
        );
    }

    public static vec3 Project_(vec3 P, vec3 La, vec3 Lb) {
        float DltAP_x = P.x - La.x;
        float DltAP_y = P.y - La.y;
        float DltAP_z = P.z - La.z;

        float DltAB_x = Lb.x - La.x;
        float DltAB_y = Lb.y - La.y;
        float DltAB_z = Lb.z - La.z;

        float DotAP_AB         = (DltAP_x * DltAB_x) + (DltAP_y * DltAB_y) + (DltAP_z * DltAB_z);
        float DltAB_LengthSqrd = (DltAB_x * DltAB_x) + (DltAB_y * DltAB_y) + (DltAB_z * DltAB_z);

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DltAB:
        float Scaler = DotAP_AB / DltAB_LengthSqrd;        // (LengthNew / LengthOld)

        return new vec3(
            La.x + (DltAB_x * Scaler),
            La.y + (DltAB_y * Scaler),
            La.z + (DltAB_z * Scaler)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
