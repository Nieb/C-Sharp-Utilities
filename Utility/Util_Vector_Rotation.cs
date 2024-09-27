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
    public static vec2 rot(vec2 Pnt, float Theta) {
        if (Theta == 0.0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        return new vec2( Pnt.x*CosT - Pnt.y*SinT,
                         Pnt.x*SinT + Pnt.y*CosT );
    }

    //==========================================================================================================================================================
    public static vec2 rot(vec2 Pnt, vec2 Pivot, float Theta) {
        if (Theta == 0.0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        float Dlt_x = Pnt.x - Pivot.x;
        float Dlt_y = Pnt.y - Pivot.y;

        return new vec2( Pivot.x  +  Dlt_x*CosT - Dlt_y*SinT,
                         Pivot.y  +  Dlt_x*SinT + Dlt_y*CosT );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 pch(vec3 Pnt, float Theta) {
        if (Theta == 0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        return new vec3(
                 Pnt.x,
            CosT*Pnt.y + -SinT*Pnt.z,
            SinT*Pnt.y +  CosT*Pnt.z
        );
    }

    //==========================================================================================================================================================
    public static vec3 pch(vec3 Pnt, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        float Dlt_y = Pnt.y - Pivot.y;
        float Dlt_z = Pnt.z - Pivot.z;

        return new vec3(
              Pnt.x,
            Pivot.y  +  CosT*Dlt_y + -SinT*Dlt_z,
            Pivot.z  +  SinT*Dlt_y +  CosT*Dlt_z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 yaw(vec3 Pnt, float Theta) {
        if (Theta == 0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        return new vec3(
             CosT*Pnt.x + SinT*Pnt.z,
                  Pnt.y,
            -SinT*Pnt.x + CosT*Pnt.z
        );
    }

    //==========================================================================================================================================================
    public static vec3 yaw(vec3 Pnt, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        float Dlt_x = Pnt.x - Pivot.x;
        float Dlt_z = Pnt.z - Pivot.z;

        return new vec3(
            Pivot.x  +   CosT*Dlt_x + SinT*Dlt_z,
              Pnt.y,
            Pivot.z  +  -SinT*Dlt_x + CosT*Dlt_z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 rol(vec3 Pnt, float Theta) {
        if (Theta == 0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        return new vec3(
            CosT*Pnt.x + -SinT*Pnt.y,
            SinT*Pnt.x +  CosT*Pnt.y,
                 Pnt.z
        );
    }

    //==========================================================================================================================================================
    public static vec3 rol(vec3 Pnt, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = MathF.Cos(Theta);
        float SinT = MathF.Sin(Theta);

        float Dlt_x = Pnt.x - Pivot.x;
        float Dlt_y = Pnt.y - Pivot.y;

        return new vec3(
            Pivot.x  +  CosT*Dlt_x + -SinT*Dlt_y,
            Pivot.y  +  SinT*Dlt_x +  CosT*Dlt_y,
              Pnt.z
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 rot(vec3 Pnt, vec3 Axis, float Theta) {
        if (Theta == 0f)
            return Pnt;

        Theta = -Theta; //  Theta is clockwise.
        float  CosT = MathF.Cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = MathF.Sin(Theta);

        //  DewIt:
        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;
        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;
        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new vec3(
            Pnt.x*(Axx_iCosT +    CosT)  +  Pnt.y*(Axy_iCosT - Az_SinT)  +  Pnt.z*(Axz_iCosT + Ay_SinT),
            Pnt.x*(Axy_iCosT + Az_SinT)  +  Pnt.y*(Ayy_iCosT +    CosT)  +  Pnt.z*(Ayz_iCosT - Ax_SinT),
            Pnt.x*(Axz_iCosT - Ay_SinT)  +  Pnt.y*(Ayz_iCosT + Ax_SinT)  +  Pnt.z*(Azz_iCosT +    CosT)
        );
    }

    //==========================================================================================================================================================
    public static vec3 rot(vec3 Pnt, vec3 Pivot, vec3 Axis, float Theta) {
        if (Theta == 0f)
            return Pnt;

        //  'Point' in 'Pivot' LocalSpace.
        float Dlt_x = Pnt.x - Pivot.x;
        float Dlt_y = Pnt.y - Pivot.y;
        float Dlt_z = Pnt.z - Pivot.z;

        Theta = -Theta; //  Theta is clockwise.
        float  CosT = MathF.Cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = MathF.Sin(Theta);

        //  DewIt:
        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x*iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;
        float Axz_iCosT = Axis.x * Az_iCosT;
        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;
        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new vec3(
            Pivot.x  +  Dlt_x*(Axx_iCosT +    CosT)  +  Dlt_y*(Axy_iCosT - Az_SinT)  +  Dlt_z*(Axz_iCosT + Ay_SinT),
            Pivot.y  +  Dlt_x*(Axy_iCosT + Az_SinT)  +  Dlt_y*(Ayy_iCosT +    CosT)  +  Dlt_z*(Ayz_iCosT - Ax_SinT),
            Pivot.z  +  Dlt_x*(Axz_iCosT - Ay_SinT)  +  Dlt_y*(Ayz_iCosT + Ax_SinT)  +  Dlt_z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 rot(vec3 Pnt, vec3 ThetaVec) {
        if (ThetaVec.x == 0f && ThetaVec.y == 0f && ThetaVec.z == 0f)
            return Pnt;

        //  Derive singular rotation 'Theta'.  Length of 'ThetaVec'.
        float Theta = -MathF.Sqrt(ThetaVec.x*ThetaVec.x + ThetaVec.y*ThetaVec.y + ThetaVec.z*ThetaVec.z); //  Theta is clockwise.

        float  CosT = MathF.Cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = MathF.Sin(Theta);

        //  Derive singular rotation 'Axis'.  'ThetaVec' normalized.
        float ThetaRcp = 1f / Theta;
        float Axis_x = ThetaVec.x * ThetaRcp;
        float Axis_y = ThetaVec.y * ThetaRcp;
        float Axis_z = ThetaVec.z * ThetaRcp;

        //  DewIt:
        float Ay_iCosT = Axis_y * iCosT;
        float Az_iCosT = Axis_z * iCosT;

        float Axx_iCosT = Axis_x * Axis_x*iCosT;
        float Axy_iCosT = Axis_x * Ay_iCosT;
        float Axz_iCosT = Axis_x * Az_iCosT;
        float Ayy_iCosT = Axis_y * Ay_iCosT;
        float Ayz_iCosT = Axis_y * Az_iCosT;
        float Azz_iCosT = Axis_z * Az_iCosT;

        float Ax_SinT = Axis_x * SinT;
        float Ay_SinT = Axis_y * SinT;
        float Az_SinT = Axis_z * SinT;

        return new vec3(
            Pnt.x*(Axx_iCosT +    CosT)  +  Pnt.y*(Axy_iCosT - Az_SinT)  +  Pnt.z*(Axz_iCosT + Ay_SinT),
            Pnt.x*(Axy_iCosT + Az_SinT)  +  Pnt.y*(Ayy_iCosT +    CosT)  +  Pnt.z*(Ayz_iCosT - Ax_SinT),
            Pnt.x*(Axz_iCosT - Ay_SinT)  +  Pnt.y*(Ayz_iCosT + Ax_SinT)  +  Pnt.z*(Azz_iCosT +    CosT)
        );
    }

    //==========================================================================================================================================================
    public static vec3 rot(vec3 Pnt, vec3 Pivot, vec3 ThetaVec) {
        if (ThetaVec.x == 0f && ThetaVec.y == 0f && ThetaVec.z == 0f)
            return Pnt;

        //  'Point' in 'Pivot' LocalSpace.
        float Dlt_x = Pnt.x - Pivot.x;
        float Dlt_y = Pnt.y - Pivot.y;
        float Dlt_z = Pnt.z - Pivot.z;

        //  Derive singular rotation 'Theta'.  Length of 'ThetaVec'.
        float Theta = -MathF.Sqrt(ThetaVec.x*ThetaVec.x + ThetaVec.y*ThetaVec.y + ThetaVec.z*ThetaVec.z); //  Theta is clockwise.

        float  CosT = MathF.Cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = MathF.Sin(Theta);

        //  Derive singular rotation 'Axis'.  'ThetaVec' normalized.
        float ThetaRcp = 1f / Theta;
        float Axis_x = ThetaVec.x * ThetaRcp;
        float Axis_y = ThetaVec.y * ThetaRcp;
        float Axis_z = ThetaVec.z * ThetaRcp;

        //  DewIt:
        float Ay_iCosT = Axis_y * iCosT;
        float Az_iCosT = Axis_z * iCosT;

        float Axx_iCosT = Axis_x * Axis_x*iCosT;
        float Axy_iCosT = Axis_x * Ay_iCosT;
        float Axz_iCosT = Axis_x * Az_iCosT;
        float Ayy_iCosT = Axis_y * Ay_iCosT;
        float Ayz_iCosT = Axis_y * Az_iCosT;
        float Azz_iCosT = Axis_z * Az_iCosT;

        float Ax_SinT = Axis_x * SinT;
        float Ay_SinT = Axis_y * SinT;
        float Az_SinT = Axis_z * SinT;

        return new vec3(
            Pivot.x  +  Dlt_x*(Axx_iCosT +    CosT)  +  Dlt_y*(Axy_iCosT - Az_SinT)  +  Dlt_z*(Axz_iCosT + Ay_SinT),
            Pivot.y  +  Dlt_x*(Axy_iCosT + Az_SinT)  +  Dlt_y*(Ayy_iCosT +    CosT)  +  Dlt_z*(Ayz_iCosT - Ax_SinT),
            Pivot.z  +  Dlt_x*(Axz_iCosT - Ay_SinT)  +  Dlt_y*(Ayz_iCosT + Ax_SinT)  +  Dlt_z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
