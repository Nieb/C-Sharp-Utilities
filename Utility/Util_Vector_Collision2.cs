using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool PointVsPoint(vec2 Pa, vec2 Pb, float Threshold) => PointVsCircle(Pa, Pb, Threshold);

    //==========================================================================================================================================================
    ///
    ///     PointVsCircle(  Point,  Circle-Position,  Circle-Radius  )
    ///
    public static bool PointVsCircle(vec2 P, vec2 Cp, float Cr) {
        float d_x = P.x - Cp.x;
        float d_y = P.y - Cp.y;
        return (d_x*d_x + d_y*d_y < Cr*Cr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// "Aar" == "Axis Aligned Rectangle"
    ///
    ///                   RectSiz
    ///      +Y *--------@
    ///         |        |
    ///         |        |
    ///         |        |
    ///         @--------* +X
    ///  RectPos
    ///
    ///     PointVsAar(  Point,  Rectangle-Position,  Rectangle-Size  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool PointVsAar(vec2 P, vec2 Rp, vec2 Rs) => (
           P.x <  Rp.x+Rs.x
        && P.x >= Rp.x
        && P.y <  Rp.y+Rs.y
        && P.y >= Rp.y
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// https://www.desmos.com/calculator/dzkn7zysvv
    ///
    ///             A
    ///       +Y    @       Winding is Anti-Clockwise.
    ///            / \
    ///           /   \
    ///          /     \
    ///         @-------@   +X
    ///        B         C
    ///
    ///     PointVsTriangle(  Point,  Triangle-Point-A,  B,  C  )
    ///
    public static bool PointVsTriangle(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        float dPA_x = Ta.x - P.x;
        float dPA_y = Ta.y - P.y;
        float dPB_x = Tb.x - P.x;
        float dPB_y = Tb.y - P.y;
        float dPC_x = Tc.x - P.x;
        float dPC_y = Tc.y - P.y;
        return (dPA_x*dPC_y >= dPA_y*dPC_x)
            && (dPB_x*dPA_y >= dPB_y*dPA_x)
            && (dPC_x*dPB_y >= dPC_y*dPB_x);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool PointVsLine(vec2 P,                                      //  Point
                                   vec2 La, vec2 Lb, float Tolerance) {         //  Line-Point-A, Line-Point-B

        //if (P.x == La.x && P.y == La.y) return true;  The occurrence of these is so rare that it is not worth checking for.
        //if (P.x == Lb.x && P.y == Lb.y) return true;

        float dAP_x =  P.x - La.x;
        float dAP_y =  P.y - La.y;

        float dAB_x = Lb.x - La.x;
        float dAB_y = Lb.y - La.y;

        float DotAP_AB = (dAP_x * dAB_x) + (dAP_y * dAB_y);
        float DotAB_AB = (dAB_x * dAB_x) + (dAB_y * dAB_y);

        // Get distance to NearestPointOnLine from LinePointA as multiple of DeltaAB:
        float Scaler = DotAP_AB / DotAB_AB;

        // Is ProjectedPoint going to be between LinePointA and LinePointB:
        if (Scaler < 0f || Scaler >= 1f) return false; // -1

        // Project Point onto Line:
        float PP_x = dAB_x * Scaler;
        float PP_y = dAB_y * Scaler;

        // Distance between Point and ProjectedPoint:
        float dPPP_x = dAP_x - PP_x;
        float dPPP_y = dAP_y - PP_y;

        return (dPPP_x*dPPP_x + dPPP_y*dPPP_y < Tolerance*Tolerance);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool AarVsAar(vec2 Rp1, vec2 Rs1,                             //  Rectangle-Position, Rectangle-Size
                                vec2 Rp2, vec2 Rs2) => (
           Rp1.x       <  Rp2.x+Rs2.x
        && Rp1.x+Rs1.x >= Rp2.x
        && Rp1.y       <  Rp2.y+Rs2.y
        && Rp1.y+Rs1.y >= Rp2.y
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool CircleVsCircle(vec2 Cp1, float Cr1,                      //  Circle-Position   , Circle-Radius
                                      vec2 Cp2, float Cr2) {
        float d_x = Cp1.x - Cp2.x;
        float d_y = Cp1.y - Cp2.y;
        return ((d_x*d_x + d_y*d_y) < (Cr1*Cr1 + Cr2*Cr2));
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool CircleVsAar(vec2 Cp, float Cr,                           //  Circle-Position   , Circle-Radius
                                   vec2 Rp, vec2  Rs) {                         //  Rectangle-Position, Rectangle-Size

        float C_Lf = Cp.x - Cr; // "Circle Left"
        float C_Rt = Cp.x + Cr; // "Circle Right"
        float C_Bm = Cp.y - Cr; // "Circle Bottom"
        float C_Tp = Cp.y + Cr; // "Circle Top"

        float R_Lf = Rp.x;        // "Rectangle Left"
        float R_Rt = Rp.x + Rs.x; // "Rectangle Right"
        float R_Bm = Rp.y;        // "Rectangle Bottom"
        float R_Tp = Rp.y + Rs.y; // "Rectangle Top"

        if (C_Lf > R_Rt || C_Bm > R_Tp || C_Rt < R_Lf || C_Tp < R_Bm) return false;

        if      (Cp.y >= R_Bm && Cp.y < R_Tp && C_Lf < R_Rt && C_Rt > R_Lf) return true;
        else if (Cp.x >= R_Lf && Cp.x < R_Rt && C_Bm < R_Tp && C_Tp > R_Bm) return true;

        float d_x = (Cp.x < R_Lf) ? Cp.x - R_Lf
                  : (Cp.x > R_Rt) ? Cp.x - R_Rt
                  : 0f;

        float d_y = (Cp.y < R_Bm) ? Cp.y - R_Bm
                  : (Cp.y > R_Tp) ? Cp.y - R_Tp
                  : 0f;

        if (d_x*d_x + d_y*d_y <= Cr*Cr) return true;

        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //public static int WhichSideOfLine(vec2 P,
    //                                  vec2 La, vec2 Lb) {
    //    float Determinant = (P.x-La.x)*(Lb.y-La.y) - (P.y-La.y)*(Lb.x-La.x); // cross(DeltaAP, DeltaAB)
    //    //         P           1
    //    //
    //    //  A──────P──────B    0
    //    //
    //    //         P          -1
    //    return 0 + (Determinant > 0f) - (Determinant < 0f);
    //}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Parallel overlapping Lines will not test positive as a collision.
    ///
    public static bool LineVsLine(vec2 La1, vec2 Lb1,
                                  vec2 La2, vec2 Lb2 ) {
        //=====================================================================================================================================
        float dAB1_x   = Lb1.x - La1.x;
        float dAB1_y   = Lb1.y - La1.y;
        float dAB2_x   = Lb2.x - La2.x;
        float dAB2_y   = Lb2.y - La2.y;
        float dA12_x = La1.x - La2.x;
        float dA12_y = La1.y - La2.y;
        //=====================================================================================================================================
        float n1 = dAB1_x*dA12_y - dAB1_y*dA12_x; //  DeltaAB1  cross  DeltaA12
        float n2 = dAB2_x*dA12_y - dAB2_y*dA12_x; //  DeltaAB2  cross  DeltaA12
        float d  = dAB1_x*dAB2_y - dAB1_y*dAB2_x; //  DeltaAB1  cross  DeltaAB2
        float r  = n1 / d;     //@@  DivByZero possible?
        //@@  EarlyOut?
        float s  = n2 / d;
        //=====================================================================================================================================
        return (r >= 0f && r <= 1f) && (s >= 0f && s <= 1f);
    }


    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool LineVsAar(vec2 La, vec2 Lb,                              //  Line-Point-A      , Line-Point-B
                                 vec2 Rp, vec2 Rs ) {                           //  Rectangle-Position, Rectangle-Size
        //=====================================================================================================================================
        float R_Rt = Rp.x + Rs.x;
        float R_Bm = Rp.y + Rs.y;       //@@  Fix Y inversion...
        //=====================================================================================================================================
        //  Is Area-of-Line over Area-of-Rectangle?
        float L_Lf = 0f;
        float L_Rt = 0f;
        if      (La.x <= Lb.x) { L_Lf = La.x; L_Rt = Lb.x; }
        else if (La.x >  Lb.x) { L_Lf = Lb.x; L_Rt = La.x; }

        float L_Bm = 0f;
        float L_Tp = 0f;
        if      (La.y <= Lb.y) { L_Bm = Lb.y; L_Tp = La.y; }
        else if (La.y >  Lb.y) { L_Bm = La.y; L_Tp = Lb.y; }

        if (Rp.x >= L_Rt || Rp.y >= L_Bm || R_Rt < L_Lf || R_Bm < L_Tp) return false;
        //=====================================================================================================================================
        //  Is PointB in Rectangle?     Check B first, it's typically used as the destination of a movement vector.
        if (   Lb.x <  R_Rt
            && Lb.x >= Rp.x
            && Lb.y <  R_Bm
            && Lb.y >= Rp.y) return true;
        //=====================================================================================================================================
        // Is PointA in Rectangle?
        if (   La.x <  R_Rt
            && La.x >= Rp.x
            && La.y <  R_Bm
            && La.y >= Rp.y) return true;
        //=====================================================================================================================================
        // Are any of the 4 Rectangle-Lines colliding with the Line?
        float d1A_1B_x = Lb.x - La.x;
        float d1A_1B_y = Lb.y - La.y;
        float d2A_2B_x;
        float d2A_2B_y;
        float d1A_2A_x;
        float d1A_2A_y;
        //=====================================================================================================================================
        float n1;
        float n2;
        float d;
        float r;
        float s;
        //=====================================================================================================================================
        d2A_2B_x = R_Rt - Rp.x;
        d2A_2B_y = Rp.y - Rp.y;
        d1A_2A_x = La.x - Rp.x;
        d1A_2A_y = La.y - Rp.y;
        n1 = (d1A_2A_y * d1A_1B_x) - (d1A_2A_x * d1A_1B_y);
        n2 = (d1A_2A_y * d2A_2B_x) - (d1A_2A_x * d2A_2B_y);
        d  = (d1A_1B_x * d2A_2B_y) - (d1A_1B_y * d2A_2B_x);
        r  = n1 / d;
        s  = n2 / d;
        if (r >= 0f && r <= 1f && s >= 0f && s <= 1f) return true;
        //=====================================================================================================================================
        d2A_2B_x = R_Rt - R_Rt;
        d2A_2B_y = R_Bm - Rp.y;
        d1A_2A_x = La.x - R_Rt;
        d1A_2A_y = La.y - Rp.y;
        n1 = (d1A_2A_y * d1A_1B_x) - (d1A_2A_x * d1A_1B_y);
        n2 = (d1A_2A_y * d2A_2B_x) - (d1A_2A_x * d2A_2B_y);
        d  = (d1A_1B_x * d2A_2B_y) - (d1A_1B_y * d2A_2B_x);
        r  = n1 / d;
        s  = n2 / d;
        if (r >= 0f && r <= 1f && s >= 0f && s <= 1f) return true;
        //=====================================================================================================================================
        d2A_2B_x = Rp.x - R_Rt;
        d2A_2B_y = R_Bm - R_Bm;
        d1A_2A_x = La.x - R_Rt;
        d1A_2A_y = La.y - R_Bm;
        n1 = (d1A_2A_y * d1A_1B_x) - (d1A_2A_x * d1A_1B_y);
        n2 = (d1A_2A_y * d2A_2B_x) - (d1A_2A_x * d2A_2B_y);
        d  = (d1A_1B_x * d2A_2B_y) - (d1A_1B_y * d2A_2B_x);
        r  = n1 / d;
        s  = n2 / d;
        if (r >= 0f && r <= 1f && s >= 0f && s <= 1f) return true;
        //=====================================================================================================================================
        // The function will never make it here.
        //d2A_2B_x = Rp.x - Rp.x;
        //d2A_2B_y = Rp.y - R_Bm;
        //d1A_2A_x = La.x - Rp.x;
        //d1A_2A_y = La.y - R_Bm;
        //n1 = (d1A_2A_y * d1A_1B_x) - (d1A_2A_x * d1A_1B_y);
        //n2 = (d1A_2A_y * d2A_2B_x) - (d1A_2A_x * d2A_2B_y);
        //d  = (d1A_1B_x * d2A_2B_y) - (d1A_1B_y * d2A_2B_x);
        //r  = n1 / d;
        //s  = n2 / d;
        //if (r >= 0f && r <= 1f && s >= 0f && s <= 1f) return true;
        //=====================================================================================================================================
        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool LineVsCircle(vec2 La, vec2 Lb,                           //  Line-Point-A   , Line-Point-B
                                    vec2 Cp, float Cr) {                        //  Circle-Position, Circle-Radius

        //  CircleRadius Squared:
        float Cr_Sqrd = Cr*Cr;

        //  Is LinePointB in Circle?    Check B first, it's typically used as the destination of a movement vector.
        float dBC_x = Cp.x - Lb.x;
        float dBC_y = Cp.y - Lb.y;
        if ((dBC_x*dBC_x + dBC_y*dBC_y) < Cr_Sqrd) return true;

        //  Is LinePointA in Circle?
        float dAC_x = Cp.x - La.x;
        float dAC_y = Cp.y - La.y;
        if ((dAC_x*dAC_x + dAC_y*dAC_y) < Cr_Sqrd) return true;

        // Get distance to NearestPointOnLine from LinePointA as multiple of DeltaAB:
        float dAB_x = Lb.x - La.x;
        float dAB_y = Lb.y - La.y;
        float Scaler = (dAC_x*dAB_x + dAC_y*dAB_y) / (dAB_x*dAB_x + dAB_y*dAB_y);

        // Is ProjectedPoint going to be between LinePointA and LinePointB:
        if (Scaler < 0f || Scaler >= 1f) return false;

        //  CirclePosition projected on to Line:
        float CpP_x = La.x + dAB_x * Scaler;
        float CpP_y = La.y + dAB_y * Scaler;

        // Is ProjectedPoint in Circle?
        float dPC_X = CpP_x - Cp.x;
        float dPC_Y = CpP_y - Cp.y;
        if ((dPC_X*dPC_X + dPC_Y*dPC_Y) < Cr_Sqrd) return true;

        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
