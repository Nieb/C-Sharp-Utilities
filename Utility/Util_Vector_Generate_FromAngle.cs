using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  The starting orientations for these are designed around being practical, not mathematically "correct".
    //
    //  All Thetas are Clockwise
    //  and are in Radians.
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Vector2  FROM  Angle.
    ///
    ///     (  0) == ( 0, 1)
    ///     ( 90) == ( 1, 0)
    ///     (180) == ( 0,-1)
    ///     (270) == (-1, 0)
    ///     (360) == ( 0, 1)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 FromAng(float Theta) => new vec2( MathF.Sin(Theta), MathF.Cos(Theta) );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Vector3  FROM  Pitch.  Result on plane spanning YZ.
    ///
    ///     (  0) == ( 0, 0,-1)
    ///     ( 90) == ( 0,-1, 0)
    ///     (180) == ( 0, 0, 1)
    ///     (270) == ( 0, 1, 0)
    ///     (360) == ( 0, 0,-1)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 FromPch(float Theta) => new vec3( 0f, -MathF.Sin(Theta), -MathF.Cos(Theta) );

    //==========================================================================================================================================================
    ///
    /// Vector3  FROM  Yaw.    Result on plane spanning XZ.
    ///
    ///     (  0) == ( 0, 0,-1)
    ///     ( 90) == ( 1, 0, 0)
    ///     (180) == ( 0, 0, 1)
    ///     (270) == (-1, 0, 0)
    ///     (360) == ( 0, 0,-1)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 FromYaw(float Theta) => new vec3( MathF.Sin(Theta), 0f, -MathF.Cos(Theta) );

    //==========================================================================================================================================================
    ///
    /// Vector3  FROM  Roll.   Result on plane spanning XY.
    ///
    ///     (  0) == ( 0, 1, 0)
    ///     ( 90) == ( 1, 0, 0)
    ///     (180) == ( 0,-1, 0)
    ///     (270) == (-1, 0, 0)
    ///     (360) == ( 0, 1, 0)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 FromRol(float Theta) => new vec3( MathF.Sin(Theta), MathF.Cos(Theta), 0f );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Vector3  FROM  Pitch & Yaw.
    ///
    ///     (  0,   0) == ( 0, 0,-1)
    ///     (  0,  90) == ( 1, 0, 0)
    ///     (  0, 180) == ( 0, 0, 1)
    ///     (  0, 270) == (-1, 0, 0)
    ///
    ///     (-90,   0) == ( 0, 1, 0)
    ///     (  0,   0) == ( 0, 0,-1)
    ///     ( 90,   0) == ( 0,-1, 0)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 FromPchYaw(float Pch, float Yaw) {
        float CosPch = MathF.Cos(Pch);

        return new vec3(
             CosPch * MathF.Sin(Yaw),
                     -MathF.Sin(Pch),
            -CosPch * MathF.Cos(Yaw)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Rotation Vector3(Pitch, Yaw, 0)
    ///   FROM
    /// Pointing Vector3(X, Y, Z)  normalized
    ///
    ///     ( 0, 0,-1) == (  0,  0, 0)
    ///     ( 0,-1, 0) == ( 90,  0, 0)
    ///     ( 0, 0, 1) == (  0,180, 0)
    ///     ( 0, 1, 0) == (-90,  0, 0)
    ///
    ///     ( 0, 0,-1) == (  0,  0, 0)
    ///     ( 1, 0, 0) == (  0, 90, 0)
    ///     ( 0, 0, 1) == (  0,180, 0)
    ///     (-1, 0, 0) == (  0,270, 0)
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 RotFromVec(vec3 Vn) {
        Vn.y = -Vn.y;
        Vn.z = -Vn.z;

        float Pch = atan2(Vn.y, sqrt(Vn.x*Vn.x + Vn.z*Vn.z));

        float Yaw = (abs(Pch) >= PIH) ? 0f : wrap(atan2(Vn.x, Vn.z), 0f, PI2);

        return new vec3(Pch, Yaw, 0f);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}