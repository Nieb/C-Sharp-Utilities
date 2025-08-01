using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static partial class VEC_Geometry {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float Circle_SurfaceArea(float Rds = 1f) => PI * (Rds*Rds);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float Cylinder_SurfaceArea(float Rds = 1f, float Height = 2f) =>  Rds      * PI2 * (Rds + Height); //  (PI2 * (Rds*Rds)) + (PI2 * Rds * Height);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float Cylinder_Volume     (float Rds = 1f, float Height = 2f) => (Rds*Rds) * PI  *        Height;

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float Sphere_SurfaceArea(float Rds = 1f) => PI4        * (Rds*Rds);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float Sphere_Volume     (float Rds = 1f) => PI*(4f/3f) * (Rds*Rds);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
