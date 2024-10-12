
namespace TEST;
internal static partial class Program {
    static void Test__Vector_Rotation() {
        PRINT("\n\n[Utility.VEC -- Rotation]\n");
        //PRINT($"{}");

        //======================================================================================================================================================
        RESULT("vec2 rot(P,        Theta)", true
            && rot((0, 1), ToRad(-450)).IsApproximately((-1, 0))
            && rot((0, 1), ToRad(-360)).IsApproximately(( 0, 1))
            && rot((0, 1), ToRad(-270)).IsApproximately(( 1, 0))
            && rot((0, 1), ToRad(-180)).IsApproximately(( 0,-1))
            && rot((0, 1), ToRad( -90)).IsApproximately((-1, 0))
            && rot((0, 1),          0 ).IsApproximately(( 0, 1))
            && rot((0, 1), ToRad(  90)).IsApproximately(( 1, 0))
            && rot((0, 1), ToRad( 180)).IsApproximately(( 0,-1))
            && rot((0, 1), ToRad( 270)).IsApproximately((-1, 0))
            && rot((0, 1), ToRad( 360)).IsApproximately(( 0, 1))
            && rot((0, 1), ToRad( 450)).IsApproximately(( 1, 0))

            && rot((0, 1), ToRad(-405)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))
            && rot((0, 1), ToRad(-315)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
            && rot((0, 1), ToRad(-225)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP))
            && rot((0, 1), ToRad(-135)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP))
            && rot((0, 1), ToRad( -45)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))
            && rot((0, 1), ToRad(  45)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
            && rot((0, 1), ToRad( 135)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP))
            && rot((0, 1), ToRad( 225)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP))
            && rot((0, 1), ToRad( 315)).IsApproximately((-SQRT2_RCP, SQRT2_RCP))
            && rot((0, 1), ToRad( 405)).IsApproximately(( SQRT2_RCP, SQRT2_RCP))
        );

        RESULT("vec2 rot(P, Pivot, Theta)", true
            && rot((2, 3), (2, 2),         0 ).IsApproximately((2, 3))
            && rot((2, 3), (2, 2), ToRad( 90)).IsApproximately((3, 2))
            && rot((2, 3), (2, 2), ToRad(180)).IsApproximately((2, 1))
            && rot((2, 3), (2, 2), ToRad(270)).IsApproximately((1, 2))
            && rot((2, 3), (2, 2), ToRad(360)).IsApproximately((2, 3))
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("vec3 pch(P,        Theta)", true
            && pch((0, 0,-2),         0 ).IsApproximately((0, 0,-2))
            && pch((0, 0,-2), ToRad( 90)).IsApproximately((0,-2, 0))
            && pch((0, 0,-2), ToRad(180)).IsApproximately((0, 0, 2))
            && pch((0, 0,-2), ToRad(270)).IsApproximately((0, 2, 0))
            && pch((0, 0,-2), ToRad(360)).IsApproximately((0, 0,-2))
        );

        RESULT("vec3 pch(P, Pivot, Theta)", true
            && pch((3, 3, 1), (3, 3, 3),         0 ).IsApproximately(( 3, 3, 1))
            && pch((3, 3, 1), (3, 3, 3), ToRad( 90)).IsApproximately(( 3, 1, 3))
            && pch((3, 3, 1), (3, 3, 3), ToRad(180)).IsApproximately(( 3, 3, 5))
            && pch((3, 3, 1), (3, 3, 3), ToRad(270)).IsApproximately(( 3, 5, 3))
            && pch((3, 3, 1), (3, 3, 3), ToRad(360)).IsApproximately(( 3, 3, 1))
        );

        //======================================================================================================================================================
        RESULT("vec3 yaw(P,        Theta)", true
            && yaw((0, 0,-2),         0 ).IsApproximately(( 0, 0,-2))
            && yaw((0, 0,-2), ToRad( 90)).IsApproximately(( 2, 0, 0))
            && yaw((0, 0,-2), ToRad(180)).IsApproximately(( 0, 0, 2))
            && yaw((0, 0,-2), ToRad(270)).IsApproximately((-2, 0, 0))
            && yaw((0, 0,-2), ToRad(360)).IsApproximately(( 0, 0,-2))
        );

        RESULT("vec3 yaw(P, Pivot, Theta)", true
            && yaw((3, 3, 1), (3, 3, 3),         0 ).IsApproximately(( 3, 3, 1))
            && yaw((3, 3, 1), (3, 3, 3), ToRad( 90)).IsApproximately(( 5, 3, 3))
            && yaw((3, 3, 1), (3, 3, 3), ToRad(180)).IsApproximately(( 3, 3, 5))
            && yaw((3, 3, 1), (3, 3, 3), ToRad(270)).IsApproximately(( 1, 3, 3))
            && yaw((3, 3, 1), (3, 3, 3), ToRad(360)).IsApproximately(( 3, 3, 1))
        );

        //======================================================================================================================================================
        RESULT("vec3 rol(P,        Theta)", true
            && rol((0, 2, 0),         0 ).IsApproximately(( 0, 2, 0))
            && rol((0, 2, 0), ToRad( 90)).IsApproximately(( 2, 0, 0))
            && rol((0, 2, 0), ToRad(180)).IsApproximately(( 0,-2, 0))
            && rol((0, 2, 0), ToRad(270)).IsApproximately((-2, 0, 0))
            && rol((0, 2, 0), ToRad(360)).IsApproximately(( 0, 2, 0))
        );

        RESULT("vec3 rol(P, Pivot, Theta)", true
            && rol((3, 5, 3), (3, 3, 3),         0 ).IsApproximately(( 3, 5, 3))
            && rol((3, 5, 3), (3, 3, 3), ToRad( 90)).IsApproximately(( 5, 3, 3))
            && rol((3, 5, 3), (3, 3, 3), ToRad(180)).IsApproximately(( 3, 1, 3))
            && rol((3, 5, 3), (3, 3, 3), ToRad(270)).IsApproximately(( 1, 3, 3))
            && rol((3, 5, 3), (3, 3, 3), ToRad(360)).IsApproximately(( 3, 5, 3))
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("vec3 rot(P,        Axis, Theta)", true
            && rot((0, 2, 0), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),         0 ).IsApproximately(( 0, 2, 0))
            && rot((0, 2, 0), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(120)).IsApproximately(( 2, 0, 0))
            && rot((0, 2, 0), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(240)).IsApproximately(( 0, 0, 2))
            && rot((0, 2, 0), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(360)).IsApproximately(( 0, 2, 0))

            && rot((0, 2, 0), (SQRT2_RCP, 0, SQRT2_RCP), ToRad(-270)).IsApproximately(( SQRT2, 0,-SQRT2))
            && rot((0, 2, 0), (SQRT2_RCP, 0, SQRT2_RCP), ToRad( -90)).IsApproximately((-SQRT2, 0, SQRT2))
            && rot((0, 2, 0), (SQRT2_RCP, 0, SQRT2_RCP), ToRad(  90)).IsApproximately(( SQRT2, 0,-SQRT2))
            && rot((0, 2, 0), (SQRT2_RCP, 0, SQRT2_RCP), ToRad( 270)).IsApproximately((-SQRT2, 0, SQRT2))

            && rot((0, 1, 0), (SQRT2_RCP, 0, SQRT2_RCP), ToRad(  45)).IsApproximately((0.5f,SQRT2_RCP,-0.5f))
            && rot((0, 1, 0), (SQRT2_RCP, 0, SQRT2_RCP), ToRad(  45)).Length.IsApproximately(1)

            && rot((0, 2, 0), (SQRT2_RCP, 0, SQRT2_RCP), ToRad(  45)).IsApproximately((1,SQRT2,-1))
            && rot((0, 2, 0), (SQRT2_RCP, 0, SQRT2_RCP), ToRad(  45)).Length.IsApproximately(2)
        );

        RESULT("vec3 rot(P, Pivot, Axis, Theta)", true
            && rot((0, 5, 0), (0, 3, 0), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP),         0 ).IsApproximately(( 0, 5, 0))
            && rot((0, 5, 0), (0, 3, 0), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(120)).IsApproximately(( 2, 3, 0))
            && rot((0, 5, 0), (0, 3, 0), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(240)).IsApproximately(( 0, 3, 2))
            && rot((0, 5, 0), (0, 3, 0), (SQRT3_RCP, SQRT3_RCP, SQRT3_RCP), ToRad(360)).IsApproximately(( 0, 5, 0))
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("vec3 rot(P,        ThetaVec)", true
            && rot(( 0, 1,   0), (        0,         0,         0)).IsApproximately((        0,        1,        0))
            && rot(( 0, 1,   0), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).IsApproximately(( TWOTHIRD,-ONETHIRD, TWOTHIRD)) //  180 along diagonal axis
            && rot(( 0, 2,   0), (PI2/SQRT3, PI2/SQRT3, PI2/SQRT3)).IsApproximately((        0,        2,        0)) //  360 along diagonal axis

            && rot(( 0, 1,   0), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).Length.IsApproximately(1)
            && rot(( 0, 2,   0), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).Length.IsApproximately(2)
            && rot(( 0, 0,  PI), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).Length.IsApproximately(PI)
            && rot(( 0, 0, PI2), (PI2/SQRT3, PI2/SQRT3, PI2/SQRT3)).Length.IsApproximately(PI2)
            && rot(( 0, 0, PI3), (PI3/SQRT3, PI3/SQRT3, PI3/SQRT3)).Length.IsApproximately(PI3)
            && rot(( 0, 0, PI4), (PI4/SQRT3, PI4/SQRT3, PI4/SQRT3)).Length.IsApproximately(PI4)

            && rot((-SQRT2_RCP, 0, SQRT2_RCP), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).IsApproximately(( SQRT2_RCP, 0,-SQRT2_RCP)) //  180 along diagonal axis
            && rot((-SQRT2_RCP, 0, SQRT2_RCP), (PI2/SQRT3, PI2/SQRT3, PI2/SQRT3)).IsApproximately((-SQRT2_RCP, 0, SQRT2_RCP)) //  360 along diagonal axis

            && rot(( 0, 0, 1), ( PI/SQRT2, 0, PI/SQRT2)).IsApproximately(( 1, 0, 0)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), (-PI/SQRT2, 0,-PI/SQRT2)).IsApproximately(( 1, 0, 0)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), (-PI/SQRT2, 0, PI/SQRT2)).IsApproximately((-1, 0, 0)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), ( PI/SQRT2, 0,-PI/SQRT2)).IsApproximately((-1, 0, 0)) //  180 along diagonal-ish axis

            && rot(( 0, 0, 1), ( 0, PI/SQRT2, PI/SQRT2)).IsApproximately(( 0, 1, 0)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), ( 0,-PI/SQRT2,-PI/SQRT2)).IsApproximately(( 0, 1, 0)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), ( 0,-PI/SQRT2, PI/SQRT2)).IsApproximately(( 0,-1, 0)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), ( 0, PI/SQRT2,-PI/SQRT2)).IsApproximately(( 0,-1, 0)) //  180 along diagonal-ish axis

            && rot(( 0, 0, 1), ( PI/SQRT2, PI/SQRT2, 0)).IsApproximately(( 0, 0,-1)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), (-PI/SQRT2,-PI/SQRT2, 0)).IsApproximately(( 0, 0,-1)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), (-PI/SQRT2, PI/SQRT2, 0)).IsApproximately(( 0, 0,-1)) //  180 along diagonal-ish axis
            && rot(( 0, 0, 1), ( PI/SQRT2,-PI/SQRT2, 0)).IsApproximately(( 0, 0,-1)) //  180 along diagonal-ish axis

            && rot(( 0, 0, 1), ( PIH/SQRT2, 0, PIH/SQRT2)).IsApproximately(( 0.5f     , SQRT2_RCP, 0.5f)) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), (-PIH/SQRT2, 0,-PIH/SQRT2)).IsApproximately(( 0.5f     ,-SQRT2_RCP, 0.5f)) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), (-PIH/SQRT2, 0, PIH/SQRT2)).IsApproximately((-0.5f     ,-SQRT2_RCP, 0.5f)) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), ( PIH/SQRT2, 0,-PIH/SQRT2)).IsApproximately((-0.5f     , SQRT2_RCP, 0.5f)) //  90 along diagonal-ish axis

            && rot(( 0, 0, 1), ( 0, PIH/SQRT2, PIH/SQRT2)).IsApproximately((-SQRT2_RCP, 0.5f     , 0.5f)) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), ( 0,-PIH/SQRT2,-PIH/SQRT2)).IsApproximately(( SQRT2_RCP, 0.5f     , 0.5f)) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), ( 0,-PIH/SQRT2, PIH/SQRT2)).IsApproximately(( SQRT2_RCP,-0.5f     , 0.5f)) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), ( 0, PIH/SQRT2,-PIH/SQRT2)).IsApproximately((-SQRT2_RCP,-0.5f     , 0.5f)) //  90 along diagonal-ish axis

            && rot(( 0, 0, 1), ( PIH/SQRT2, PIH/SQRT2, 0)).IsApproximately((-SQRT2_RCP, SQRT2_RCP, 0f  )) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), (-PIH/SQRT2,-PIH/SQRT2, 0)).IsApproximately(( SQRT2_RCP,-SQRT2_RCP, 0f  )) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), (-PIH/SQRT2, PIH/SQRT2, 0)).IsApproximately((-SQRT2_RCP,-SQRT2_RCP, 0f  )) //  90 along diagonal-ish axis
            && rot(( 0, 0, 1), ( PIH/SQRT2,-PIH/SQRT2, 0)).IsApproximately(( SQRT2_RCP, SQRT2_RCP, 0f  )) //  90 along diagonal-ish axis
        );

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        RESULT("vec3 rot(P, Pivot, ThetaVec)", true
            && rot((5,6,5), (5,5,5), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).IsApproximately((5+TWOTHIRD         ,5-ONETHIRD         ,5+TWOTHIRD         ))
            && rot((5,7,5), (5,5,5), (PI /SQRT3, PI /SQRT3, PI /SQRT3)).IsApproximately((5+TWOTHIRD+TWOTHIRD,5-ONETHIRD-ONETHIRD,5+TWOTHIRD+TWOTHIRD))

            && rot((5,6,5), (5,5,5), (PIH/SQRT2,         0, PIH/SQRT2)).IsApproximately((5+SQRT2_RCP        ,5                  ,5-SQRT2_RCP        ))

            && (rot((5,6,5    ), (5,5,5), (PI /SQRT3, PI /SQRT3, PI /SQRT3)) - (5,5,5)).Length.IsApproximately(1)
            && (rot((5,7,5    ), (5,5,5), (PI /SQRT3, PI /SQRT3, PI /SQRT3)) - (5,5,5)).Length.IsApproximately(2)
            && (rot((5,5,5+PI ), (5,5,5), (PI /SQRT3, PI /SQRT3, PI /SQRT3)) - (5,5,5)).Length.IsApproximately(PI)
            && (rot((5,5,5+PI2), (5,5,5), (PI2/SQRT3, PI2/SQRT3, PI2/SQRT3)) - (5,5,5)).Length.IsApproximately(PI2)
            && (rot((5,5,5+PI3), (5,5,5), (PI3/SQRT3, PI3/SQRT3, PI3/SQRT3)) - (5,5,5)).Length.IsApproximately(PI3)
            && (rot((5,5,5+PI4), (5,5,5), (PI4/SQRT3, PI4/SQRT3, PI4/SQRT3)) - (5,5,5)).Length.IsApproximately(PI4)
        );

        //======================================================================================================================================================
    }
}
