using System;

namespace TEST;
internal static partial class Program {
    static void Test__Vector_Collision3() {
        PRINT("\n\n[Utility.VEC -- Collision3]\n");
        //PRINT($"{}");

        //======================================================================================================================================================
        RESULT("WhichSideOfPlane()", true
            && WhichSideOfPlane((4,5,6), (1,2,3), (SQRT3_RCP,SQRT3_RCP,SQRT3_RCP)) ==  1
            && WhichSideOfPlane((6,3,0), (3,3,3), (SQRT3_RCP,SQRT3_RCP,SQRT3_RCP)) ==  0
            && WhichSideOfPlane((1,2,3), (4,5,6), (SQRT3_RCP,SQRT3_RCP,SQRT3_RCP)) == -1
        );

        //======================================================================================================================================================
        RESULT("PointVsSphere()", true
            && PointVsSphere((1,1,1), (1,1,1), 1f) == true
            && PointVsSphere((1,1,2), (1,1,1), 1f) == true
            && PointVsSphere((1,2,1), (1,1,1), 1f) == true
            && PointVsSphere((2,1,1), (1,1,1), 1f) == true

            && PointVsSphere((-1,-1,-1), (-1,-1,-1), 1f) == true
            && PointVsSphere((-1,-1,-2), (-1,-1,-1), 1f) == true
            && PointVsSphere((-1,-2,-1), (-1,-1,-1), 1f) == true
            && PointVsSphere((-2,-1,-1), (-1,-1,-1), 1f) == true

            && PointVsSphere((1.70f,1,1.70f), (1,1,1), 1f) == true
            && PointVsSphere((1.71f,1,1.71f), (1,1,1), 1f) == false

            && PointVsSphere((-1.70f,-1,-1.70f), (-1,-1,-1), 1f) == true
            && PointVsSphere((-1.71f,-1,-1.71f), (-1,-1,-1), 1f) == false

            && PointVsSphere((3.57f,3.57f,3.57f), (3,3,3), 1f) == true
            && PointVsSphere((3.58f,3.58f,3.58f), (3,3,3), 1f) == false

            && PointVsSphere((-3.57f,-3.57f,-3.57f), (-3,-3,-3), 1f) == true
            && PointVsSphere((-3.58f,-3.58f,-3.58f), (-3,-3,-3), 1f) == false
        );

        //======================================================================================================================================================
        RESULT("PointVsBox()", true
            && PointVsBox((1,1,1), (1,1,1), (1,1,1)) == true
            && PointVsBox((2,2,2), (1,1,1), (1,1,1)) == false

            && PointVsBox((2,1,1), (1,1,1), (1,1,1)) == false
            && PointVsBox((1,2,1), (1,1,1), (1,1,1)) == false
            && PointVsBox((1,1,2), (1,1,1), (1,1,1)) == false
            && PointVsBox((2,2,1), (1,1,1), (1,1,1)) == false
            && PointVsBox((1,2,2), (1,1,1), (1,1,1)) == false
            && PointVsBox((2,1,2), (1,1,1), (1,1,1)) == false

            && PointVsBox((-1,-1,-1), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-2,-2,-2), (-2,-2,-2), (1,1,1)) == true

            && PointVsBox((-2,-1,-1), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-1,-2,-1), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-1,-1,-2), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-2,-2,-1), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-1,-2,-2), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-2,-1,-2), (-2,-2,-2), (1,1,1)) == false

            && PointVsBox((0.9999999f,0.9999999f,0.9999999f), (1,1,1), (1,1,1)) == false
            && PointVsBox((1.9999999f,1.9999999f,1.9999999f), (1,1,1), (1,1,1)) == true

            && PointVsBox((1.9999999f,0.9999999f,0.9999999f), (1,1,1), (1,1,1)) == false
            && PointVsBox((0.9999999f,1.9999999f,0.9999999f), (1,1,1), (1,1,1)) == false
            && PointVsBox((0.9999999f,0.9999999f,1.9999999f), (1,1,1), (1,1,1)) == false
            && PointVsBox((1.9999999f,1.9999999f,0.9999999f), (1,1,1), (1,1,1)) == false
            && PointVsBox((0.9999999f,1.9999999f,1.9999999f), (1,1,1), (1,1,1)) == false
            && PointVsBox((1.9999999f,0.9999999f,1.9999999f), (1,1,1), (1,1,1)) == false

            && PointVsBox((-0.9999999f,-0.9999999f,-0.9999999f), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-1.9999999f,-1.9999999f,-1.9999999f), (-2,-2,-2), (1,1,1)) == true

            && PointVsBox((-1.9999999f,-0.9999999f,-0.9999999f), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-0.9999999f,-1.9999999f,-0.9999999f), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-0.9999999f,-0.9999999f,-1.9999999f), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-1.9999999f,-1.9999999f,-0.9999999f), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-0.9999999f,-1.9999999f,-1.9999999f), (-2,-2,-2), (1,1,1)) == false
            && PointVsBox((-1.9999999f,-0.9999999f,-1.9999999f), (-2,-2,-2), (1,1,1)) == false

            && PointVsBox((-1.0000001f,-1.0000001f,-1.0000001f), (-2,-2,-2), (1,1,1)) == true
            && PointVsBox((-1.9999999f,-1.9999999f,-1.9999999f), (-2,-2,-2), (1,1,1)) == true

            && PointVsBox((-1.9999999f,-1.0000001f,-1.0000001f), (-2,-2,-2), (1,1,1)) == true
            && PointVsBox((-1.0000001f,-1.9999999f,-1.0000001f), (-2,-2,-2), (1,1,1)) == true
            && PointVsBox((-1.0000001f,-1.0000001f,-1.9999999f), (-2,-2,-2), (1,1,1)) == true
            && PointVsBox((-1.9999999f,-1.9999999f,-1.0000001f), (-2,-2,-2), (1,1,1)) == true
            && PointVsBox((-1.0000001f,-1.9999999f,-1.9999999f), (-2,-2,-2), (1,1,1)) == true
            && PointVsBox((-1.9999999f,-1.0000001f,-1.9999999f), (-2,-2,-2), (1,1,1)) == true
        );

        //======================================================================================================================================================
        RESULT("PointVsCylinder()", true
            && PointVsCylinder((1,1,1), (1,0,1), 1, 2) == true
            && PointVsCylinder((1,2,1), (1,0,1), 1, 2) == false
            && PointVsCylinder((1,0,1), (1,0,1), 1, 2) == true

            && PointVsCylinder((1.70f,0,1.70f), (1,0,1), 1, 2) == true
            && PointVsCylinder((1.71f,0,1.71f), (1,0,1), 1, 2) == false

            && PointVsCylinder((0.30f,0,0.30f), (1,0,1), 1, 2) == true
            && PointVsCylinder((0.29f,0,0.29f), (1,0,1), 1, 2) == false
        );

        //======================================================================================================================================================
        RESULT("RayVsPlaneX()", true
            && RayVsPlaneX((2,2,2), ( 1, 0, 0), ( 1, 0, 0), 1) == (1,2,2,-1)
            && RayVsPlaneX((2,2,2), (-1, 0, 0), (-1, 0, 0), 1) == (1,2,2, 1)
            && RayVsPlaneX((2,2,2), ( 0, 1, 0), ( 0, 1, 0), 1) == (2,2,2, 0)
            && RayVsPlaneX((2,2,2), ( 0,-1, 0), ( 0,-1, 0), 1) == (2,2,2, 0)
            && RayVsPlaneX((2,2,2), ( 0, 0, 1), ( 0, 0, 1), 1) == (2,2,2, 0)
            && RayVsPlaneX((2,2,2), ( 0, 0,-1), ( 0, 0,-1), 1) == (2,2,2, 0)
        );

        RESULT("RayVsPlaneY()", true
            && RayVsPlaneY((2,2,2), (1,0,0), (1,0,0), 1) == (2,2,2, 0)
            && RayVsPlaneY((2,2,2), (0,1,0), (0,1,0), 1) == (2,1,2,-1)
            && RayVsPlaneY((2,2,2), (0,0,1), (0,0,1), 1) == (2,2,2, 0)
            && RayVsPlaneY((2,2,2), (1,0,0), (1,0,0), 1) == (2,2,2, 0)
            && RayVsPlaneY((2,2,2), (0,1,0), (0,1,0), 1) == (2,1,2,-1)
            && RayVsPlaneY((2,2,2), (0,0,1), (0,0,1), 1) == (2,2,2, 0)
        );

        RESULT("RayVsPlaneZ()", true
            && RayVsPlaneZ((2,2,2), (1,0,0), (1,0,0), 1) == (2,2,2, 0)
            && RayVsPlaneZ((2,2,2), (0,1,0), (0,1,0), 1) == (2,2,2, 0)
            && RayVsPlaneZ((2,2,2), (0,0,1), (0,0,1), 1) == (2,2,1,-1)
            && RayVsPlaneZ((2,2,2), (1,0,0), (1,0,0), 1) == (2,2,2, 0)
            && RayVsPlaneZ((2,2,2), (0,1,0), (0,1,0), 1) == (2,2,2, 0)
            && RayVsPlaneZ((2,2,2), (0,0,1), (0,0,1), 1) == (2,2,1,-1)
        );

        //======================================================================================================================================================
        //RESULT("RayVsPlane()", true
        //    && RayVsPlane(vec3 Rp, vec3 Rn, vec3 Pp, vec3 Pn)
        //);

        //======================================================================================================================================================
        //RESULT("RayVsAab()", true
        //    && RayVsAab(vec3 Rp, vec3 Rn, vec3 Rnr, vec3 Bp, vec3 Bs)
        //);

        //======================================================================================================================================================
        //RESULT("RayVsTriangle()", true
        //    && RayVsTriangle(vec3 Rp, vec3 Rn, vec3 Ta, vec3 Tb, vec3 Tc, bool BackFaceTest)
        //);

        //======================================================================================================================================================
    }
}
