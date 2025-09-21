

namespace Utility;
internal static partial class VEC_Miscellaneous {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    "Barycentric"
    //
    //  https://www.desmos.com/calculator/9d31eb577f
    //
    //  Returns 3 weights corresponding to a position relative to the 3 points of a triangle.
    //      Center == (1/3, 1/3, 1/3)
    //
    internal static vec3 Barycentric(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        vec2 dAB = Tb-Ta;
        vec2 dAC = Tc-Ta;
        vec2 dAP = P -Ta;

        float Scaler = 1f / (dAB.x*dAC.y - dAC.x*dAB.y);

        float Bw = (dAP.x*dAC.y - dAP.y*dAC.x) * Scaler;
        float Cw = (dAP.y*dAB.x - dAP.x*dAB.y) * Scaler;
        float Aw = 1f - Bw - Cw;

        return new vec3(Aw, Bw, Cw);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                     "Delaunay"
    //
    //  Test if a Point is inside of a Triangle's CircumCircle.
    //
    internal static bool Delaunay(vec2 P, vec2 Ta, vec2 Tb, vec2 Tc) {
        vec2 dAB = Tb-Ta;
        vec2 dBC = Tc-Tb;

        float Determinant = 2f * (dAB.x*dBC.y - dAB.y*dBC.x);

        vec2 d;
        vec2 CCp; //  CircumCircle Position.

        if (abs(Determinant) < EPSILON) {
            //  Triangle points are Collinear, define CircumCircle by delta between furthest points.
            vec2 Min = min(Ta, Tb, Tc);
            vec2 Max = max(Ta, Tb, Tc);

            CCp = (Min+Max) * 0.5f;

            d = CCp - Min;

        } else {
            vec2 dAC = Tc-Ta;

            float AB_AB = dot(dAB, Ta+Tb);
            float AC_AC = dot(dAC, Ta+Tc);

            CCp = new vec2(
                (dAC.y*AB_AB - dAB.y*AC_AC) / Determinant,
                (dAB.x*AC_AC - dAC.x*AB_AB) / Determinant
            );

            d = CCp - Ta;
        }

        float CC_RdsSqrd = dot(d);

        d = CCp - P;

        return (dot(d) < CC_RdsSqrd);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  AKA: HaversineDistance
    //
    //  Inputs are a Rotation-Vector (Pitch, Yaw) in radians.
    //  Output is Distance in radians (0 to PI).
    //
    internal static float SphericalDistance(vec2 A, vec2 B) {
        vec2 dAB = B-A;
        dAB = sin(dAB * 0.5f);

        float D = dAB.x * dAB.x
                + dAB.y * dAB.y * cos(A.x) * cos(B.x);

        return 2f * asin( sqrt(D) );
    }

    //==========================================================================================================================================================
    //
    //  Inputs are a Unit-Pointing-Vector.
    //  Output is Distance in radians (0 to PI).
    //
    internal static float SphericalDistance(vec3 A, vec3 B) => acos(dot(A,B));

    internal static float SphericalDistance_(vec3 A, vec3 B) => atan2(cross(A,B).length, dot(A,B));

    internal static float SphericalDistance__(vec3 A, vec3 B) {
        // num = |A × B| = |A||B| sinθ
        float cx = A.y*B.z - A.z*B.y;
        float cy = A.z*B.x - A.x*B.z;
        float cz = A.x*B.y - A.y*B.x;
        float num = sqrt(cx*cx + cy*cy + cz*cz);

        // den = A · B = |A||B| cosθ
        float den = A.x*B.x + A.y*B.y + A.z*B.z;

        // θ = atan2(|A×B|, A·B) — no clamps, no NaNs from tiny overshoots.
        return atan2(num, den);
    }

    //##########################################################################################################################################################
    /*##########################################################################################################################################################

        Spherical Coordinate System

            ( r,  θ,  φ )

                X   Depth/Elevation     r               Radial Distance         Distance along the line connecting the point to a fixed point called the origin.
                Y   Pitch               θ "theta"       Polar Angle             Angle between this radial line and a given polar axis.
                Z   Yaw                 φ "phi"         Azimuthal Angle         Angle which is the angle of rotation of the radial line around the polar axis.

    //########################################################################################################################################################*/
    //##########################################################################################################################################################
}
