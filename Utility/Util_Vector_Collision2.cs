using System;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool PointVsPoint(vec2 Pa, vec2 Pb, float Threshold) =>
        PointVsCircle(Pa, Pb, Threshold);

    //##########################################################################################################################################################
    public static bool PointVsCircle(vec2 P, vec2 Cp, float Cr) {               //  ( Point,  Circle-Position,  Circle-Radius )
        float Dlt_X = P.x - Cp.x;
        float Dlt_Y = P.y - Cp.y;
        return (Dlt_X*Dlt_X + Dlt_Y*Dlt_Y < Cr*Cr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool PointVsAar(vec2 P, vec2 Rp, vec2 Rs) => (                //  ( Point,  Rectangle-Position,  Rectangle-Size )
           P.x <  Rp.x+Rs.x                                                     //      +Y +--------@ RectSiz
        && P.x >= Rp.x                                                          //         |        |
        && P.y <  Rp.y+Rs.y                                                     //         |        |
        && P.y >= Rp.y                                                          //         |        |
    );                                                                          // RectPos @--------+ +X

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool PointVsTriangle(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {        //  ( Point, Triangle(Ta, Tb, Tc) )
        float dPA_x = Ta.x - P.x;                                                //  Winding is Anti-Clockwise.
        float dPA_y = Ta.y - P.y;                                                //  https://www.desmos.com/calculator/dzkn7zysvv
        float dPB_x = Tb.x - P.x;
        float dPB_y = Tb.y - P.y;
        float dPC_x = Tc.x - P.x;
        float dPC_y = Tc.y - P.y;
        return (dPA_x*dPC_y >= dPC_x*dPA_y) && (dPB_x*dPA_y >= dPA_x*dPB_y) && (dPC_x*dPB_y >= dPB_x*dPC_y);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool AarVsAar(vec2 Rct1_Pos, vec2 Rct1_Siz,
                                vec2 Rct2_Pos, vec2 Rct2_Siz) => (
           Rct1_Pos.x            <  Rct2_Pos.x+Rct2_Siz.x
        && Rct1_Pos.x+Rct1_Siz.x >= Rct2_Pos.x
        && Rct1_Pos.y            <  Rct2_Pos.y+Rct2_Siz.y
        && Rct1_Pos.y+Rct1_Siz.y >= Rct2_Pos.y
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool CircleVsCircle(vec2 Cir1_Pos, float Cir1_Rds,
                                      vec2 Cir2_Pos, float Cir2_Rds) {
        float Dlt_X = Cir1_Pos.x - Cir2_Pos.x;
        float Dlt_Y = Cir1_Pos.y - Cir2_Pos.y;
        return ((Dlt_X*Dlt_X + Dlt_Y*Dlt_Y) < (Cir1_Rds*Cir1_Rds + Cir2_Rds*Cir2_Rds));
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool CircleVsAar(vec2 Cir_Pos, float Cir_Rds,
                                   vec2 Rct_Pos, vec2  Rct_Siz) {

        float Cir_Lf = Cir_Pos.x - Cir_Rds; // "Circle Left"
        float Cir_Rt = Cir_Pos.x + Cir_Rds; // "Circle Right"
        float Cir_Bm = Cir_Pos.y - Cir_Rds; // "Circle Bottom"
        float Cir_Tp = Cir_Pos.y + Cir_Rds; // "Circle Top"

        float Rct_Lt = Rct_Pos.x;             // "Rectangle Left"
        float Rct_Rt = Rct_Pos.x + Rct_Siz.x; // "Rectangle Right"
        float Rct_Bm = Rct_Pos.y;             // "Rectangle Bottom"
        float Rct_Tp = Rct_Pos.y + Rct_Siz.y; // "Rectangle Top"

        if (Cir_Lf > Rct_Rt || Cir_Bm > Rct_Tp || Cir_Rt < Rct_Lt || Cir_Tp < Rct_Bm) return false;

        if      (Cir_Pos.y >= Rct_Bm && Cir_Pos.y < Rct_Tp && Cir_Lf < Rct_Rt && Cir_Rt > Rct_Lt) return true;
        else if (Cir_Pos.x >= Rct_Lt && Cir_Pos.x < Rct_Rt && Cir_Bm < Rct_Tp && Cir_Tp > Rct_Bm) return true;

        float Dlt_X = (Cir_Pos.x < Rct_Lt) ? Cir_Pos.x - Rct_Lt
                    : (Cir_Pos.x > Rct_Rt) ? Cir_Pos.x - Rct_Rt
                    : 0.0f;

        float Dlt_Y = (Cir_Pos.y < Rct_Bm) ? Cir_Pos.y - Rct_Bm
                    : (Cir_Pos.y > Rct_Tp) ? Cir_Pos.y - Rct_Tp
                    : 0.0f;

        if (Dlt_X*Dlt_X + Dlt_Y*Dlt_Y <= Cir_Rds*Cir_Rds) return true;

        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //public static int WhichSideOfLine(vec2 Pnt,
    //                                  vec2 LinA, vec2 LinB) {
    //    float Determinant = (Pnt.x-LinA.x)*(LinB.y-LinA.y) - (Pnt.y-LinA.y)*(LinB.x-LinA.x); // cross(DeltaAP, DeltaAB)
    //    //         P           1
    //    //
    //    //  A──────P──────B    0
    //    //
    //    //         P          -1
    //    return 0 + (Determinant > 0.0) - (Determinant < 0.0);
    //}

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool PointVsLine(vec2 Pnt,
                                   vec2 LinA, vec2 LinB, float Tolerance) {
        //if (Pnt.x = LinA.x && Pnt.y = LinA.y) return true;  The occurrence of these is so rare that it is not worth checking for.
        //if (Pnt.x = LinB.x && Pnt.y = LinB.y) return true;

        float DltAP_X =  Pnt.x - LinA.x;
        float DltAP_Y =  Pnt.y - LinA.y;

        float DltAB_X = LinB.x - LinA.x;
        float DltAB_Y = LinB.y - LinA.y;

        float DotAP_AB = (DltAP_X * DltAB_X) + (DltAP_Y * DltAB_Y);
        float DotAB_AB = (DltAB_X * DltAB_X) + (DltAB_Y * DltAB_Y);

        // Get distance to NearestPointOnLine from LinA as multiple of DltAB:
        float DltAB_Scalar = DotAP_AB / DotAB_AB;

        // Is ProjectedPoint going to be between A and B:
        if (DltAB_Scalar < 0.0 || DltAB_Scalar >= 1.0) return false; // -1

        // Project 'Pnt' onto Line:
        float PrjPnt_X = DltAB_X * DltAB_Scalar;
        float PrjPnt_Y = DltAB_Y * DltAB_Scalar;

        // Distance between 'Pnt' and 'PrjPnt':
        float DltPPP_X = DltAP_X - PrjPnt_X;
        float DltPPP_Y = DltAP_Y - PrjPnt_Y;

        return (DltPPP_X*DltPPP_X + DltPPP_Y*DltPPP_Y < Tolerance*Tolerance);
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public static bool PointVsLine_1(vec2 Pnt,
                                     vec2 LinA, vec2 LinB, float Tolerance) {
        float DltPA_X = LinA.x - Pnt.x;
        float DltPA_Y = LinA.y - Pnt.y;

        float DltPB_X = LinB.x - Pnt.x;
        float DltPB_Y = LinB.y - Pnt.y;

        float APB_Len = MathF.Sqrt(DltPA_X*DltPA_X + DltPA_Y*DltPA_Y) + MathF.Sqrt(DltPB_X*DltPB_X + DltPB_Y*DltPB_Y);   //@@  SQRTs can likely be optimized out.

        float DltAB_X = LinB.x - LinA.x;
        float DltAB_Y = LinB.y - LinA.y;

        float AB_Len  = MathF.Sqrt(DltAB_X*DltAB_X + DltAB_Y*DltAB_Y);    //@@  SQRT can likely be optimized out.

        return (APB_Len < AB_Len + Tolerance) && (APB_Len > AB_Len - Tolerance);
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public static bool PointVsLine_2(vec2 Pnt,
                                     vec2 LinA, vec2 LinB, float Tolerance) {
        float DltAB_X = LinB.x - LinA.x;
        float DltAB_Y = LinB.y - LinA.y;
        float LenAB = DltAB_X*DltAB_X + DltAB_Y*DltAB_Y;

        float DltPA_X = LinA.x - Pnt.x;
        float DltPA_Y = LinA.y - Pnt.y;
        float LenPA = DltPA_X*DltPA_X + DltPA_Y*DltPA_Y;
        if (LenPA > LenAB) return false;

        float DltPB_X = LinB.x - Pnt.x;
        float DltPB_Y = LinB.y - Pnt.y;
        float LenPB = DltPB_X*DltPB_X + DltPB_Y*DltPB_Y;
        if (LenPB > LenAB) return false;

        LenAB = 1.0f / MathF.Sqrt(LenAB);   //@@ SQRT can likely be optimized out.

        float Dtrmnt = DltPB_X*DltPA_Y - DltPA_X*DltPB_Y;
        Dtrmnt = Dtrmnt*LenAB;

        return (Dtrmnt > -Tolerance) && (Dtrmnt < Tolerance);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool LineVsLine(vec2 Lin1A, vec2 Lin1B,  //  Parallel overlapping Lines will not test positive as a collision.
                                  vec2 Lin2A, vec2 Lin2B ) {
        //=====================================================================================================================================
        float Dlt_Lin1_X   = Lin1B.x - Lin1A.x; //  Line1 in LocalSpace.   A = (0,0)  B = (#,#)
        float Dlt_Lin1_Y   = Lin1B.y - Lin1A.y;
        float Dlt_Lin2_X   = Lin2B.x - Lin2A.x; //  Line2 in LocalSpace.   A = (0,0)  B = (#,#)
        float Dlt_Lin2_Y   = Lin2B.y - Lin2A.y;
        float Dlt_LinPos_X = Lin1A.x - Lin2A.x;
        float Dlt_LinPos_Y = Lin1A.y - Lin2A.y;
        //=====================================================================================================================================
        float n1 = Dlt_Lin1_X*Dlt_LinPos_Y - Dlt_Lin1_Y*Dlt_LinPos_X; //  Dlt_Lin1  cross  Dlt_LinPos
        float n2 = Dlt_Lin2_X*Dlt_LinPos_Y - Dlt_Lin2_Y*Dlt_LinPos_X; //  Dlt_Lin2  cross  Dlt_LinPos
        float d  = Dlt_Lin1_X*Dlt_Lin2_Y   - Dlt_Lin1_Y*Dlt_Lin2_X;   //  Dlt_Lin1  cross  Dlt_Lin2
        float r  = n1 / d;     //@@  DivByZero possible?
        //@@  EarlyOut?
        float s  = n2 / d;
        //=====================================================================================================================================
        return (r >= 0.0 && r <= 1.0) && (s >= 0.0 && s <= 1.0);
    }


    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool LineVsAar(vec2 LinA,    vec2 LinB,
                                 vec2 Rct_Pos, vec2 Rct_Siz ) {  // Pos = BottomLeft     Siz = (Width, Height)
        //=====================================================================================================================================
        float Rct_Rt = Rct_Pos.x + Rct_Siz.x;
        float Rct_Bm = Rct_Pos.y + Rct_Siz.y;
        //=====================================================================================================================================
        // Is Area-of-Line over Area-of-Rectangle?
        float Lin_Lf = 0.0f;
        float Lin_Rt = 0.0f;
        if      (LinA.x <= LinB.x) { Lin_Lf = LinA.x; Lin_Rt = LinB.x; }
        else if (LinA.x >  LinB.x) { Lin_Lf = LinB.x; Lin_Rt = LinA.x; }

        float Lin_Bm = 0.0f;
        float Lin_Tp = 0.0f;
        if      (LinA.y <= LinB.y) { Lin_Bm = LinB.y; Lin_Tp = LinA.y; }
        else if (LinA.y >  LinB.y) { Lin_Bm = LinA.y; Lin_Tp = LinB.y; }

        if (Rct_Pos.x >= Lin_Rt || Rct_Pos.y >= Lin_Bm || Rct_Rt < Lin_Lf || Rct_Bm < Lin_Tp) return false;
        //=====================================================================================================================================
        // Is PointB in Rectangle?
        // Check PointB first, it's typically used as the destination of a movement vector.
        if (   LinB.x <  Rct_Rt
            && LinB.x >= Rct_Pos.x
            && LinB.y <  Rct_Bm
            && LinB.y >= Rct_Pos.y) return true;
        //=====================================================================================================================================
        // Is PointA in Rectangle?
        if (   LinA.x <  Rct_Rt
            && LinA.x >= Rct_Pos.x
            && LinA.y <  Rct_Bm
            && LinA.y >= Rct_Pos.y) return true;
        //=====================================================================================================================================
        // Are any of the 4 Rectangle-Lines colliding with the Line?
        float Delta_1A_1B_X = LinB.x - LinA.x;
        float Delta_1A_1B_Y = LinB.y - LinA.y;
        float Delta_2A_2B_X;
        float Delta_2A_2B_Y;
        float Delta_1A_2A_X;
        float Delta_1A_2A_Y;
        //=====================================================================================================================================
        float n1;
        float n2;
        float d;
        float r;
        float s;
        //=====================================================================================================================================
        Delta_2A_2B_X = Rct_Rt    - Rct_Pos.x;
        Delta_2A_2B_Y = Rct_Pos.y - Rct_Pos.y;
        Delta_1A_2A_X = LinA.x - Rct_Pos.x;
        Delta_1A_2A_Y = LinA.y - Rct_Pos.y;
        n1 = (Delta_1A_2A_Y * Delta_1A_1B_X) - (Delta_1A_2A_X * Delta_1A_1B_Y);
        n2 = (Delta_1A_2A_Y * Delta_2A_2B_X) - (Delta_1A_2A_X * Delta_2A_2B_Y);
        d  = (Delta_1A_1B_X * Delta_2A_2B_Y) - (Delta_1A_1B_Y * Delta_2A_2B_X);
        r  = n1 / d;
        s  = n2 / d;
        if (r >= 0.0 && r <= 1.0 && s >= 0.0 && s <= 1.0) return true;
        //=====================================================================================================================================
        Delta_2A_2B_X = Rct_Rt - Rct_Rt;
        Delta_2A_2B_Y = Rct_Bm - Rct_Pos.y;
        Delta_1A_2A_X = LinA.x - Rct_Rt;
        Delta_1A_2A_Y = LinA.y - Rct_Pos.y;
        n1 = (Delta_1A_2A_Y * Delta_1A_1B_X) - (Delta_1A_2A_X * Delta_1A_1B_Y);
        n2 = (Delta_1A_2A_Y * Delta_2A_2B_X) - (Delta_1A_2A_X * Delta_2A_2B_Y);
        d  = (Delta_1A_1B_X * Delta_2A_2B_Y) - (Delta_1A_1B_Y * Delta_2A_2B_X);
        r  = n1 / d;
        s  = n2 / d;
        if (r >= 0.0 && r <= 1.0 && s >= 0.0 && s <= 1.0) return true;
        //=====================================================================================================================================
        Delta_2A_2B_X = Rct_Pos.x - Rct_Rt;
        Delta_2A_2B_Y = Rct_Bm    - Rct_Bm;
        Delta_1A_2A_X = LinA.x - Rct_Rt;
        Delta_1A_2A_Y = LinA.y - Rct_Bm;
        n1 = (Delta_1A_2A_Y * Delta_1A_1B_X) - (Delta_1A_2A_X * Delta_1A_1B_Y);
        n2 = (Delta_1A_2A_Y * Delta_2A_2B_X) - (Delta_1A_2A_X * Delta_2A_2B_Y);
        d  = (Delta_1A_1B_X * Delta_2A_2B_Y) - (Delta_1A_1B_Y * Delta_2A_2B_X);
        r  = n1 / d;
        s  = n2 / d;
        if (r >= 0.0 && r <= 1.0 && s >= 0.0 && s <= 1.0) return true;
        //=====================================================================================================================================
        // The function will never make it here.
        //Delta_2A_2B_X = Rct_Pos.x - Rct_Pos.x;
        //Delta_2A_2B_Y = Rct_Pos.y - Rct_Bm;
        //Delta_1A_2A_X = LinA.x - Rct_Pos.x;
        //Delta_1A_2A_Y = LinA.y - Rct_Bm;
        //n1 = (Delta_1A_2A_Y * Delta_1A_1B_X) - (Delta_1A_2A_X * Delta_1A_1B_Y);
        //n2 = (Delta_1A_2A_Y * Delta_2A_2B_X) - (Delta_1A_2A_X * Delta_2A_2B_Y);
        //d  = (Delta_1A_1B_X * Delta_2A_2B_Y) - (Delta_1A_1B_Y * Delta_2A_2B_X);
        //r  = n1 / d;
        //s  = n2 / d;
        //IF (r >= 0.0 && r <= 1.0 && s >= 0.0 && s <= 1.0) return true;
        //=====================================================================================================================================
        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static bool LineVsCircle(vec2 LinA   , vec2 LinB,
                                    vec2 Cir_Pos, float Cir_Rds) {
        //=====================================================================================================================================
        float Cir_Lf = Cir_Pos.x - Cir_Rds;
        float Cir_Tp = Cir_Pos.y - Cir_Rds;
        float Cir_Rt = Cir_Pos.x + Cir_Rds;
        float Cir_Bm = Cir_Pos.y + Cir_Rds;
        //=====================================================================================================================================
        // Is Area-of-Line over Area-of-Circle?
        float Lin_Lf = 0.0f;
        float Lin_Rt = 0.0f;
        if      (LinA.x <= LinB.x) { Lin_Lf = LinA.x; Lin_Rt = LinB.x; }
        else if (LinA.x >  LinB.x) { Lin_Lf = LinB.x; Lin_Rt = LinA.x; }

        float Lin_Tp = 0.0f;
        float Lin_Bm = 0.0f;
        if      (LinA.y <= LinB.y) { Lin_Tp = LinA.y; Lin_Bm = LinB.y; }
        else if (LinA.y >  LinB.y) { Lin_Tp = LinB.y; Lin_Bm = LinA.y; }

        if (Cir_Lf > Lin_Rt || Cir_Tp > Lin_Bm || Cir_Rt < Lin_Lf || Cir_Bm < Lin_Tp) return false;
        //=====================================================================================================================================
        float CirRds_Sqrd = Cir_Rds*Cir_Rds;
        //=====================================================================================================================================
        // Is PointB in Circle?                                Check PointB first, it's typically used as the destination of a movement vector.
        float DeltaBC_X = Cir_Pos.x - LinB.x;
        float DeltaBC_Y = Cir_Pos.y - LinB.y;
        if ((DeltaBC_X*DeltaBC_X + DeltaBC_Y*DeltaBC_Y) < CirRds_Sqrd) return true;
        //=====================================================================================================================================
        // Is PointA in Circle?
        float DeltaAC_X = Cir_Pos.x - LinA.x;
        float DeltaAC_Y = Cir_Pos.y - LinA.y;
        if ((DeltaAC_X*DeltaAC_X + DeltaAC_Y*DeltaAC_Y) < CirRds_Sqrd) return true;
        //=====================================================================================================================================
        // PointD = CircleCenter projected on to Line.
        float DeltaAB_X = LinB.x - LinA.x;
        float DeltaAB_Y = LinB.y - LinA.y;
        float DeltaAD_L = (DeltaAC_X*DeltaAB_X + DeltaAC_Y*DeltaAB_Y) / (DeltaAB_X*DeltaAB_X + DeltaAB_Y*DeltaAB_Y);
        float PntD_X = LinA.x + DeltaAB_X * DeltaAD_L;
        float PntD_Y = LinA.y + DeltaAB_Y * DeltaAD_L;
        //=====================================================================================================================================
        // Is PntD between PointA and PointB?
        if (PntD_X > Lin_Rt || PntD_Y > Lin_Bm || PntD_X < Lin_Lf || PntD_Y < Lin_Tp) return false;
        //=====================================================================================================================================
        // Is PntD in Circle?
        float DeltaDC_X = PntD_X - Cir_Pos.x;
        float DeltaDC_Y = PntD_Y - Cir_Pos.y;
        if ((DeltaDC_X*DeltaDC_X + DeltaDC_Y*DeltaDC_Y) < CirRds_Sqrd) return true;
        //=====================================================================================================================================
        return false;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
