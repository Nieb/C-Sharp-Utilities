using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static class VEC_Collision2 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// "Aar" == "Axis Aligned Rectangle"
    ///
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///            P         > 0
    ///
    ///     A------P------B  = 0
    ///
    ///            P         < 0
    ///
    //internal static int PointVsLine(vec2 P, vec2 Lp, vec2 Ln) {
    internal static int WhichSideOfLine(vec2 P, vec2 La, vec2 Lb) {
        float Determinant = (P.x-La.x)*(Lb.y-La.y) - (P.y-La.y)*(Lb.x-La.x); // cross(dAP, dAB)
        return (Determinant > 0f) ?  1
             : (Determinant < 0f) ? -1 : 0;
    }


    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     PointVsLine(  Point,  Line-PointA,  Line-PointB,  Tolerance  )
    ///
    internal static bool PointVsLine(vec2 P, vec2 La, vec2 Lb, float Tolerance) {
        vec2 dAP = P  - La;
        vec2 dAB = Lb - La;

        //  Distance from LinePointA to NearestPointOnLine, as multiple of DeltaAB:
        float Scaler = dot(dAP, dAB) / dot(dAB, dAB);

        //  Is ProjectedPoint going to be between Line-PointA and Line-PointB:
        if (Scaler < 0f || Scaler >= 1f)
            return false;

        //  Point <---> ProjectedPoint:
        vec2 dPP = dAP - dAB*Scaler;

        return (dPP.x*dPP.x + dPP.y*dPP.y) < (Tolerance*Tolerance);
    }






    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsPoint(vec2 Pa, vec2 Pb, float Tolerance) =>
        PointVsCircle(Pa, Pb, Tolerance);

    //==========================================================================================================================================================
    ///
    ///     PointVsCircle(  Point,  CirclePosition,  CircleRadius  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsCircle(vec2 P, vec2 Cp, float Cr) {
        vec2 d = P - Cp;
        return dot(d,d) < (Cr*Cr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// "Axis-Aligned-Rectangle"
    ///
    ///                   RectSiz
    ///      +Y *--------@
    ///         |        |
    ///         |        |
    ///         |        |
    ///         @--------* +X
    ///  RectPos
    ///
    ///     PointVsRect(  Point,  RectanglePosition,  RectangleSize  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsRect(vec2 P, vec2 Rp, vec2 Rs) => (
           P.x >= Rp.x
        && P.y >= Rp.y
        && P.x <  Rp.x+Rs.x
        && P.y <  Rp.y+Rs.y
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Weinding is Anti-Clockwise.
    ///
    ///             A
    ///       +Y    @
    ///            / \
    ///           /   \
    ///          /     \
    ///         @-------@   +X
    ///        B         C
    ///
    /// https://www.desmos.com/calculator/8jfeiiyuap
    ///
    ///     PointVsTriangle(  Point,  TrianglePointA,  TrianglePointB,  TrianglePointC  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsTriangle(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        vec2 dPA = Ta - P;
        vec2 dPB = Tb - P;
        vec2 dPC = Tc - P;

        return (dPA.x*dPB.y >= dPA.y*dPB.x)
            && (dPB.x*dPC.y >= dPB.y*dPC.x)
            && (dPC.x*dPA.y >= dPC.y*dPA.x);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Irregular Quadrilateral"
    //      Quad must be convex.
    //      Weinding is Anti-Clockwise.
    //
    //      B
    //       @---___
    //    +Y  \     `--___
    //         \          `--___    A
    //          \               `--@
    //           \                /
    //            \              /
    //             \            /
    //              \     __---@
    //               @--``      D
    //              C              +X
    //
    //  https://www.desmos.com/calculator/eyeuk0o9oj
    //
    //      PointVsQuad(  Point,  QuadPointA,  QuadPointB,  QuadPointC,  QuadPointD  )
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsQuad(vec2 P, vec2 Qa, vec2 Qb, vec2 Qc, vec2 Qd) {
        vec2 dPA = Qa - P;
        vec2 dPB = Qb - P;
        vec2 dPC = Qc - P;
        vec2 dPD = Qd - P;

        return (dPA.x*dPB.y >= dPA.y*dPB.x)
            && (dPB.x*dPC.y >= dPB.y*dPC.x)
            && (dPC.x*dPD.y >= dPC.y*dPD.x)
            && (dPD.x*dPA.y >= dPD.y*dPA.x);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Irregular Polygon"
    //      Polygon must be convex.
    //      Weinding is Anti-Clockwise.
    //
    internal static bool PointVsPolygon(vec2 P, vec2[] Poly) {
        #if DEBUG
            if (Poly.Length < 3) throw new ArgumentException("Derp?");
            if (Poly.Length < 5) throw new ArgumentException("Use PointVsTri() or PointVsQuad() for polygons with sides fewer than 5.");
        #endif

        int iA, iB;
        vec2 dPA;
        vec2 dPB = Poly[0] - P;
        for (int i = 0; i < Poly.Length; ++i) {
            iA = i;
            iB = (i+1 == Poly.Length) ? 0 : i+1;

            dPA = dPB;
            dPB = Poly[iB] - P;

            if (dPA.x*dPB.y <= dPA.y*dPB.x)
                return false;
        }

        return true;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     RectVsRect(  Rectangle1-Position,  Rectangle1-Size,  Rectangle2-Position,  Rectangle2-Size)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool RectVsRect(vec2 R1p, vec2 R1s, vec2 R2p, vec2 R2s) => (
           R1p.x       <  R2p.x+R2s.x
        && R1p.y       <  R2p.y+R2s.y
        && R1p.x+R1s.x >= R2p.x
        && R1p.y+R1s.y >= R2p.y
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     CircleVsCircle(  Circle1-Position,  Circle1-Radius,  Circle2-Position,  Circle2-Radius  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool CircleVsCircle(vec2 C1p, float C1r, vec2 C2p, float C2r) {
        float d_x = C1p.x - C2p.x;
        float d_y = C1p.y - C2p.y;
        return ((d_x*d_x + d_y*d_y) < (C1r*C1r + C2r*C2r));
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     CircleVsRect(  Circle-Position,  Circle-Radius,  Rectangle-Position,  Rectangle-Size  )
    ///
    internal static bool CircleVsRect(vec2 Cp, float Cr, vec2 Rp, vec2  Rs) {
        float C_Lf = Cp.x - Cr; // "Circle Left"
        float C_Rt = Cp.x + Cr; // "Circle Right"
        float C_Bm = Cp.y - Cr; // "Circle Bottom"
        float C_Tp = Cp.y + Cr; // "Circle Top"

        float R_Lf = Rp.x;        // "Rectangle Left"
        float R_Rt = Rp.x + Rs.x; // "Rectangle Right"
        float R_Bm = Rp.y;        // "Rectangle Bottom"
        float R_Tp = Rp.y + Rs.y; // "Rectangle Top"

        if      (C_Lf >  R_Rt  ||  C_Bm > R_Tp  ||  C_Rt < R_Lf  ||  C_Tp < R_Bm) return false;     //  7   @@ 21 comparisons  &  3 branches

        if      (Cp.y >= R_Bm  &&  Cp.y < R_Tp  &&  C_Lf < R_Rt  &&  C_Rt > R_Lf) return true;      //  7
        else if (Cp.x >= R_Lf  &&  Cp.x < R_Rt  &&  C_Bm < R_Tp  &&  C_Tp > R_Bm) return true;      //  7   @@ Get rid of these???

        float d_x = (Cp.x < R_Lf) ? Cp.x - R_Lf
                  : (Cp.x > R_Rt) ? Cp.x - R_Rt
                                  : 0f;

        float d_y = (Cp.y < R_Bm) ? Cp.y - R_Bm
                  : (Cp.y > R_Tp) ? Cp.y - R_Tp
                                  : 0f;

        return (d_x*d_x + d_y*d_y <= Cr*Cr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Parallel overlapping Lines will not test positive as a collision.
    ///
    internal static bool LineVsLine(vec2 L1a, vec2 L1b, vec2 L2a, vec2 L2b ) {
        //=====================================================================================================================================
        float dAB1_x = L1b.x - L1a.x;
        float dAB1_y = L1b.y - L1a.y;
        float dAB2_x = L2b.x - L2a.x;
        float dAB2_y = L2b.y - L2a.y;
        float dA12_x = L1a.x - L2a.x;
        float dA12_y = L1a.y - L2a.y;
        //=====================================================================================================================================
        float n1 = dAB1_x*dA12_y - dAB1_y*dA12_x; //  cross(DeltaAB1, DeltaA12)
        float n2 = dAB2_x*dA12_y - dAB2_y*dA12_x; //  cross(DeltaAB2, DeltaA12)
        float d  = dAB1_x*dAB2_y - dAB1_y*dAB2_x; //  cross(DeltaAB1, DeltaAB2)
        float r  = n1 / d;     //@@  DivByZero possible?
        //@@  EarlyOut?
        float s  = n2 / d;
        //=====================================================================================================================================
        return (r >= 0f && r <= 1f) && (s >= 0f && s <= 1f);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     LineVsAar(  Line-Point-A,  Line-Point-B,  Rectangle-Position,  Rectangle-Size  )
    ///
    internal static bool LineVsAar(vec2 La, vec2 Lb, vec2 Rp, vec2 Rs ) {
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
    ///
    ///     LineVsCircle(  Line-Point-A,  Line-Point-B,  Circle-Position,  Circle-Radius  )
    ///
    internal static bool LineVsCircle(vec2 La, vec2 Lb, vec2 Cp, float Cr) {

        float Cr_Sqrd = Cr*Cr;

        //  Is LinePointB in Circle?    Check B first, it's typically used as the destination of a movement vector.
        float dBC_x = Cp.x - Lb.x;
        float dBC_y = Cp.y - Lb.y;
        if ((dBC_x*dBC_x + dBC_y*dBC_y) < Cr_Sqrd)
            return true;

        //  Is LinePointA in Circle?
        float dAC_x = Cp.x - La.x;
        float dAC_y = Cp.y - La.y;
        if ((dAC_x*dAC_x + dAC_y*dAC_y) < Cr_Sqrd)
            return true;

        // Get distance to NearestPointOnLine from LinePointA as multiple of DeltaAB:
        float dAB_x = Lb.x - La.x;
        float dAB_y = Lb.y - La.y;
        float Scaler = (dAC_x*dAB_x + dAC_y*dAB_y) / (dAB_x*dAB_x + dAB_y*dAB_y);

        // Is ProjectedPoint going to be between LinePointA and LinePointB:
        if (Scaler < 0f || Scaler >= 1f)
            return false;

        //  CirclePosition projected on to Line:
        float CpP_x = La.x + dAB_x * Scaler;
        float CpP_y = La.y + dAB_y * Scaler;

        // Is ProjectedPoint in Circle?
        float dPC_X = CpP_x - Cp.x;
        float dPC_Y = CpP_y - Cp.y;
        if ((dPC_X*dPC_X + dPC_Y*dPC_Y) < Cr_Sqrd)
            return true;

        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
