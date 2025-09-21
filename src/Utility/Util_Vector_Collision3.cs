using System;
using System.Runtime.CompilerServices;

using static Utility.FLT;
using static Utility.VEC;

namespace Utility;
internal static class VEC_Collision3 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //                @    P > 0
    //            |
    //      ------+---@--  P = 0
    //
    //                @    P < 0
    //
    //      WhichSideOfPlane(  Point,  Plane-Position,  Plane-Normal  )
    //
    internal static float WhichSideOfPlane(vec3 Pnt, vec3 Pp, vec3 Pn) => dot(Pn, Pnt-Pp);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  PointVsSphere(  Point,  Sphere-Position,  Sphere-Radius  )
    //
    internal static bool PointVsSphere(vec3 P, vec3 Sp, float Sr) => dot(Sp-P) <= (Sr*Sr);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  PointVsBox(  Point,  Box-Position,  Box-Size  )
    //
    //      Axis-Aligned-Box
    //
    //      Inverted box == false
    //          Impossible for a Point to be both:
    //              > Box_BoundsMin
    //                  AND
    //              < Box_BoundsMax
    //
    //
    //       +Y            BoxSize
    //          *--------@
    //          |        |
    //          |        |
    //          |        |
    //          @--------*
    //    BoxPos           +X
    //
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool PointVsBox(vec3 P, vec3 Bp, vec3 Bs) => (
           P >= Bp
        && P <= Bp+Bs
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  PointVsCylinder(  Point,  Cylinder-Position,  Cylinder-Radius,  Cylinder-Height  )
    //
    internal static bool PointVsCylinder(vec3 P, vec3 Cp, float Cr, float Ch) => (
           P.y >= Cp.y                  //  Is Point in same vertical space as Cylinder?
        && P.y <= Cp.y+Ch
        && dot(P.xz - Cp.xz) <= (Cr*Cr) //  Is Point inside of Cylinder-Radius?
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  All  RayVsSurface()  functions return:  vec4( HitPosX, HitPosY, HitPosZ, HitDistance )      **  Should these only return HitDistance ???
    //                                                                                              **  HitPos isn't always needed, and is easy to calculate:
    //                         Surface      Ray                                                             RayPos + (RayNrm * Distance)
    //      Distance < 0.0      |-->        -->  Surface is Behind Ray.
    //
    //
    //      Distance = 0.0      |-->         |   Ray is parallel to surface plane.                  **  'Distance = 0' should be 'RayPos is inside Volume',
    //                                       V                                                          'parallel to surface' should be 'RAY_MISS'.
    //
    //      Distance > 0.0      |-->        <--  Surface is InFront of Ray.
    //
    //
    //  If surface has bounds  and  Ray-Line does not intersect, it will return:  RAY_MISS
    //
    //==========================================================================================================================================================
    internal static readonly float RAY_MISS = FLOAT_NEG_INF;

    internal static readonly vec4 RAY_MISS___ = new vec4(FLOAT_NEG_INF, FLOAT_NEG_INF, FLOAT_NEG_INF, FLOAT_NEG_INF);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Surface
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned Plane.
    //
    //      RayVsPlaneX(  Ray-Position,  Ray-Normal,    Plane-PositionX  )  Plane spans YZ.
    //      RayVsPlaneY(  Ray-Position,  Ray-Normal,    Plane-PositionY  )  Plane spans XZ.
    //      RayVsPlaneZ(  Ray-Position,  Ray-Normal,    Plane-PositionZ  )  Plane spans XY.
    //
    internal static float RayVsPlaneX(vec3 Rp, vec3 Rn, float Pp_x) => (Pp_x - Rp.x) / Rn.x;
    internal static float RayVsPlaneY(vec3 Rp, vec3 Rn, float Pp_y) => (Pp_y - Rp.y) / Rn.y;
    internal static float RayVsPlaneZ(vec3 Rp, vec3 Rn, float Pp_z) => (Pp_z - Rp.z) / Rn.z;

    //==========================================================================================================================================================
    //
    //      RayVsPlane(  Ray-Position,  Ray-Normal,    Plane-Position,  Plane-Normal  )
    //
    internal static float RayVsPlane(vec3 Rp, vec3 Rn, vec3 Pp, vec3 Pn) => dot(Pn, Rp-Pp) / -dot(Rn, Pn);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Axis-Aligned; Quad spans YZ.
    //
    //      RayVsQuadX(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Quad-Position,  Quad-Size  )
    //
    internal static vec4 RayVsQuadX(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
        float Distance = (Qp.x - Rp.x) * Rnr.x;
        vec3 Hp = Rp + (Rn*Distance); //  HitPosition
        return (Hp.z >= Qp.z && Hp.z < Qp.z+Qs.x
            &&  Hp.y >= Qp.y && Hp.y < Qp.y+Qs.y) ? new vec4(Hp, Distance) : RAY_MISS___;
    }

    //==========================================================================================================================================================
    //
    //  Axis-Aligned; Quad spans XZ.
    //
    //      RayVsQuadY(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Quad-Position,  Quad-Size  )
    //
    internal static vec4 RayVsQuadY(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
        float Distance = (Qp.y - Rp.y) * Rnr.y;
        vec3 Hp = Rp + (Rn*Distance); //  HitPosition
        return (Hp.x >= Qp.x && Hp.x < Qp.x+Qs.x
            &&  Hp.z >= Qp.z && Hp.z < Qp.z+Qs.y) ? new vec4(Hp, Distance) : RAY_MISS___;
    }

    //==========================================================================================================================================================
    //
    //  Axis-Aligned; Quad spans XY.
    //
    //      RayVsQuadZ(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,    Quad-Position,  Quad-Size  )
    //
    internal static vec4 RayVsQuadZ(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Qp, vec2 Qs) {
        float Distance = (Qp.z - Rp.z) * Rnr.z;
        vec3 Hp = Rp + (Rn*Distance); //  HitPosition
        return (Hp.x >= Qp.x && Hp.x < Qp.x+Qs.x
            &&  Hp.y >= Qp.y && Hp.y < Qp.y+Qs.y) ? new vec4(Hp, Distance) : RAY_MISS___;
    }

    //==========================================================================================================================================================
    //
    //      RayVsQuad(  Ray-Position,  Ray-Normal,    Quad-Position,  Quad-Normal,  Quad-???  )
    //
    internal static vec4 RayVsQuad(vec3 Rp, vec3 Rn,    vec3 Qp, vec3 Qn, vec3 Qnt) {
        float WhichSide =  dot(Qn, Rp-Qp);
        float Dot_RnPn  = -dot(Rn, Qn);

        float Distance  = WhichSide / Dot_RnPn;

        vec3 HitPos = Rp + (Rn*Distance);

        vec4 ToDo = RAY_MISS___;
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
    //
    //      RayVsTriangle(  Ray-Position,  Ray-Normal,    Triangle-PointA,  Triangle-PointB,  Triangle-PointC,    BackFaceTest  )
    //
    internal static float RayVsTriangle(vec3 Rp, vec3 Rn,   vec3 Ta, vec3 Tb, vec3 Tc,   bool BackFaceTest = true) {
        vec3 dAB = Tb - Ta;
        vec3 dAC = Tc - Ta;

        vec3 H = cross(Rn, dAC);
        float Determinant = dot(dAB, H);

        //  Is Ray pointing in the same direction as SurfaceNormal?
        if (Determinant < 0f && !BackFaceTest)
            return RAY_MISS;

        //  Is Ray coplanar with Triangle Surface?
        if (Determinant == 0f)
            return RAY_MISS;

        vec3 dAP = Rp - Ta;
        float DtrRcp = 1f/Determinant;
        float U = dot(dAP, H) * DtrRcp;

        //  Will intersection be inside of triangle?
        if (U < 0f || U > 1f)
            return RAY_MISS;

        vec3 Q = cross(dAP, dAB);
        float V = dot(Rn, Q) * DtrRcp;

        //  Will intersection be inside of triangle?
        if (V < 0f || U+V > 1f)
            return RAY_MISS;

        return dot(dAC, Q) * DtrRcp;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                                    Ray  VS  Volume
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Geometric solution.
    //
    //      RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    //
    internal static float RayVsSphere(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
        vec3 dRS = Sp - Rp;

        float SrSr = Sr * Sr;

        //  Distance from RayPos to ProjectedPoint:
        float sP = dot(dRS, Rn);

        //  Distance from RayPos to SpherePos, squared:
        float sS = dot(dRS, dRS);

        //  Compare:
        float dS = sS - sP*sP;

        //  Is ProjectedPoint inside Sphere?
        if (dS > SrSr)
            return RAY_MISS;

        dS = sqrt(SrSr - dS);

        return sP - dS;

        //float s0 = sP - dS; vec3 HitPos0 = Rp + (Rn * s0);
        //float s1 = sP + dS; vec3 HitPos1 = Rp + (Rn * s1);
        //return new vec4(HitPos0, s0);
    }

    //==========================================================================================================================================================
    //
    //  Analytic solution.
    //
    //      RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    //
    internal static vec4 RayVsSphere_(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
        vec3 dSR = Rp - Sp;

        float a =      dot( Rn, Rn );
        float b = 2f * dot( Rn, dSR);
        float c =      dot(dSR, dSR) - Sr*Sr;

        float Qn = sqrt(b*b - 4f*a*c);
        float Qd = 2f * a;

        float s0 = (-b - Qn) / Qd;
        float s1 = (-b + Qn) / Qd;

        vec3 HitPos0 = Rp + (Rn * s0);
        vec3 HitPos1 = Rp + (Rn * s1);

        return new vec4(HitPos0, s0);
    }


    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      RayVsBox(  Ray-Position,  Ray-Normal,  Box-Position,  Box-Size  )
    //
    internal static float RayVsBox(vec3 Rp, vec3 Rn, vec3 Bp, vec3 Bs) {
        //  Distance to bounding-planes from RayPos along RayNrm,
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
        vec3 dNear = (Bp    - Rp) / Rn; //  Note: DivByZero == -∞|∞
        vec3 dFar  = (Bp+Bs - Rp) / Rn; //        is desired in cases where ray is coplanar with an axis-plane.

        //  Reorient (swap) relative to RayPos:
        (dNear.x, dFar.x) = (dNear.x > dFar.x) ? (dFar.x, dNear.x) : (dNear.x, dFar.x);
        (dNear.y, dFar.y) = (dNear.y > dFar.y) ? (dFar.y, dNear.y) : (dNear.y, dFar.y);
        (dNear.z, dFar.z) = (dNear.z > dFar.z) ? (dFar.z, dNear.z) : (dNear.z, dFar.z);

        //  Select PlaneHits in Quadrant/Octant of Box:
        float DistToFrontFace = max(dNear.x, dNear.y, dNear.z);
        float DistToBackFace  = min(dFar.x , dFar.y , dFar.z );

        //  Did we hit it?
        return (DistToFrontFace > DistToBackFace) ? RAY_MISS
             : (DistToBackFace  <             0f) ? DistToBackFace  //  Box is behind RayPos.
             : (DistToFrontFace <=            0f) ? 0f              //  RayPos is inside Box.
                                                  : DistToFrontFace;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  3D Grid Traversal
    //
    //      (vec4 Result, int HitSide) = RayVsVoxelChunk(  Ray-Position,  Ray-Normal,  Ray-NormalReciprocal,  VoxelChunk-Position,  VoxelChunk-Size,)
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
    //          "Ray_Travel" was called "Ray_LenNext"...
    //
    //      Currently, input-param RayPos must start at/within bounds of VoxelChunk....?
    //
    internal static (vec4, int) RayVsVoxelChunk(vec3 Rp, vec3 Rn, vec3 Rnr,    vec3 Vp, ivec3 Vs, uint[] Voxel) {
        #if DEBUG || true
        {
            int VolumeCompare = (Vs.x * Vs.y * Vs.z) - Voxel.Length;
            if      (VolumeCompare < 0) throw new ArgumentException("Derp?  Voxel-Volume is less than Voxel.Length.");
            else if (VolumeCompare > 0) throw new ArgumentException("Derp?  Voxel-Volume is greater than Voxel.Length.");
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
            bool BoundsCheck = (
                Ray_Coord.x >= 0 && Ray_Coord.x <= Vs.x &&
                Ray_Coord.y >= 0 && Ray_Coord.y <= Vs.y &&
                Ray_Coord.z >= 0 && Ray_Coord.z <= Vs.z
            );

            if (BoundsCheck) {
                int iVox = Ray_Coord.x
                         + Ray_Coord.y * Vs.y
                         + Ray_Coord.z * Vs.z;

                if ((Voxel[iVox] & 0xFF000000) != 0) //  if (Alpha != 0)    Assuming: AaBbGgRr  (Alpha,Blue,Green,Red)
                    return (
                        new vec4(Rp + (Rn*HitDist), HitDist),
                        HitSide
                    );

            } else {
                //  We hit/exited the bounds of the VoxelChunk:
                return (
                    RAY_MISS___,
                    -1
                );
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
