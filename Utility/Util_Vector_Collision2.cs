using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
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
    ///     L------P------N  = 0
    ///
    ///            P         < 0
    ///
    //public static int PointVsLine(vec2 P, vec2 Lp, vec2 Ln) {
    public static int WhichSideOfLine(vec2 P, vec2 La, vec2 Lb) {
        float Determinant = (P.x-La.x)*(Lb.y-La.y) - (P.y-La.y)*(Lb.x-La.x); // cross(DeltaAP, DeltaAB)
        return (Determinant > 0f) ?  1
             : (Determinant < 0f) ? -1 : 0;
    }




    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     PointVsLine(  Point,  Line-PointA,  Line-PointB,  Tolerance  )
    ///
    public static bool PointVsLine(vec2 P, vec2 La, vec2 Lb, float Tolerance) {
        //if (P.x == La.x && P.y == La.y) return true;  The occurrence of these is so rare that it is not worth checking for.
        //if (P.x == Lb.x && P.y == Lb.y) return true;

        //  Delta from Line-PointA  to  Point & Line-PointB:
        float dAP_x =  P.x - La.x;
        float dAP_y =  P.y - La.y;

        float dAB_x = Lb.x - La.x;
        float dAB_y = Lb.y - La.y;

        float DotPB           = (dAP_x * dAB_x) + (dAP_y * dAB_y);
        float Line_LengthSqrd = (dAB_x * dAB_x) + (dAB_y * dAB_y);

        //  Get distance to NearestPointOnLine from Line-PointA as multiple of DeltaAB:
        float Scaler = DotPB / Line_LengthSqrd;

        //  Is ProjectedPoint going to be between Line-PointA and Line-PointB:
        if (Scaler < 0f || Scaler >= 1f) return false;

        //  Project Point onto Line:
        float pP_x = dAB_x * Scaler;
        float pP_y = dAB_y * Scaler;

        //  Delta between Point and ProjectedPoint:
        float dPP_x = dAP_x - pP_x;
        float dPP_y = dAP_y - pP_y;

        return (dPP_x*dPP_x + dPP_y*dPP_y < Tolerance*Tolerance);
    }




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
    ///     PointVsCircle(  Point,  CirclePosition,  CircleRadius  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool PointVsCircle(vec2 P, vec2 Cp, float Cr) {
        float d_x = P.x - Cp.x;
        float d_y = P.y - Cp.y;
        return (d_x*d_x + d_y*d_y < Cr*Cr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///                   RectSiz
    ///      +Y *--------@
    ///         |        |
    ///         |        |
    ///         |        |
    ///         @--------* +X
    ///  RectPos
    ///
    ///     PointVsAar(  Point,  RectanglePosition,  RectangleSize  )
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
    /// https://www.desmos.com/calculator/8jfeiiyuap
    ///
    ///             A   Weinding is Anti-Clockwise.
    ///       +Y    @
    ///            / \
    ///           /   \
    ///          /     \
    ///         @-------@   +X
    ///        B         C
    ///
    ///     PointVsTriangle(  Point,  TrianglePointA,  TrianglePointB,  TrianglePointC  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool PointVsTriangle(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        float  dPA_x = Ta.x - P.x,  dPA_y = Ta.y - P.y;
        float  dPB_x = Tb.x - P.x,  dPB_y = Tb.y - P.y;
        float  dPC_x = Tc.x - P.x,  dPC_y = Tc.y - P.y;

        return (dPA_x*dPB_y >= dPA_y*dPB_x)
            && (dPB_x*dPC_y >= dPB_y*dPC_x)
            && (dPC_x*dPA_y >= dPC_y*dPA_x);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// https://www.desmos.com/calculator/eyeuk0o9oj
    ///
    /// "Irregular Quadrilateral"
    /// Quad must be convex.
    ///
    ///     B
    ///      @---___
    ///   +Y  \     `--___
    ///        \          `--___    A   Weinding is Anti-Clockwise.
    ///         \               `--@
    ///          \                /
    ///           \              /
    ///            \            /
    ///             \     __---@
    ///              @--``      D
    ///             C              +X
    ///
    ///     PointVsQuad(  Point,  QuadPointA,  QuadPointB,  QuadPointC,  QuadPointD  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool PointVsQuad(vec2 P, vec2 Qa, vec2 Qb, vec2 Qc, vec2 Qd) {
        float  dPA_x = Qa.x - P.x,  dPA_y = Qa.y - P.y;
        float  dPB_x = Qb.x - P.x,  dPB_y = Qb.y - P.y;
        float  dPC_x = Qc.x - P.x,  dPC_y = Qc.y - P.y;
        float  dPD_x = Qd.x - P.x,  dPD_y = Qd.y - P.y;

        return (dPA_x*dPB_y >= dPA_y*dPB_x)
            && (dPB_x*dPC_y >= dPB_y*dPC_x)
            && (dPC_x*dPD_y >= dPC_y*dPD_x)
            && (dPD_x*dPA_y >= dPD_y*dPA_x);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Polygon must be convex.
    ///
    public static bool PointVsPolygon(vec2 P, vec2[] Poly) {
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
    ///     AarVsAar(  Rectangle1-Position,  Rectangle1-Size,  Rectangle2-Position,  Rectangle2-Size)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool AarVsAar(vec2 Rp1, vec2 Rs1, vec2 Rp2, vec2 Rs2) => (
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
    ///
    ///     CircleVsCircle(  Circle1-Position,  Circle1-Radius,  Circle2-Position,  Circle2-Radius  )
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool CircleVsCircle(vec2 Cp1, float Cr1, vec2 Cp2, float Cr2) {
        float d_x = Cp1.x - Cp2.x;
        float d_y = Cp1.y - Cp2.y;
        return ((d_x*d_x + d_y*d_y) < (Cr1*Cr1 + Cr2*Cr2));
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     CircleVsAar(  Circle-Position,  Circle-Radius,  Rectangle-Position,  Rectangle-Size  )
    ///
    public static bool CircleVsAar(vec2 Cp, float Cr, vec2 Rp, vec2  Rs) {
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
    public static bool LineVsLine(vec2 La1, vec2 Lb1, vec2 La2, vec2 Lb2 ) {
        //=====================================================================================================================================
        float dAB1_x = Lb1.x - La1.x;
        float dAB1_y = Lb1.y - La1.y;
        float dAB2_x = Lb2.x - La2.x;
        float dAB2_y = Lb2.y - La2.y;
        float dA12_x = La1.x - La2.x;
        float dA12_y = La1.y - La2.y;
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
    public static bool LineVsAar(vec2 La, vec2 Lb, vec2 Rp, vec2 Rs ) {
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
    public static bool LineVsCircle(vec2 La, vec2 Lb, vec2 Cp, float Cr) {

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
