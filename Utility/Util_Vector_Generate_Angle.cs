using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Thetas are clockwise.
    //      (  0,   0) == ( 0, 0,-1)
    //      ( 90,   0) == ( 0,-1, 0)
    //      (-90,   0) == ( 0, 1, 0)
    //
    //      (  0,   0) == ( 0, 0,-1)
    //      (  0,  90) == ( 1, 0, 0)
    //      (  0, 180) == ( 0, 0, 1)
    //      (  0, 270) == (-1, 0, 0)
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 FromAng(float Theta) {                                   //  Vector2 from Angle. (in radians)
        Theta = -Theta; // Theta is clockwise.
        return new vec2( MathF.Cos(Theta), MathF.Sin(Theta) );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 FromPch(float Theta) {                                   //  Vector3 from Pitch.
        Theta = -Theta; // Theta is clockwise.                                  //  Result will be on plane spanning YZ.
        return new vec3( 0.0f, MathF.Sin(Theta), -MathF.Cos(Theta) );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 FromYaw(float Theta) {                                   //  Vector3 from Yaw.
        Theta = -Theta; // Theta is clockwise.                                  //  Result will be on plane spanning XZ.
        return new vec3( MathF.Cos(Theta), 0.0f, -MathF.Sin(Theta) );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 FromRol(float Theta) {                                   //  Vector3 from Roll.
        Theta = -Theta; // Theta is clockwise.                                  //  Result will be on plane spanning XY.
        return new vec3( MathF.Cos(Theta), MathF.Sin(Theta), 0.0f );
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 FromPchYaw(float Pch, float Yaw) {                       //  Vector3 from Pitch & Yaw.
        float CosPch = MathF.Cos(Pch);

        return new vec3(
             CosPch * MathF.Sin(Yaw),
                     -MathF.Sin(Pch),
            -CosPch * MathF.Cos(Yaw)
        );
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 RotFromVec(vec3 V) =>                                    //  Generate 'Rot == vec3(Pitch, Yaw, 0)' from Vector3.
        new vec3( MathF.Asin(-V.y),  MathF.Atan2(V.x, V.z),  0.0f );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
