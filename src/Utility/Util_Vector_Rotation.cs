


namespace Utility;
internal static class VEC_Rotation {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                   "Rotate Left"
    //
    //  Rotate 90 degrees Anti-Clockwise.
    //
    [Impl(AggressiveInlining)] internal static vec2 rotl(vec2 P) => new vec2(-P.y, P.x);

    //==========================================================================================================================================================
    //                                                                   "Rotate Right"
    //
    //   Rotate 90 degrees Clockwise.
    //
    [Impl(AggressiveInlining)] internal static vec2 rotr(vec2 P) => new vec2(P.y, -P.x);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static vec2 rot(vec2 P, float Theta) {
        if (Theta == 0.0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

        return new vec2( P.x*CosT - P.y*SinT,
                         P.x*SinT + P.y*CosT );
    }

    //==========================================================================================================================================================
    internal static vec2 rot(vec2 P, vec2 Pivot, float Theta) {
        if (Theta == 0.0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

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
    //
    //
    //
    internal static vec3 pch(vec3 P, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

        return new vec3(
                 P.x,
            CosT*P.y + -SinT*P.z,
            SinT*P.y +  CosT*P.z
        );
    }

    //==========================================================================================================================================================
    internal static vec3 pch(vec3 P, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

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
    internal static vec3 yaw(vec3 P, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

        return new vec3(
             CosT*P.x + SinT*P.z,
                  P.y,
            -SinT*P.x + CosT*P.z
        );
    }

    //==========================================================================================================================================================
    internal static vec3 yaw(vec3 P, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

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
    internal static vec3 rol(vec3 P, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

        return new vec3(
            CosT*P.x + -SinT*P.y,
            SinT*P.x +  CosT*P.y,
                 P.z
        );
    }

    //==========================================================================================================================================================
    internal static vec3 rol(vec3 P, vec3 Pivot, float Theta) {
        if (Theta == 0f)
            return P;

        Theta = -Theta; //  Theta is clockwise.
        float CosT = cos(Theta);
        float SinT = sin(Theta);

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
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  rot(vec3 P,             vec3 Axis, float Theta)  Rotate "Point", around  ZERO  , on "Axis", by "Theta".
    //  rot(vec3 P, vec3 Pivot, vec3 Axis, float Theta)  Rotate "Point", around "Pivot", on "Axis", by "Theta".
    //
    //  rot(vec3 P,                        vec3  Theta)  Rotate "Point", around  ZERO  , on/by "Theta(Pitch, Yaw, Roll)".
    //  rot(vec3 P, vec3 Pivot,            vec3  Theta)  Rotate "Point", around "Pivot", on/by "Theta(Pitch, Yaw, Roll)".
    //
    //      ADD 16 (12+, 4-)
    //      MUL 21
    //      COS 1
    //      SIN 1
    //
    internal static vec3 rot(vec3 P, vec3 Axis, float Theta) {
        if (Theta == 0f)
            return P;

        //  'Theta' is clockwise:
        Theta = -Theta;

        //  DewIt:
        float  CosT = cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = sin(Theta);

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
            P.x*(Axx_iCosT +    CosT)  +  P.y*(Axy_iCosT - Az_SinT)  +  P.z*(Axz_iCosT + Ay_SinT),
            P.x*(Axy_iCosT + Az_SinT)  +  P.y*(Ayy_iCosT +    CosT)  +  P.z*(Ayz_iCosT - Ax_SinT),
            P.x*(Axz_iCosT - Ay_SinT)  +  P.y*(Ayz_iCosT + Ax_SinT)  +  P.z*(Azz_iCosT +    CosT)
        );
    }

    //==========================================================================================================================================================
    internal static vec3 rot(vec3 P, vec3 Pivot, vec3 Axis, float Theta) {
        if (Theta == 0f)
            return P;

        //  'Point' localized to 'Pivot'.
        vec3 dPP = P - Pivot;

        //  'Theta' is clockwise:
        Theta = -Theta;

        //  DewIt:
        float  CosT = cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = sin(Theta);

        float Ay_iCosT = Axis.y * iCosT;
        float Az_iCosT = Axis.z * iCosT;

        float Axx_iCosT = Axis.x * Axis.x * iCosT;
        float Axy_iCosT = Axis.x * Ay_iCosT;

        float Ayy_iCosT = Axis.y * Ay_iCosT;
        float Ayz_iCosT = Axis.y * Az_iCosT;

        float Axz_iCosT = Axis.x * Az_iCosT;
        float Azz_iCosT = Axis.z * Az_iCosT;

        float Ax_SinT = Axis.x * SinT;
        float Ay_SinT = Axis.y * SinT;
        float Az_SinT = Axis.z * SinT;

        return new vec3(
            Pivot.x  +  dPP.x*(Axx_iCosT +    CosT)  +  dPP.y*(Axy_iCosT - Az_SinT)  +  dPP.z*(Axz_iCosT + Ay_SinT),
            Pivot.y  +  dPP.x*(Axy_iCosT + Az_SinT)  +  dPP.y*(Ayy_iCosT +    CosT)  +  dPP.z*(Ayz_iCosT - Ax_SinT),
            Pivot.z  +  dPP.x*(Axz_iCosT - Ay_SinT)  +  dPP.y*(Ayz_iCosT + Ax_SinT)  +  dPP.z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/3d/taev4ge4ks
    //
    internal static vec3 rot(vec3 P, vec3 ThetaV) {
        if (ThetaV == 0f)
            return P;

        //  'Theta' is clockwise:
        ThetaV = -ThetaV;

        //  Derive rotation 'Theta' (length of ThetaV):
        float Theta = sqrt(ThetaV.x*ThetaV.x + ThetaV.y*ThetaV.y + ThetaV.z*ThetaV.z);

        //  Derive rotation 'Axis' (ThetaV normalized):
        vec3 Axis = ThetaV * (1f / Theta);

        //  DewIt:
        float  CosT = cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = sin(Theta);

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
            P.x*(Axx_iCosT +    CosT)  +  P.y*(Axy_iCosT - Az_SinT)  +  P.z*(Axz_iCosT + Ay_SinT),
            P.x*(Axy_iCosT + Az_SinT)  +  P.y*(Ayy_iCosT +    CosT)  +  P.z*(Ayz_iCosT - Ax_SinT),
            P.x*(Axz_iCosT - Ay_SinT)  +  P.y*(Ayz_iCosT + Ax_SinT)  +  P.z*(Azz_iCosT +    CosT)
        );
    }

    //==========================================================================================================================================================
    internal static vec3 rot(vec3 P, vec3 Pivot, vec3 ThetaV) {
        if (ThetaV == 0f)
            return P;

        //  'Point' localized to 'Pivot':
        vec3 dPP = P - Pivot;

        //  'Theta' is clockwise:
        ThetaV = -ThetaV;

        //  Derive rotation 'Theta' (length of ThetaV):
        float Theta = sqrt(ThetaV.x*ThetaV.x + ThetaV.y*ThetaV.y + ThetaV.z*ThetaV.z);

        //  Derive rotation 'Axis' (ThetaV normalized):
        vec3 Axis = ThetaV * (1f / Theta);

        //  DewIt:
        float  CosT = cos(Theta);
        float iCosT = 1f - CosT;
        float  SinT = sin(Theta);

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
            Pivot.x  +  dPP.x*(Axx_iCosT +    CosT)  +  dPP.y*(Axy_iCosT - Az_SinT)  +  dPP.z*(Axz_iCosT + Ay_SinT),
            Pivot.y  +  dPP.x*(Axy_iCosT + Az_SinT)  +  dPP.y*(Ayy_iCosT +    CosT)  +  dPP.z*(Ayz_iCosT - Ax_SinT),
            Pivot.z  +  dPP.x*(Axz_iCosT - Ay_SinT)  +  dPP.y*(Ayz_iCosT + Ax_SinT)  +  dPP.z*(Azz_iCosT +    CosT)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
