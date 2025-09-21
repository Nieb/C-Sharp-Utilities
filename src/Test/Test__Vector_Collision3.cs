
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Collision3() {
        PRINT("\n[Utility.VEC -- Collision3]");
        //PRINT($"{}");

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("WhichSideOfPlane()", true
            && WhichSideOfPlane((4f,5f,6f), (1f,2f,3f), (SQRT3_RCP,SQRT3_RCP,SQRT3_RCP)) >  0f
            && WhichSideOfPlane((6f,3f,0f), (3f,3f,3f), (SQRT3_RCP,SQRT3_RCP,SQRT3_RCP)) == 0f
            && WhichSideOfPlane((1f,2f,3f), (4f,5f,6f), (SQRT3_RCP,SQRT3_RCP,SQRT3_RCP)) <  0f
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("PointVsSphere()", true
            && PointVsSphere((1f,1f,1f), (1f,1f,1f), 1f) == true
            && PointVsSphere((1f,1f,2f), (1f,1f,1f), 1f) == true
            && PointVsSphere((1f,2f,1f), (1f,1f,1f), 1f) == true
            && PointVsSphere((2f,1f,1f), (1f,1f,1f), 1f) == true

            && PointVsSphere((-1f,-1f,-1f), (-1f,-1f,-1f), 1f) == true
            && PointVsSphere((-1f,-1f,-2f), (-1f,-1f,-1f), 1f) == true
            && PointVsSphere((-1f,-2f,-1f), (-1f,-1f,-1f), 1f) == true
            && PointVsSphere((-2f,-1f,-1f), (-1f,-1f,-1f), 1f) == true

            && PointVsSphere((1.70f,1f,1.70f), (1f,1f,1f), 1f) == true
            && PointVsSphere((1.71f,1f,1.71f), (1f,1f,1f), 1f) == false

            && PointVsSphere((-1.70f,-1f,-1.70f), (-1f,-1f,-1f), 1f) == true
            && PointVsSphere((-1.71f,-1f,-1.71f), (-1f,-1f,-1f), 1f) == false

            && PointVsSphere((3.57f,3.57f,3.57f), (3f,3f,3f), 1f) == true
            && PointVsSphere((3.58f,3.58f,3.58f), (3f,3f,3f), 1f) == false

            && PointVsSphere((-3.57f,-3.57f,-3.57f), (-3f,-3f,-3f), 1f) == true
            && PointVsSphere((-3.58f,-3.58f,-3.58f), (-3f,-3f,-3f), 1f) == false
        );

        //======================================================================================================================================================
        RESULT("PointVsBox()", true
            && PointVsBox((1f,1f,1f), (1f,1f,1f), (1f,1f,1f)) == true
            && PointVsBox((2f,2f,2f), (1f,1f,1f), (1f,1f,1f)) == true

            && PointVsBox((2f,1f,1f), (1f,1f,1f), (1f,1f,1f)) == true
            && PointVsBox((1f,2f,1f), (1f,1f,1f), (1f,1f,1f)) == true
            && PointVsBox((1f,1f,2f), (1f,1f,1f), (1f,1f,1f)) == true
            && PointVsBox((2f,2f,1f), (1f,1f,1f), (1f,1f,1f)) == true
            && PointVsBox((1f,2f,2f), (1f,1f,1f), (1f,1f,1f)) == true
            && PointVsBox((2f,1f,2f), (1f,1f,1f), (1f,1f,1f)) == true

            && PointVsBox((-1f,-1f,-1f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-2f,-2f,-2f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            && PointVsBox((-2f,-1f,-1f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1f,-2f,-1f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1f,-1f,-2f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-2f,-2f,-1f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1f,-2f,-2f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-2f,-1f,-2f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            && PointVsBox((0.9999999f,0.9999999f,0.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((1.9999999f,1.9999999f,1.9999999f), (1f,1f,1f), (1f,1f,1f)) == true

            && PointVsBox((1.9999999f,0.9999999f,0.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((0.9999999f,1.9999999f,0.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((0.9999999f,0.9999999f,1.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((1.9999999f,1.9999999f,0.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((0.9999999f,1.9999999f,1.9999999f), (1f,1f,1f), (1f,1f,1f)) == false
            && PointVsBox((1.9999999f,0.9999999f,1.9999999f), (1f,1f,1f), (1f,1f,1f)) == false

            && PointVsBox((-0.9999999f,-0.9999999f,-0.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-1.9999999f,-1.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            && PointVsBox((-1.9999999f,-0.9999999f,-0.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-0.9999999f,-1.9999999f,-0.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-0.9999999f,-0.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-1.9999999f,-1.9999999f,-0.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-0.9999999f,-1.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false
            && PointVsBox((-1.9999999f,-0.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == false

            && PointVsBox((-1.0000001f,-1.0000001f,-1.0000001f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.9999999f,-1.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            && PointVsBox((-1.9999999f,-1.0000001f,-1.0000001f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.0000001f,-1.9999999f,-1.0000001f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.0000001f,-1.0000001f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.9999999f,-1.9999999f,-1.0000001f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.0000001f,-1.9999999f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true
            && PointVsBox((-1.9999999f,-1.0000001f,-1.9999999f), (-2f,-2f,-2f), (1f,1f,1f)) == true

            //  Inverted box == false, always.
            //      Impossible for a Point to be both:
            //          > Box_MinBounds
            //              AND
            //          < Box_MaxBounds
            && PointVsBox((2f,2f,2f), (3f,3f,3f), (-2f,-2f,-2f)) == false
            && PointVsBox((4f,4f,4f), (3f,3f,3f), (-2f,-2f,-2f)) == false
        );

        //======================================================================================================================================================
        RESULT("PointVsCylinder()", true
            && PointVsCylinder(      (1f, 1f, 1f),    (1f ,0f ,1f), 1f, 2f) == true
            && PointVsCylinder(      (1f, 2f, 1f),    (1f ,0f ,1f), 1f, 2f) == true
            && PointVsCylinder(      (1f, 0f, 1f),    (1f ,0f ,1f), 1f, 2f) == true

            && PointVsCylinder((1.70f, 0f, 1.70f),    (1f, 0f, 1f), 1f, 2f) == true
            && PointVsCylinder((1.71f, 0f, 1.71f),    (1f, 0f, 1f), 1f, 2f) == false

            && PointVsCylinder((0.30f, 0f, 0.30f),    (1f, 0f, 1f), 1f, 2f) == true
            && PointVsCylinder((0.29f, 0f, 0.29f),    (1f, 0f, 1f), 1f, 2f) == false
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("RayVsPlaneX()", true
            && RayVsPlaneX((2f,2f,2f), ( 1f, 0f, 0f), 1f) == -1f        //(1f,2f,2f,-1f)
            && RayVsPlaneX((2f,2f,2f), (-1f, 0f, 0f), 1f) ==  1f        //(1f,2f,2f, 1f)
            && RayVsPlaneX((2f,2f,2f), ( 0f, 1f, 0f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneX((2f,2f,2f), ( 0f,-1f, 0f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneX((2f,2f,2f), ( 0f, 0f, 1f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneX((2f,2f,2f), ( 0f, 0f,-1f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
        );

        RESULT("RayVsPlaneY()", true
            && RayVsPlaneY((2f,2f,2f), ( 1f, 0f, 0f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneY((2f,2f,2f), (-1f, 0f, 0f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneY((2f,2f,2f), ( 0f, 1f, 0f), 1f) == -1f        //(2f,1f,2f,-1f)
            && RayVsPlaneY((2f,2f,2f), ( 0f,-1f, 0f), 1f) ==  1f        //(2f,1f,2f, 1f)
            && RayVsPlaneY((2f,2f,2f), ( 0f, 0f, 1f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneY((2f,2f,2f), ( 0f, 0f,-1f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
        );

        RESULT("RayVsPlaneZ()", true
            && RayVsPlaneZ((2f,2f,2f), ( 1f, 0f, 0f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneZ((2f,2f,2f), (-1f, 0f, 0f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneZ((2f,2f,2f), ( 0f, 1f, 0f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneZ((2f,2f,2f), ( 0f,-1f, 0f), 1f) == RAY_MISS   //(2f,2f,2f, 0f)
            && RayVsPlaneZ((2f,2f,2f), ( 0f, 0f, 1f), 1f) == -1f        //(2f,2f,1f,-1f)
            && RayVsPlaneZ((2f,2f,2f), ( 0f, 0f,-1f), 1f) ==  1f        //(2f,2f,1f, 1f)
        );

        //======================================================================================================================================================
        //RESULT("RayVsPlane()", true
        //    && RayVsPlane(vec3 Rp, vec3 Rn, vec3 Pp, vec3 Pn)
        //);

        //######################################################################################################################################################
        //######################################################################################################################################################
        //RESULT("RayVsTriangle()", true
        //    && RayVsTriangle(vec3 Rp, vec3 Rn, vec3 Ta, vec3 Tb, vec3 Tc, bool BackFaceTest)
        //);

        //======================================================================================================================================================
        RESULT("RayVsBox()", true
            && RayVsBox((1.5f, 1.5f, 5.0f),(        0f,        0f,       -1f),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(3f)              //(1.5f, 1.5f, 2.0f, 3f)

            && RayVsBox((0.0f, 0.0f, 2.5f),( SQRT3_RCP, SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)           //(1.0f, 1.0f, 1.5f, SQRT3)
            && RayVsBox((0.0f, 0.0f, 3.0f),( SQRT3_RCP, SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)           //(1.0f, 1.0f, 2.0f, SQRT3)
            && RayVsBox((0.0f, 0.0f, 3.5f),( SQRT3_RCP, SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3 * 1.5f)    //(1.5f, 1.5f, 2.0f, SQRT3 * 1.5f)

            && RayVsBox((0.0f, 0.0f,-0.5f),( SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3 * 1.5f)    //(1.5f, 1.5f, 1.0f, SQRT3 * 1.5f)
            && RayVsBox((0.0f, 0.0f, 0.0f),( SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)           //(1.0f, 1.0f, 1.0f, SQRT3)
            && RayVsBox((0.0f, 0.0f, 0.5f),( SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)           //(1.0f, 1.0f, 1.5f, SQRT3)

            && RayVsBox((2.5f, 2.5f, 3.0f),(-SQRT3_RCP,-SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)           //(1.5f, 1.5f, 2.0f, SQRT3)
            && RayVsBox((3.0f, 3.0f, 3.0f),(-SQRT3_RCP,-SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3)           //(2.0f, 2.0f, 2.0f, SQRT3)
            && RayVsBox((3.5f, 3.5f, 3.0f),(-SQRT3_RCP,-SQRT3_RCP,-SQRT3_RCP),  (1f,1f,1f),(1f,1f,1f)).IsApproximately(SQRT3 * 1.5f)    //(2.0f, 2.0f, 1.5f, SQRT3 * 1.5f)
        );
        /*
        UtilityTest.Program.PRINT(
            $"""

            RAYvsBOX    Rp: {Rp:0.000}    Rn: {Rn:0.000}    Rnr: {Rnr:0.000}    Bp: {Bp:0.000}    Bs: {Bs:0.000}

                                      Dist To Near: {DistNear:0.000}
                                       Dist To Far: {DistFar:0.000}

                                 Dist To FrontFace: {DistToFrontFace:0.000}
                                  Dist To BackFace: {DistToBackFace:0.000}

                (DistToFrontFace > DistToBackFace): {(DistToFrontFace > DistToBackFace)}
                (DistToBackFace  <             0f): {(DistToBackFace  <             0f)}
                (DistToFrontFace <=            0f): {(DistToFrontFace <=            0f)}

                                            RESULT: {((DistToFrontFace > DistToBackFace) ? RAY_MISS
                                                    : (DistToBackFace  <             0f) ? new vec4(Rp + (Rn*DistToBackFace), DistToBackFace)
                                                    : (DistToFrontFace <=            0f) ? new vec4(Rp, 0f)
                                                                                         : new vec4(Rp + (Rn*DistToFrontFace), DistToFrontFace))}
            """
        );
        */

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("RayVsSphere()", true
            && RayVsSphere((-1,-1,-1), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 1, 1, 1), 1) != RAY_MISS
            && RayVsSphere((-1,-1,-1), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 1, 1, 1), 1).IsApproximately(SQRT3 + SQRT3 - 1f)  //((1f-SQRT3_RCP, 1f-SQRT3_RCP, 1f-SQRT3_RCP, SQRT3+SQRT3-1f))

            && RayVsSphere(( 4,-1, 4), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 6, 1, 6), 1) != RAY_MISS
            && RayVsSphere(( 4,-1, 4), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 6, 1, 6), 1).IsApproximately(SQRT3 + SQRT3 - 1f)  //((6f-SQRT3_RCP, 1f-SQRT3_RCP, 6f-SQRT3_RCP, SQRT3+SQRT3-1f))
        );

        //PRINT($"{RayVsSphere((-1,-1,-1), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 1, 1, 1), 1)}");
        //PRINT($"{(1f-SQRT3_RCP, 1f-SQRT3_RCP, 1f-SQRT3_RCP, SQRT3+SQRT3-1f)}");

        //PRINT($"{RayVsSphere(( 4,-1, 4), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ( 6, 1, 6), 1)}");
        //PRINT($"{(4f-SQRT3_RCP, 1f-SQRT3_RCP, 6f-SQRT3_RCP, SQRT3+SQRT3-1f)}");

        //PRINT($"{SQRT3_RCP}");
        //PRINT($"{1f-SQRT3_RCP}");
        //PRINT($"{new vec3(SQRT3_RCP, SQRT3_RCP, SQRT3_RCP).Length}");
        //PRINT($"{distance((-1,-1,-1), (1,1,1))}");

        //======================================================================================================================================================
        RESULT("RayVsSphere__Analytic()", true
        );

        //======================================================================================================================================================

        //(vec4 HitPos, int HitSide) = RayVsVoxelChunk(
        //    (1.0f,0.5f,0.5f), (1,0,0), (1,0,0),
        //    (1,-1,-1), (2,2,2), new uint[] {
        //        0xff808080, 0xff808080, 0xff808080, 0xff808080,
        //        0xff808080, 0xff808080, 0xff808080, 0xff808080
        //    }
        //);

        //PRINT($"{HitPos}");
        //PRINT($"{HitSide}");

        //RESULT("RayVsVoxelChunk()", true
        //    && HitPos  == (1,0,0,1)
        //    && HitSide == 1
        //);

        //######################################################################################################################################################
        //######################################################################################################################################################
    }
}
