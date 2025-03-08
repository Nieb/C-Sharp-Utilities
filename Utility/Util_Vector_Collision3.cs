using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static partial class VEC {
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
        //  Is this even something practical or useful...?
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
    //                                                                    Ray  VS  Volume
    //==========================================================================================================================================================
    ///
    ///     RayVsSphere(  Ray-Position,  Ray-Normal,    Sphere-Position,  Sphere-Radius  )
    ///
    internal static vec4 RayVsSphere(vec3 Rp, vec3 Rn, vec3 Sp, float Sr) {
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
    internal static vec4 RayVsBox(vec3 Rp, vec3 Rn, vec3 Rnr, vec3 Bp, vec3 Bs) {
        //
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
    ///
    /// 3D Grid Traversal
    ///
    ///     Ray vs Voxel Tile/Chunk
    ///
    internal static vec4 RayVsVoxel(vec3 Ray_Pos, vec3 Ray_Nrm, vec3 Ray_NrmRecip,    vec3 Tile_Pos, vec3 Tile_Size, int[] Voxel) {
        //==========================================================================================================================================================
        #if DEBUG && false
            if (Tile_Size.x * Tile_Size.y * Tile_Size.z != Voxel.Length) {
                //...
            }
        #endif

        //==========================================================================================================================================================
        //  Offset RayPos into Tile's local space:
        Ray_Pos = Ray_Pos - Tile_Pos;

        ivec3 Ray_StepDir = new ivec3(
            (Ray_Nrm.x < 0f) ? -1 : 1,
            (Ray_Nrm.y < 0f) ? -1 : 1,
            (Ray_Nrm.z < 0f) ? -1 : 1
        );
        vec3 Ray_StepDist = abs(Ray_NrmRecip); //  abs(1f / Ray_Nrm);

        ivec3 Ray_Coord = new ivec3(
            (Ray_Nrm.x < 0f) ? (int)floor(Ray_Pos.x + EPSILON) : (int)floor(Ray_Pos.x - EPSILON),
            (Ray_Nrm.y < 0f) ? (int)floor(Ray_Pos.y + EPSILON) : (int)floor(Ray_Pos.y - EPSILON),
            (Ray_Nrm.z < 0f) ? (int)floor(Ray_Pos.z + EPSILON) : (int)floor(Ray_Pos.z - EPSILON)
        );
        vec3 Ray_LenNext = new vec3(
            (Ray_Nrm.x < 0f) ? (Ray_Pos.x     - Ray_Coord.x) * Ray_StepDist.x
                             : (Ray_Coord.x+1 - Ray_Pos.x  ) * Ray_StepDist.x,
            (Ray_Nrm.y < 0f) ? (Ray_Pos.y     - Ray_Coord.y) * Ray_StepDist.y
                             : (Ray_Coord.y+1 - Ray_Pos.y  ) * Ray_StepDist.y,
            (Ray_Nrm.z < 0f) ? (Ray_Pos.z     - Ray_Coord.z) * Ray_StepDist.z
                             : (Ray_Coord.z+1 - Ray_Pos.z  ) * Ray_StepDist.z
        );

        //PRINT($"    Ray_Pos: {Ray_Pos}");
        //PRINT($"     Ray_LenNext: {Ray_LenNext}");
        //PRINT($"  Ray_Coord Start: {Ray_Coord}");

        //======================================================================================================================================================
        const int VOX_Empty = -1;
        vec4  Result;
        float HitDist = 0f;
        int   HitSide = -1;
        //          -X+  -Y+            -Z+
        //      -    1    2    -    -    5    6    -    -    9   10    -
        //          / \  / \            / \  / \            / \  / \
        //         /   \/   \          /   \/   \          /   \/   \
        //        /    /\    \        /    /\    \        /    /\    \
        //       /    /  \    \      /    /  \    \      /    /  \    \
        //      0    1    2    3    4    5    6    7    8    9   10   11
        //     -x   -Y   +x   +Y   -z        +z
        //
        while (true) {
            //  Which axis has a closer point on Ray?
            if      (Ray_LenNext.x < Ray_LenNext.y && Ray_LenNext.x < Ray_LenNext.z) { HitDist = Ray_LenNext.x;  HitSide = 1-Ray_StepDir.x;  Ray_Coord.x += Ray_StepDir.x;  Ray_LenNext.x += Ray_StepDist.x; }
            else if (Ray_LenNext.y < Ray_LenNext.x && Ray_LenNext.y < Ray_LenNext.z) { HitDist = Ray_LenNext.y;  HitSide = 2-Ray_StepDir.y;  Ray_Coord.y += Ray_StepDir.y;  Ray_LenNext.y += Ray_StepDist.y; }
            else                                                                     { HitDist = Ray_LenNext.z;  HitSide = 5-Ray_StepDir.z;  Ray_Coord.z += Ray_StepDir.z;  Ray_LenNext.z += Ray_StepDist.z; }

            //  Are we still inside the bounds of the Voxel Tile?
            if ((Ray_Coord.x >= 0 && Ray_Coord.x <= Tile_Size.x) && (Ray_Coord.y >= 0 && Ray_Coord.y <= Tile_Size.y) && (Ray_Coord.z >= 0 && Ray_Coord.z <= Tile_Size.z)) {
                //PRINT($"        [ {Ray_Coord.x}, {Ray_Coord.y}, {Ray_Coord.z} ]");
                if (Voxel[Ray_Coord.x + Ray_Coord.y*(int)round(Tile_Size.y) + Ray_Coord.z*(int)round(Tile_Size.z)] != VOX_Empty) {
                    Result = new vec4(Ray_Pos + (Ray_Nrm*HitDist), HitDist);

                    #if DEBUG && false
                        if      (HitSide = 0) DrawCircleX(Result, 0.0625, 12, RGBA(255, 68, 68,255));
                        else if (HitSide = 1) DrawCircleY(Result, 0.0625, 12, RGBA(  0,255,  0,255));
                        else if (HitSide = 2) DrawCircleX(Result, 0.0625, 12, RGBA(255, 68, 68,255));
                        else if (HitSide = 3) DrawCircleY(Result, 0.0625, 12, RGBA(  0,255,  0,255));
                        else if (HitSide = 4) DrawCircleZ(Result, 0.0625, 12, RGBA(  0,112,255,255));
                        else if (HitSide = 6) DrawCircleZ(Result, 0.0625, 12, RGBA(  0,112,255,255));
                    #endif

                    break;
                }

            } else { //  We hit the bounds of the Voxel Tile.
                #if DEBUG && false
                    Result = new vec4(Ray_Pos + (Ray_Nrm*HitDist), HitDist);

                    if      (HitSide = 0) DrawCircleX(Result, 0.0625, 12, RGBA(192, 52, 52,255));
                    else if (HitSide = 1) DrawCircleY(Result, 0.0625, 12, RGBA(  0,192,  0,255));
                    else if (HitSide = 2) DrawCircleX(Result, 0.0625, 12, RGBA(192, 52, 52,255));
                    else if (HitSide = 3) DrawCircleY(Result, 0.0625, 12, RGBA(  0,192,  0,255));
                    else if (HitSide = 4) DrawCircleZ(Result, 0.0625, 12, RGBA(  0, 96,192,255));
                    else if (HitSide = 6) DrawCircleZ(Result, 0.0625, 12, RGBA(  0, 96,192,255));

                    break;
                #else
                    Result = RAY_MISS;

                    break;
                #endif
            }
        }

        //==========================================================================================================================================================
        #if DEBUG && false
            PRINT($"    RayStep End: {Ray_Coord}");
            PRINT($"         Result: {Result}");

            if (GetRawMouseWheelDelta() < 0) {
                /*
                if      (HitSide = 0 && Ray_Coord.x > 0       ) Voxel[ Ray_Coord.x-1, Ray_Coord.y  , Ray_Coord.z   ] = ABGR(Random(64,192), Random(64,192), Random(64,192), 255); // -X
                else if (HitSide = 1 && Ray_Coord.y > 0       ) Voxel[ Ray_Coord.x  , Ray_Coord.y-1, Ray_Coord.z   ] = ABGR(Random(64,192), Random(64,192), Random(64,192), 255); // -Y
                else if (HitSide = 2 && Ray_Coord.x < TileSize) Voxel[ Ray_Coord.x+1, Ray_Coord.y  , Ray_Coord.z   ] = ABGR(Random(64,192), Random(64,192), Random(64,192), 255); // +X
                else if (HitSide = 3 && Ray_Coord.y < TileSize) Voxel[ Ray_Coord.x  , Ray_Coord.y+1, Ray_Coord.z   ] = ABGR(Random(64,192), Random(64,192), Random(64,192), 255); // +Y
                else if (HitSide = 4 && Ray_Coord.z > 0       ) Voxel[ Ray_Coord.x  , Ray_Coord.y  , Ray_Coord.z-1 ] = ABGR(Random(64,192), Random(64,192), Random(64,192), 255); // -Z
                else if (HitSide = 6 && Ray_Coord.z < TileSize) Voxel[ Ray_Coord.x  , Ray_Coord.y  , Ray_Coord.z+1 ] = ABGR(Random(64,192), Random(64,192), Random(64,192), 255); // +Z
                */
                if      (HitSide == 0 && Ray_Coord.x > 0       ) Voxel[ Ray_Coord.x-1, Ray_Coord.y  , Ray_Coord.z   ] = VOX_Grey; // -X
                else if (HitSide == 1 && Ray_Coord.y > 0       ) Voxel[ Ray_Coord.x  , Ray_Coord.y-1, Ray_Coord.z   ] = VOX_Grey; // -Y
                else if (HitSide == 2 && Ray_Coord.x < TileSize) Voxel[ Ray_Coord.x+1, Ray_Coord.y  , Ray_Coord.z   ] = VOX_Grey; // +X
                else if (HitSide == 3 && Ray_Coord.y < TileSize) Voxel[ Ray_Coord.x  , Ray_Coord.y+1, Ray_Coord.z   ] = VOX_Grey; // +Y
                else if (HitSide == 4 && Ray_Coord.z > 0       ) Voxel[ Ray_Coord.x  , Ray_Coord.y  , Ray_Coord.z-1 ] = VOX_Grey; // -Z
                else if (HitSide == 6 && Ray_Coord.z < TileSize) Voxel[ Ray_Coord.x  , Ray_Coord.y  , Ray_Coord.z+1 ] = VOX_Grey; // +Z

                UpdateTileMesh();

            } else if (GetRawMouseWheelDelta() > 0) {
                if (Ray_Coord.x >= 0 && Ray_Coord.x <= TileSize && Ray_Coord.y >= 0 && Ray_Coord.y <= TileSize && Ray_Coord.z >= 0 && Ray_Coord.z <= TileSize) {
                    Voxel[ Ray_Coord.x, Ray_Coord.y, Ray_Coord.z ] = VOX_Empty;
                    UpdateTileMesh();
                }
            }
        #endif

        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
