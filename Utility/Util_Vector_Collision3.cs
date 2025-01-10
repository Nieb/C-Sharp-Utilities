

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///               @    1
    ///           |
    ///     ------+---@--  0
    ///
    ///               @   -1
    ///
    ///     WhichSideOfPlane(  Point,  Plane-Position,  Plane-Normal  )
    ///
    //public static int PointVsPlane(vec3 V, vec3 Pp, vec3 Pn) {
    public static int WhichSideOfPlane(vec3 V, vec3 Pp, vec3 Pn) {
        float Determinant = (Pn.x*(V.x-Pp.x) + Pn.y*(V.y-Pp.y) + Pn.z*(V.z-Pp.z)); // dot(Pn, V - Pp)
        return (Determinant > 0f) ?  1
             : (Determinant < 0f) ? -1 : 0;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     PointVsSphere(  Point,  Sphere-Position,  Sphere-Radius  )
    ///
    public static bool PointVsSphere(vec3 P, vec3 Sp, float Sr) {
        float d_x = Sp.x - P.x;
        float d_y = Sp.y - P.y;
        float d_z = Sp.z - P.z;
        return (d_x*d_x + d_y*d_y + d_z*d_z) <= (Sr*Sr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Aab = "Axis-Aligned-Box"
    ///
    ///                    BoxSiz
    ///      +Y *--------@
    ///         |        |
    ///         |        |
    ///         |        |
    ///         @--------* +X
    ///   BoxPos
    ///
    ///     PointVsBox(  Point,  Box-Position,  Box-Size  )
    ///
    public static bool PointVsBox(vec3 P, vec3 Bp, vec3 Bs) => (
           P.x >= Bp.x
        && P.x <  Bp.x+Bs.x
        && P.y >= Bp.y
        && P.y <  Bp.y+Bs.y
        && P.z >= Bp.z
        && P.z <  Bp.z+Bs.z
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     PointVsCylinder(  Point,  Cylinder-Position,  Cylinder-Radius,  Cylinder-Height  )
    ///
    public static bool PointVsCylinder(vec3 P, vec3 Cp, float Cr, float Ch) {
        //  Is Point below or above Cylinder?
        if (P.y < Cp.y || P.y >= Cp.y+Ch) return false;

        //  Is Point inside of Cylinder-Radius?
        float d_x = P.x - Cp.x;
        float d_z = P.z - Cp.z;
        return (d_x*d_x + d_z*d_z < Cr*Cr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// All  RayVs<Surface>()  functions return:  vec4( HitPosX, HitPosY, HitPosZ, HitDistance )
    ///
    ///                        Surface      Ray
    ///     Distance < 0.0      |-->        -->  Surface is Behind Ray.
    ///
    ///     Distance = 0.0      |-->         |   Ray is parallel to surface plane.
    ///                                      V
    ///
    ///     Distance > 0.0      |-->        <--  Surface is InFront of Ray.
    ///
    ///
    /// If surface has bounds  and  Ray-Line does not intersect, it will return:  RAY_MISS
    ///
    //==========================================================================================================================================================
    public static readonly vec4 RAY_MISS = new vec4(FLOAT_NEG_INF, FLOAT_NEG_INF, FLOAT_NEG_INF, FLOAT_NEG_INF);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Surface
    //==========================================================================================================================================================
    ///
    /// Axis-Aligned, Plane spans YZ.
    ///
    ///     RayVsPlaneX(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Plane-Position  )
    ///
    public static vec4 RayVsPlaneX(vec3 Rp, vec3 Rn, vec3 Rnr, float Pp_x) {
        float Distance = (Pp_x - Rp.x) * Rnr.x;
        return new vec4(Rp + (Rn*Distance), Distance);
    }

    //==========================================================================================================================================================
    ///
    /// Axis-Aligned, Plane spans XZ.
    ///
    ///     RayVsPlaneY(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Plane-Position  )
    ///
    public static vec4 RayVsPlaneY(vec3 Rp, vec3 Rn, vec3 Rnr, float Pp_y) {
        float Distance = (Pp_y - Rp.y) * Rnr.y;
        return new vec4(Rp + (Rn*Distance), Distance);
    }

    //==========================================================================================================================================================
    ///
    /// Axis-Aligned, Plane spans XY.
    ///
    ///     RayVsPlaneZ(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Plane-Position  )
    ///
    public static vec4 RayVsPlaneZ(vec3 Rp, vec3 Rn, vec3 Rnr, float Pp_z) {
        float Distance = (Pp_z - Rp.z) * Rnr.z;
        return new vec4(Rp + (Rn*Distance), Distance);
    }

    //==========================================================================================================================================================
    ///
    ///     RayVsPlane(  Ray-Position,  Ray-Normal,    Plane-Position,  Plane-Normal  )
    ///
    public static vec4 RayVsPlane(vec3 Rp, vec3 Rn, vec3 Pp, vec3 Pn) {
        float WhichSide         =  dot(Pn, Rp-Pp);
        float Dot_RayNrm_PlnNrm = -dot(Rn, Pn);

        float Distance = WhichSide / Dot_RayNrm_PlnNrm;

        return new vec4(Rp + (Rn*Distance), Distance);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     RayVsTriangle(  Ray-Position,  Ray-Normal,    Triangle-PointA,  Triangle-PointB,  Triangle-PointC,    BackFaceTest  )
    ///
    public static vec4 RayVsTriangle(vec3 Rp, vec3 Rn,   vec3 Ta, vec3 Tb, vec3 Tc,   bool BackFaceTest = true) {
        vec3 dAB = Tb - Ta;
        vec3 dAC = Tc - Ta;

        vec3 H = cross(Rn, dAC);
        float Determinant = dot(dAB, H);

        if (Determinant < 0f && !BackFaceTest)
            return RAY_MISS;

        if (Determinant == 0f) //  Is Ray parallel with Triangle Surface.
            return new vec4(Rp, 0f);

        vec3 dAP = Rp - Ta;
        float DtrRcp = 1f/Determinant;
        float U = dot(dAP, H) * DtrRcp;

        if (U < 0f || U > 1f) //  Will intersection be inside of triangle?
            return RAY_MISS;

        vec3 Q = cross(dAP, dAB);
        float V = dot(Rn, Q) * DtrRcp;

        if (V < 0f || U+V > 1f) //  Will intersection be inside of triangle?
            return RAY_MISS;

        float Distance = dot(dAC, Q) * DtrRcp;

        return new vec4((Rp + Rn*Distance), Distance);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Axis-Aligned; Quad spans YZ.
    ///
    ///     RayVsQuadX(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Quad-Position,  Quad-Size  )
    ///
    public static vec4 RayVsQuadX(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
        float Distance = (Qp.x - Rp.x) * Rnr.x;
        vec3 Hp = Rp + (Rn*Distance); //  HitPosition
        return (Hp.z >= Qp.z && Hp.z < Qp.z+Qs.x
            &&  Hp.y >= Qp.y && Hp.y < Qp.y+Qs.y) ? new vec4(Hp, Distance) : RAY_MISS;
    }

    //==========================================================================================================================================================
    ///
    /// Axis-Aligned; Quad spans XZ.
    ///
    ///     RayVsQuadY(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Quad-Position,  Quad-Size  )
    ///
    public static vec4 RayVsQuadY(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
        float Distance = (Qp.y - Rp.y) * Rnr.y;
        vec3 Hp = Rp + (Rn*Distance); //  HitPosition
        return (Hp.x >= Qp.x && Hp.x < Qp.x+Qs.x
            &&  Hp.z >= Qp.z && Hp.z < Qp.z+Qs.y) ? new vec4(Hp, Distance) : RAY_MISS;
    }

    //==========================================================================================================================================================
    ///
    /// Axis-Aligned; Quad spans XY.
    ///
    ///     RayVsQuadZ(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Quad-Position,  Quad-Size  )
    ///
    public static vec4 RayVsQuadZ(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
        float Distance = (Qp.z - Rp.z) * Rnr.z;
        vec3 Hp = Rp + (Rn*Distance); //  HitPosition
        return (Hp.x >= Qp.x && Hp.x < Qp.x+Qs.x
            &&  Hp.y >= Qp.y && Hp.y < Qp.y+Qs.y) ? new vec4(Hp, Distance) : RAY_MISS;
    }

    //==========================================================================================================================================================
    ///
    ///     RayVsQuad(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Normal,  Quad-???  )
    ///
    public static vec4 RayVsQuad(vec3 Rp, vec3 Rn,    vec3 Qp, vec3 Qn, vec3 Qnt) {
        float WhichSide =  dot(Qn, Rp-Qp);
        float Dot_RnPn  = -dot(Rn, Qn);
        float Distance  = WhichSide / Dot_RnPn;
        vec3 HitPos = Rp + (Rn*Distance);

        vec4 ToDo = RAY_MISS;
        //
        //  Hmm, how to express Quad orientation...
        //
        //  Use vec3 "Quad-Bounds" instead?  Normal & size can be derived...  "Quad-Extent" ?
        //      Nope, this still lacks orientation...
        //
        //  Need 3 vec3s to define quad-plane.
        //      Quad_Pos, Quad_Nrm, Quad_NrmTangent
        //                Quad_Nrm, Quad_NrmTangent, Quad_NrmBiTangent
        //
        //  Is this even something practical or useful...?
        //
        return ToDo;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Volume
    //==========================================================================================================================================================
    ///
    ///     RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    ///
    public static vec4 RayVsSphere(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
        vec4 ToDo = RAY_MISS;
        //
        //  Is Ray_Pos inside the Sphere?
        //      return new vec4(Rp, 0f);
        //
        //  Project SpherePos onto Ray-Line,
        //  is this ProjectedPoint inside the Sphere?
        //  if so, determine HitPos...
        //
        //                            \  @
        //                             \ :
        //                              \:
        //                               X
        //                               :\
        //                               : \
        //                               :  \
        //                               :   |
        //                               :   |
        //          0------------------->0   |
        //                               :   |
        //                               :   |
        //                               :  /
        //                               : /
        //                               :/
        //                               X
        //                              /:
        //                             / :
        //                            /  V
        //
        return ToDo;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     RayVsBox(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,  Box-Position,  Box-Size  )
    ///
    public static vec4 RayVsBox(vec3 Rp, vec3 Rn, vec3 Rnr, vec3 Bp, vec3 Bs) {
        //
        //  Distance to bounding planes from RayPos along RayNrm,
        //  for 3 Axes, Near & Far, 6 total.
        //
        //       +Y  |      |
        //           |      |                                          +Y -Z (far)
        //       ----+------+----  <- DstMaxY                           | /
        //           |      |                                           |/
        //           |      |                              DstMinZ ->   +---- +X
        //           |      |                                          /
        //       ----+------+----  <- DstMinY                         /
        //           |      |                                        /
        //           |      |  +X                      DstMaxZ ->  +Z (near)
        //           ^
        //        DstMinX   ^
        //               DstMaxX
        //
        float DistNear_x = (Bp.x      - Rp.x) * Rnr.x;
        float DistFar_x  = (Bp.x+Bs.x - Rp.x) * Rnr.x;
        if (DistNear_x > DistFar_x)
            (DistNear_x, DistFar_x) = (DistFar_x, DistNear_x); //  Reorient relative to RayPos.

        float DistNear_y = (Bp.y      - Rp.y) * Rnr.y;
        float DistFar_y  = (Bp.y+Bs.y - Rp.y) * Rnr.y;
        if (DistNear_y > DistFar_y)
            (DistNear_y, DistFar_y) = (DistFar_y, DistNear_y);

        float DistNear_z = (Bp.z      - Rp.z) * Rnr.z;
        float DistFar_z  = (Bp.z+Bs.z - Rp.z) * Rnr.z;
        if (DistNear_z > DistFar_z)
            (DistNear_z, DistFar_z) = (DistFar_z, DistNear_z);

        //  Select PlaneHits in Quadrant/Octant of Box:
        float DistToBackFace  = min(DistFar_x , DistFar_y , DistFar_z );
        float DistToFrontFace = max(DistNear_x, DistNear_y, DistNear_z);

        //  Did we hit it?
        return (DistToFrontFace > DistToBackFace) ? RAY_MISS
             : (DistToBackFace  <             0f) ? new vec4(Rp + (Rn*DistToBackFace), DistToBackFace)   //  Box is behind RayPos.
             : (DistToFrontFace <=            0f) ? new vec4(Rp, 0f)                                     //  RayPos is inside Box.
                                                  : new vec4(Rp + (Rn*DistToFrontFace), DistToFrontFace);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
