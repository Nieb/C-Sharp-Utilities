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
    public static vec2 rot(vec2 P, float Theta) {
        if (Theta == 0.0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        return new vec2( P.x*CosT - P.y*SinT,
                         P.x*SinT + P.y*CosT );
    }

    //==========================================================================================================================================================
    public static vec2 rot(vec2 P, vec2 Pivot, float Theta) {
        if (Theta == 0.0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        float d_x = P.x - Pivot.x;
        float d_y = P.y - Pivot.y;

        return new vec2( Pivot.x  +  d_x*CosT - d_y*SinT,
                         Pivot.y  +  d_x*SinT + d_y*CosT );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 pch(vec3 P, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        return new vec3(
                 P.x,
            CosT*P.y + -SinT*P.z,
            SinT*P.y +  CosT*P.z
        );
    }

    //==========================================================================================================================================================
    public static vec3 pch(vec3 P, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        float d_y = P.y - Pivot.y;
        float d_z = P.z - Pivot.z;

        return new vec3(
                P.x,
            Pivot.y  +  CosT*d_y + -SinT*d_z,
            Pivot.z  +  SinT*d_y +  CosT*d_z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 yaw(vec3 P, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        return new vec3(
             CosT*P.x + SinT*P.z,
                  P.y,
            -SinT*P.x + CosT*P.z
        );
    }

    //==========================================================================================================================================================
    public static vec3 yaw(vec3 P, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        float d_x = P.x - Pivot.x;
        float d_z = P.z - Pivot.z;

        return new vec3(
            Pivot.x  +   CosT*d_x + SinT*d_z,
                P.y,
            Pivot.z  +  -SinT*d_x + CosT*d_z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 rol(vec3 P, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        return new vec3(
            CosT*P.x + -SinT*P.y,
            SinT*P.x +  CosT*P.y,
                 P.z
        );
    }

    //==========================================================================================================================================================
    public static vec3 rol(vec3 P, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        float d_x = P.x - Pivot.x;
        float d_y = P.y - Pivot.y;

        return new vec3(
            Pivot.x  +  CosT*d_x + -SinT*d_y,
            Pivot.y  +  SinT*d_x +  CosT*d_y,
                P.z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 rot(vec3 P, vec3 Axis, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.

        float  CosT = MathF.Cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = MathF.Sin(Theta);

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;
        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new vec3(
            P.x*(Axx_iCosT +    CosT)  +  P.y*(Axy_iCosT - Az_SinT)  +  P.z*(Axz_iCosT + Ay_SinT),
            P.x*(Axy_iCosT + Az_SinT)  +  P.y*(Ayy_iCosT +    CosT)  +  P.z*(Ayz_iCosT - Ax_SinT),
            P.x*(Axz_iCosT - Ay_SinT)  +  P.y*(Ayz_iCosT + Ax_SinT)  +  P.z*(Azz_iCosT +    CosT)
        );
    }

    //==========================================================================================================================================================
    public static vec3 rot(vec3 P, vec3 Pivot, vec3 Axis, float Theta) {
        if (Theta == 0f)
            return P;

        //  'Point' in 'Pivot' LocalSpace.
        float d_x = P.x - Pivot.x;
        float d_y = P.y - Pivot.y;
        float d_z = P.z - Pivot.z;

        Theta = -Theta; //  Theta is clockwise.

        float  CosT = MathF.Cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = MathF.Sin(Theta);

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;
        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new vec3(
            Pivot.x  +  d_x*(Axx_iCosT +    CosT)  +  d_y*(Axy_iCosT - Az_SinT)  +  d_z*(Axz_iCosT + Ay_SinT),
            Pivot.y  +  d_x*(Axy_iCosT + Az_SinT)  +  d_y*(Ayy_iCosT +    CosT)  +  d_z*(Ayz_iCosT - Ax_SinT),
            Pivot.z  +  d_x*(Axz_iCosT - Ay_SinT)  +  d_y*(Ayz_iCosT + Ax_SinT)  +  d_z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// https://www.desmos.com/3d/twldzidh0g
    ///
    public static vec3 rot(vec3 P, vec3 ThetaVec) {
        if (ThetaVec.x == 0f && ThetaVec.y == 0f && ThetaVec.z == 0f)
            return P;

        ThetaVec = -ThetaVec; //  Theta is clockwise.

        //  Derive rotation Theta (length of ThetaVec):
        float Theta = MathF.Sqrt(ThetaVec.x*ThetaVec.x + ThetaVec.y*ThetaVec.y + ThetaVec.z*ThetaVec.z);

        //  Derive rotation Axis (ThetaVec normalized):
        float ThetaRcp = 1f / Theta;
        float Axis_x = ThetaVec.x * ThetaRcp;
        float Axis_y = ThetaVec.y * ThetaRcp;
        float Axis_z = ThetaVec.z * ThetaRcp;

        //  DewIt:
        float  CosT = MathF.Cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = MathF.Sin(Theta);

        float Ay_iCosT = Axis_y * iCosT;
        float Az_iCosT = Axis_z * iCosT;

        float Axx_iCosT = Axis_x * Axis_x*iCosT;
        float Axy_iCosT = Axis_x * Ay_iCosT;
        float Ayy_iCosT = Axis_y * Ay_iCosT;
        float Axz_iCosT = Axis_x * Az_iCosT;
        float Ayz_iCosT = Axis_y * Az_iCosT;
        float Azz_iCosT = Axis_z * Az_iCosT;

        float Ax_SinT = Axis_x * SinT;
        float Ay_SinT = Axis_y * SinT;
        float Az_SinT = Axis_z * SinT;

        return new vec3(
            P.x*(Axx_iCosT +    CosT)  +  P.y*(Axy_iCosT - Az_SinT)  +  P.z*(Axz_iCosT + Ay_SinT),
            P.x*(Axy_iCosT + Az_SinT)  +  P.y*(Ayy_iCosT +    CosT)  +  P.z*(Ayz_iCosT - Ax_SinT),
            P.x*(Axz_iCosT - Ay_SinT)  +  P.y*(Ayz_iCosT + Ax_SinT)  +  P.z*(Azz_iCosT +    CosT)
        );
    }

    //==========================================================================================================================================================
    public static vec3 rot(vec3 P, vec3 Pivot, vec3 ThetaVec) {
        if (ThetaVec.x == 0f && ThetaVec.y == 0f && ThetaVec.z == 0f)
            return P;

        //  'Point' in 'Pivot' LocalSpace.
        float d_x = P.x - Pivot.x;
        float d_y = P.y - Pivot.y;
        float d_z = P.z - Pivot.z;

        ThetaVec = -ThetaVec; //  Theta is clockwise.

        //  Derive rotation Theta (length of ThetaVec):
        float Theta = MathF.Sqrt(ThetaVec.x*ThetaVec.x + ThetaVec.y*ThetaVec.y + ThetaVec.z*ThetaVec.z);

        //  Derive rotation Axis (ThetaVec normalized):
        float ThetaRcp = 1f / Theta;
        float Axis_x = ThetaVec.x * ThetaRcp;
        float Axis_y = ThetaVec.y * ThetaRcp;
        float Axis_z = ThetaVec.z * ThetaRcp;

        //  DewIt:
        float  CosT = MathF.Cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = MathF.Sin(Theta);

        float Ay_iCosT = Axis_y * iCosT;
        float Az_iCosT = Axis_z * iCosT;

        float Axx_iCosT = Axis_x * Axis_x*iCosT;
        float Axy_iCosT = Axis_x * Ay_iCosT;
        float Ayy_iCosT = Axis_y * Ay_iCosT;
        float Axz_iCosT = Axis_x * Az_iCosT;
        float Ayz_iCosT = Axis_y * Az_iCosT;
        float Azz_iCosT = Axis_z * Az_iCosT;

        float Ax_SinT = Axis_x * SinT;
        float Ay_SinT = Axis_y * SinT;
        float Az_SinT = Axis_z * SinT;

        return new vec3(
            Pivot.x  +  d_x*(Axx_iCosT +    CosT)  +  d_y*(Axy_iCosT - Az_SinT)  +  d_z*(Axz_iCosT + Ay_SinT),
            Pivot.y  +  d_x*(Axy_iCosT + Az_SinT)  +  d_y*(Ayy_iCosT +    CosT)  +  d_z*(Ayz_iCosT - Ax_SinT),
            Pivot.z  +  d_x*(Axz_iCosT - Ay_SinT)  +  d_y*(Ayz_iCosT + Ax_SinT)  +  d_z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
