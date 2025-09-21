using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static class VEC_Collision2 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //             @         P > 0
    //
    //      A------@------B  P = 0
    //
    //             @         P < 0
    //
    internal static float WhichSideOfLine(vec2 P, vec2 La, vec2 Lb) => cross(P-La, Lb-La);

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
    //
    //      PointVsCircle(  Point,  CirclePosition,  CircleRadius  )
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsCircle(vec2 P, vec2 Cp, float Cr) =>
        dot(P - Cp) < (Cr*Cr);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      PointVsLine(  Point,  Line-PointA,  Line-PointB,  Tolerance  )
    //
    internal static bool PointVsLine(vec2 P, vec2 La, vec2 Lb, float T) {
        vec2 dAP = P  - La;
        vec2 dAB = Lb - La;

        //  Distance from Line-PointA to NearestPointOnLine, as multiple of DeltaAB:
        float Scaler = dot(dAP, dAB) / dot(dAB, dAB);

        //  Is ProjectedPoint going to be between Line-PointA and Line-PointB:
        #if true
            if (Scaler < 0f || Scaler >= 1f  )  return false;
        #else
            if (Scaler < -T || Scaler >= 1f+T)  return false;
        #endif

        return dot(dAP - dAB*Scaler) < (T*T);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Axis-Aligned-Rectangle"
    //
    //                    RectSiz
    //       +Y *--------@
    //          |        |
    //          |        |
    //          |        |
    //          @--------* +X
    //   RectPos
    //
    //      PointVsRect(  Point,  RectanglePosition,  RectangleSize  )
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsRect(vec2 P, vec2 Rp, vec2 Rs) => (
           P.x >= Rp.x
        && P.y >= Rp.y
        && P.x <  Rp.x+Rs.x
        && P.y <  Rp.y+Rs.y
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Weinding is Anti-Clockwise.
    //
    //              A
    //        +Y    @
    //             / \
    //            /   \
    //           /     \
    //          @-------@   +X
    //         B         C
    //
    // https://www.desmos.com/calculator/9d31eb577f
    //
    //      PointVsTriangle(  Point,  TrianglePointA,  TrianglePointB,  TrianglePointC  )
    //
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
    //
    //      RectVsRect(  Rectangle1-Position,  Rectangle1-Size,  Rectangle2-Position,  Rectangle2-Size)
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool RectVsRect(vec2 Rp1, vec2 Rs1, vec2 Rp2, vec2 Rs2) => (
           Rp1.x       <  Rp2.x+Rs2.x
        && Rp1.y       <  Rp2.y+Rs2.y
        && Rp1.x+Rs1.x >= Rp2.x
        && Rp1.y+Rs1.y >= Rp2.y
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      CircleVsCircle(  Circle1-Position,  Circle1-Radius,  Circle2-Position,  Circle2-Radius  )
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool CircleVsCircle(vec2 Cp1, float Cr1, vec2 Cp2, float Cr2) {
        vec2 d = Cp1 - Cp2;
        return dot(d,d) < (Cr1*Cr1 + Cr2*Cr2);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      CircleVsRect(  Circle-Position,  Circle-Radius,  Rectangle-Position,  Rectangle-Size  )
    //
    internal static bool CircleVsRect(vec2 Cp, float Cr, vec2 Rp, vec2 Rs) {
        float C_Lf = Cp.x - Cr; // "Circle Left"
        float C_Rt = Cp.x + Cr; // "Circle Right"
        float C_Bm = Cp.y - Cr; // "Circle Bottom"
        float C_Tp = Cp.y + Cr; // "Circle Top"

        float R_Lf = Rp.x;        // "Rectangle Left"
        float R_Rt = Rp.x + Rs.x; // "Rectangle Right"
        float R_Bm = Rp.y;        // "Rectangle Bottom"
        float R_Tp = Rp.y + Rs.y; // "Rectangle Top"

        if      (C_Lf >  R_Rt  ||  C_Bm > R_Tp  ||  C_Rt < R_Lf  ||  C_Tp < R_Bm) return false;     //  7   @@ 21 ops  &  3 branches

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

    //==========================================================================================================================================================
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal static bool RectVsCircle(vec2 Rp, vec2 Rs, vec2 Cp, float Cr) => CircleVsRect(Cp, Cr, Rp, Rs);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Parallel overlapping Lines will not test positive as a collision.
    //
    internal static bool LineVsLine(vec2 La1, vec2 Lb1, vec2 La2, vec2 Lb2) {
        vec2 dL1 = Lb1 - La1; //  Line1 in LocalSpace.   A = (0,0)  B = (#,#)
        vec2 dL2 = Lb2 - La2; //  Line2 in LocalSpace.   A = (0,0)  B = (#,#)
        vec2 dAA = La1 - La2;

        float d = cross(dL1, dL2);
        float r = cross(dL1, dAA) / d;
        float s = cross(dL2, dAA) / d;

        return (r >= 0f && r <= 1f) && (s >= 0f && s <= 1f);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      LineVsRect(  Line-Point-A,  Line-Point-B,  Rectangle-Position,  Rectangle-Size  )
    //
    internal static bool LineVsRect(vec2 La, vec2 Lb, vec2 Rp, vec2 Rs) {
        vec2 dL1 = Lb - La;
        vec2 L0 = ((dL1.x < 0f) ? Lb.x : La.x, (dL1.y < 0f) ? Lb.y : La.y);
        vec2 L1 = ((dL1.x < 0f) ? La.x : Lb.x, (dL1.y < 0f) ? La.y : Lb.y);

        vec2 R0 = ((Rs.x < 0f) ? Rp.x+Rs.x : Rp.x, (Rs.y < 0f) ? Rp.y+Rs.y : Rp.y);
        vec2 R1 = ((Rs.x < 0f) ? Rp.x : Rp.x+Rs.x, (Rs.y < 0f) ? Rp.y : Rp.y+Rs.y);
        Rs = R1 - R0;

        //  Is Area-of-Line over Area-of-Rectangle?
        if (L0 > R1 || L1 < R0) return false;

        //  Is PointB inside Rectangle?
        if (Lb >= R0 && Lb <= R1) return true;

        //  Is PointA inside Rectangle?
        if (La >= R0 && La <= R1) return true;

        vec2 dL2, dAA;
        float d, r, s;

        //  Are any of the 4 Rectangle-Lines colliding with the Line?
        dL2 = (Rs.x, 0f);
        d = cross(dL1, dL2);
        if (d != 0f) {
            dAA = La - R0;
            r = cross(dL1, dAA) / d;
            s = cross(dL2, dAA) / d;
            if ((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f)) return true;
        }

        dL2 = (0f, Rs.y);
        d = cross(dL1, dL2);
        if (d != 0f) {
            dAA = La - (R1.x, R0.y);
            r = cross(dL1, dAA) / d;
            s = cross(dL2, dAA) / d;
            if ((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f)) return true;
        }

        dL2 = (-Rs.x, 0f);
        d = cross(dL1, dL2);
        if (d != 0f) {
            dAA = La - R1;
            r = cross(dL1, dAA) / d;
            s = cross(dL2, dAA) / d;
            if ((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f)) return true;
        }

        //  The function will never make it here.
        dL2 = (0f, -Rs.y);
        d = cross(dL1, dL2);
        if (d != 0f) {
            dAA = La - (R0.x, R1.y);
            r = cross(dL1, dAA) / d;
            s = cross(dL2, dAA) / d;
            if ((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f)) return true;
        }

        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      LineVsCircle(  Line-Point-A,  Line-Point-B,  Circle-Position,  Circle-Radius  )
    //
    internal static bool LineVsCircle(vec2 La, vec2 Lb, vec2 Cp, float Cr) {
        vec2 dBC = Cp - Lb;
        float CrCr = Cr*Cr;

        //  Is Line-PointB inside Circle?
        if (dot(dBC, dBC) <= CrCr)
            return true;

        //  Is Line-PointA inside Circle?
        vec2 dAC = Cp - La;
        if (dot(dAC, dAC) <= CrCr)
            return true;

        //  Get distance to NearestPointOnLine from Line-PointA as multiple of DeltaAB:
        vec2 dAB = Lb - La;
        float Scaler = dot(dAC, dAB) / dot(dAB, dAB);

        //  Is ProjectedPoint going to be between Line-PointA and Line-PointB:
        if (Scaler < 0f || Scaler > 1f)
            return false;

        //  CirclePos projected on to Line:
        vec2 Pp = La + dAB*Scaler;

        //  Is ProjectedPoint in Circle?
        vec2 dPC = Pp - Cp;
        if (dot(dPC, dPC) <= CrCr)
            return true;

        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
