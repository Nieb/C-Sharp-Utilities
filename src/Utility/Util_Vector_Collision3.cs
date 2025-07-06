using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static class VEC_Collision3 {
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
    //internal static int PointVsPlane(vec3 V, vec3 Pp, vec3 Pn) {
    internal static int WhichSideOfPlane(vec3 V, vec3 Pp, vec3 Pn) {
        float Determinant = (Pn.x*(V.x-Pp.x) + Pn.y*(V.y-Pp.y) + Pn.z*(V.z-Pp.z)); // dot(Pn, V-Pp)

        return (Determinant > 0f) ?  1
             : (Determinant < 0f) ? -1
                                  :  0;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  PointVsSphere(  Point,  Sphere-Position,  Sphere-Radius  )
    //
    internal static bool PointVsSphere(vec3 P, vec3 Sp, float Sr) {
        float d_x = Sp.x - P.x;
        float d_y = Sp.y - P.y;
        float d_z = Sp.z - P.z;

        return (d_x*d_x + d_y*d_y + d_z*d_z) <= (Sr*Sr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  PointVsBox(  Point,  Box-Position,  Box-Size  )
    //
    //      Axis-Aligned-Box
    //
    //      Inverted box == false   always
    //          Impossible for a Point to be both:
    //              > Box_MinBounds
    //                  AND
    //              < Box_MaxBounds
    //
    //
    //                     BoxSiz
    //       +Y *--------@
    //          |        |
    //          |        |
    //          |        |
    //          @--------* +X
    //    BoxPos
    //
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsBox(vec3 P, vec3 Bp, vec3 Bs) => (P >= Bp  &&  P <= Bp+Bs);
/*
    internal static bool PointVsBox(vec3 P, vec3 Bp, vec3 Bs) => (
           P.x >= Bp.x
        && P.y >= Bp.y
        && P.z >= Bp.z

        && P.x <  Bp.x + Bs.x
        && P.y <  Bp.y + Bs.y
        && P.z <  Bp.z + Bs.z
    );
*/

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     PointVsCylinder(  Point,  Cylinder-Position,  Cylinder-Radius,  Cylinder-Height  )
    ///
    internal static bool PointVsCylinder(vec3 P, vec3 Cp, float Cr, float Ch) {
        //  Is Point below or above Cylinder?
        if (P.y < Cp.y || P.y >= Cp.y+Ch)
            return false;

        //  Is Point inside of Cylinder-Radius?
        float d_x = P.x - Cp.x;
        float d_z = P.z - Cp.z;
        return (d_x*d_x + d_z*d_z) <= (Cr*Cr);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// All  RayVsSurface()  functions return:  vec4( HitPosX, HitPosY, HitPosZ, HitDistance )
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
    internal static readonly vec4 RAY_MISS = new vec4(FLOAT_NEG_INF, FLOAT_NEG_INF, FLOAT_NEG_INF, FLOAT_NEG_INF);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Surface
    //==========================================================================================================================================================
    ///
    /// Axis-Aligned, Plane spans YZ.
    ///
    ///     RayVsPlaneX(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Plane-Position  )
    ///
    internal static vec4 RayVsPlaneX(vec3 Rp, vec3 Rn, vec3 Rnr, float Pp_x) {
        float Distance = (Pp_x - Rp.x) * Rnr.x;
        return new vec4(Rp + (Rn*Distance), Distance);
    }

    //==========================================================================================================================================================
    ///
    /// Axis-Aligned, Plane spans XZ.
    ///
    ///     RayVsPlaneY(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Plane-Position  )
    ///
    internal static vec4 RayVsPlaneY(vec3 Rp, vec3 Rn, vec3 Rnr, float Pp_y) {
        float Distance = (Pp_y - Rp.y) * Rnr.y;
        return new vec4(Rp + (Rn*Distance), Distance);
    }

    //==========================================================================================================================================================
    ///
    /// Axis-Aligned, Plane spans XY.
    ///
    ///     RayVsPlaneZ(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Plane-Position  )
    ///
    internal static vec4 RayVsPlaneZ(vec3 Rp, vec3 Rn, vec3 Rnr, float Pp_z) {
        float Distance = (Pp_z - Rp.z) * Rnr.z;
        return new vec4(Rp + (Rn*Distance), Distance);
    }

    //==========================================================================================================================================================
    ///
    ///     RayVsPlane(  Ray-Position,  Ray-Normal,    Plane-Position,  Plane-Normal  )
    ///
    internal static vec4 RayVsPlane(vec3 Rp, vec3 Rn, vec3 Pp, vec3 Pn) {
        float WhichSide         =  dot(Pn, Rp-Pp);
        float Dot_RayNrm_PlnNrm = -dot(Rn, Pn);

        float Distance = WhichSide / Dot_RayNrm_PlnNrm;

        return new vec4(Rp + (Rn*Distance), Distance);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Axis-Aligned; Quad spans YZ.
    ///
    ///     RayVsQuadX(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Quad-Position,  Quad-Size  )
    ///
    internal static vec4 RayVsQuadX(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
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
    internal static vec4 RayVsQuadY(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
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
    internal static vec4 RayVsQuadZ(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
        float Distance = (Qp.z - Rp.z) * Rnr.z;
        vec3 Hp = Rp + (Rn*Distance); //  HitPosition
        return (Hp.x >= Qp.x && Hp.x < Qp.x+Qs.x
            &&  Hp.y >= Qp.y && Hp.y < Qp.y+Qs.y) ? new vec4(Hp, Distance) : RAY_MISS;
    }

    //==========================================================================================================================================================
    ///
    ///     RayVsQuad(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Normal,  Quad-???  )
    ///
    internal static vec4 RayVsQuad(vec3 Rp, vec3 Rn,    vec3 Qp, vec3 Qn, vec3 Qnt) {
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
        //  Is this even something useful or practical...?
        //
        return ToDo;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     RayVsTriangle(  Ray-Position,  Ray-Normal,    Triangle-PointA,  Triangle-PointB,  Triangle-PointC,    BackFaceTest  )
    ///
    internal static vec4 RayVsTriangle(vec3 Rp, vec3 Rn,   vec3 Ta, vec3 Tb, vec3 Tc,   bool BackFaceTest = true) {
        vec3 dAB = Tb - Ta;
        vec3 dAC = Tc - Ta;

        vec3 H = cross(Rn, dAC);
        float Determinant = dot(dAB, H);

        if (Determinant < 0f && !BackFaceTest) //  Is Ray pointing in the same direction as SurfaceNormal?
            return RAY_MISS;

        if (Determinant == 0f) //  Is Ray parallel with Triangle Surface?
            return new vec4(Rp, 0f); //RAY_MISS;

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
    //                                                                    Ray  VS  Volume
    //==========================================================================================================================================================
    ///
    ///     RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    ///
    internal static vec4 RayVsSphere(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
        vec4 ToDo = RAY_MISS;

        //  Is Ray_Pos inside the Sphere?
        //      return new vec4(Rp, 0f);

        //  Project SpherePos onto Ray-Line:
        vec3 pSp = Rp + Rn*dot(Sp-Rp, Rn);

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

        return ToDo;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsBox(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,  Box-Position,  Box-Size  )
    //
    internal static vec4 RayVsBox(vec3 Rp, vec3 Rn, vec3 Rnr, vec3 Bp, vec3 Bs) {
        //  Distance to bounding planes from RayPos along RayNrm,
        //  for 3 Axes, Near & Far, 6 total.
        //
        //       +Y  |      |                                          +Y  -Z
        //           |      |                                           |  /
        //       ----+------+----  <- DistFarY                          | /
        //           |      |                                           |/
        //           |      |                            DistNearZ ->   +------ +X
        //           |      |                                          /
        //       ----+------+----  <- DistNearY                       /
        //           |      |                                        /
        //           |      |  +X                     DistFarZ ->  +Z
        //           ^
        //       DistNearX  ^
        //               DistFarX
        //
        vec3 DistNear = (Bp    - Rp) * Rnr;
        vec3 DistFar  = (Bp+Bs - Rp) * Rnr;

        //  Reorient (swap) relative to RayPos:
        if (DistNear.x > DistFar.x)  (DistNear.x, DistFar.x) = (DistFar.x, DistNear.x);
        if (DistNear.y > DistFar.y)  (DistNear.y, DistFar.y) = (DistFar.y, DistNear.y);
        if (DistNear.z > DistFar.z)  (DistNear.z, DistFar.z) = (DistFar.z, DistNear.z);

        //  Select PlaneHits in Quadrant/Octant of Box:
        float DistToBackFace  = min(DistFar.x , DistFar.y , DistFar.z );
        float DistToFrontFace = max(DistNear.x, DistNear.y, DistNear.z);

        //  Did we hit it?
        return (DistToFrontFace > DistToBackFace) ? RAY_MISS
             : (DistToBackFace  <             0f) ? new vec4(Rp + (Rn*DistToBackFace), DistToBackFace)   //  Box is behind RayPos.
             : (DistToFrontFace <=            0f) ? new vec4(Rp, 0f)                                     //  RayPos is inside Box.
                                                  : new vec4(Rp + (Rn*DistToFrontFace), DistToFrontFace);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  3D Grid Traversal
    //
    //      (vec4 Result, int Hitside) = RayVsVoxelChunk(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,  VoxelChunk-Position,  VoxelChunk-Size,)
    //
    //          HitSide:
    //                   X    Y              Z
    //              -    1    2    -    -    5    6    -
    //                  / \  / \            / \  / \
    //                 /   \/   \          /   \/   \
    //                /    /\    \        /    /\    \
    //               /    /  \    \      /    /  \    \
    //              0    1    2    3    4    5    6    7
    //             -x   -Y   +x   +Y   -z        +z
    //
    //  Todo:
    //      Result is in VoxelChunk's local space?  Should not be.
    //
    //      Travel/Step should occur at end of loop, otherwise first voxel will be skipped?
    //          "Ray_Travel" was called "Ray_LenNext"
    //
    //      Currently, input-param RayPos must start at bounds of VoxelChunk....?
    //
    internal static (vec4, int) RayVsVoxelChunk(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Vp, ivec3 Vs, uint[] Voxel) {
        #if DEBUG && false
            if (Vs.x * Vs.y * Vs.z != Voxel.Length) {
                //...
            }
        #endif

        //==========================================================================================================================================================
        //  Offset RayPos into VoxelChunk's local space:
        Rp = Rp - Vp;

        ivec3 Ray_StepDir = new ivec3(
            (Rn.x < 0f) ? -1 : 1,
            (Rn.y < 0f) ? -1 : 1,
            (Rn.z < 0f) ? -1 : 1
        );
        vec3 Ray_StepDist = abs(Rnr); //abs(1f / Rn);

        ivec3 Ray_Coord = new ivec3(
            (Rn.x < 0f) ? (int)floor(Rp.x + EPSILON) : (int)floor(Rp.x - EPSILON),
            (Rn.y < 0f) ? (int)floor(Rp.y + EPSILON) : (int)floor(Rp.y - EPSILON),
            (Rn.z < 0f) ? (int)floor(Rp.z + EPSILON) : (int)floor(Rp.z - EPSILON)
        );
        vec3 Ray_Travel = new vec3(
            (Rn.x < 0f)  ?  (Rp.x - Ray_Coord.x) * Ray_StepDist.x  :  (Ray_Coord.x+1 - Rp.x) * Ray_StepDist.x,
            (Rn.y < 0f)  ?  (Rp.y - Ray_Coord.y) * Ray_StepDist.y  :  (Ray_Coord.y+1 - Rp.y) * Ray_StepDist.y,
            (Rn.z < 0f)  ?  (Rp.z - Ray_Coord.z) * Ray_StepDist.z  :  (Ray_Coord.z+1 - Rp.z) * Ray_StepDist.z
        );

        //======================================================================================================================================================
        float HitDist = 0f;
        int   HitSide = -1;

        while (true) {
            //  Which Axis has a closer GridStep along Ray?
            if      (Ray_Travel.x < Ray_Travel.y && Ray_Travel.x < Ray_Travel.z) {HitDist = Ray_Travel.x;  Ray_Travel.x += Ray_StepDist.x;  Ray_Coord.x += Ray_StepDir.x;  HitSide = 1-Ray_StepDir.x;}
            else if (Ray_Travel.y < Ray_Travel.x && Ray_Travel.y < Ray_Travel.z) {HitDist = Ray_Travel.y;  Ray_Travel.y += Ray_StepDist.y;  Ray_Coord.y += Ray_StepDir.y;  HitSide = 2-Ray_StepDir.y;}
            else                                                                 {HitDist = Ray_Travel.z;  Ray_Travel.z += Ray_StepDist.z;  Ray_Coord.z += Ray_StepDir.z;  HitSide = 5-Ray_StepDir.z;}

            //  Are we still inside the bounds of the VoxelChunk?
            bool dewit =
                (Ray_Coord.x >= 0 && Ray_Coord.x <= Vs.x) &&
                (Ray_Coord.y >= 0 && Ray_Coord.y <= Vs.y) &&
                (Ray_Coord.z >= 0 && Ray_Coord.z <= Vs.z);

            if (dewit) {
                int iVox = Ray_Coord.x
                         + Ray_Coord.y * Vs.y
                         + Ray_Coord.z * Vs.z;

                if ((Voxel[iVox] & 0xFF000000) != 0) //  if (Alpha != 0)    Assuming: AaBbGgRr  (Alpha,Blue,Green,Red)
                    return (new vec4(Rp + (Rn*HitDist), HitDist), HitSide);

            } else {
                return (RAY_MISS, -1); //  We hit/exited the bounds of the VoxelChunk.
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
