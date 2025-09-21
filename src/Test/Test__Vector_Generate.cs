
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Generate() {
        PRINT("\n[Utility.VEC -- Generation]");

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("FromAng()", true
            && FromAng(        0 ).IsApproximately(( 0, 1))
            && FromAng(ToRad( 90)).IsApproximately(( 1, 0))
            && FromAng(ToRad(180)).IsApproximately(( 0,-1))
            && FromAng(ToRad(270)).IsApproximately((-1, 0))
            && FromAng(ToRad(360)).IsApproximately(( 0, 1))
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("FromPch()", true
            && FromPch(        0 ).IsApproximately(( 0,         0,        -1))
            && FromPch(ToRad( 45)).IsApproximately(( 0,-SQRT2_RCP,-SQRT2_RCP))
            && FromPch(ToRad( 90)).IsApproximately(( 0,        -1,         0))
            && FromPch(ToRad(135)).IsApproximately(( 0,-SQRT2_RCP, SQRT2_RCP))
            && FromPch(ToRad(180)).IsApproximately(( 0,         0,         1))
            && FromPch(ToRad(270)).IsApproximately(( 0,         1,         0))
            && FromPch(ToRad(360)).IsApproximately(( 0,         0,        -1))
        );

        //======================================================================================================================================================
        RESULT("FromYaw()", true
            && FromYaw(        0 ).IsApproximately((        0, 0,        -1))
            && FromYaw(ToRad( 45)).IsApproximately((SQRT2_RCP, 0,-SQRT2_RCP))
            && FromYaw(ToRad( 90)).IsApproximately((        1, 0,         0))
            && FromYaw(ToRad(135)).IsApproximately((SQRT2_RCP, 0, SQRT2_RCP))
            && FromYaw(ToRad(180)).IsApproximately((        0, 0,         1))
            && FromYaw(ToRad(270)).IsApproximately((       -1, 0,         0))
            && FromYaw(ToRad(360)).IsApproximately((        0, 0,        -1))
        );

        //======================================================================================================================================================
        RESULT("FromRol()", true
            && FromRol(        0 ).IsApproximately((        0,         1, 0))
            && FromRol(ToRad( 45)).IsApproximately((SQRT2_RCP, SQRT2_RCP, 0))
            && FromRol(ToRad( 90)).IsApproximately((        1,         0, 0))
            && FromRol(ToRad(135)).IsApproximately((SQRT2_RCP,-SQRT2_RCP, 0))
            && FromRol(ToRad(180)).IsApproximately((        0,        -1, 0))
            && FromRol(ToRad(270)).IsApproximately((       -1,         0, 0))
            && FromRol(ToRad(360)).IsApproximately((        0,         1, 0))
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("FromPchYaw()", true
            && FromPchYaw(ToRad(-360), 0).IsApproximately(( 0, 0,-1))
            && FromPchYaw(ToRad(-270), 0).IsApproximately(( 0,-1, 0))
            && FromPchYaw(ToRad(-180), 0).IsApproximately(( 0, 0, 1))
            && FromPchYaw(ToRad( -90), 0).IsApproximately(( 0, 1, 0))
            && FromPchYaw(         0 , 0).IsApproximately(( 0, 0,-1))
            && FromPchYaw(ToRad(  90), 0).IsApproximately(( 0,-1, 0))
            && FromPchYaw(ToRad( 180), 0).IsApproximately(( 0, 0, 1))
            && FromPchYaw(ToRad( 270), 0).IsApproximately(( 0, 1, 0))
            && FromPchYaw(ToRad( 360), 0).IsApproximately(( 0, 0,-1))

            && FromPchYaw( 0,ToRad(-360)).IsApproximately(( 0, 0,-1))
            && FromPchYaw( 0,ToRad(-270)).IsApproximately(( 1, 0, 0))
            && FromPchYaw( 0,ToRad(-180)).IsApproximately(( 0, 0, 1))
            && FromPchYaw( 0,ToRad( -90)).IsApproximately((-1, 0, 0))
            && FromPchYaw( 0,         0 ).IsApproximately(( 0, 0,-1))
            && FromPchYaw( 0,ToRad(  90)).IsApproximately(( 1, 0, 0))
            && FromPchYaw( 0,ToRad( 180)).IsApproximately(( 0, 0, 1))
            && FromPchYaw( 0,ToRad( 270)).IsApproximately((-1, 0, 0))
            && FromPchYaw( 0,ToRad( 360)).IsApproximately(( 0, 0,-1))
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        RESULT("RotFromVec()", true
            && RotFromVec(( 0, 0,-1))                .IsApproximately((         0,         0, 0))
            && RotFromVec(( 0,-1, 0))                .IsApproximately((ToRad( 90),         0, 0))
            && RotFromVec(( 0, 0, 1))                .IsApproximately((         0,ToRad(180), 0))
            && RotFromVec(( 0, 1, 0))                .IsApproximately((ToRad(-90),         0, 0))

            && RotFromVec(( 0, 0,-1))                .IsApproximately((         0,         0, 0))
            && RotFromVec(( 1, 0, 0))                .IsApproximately((         0,ToRad( 90), 0))
            && RotFromVec(( 0, 0, 1))                .IsApproximately((         0,ToRad(180), 0))
            && RotFromVec((-1, 0, 0))                .IsApproximately((         0,ToRad(270), 0))

            && RotFromVec(( 0,-SQRT2_RCP,-SQRT2_RCP)).IsApproximately((ToRad( 45),         0, 0))
            && RotFromVec(( 0,-SQRT2_RCP, SQRT2_RCP)).IsApproximately((ToRad( 45),ToRad(180), 0))
            && RotFromVec(( 0, SQRT2_RCP, SQRT2_RCP)).IsApproximately((ToRad(-45),ToRad(180), 0))
            && RotFromVec(( 0, SQRT2_RCP,-SQRT2_RCP)).IsApproximately((ToRad(-45),         0, 0))

            && RotFromVec(( SQRT2_RCP, 0,-SQRT2_RCP)).IsApproximately((         0,ToRad( 45), 0))
            && RotFromVec(( SQRT2_RCP, 0, SQRT2_RCP)).IsApproximately((         0,ToRad(135), 0))
            && RotFromVec((-SQRT2_RCP, 0, SQRT2_RCP)).IsApproximately((         0,ToRad(225), 0))
            && RotFromVec((-SQRT2_RCP, 0,-SQRT2_RCP)).IsApproximately((         0,ToRad(315), 0))
        );

        //######################################################################################################################################################
        //######################################################################################################################################################
        {
            vec2[] Poly5 = Polygon2(5,96), Poly6  = Polygon2( 6,96), Poly7  = Polygon2( 7,96), Poly8  = Polygon2( 8,96),
                   Poly9 = Polygon2(9,96), Poly10 = Polygon2(10,96), Poly11 = Polygon2(11,96), Poly12 = Polygon2(12,96);

            RESULT("Polygon2()", true
                &&  Poly5[ 0].IsRoughly((  0.0f       , 96.0f       )) &&  Poly5[ 1].IsRoughly((-91.30142556f, 29.66563145f))
                &&  Poly5[ 2].IsRoughly((-56.42738422f,-77.66563145f)) &&  Poly5[ 3].IsRoughly(( 56.42738422f,-77.66563145f))
                &&  Poly5[ 4].IsRoughly(( 91.30142556f, 29.66563145f))

                &&  Poly6[ 0].IsRoughly((  0f         , 96f         )) &&  Poly6[ 1].IsRoughly((-83.13843876f, 48f         ))
                &&  Poly6[ 2].IsRoughly((-83.13843876f,-48f         )) &&  Poly6[ 3].IsRoughly((  0f         ,-96f         ))
                &&  Poly6[ 4].IsRoughly(( 83.13843876f,-48f         )) &&  Poly6[ 5].IsRoughly(( 83.13843876f, 48f         ))

                &&  Poly7[ 0].IsRoughly((  0f         , 96f         )) &&  Poly7[ 1].IsRoughly((-75.05582231f, 59.85502097f))
                &&  Poly7[ 2].IsRoughly((-93.59307956f,-21.36200965f)) &&  Poly7[ 3].IsRoughly((-41.65283895f,-86.49301131f))
                &&  Poly7[ 4].IsRoughly(( 41.65283895f,-86.49301131f)) &&  Poly7[ 5].IsRoughly(( 93.59307956f,-21.36200965f))
                &&  Poly7[ 6].IsRoughly(( 75.05582231f, 59.85502097f))

                &&  Poly8[ 0].IsRoughly((  0f         , 96f         )) &&  Poly8[ 1].IsRoughly((-67.88225099f, 67.88225099f))
                &&  Poly8[ 2].IsRoughly((-96f         ,  0f         )) &&  Poly8[ 3].IsRoughly((-67.88225099f,-67.88225099f))
                &&  Poly8[ 4].IsRoughly((  0f         ,-96f         )) &&  Poly8[ 5].IsRoughly(( 67.88225099f,-67.88225099f))
                &&  Poly8[ 6].IsRoughly(( 96f         ,  0f         )) &&  Poly8[ 7].IsRoughly(( 67.88225099f, 67.88225099f))

                &&  Poly9[ 0].IsRoughly((  0f         , 96f         )) &&  Poly9[ 1].IsRoughly((-61.70761052f, 73.54026653f))
                &&  Poly9[ 2].IsRoughly((-94.54154428f, 16.67022505f)) &&  Poly9[ 3].IsRoughly((-83.13843876f,-48f         ))
                &&  Poly9[ 4].IsRoughly((-32.83393375f,-90.21049159f)) &&  Poly9[ 5].IsRoughly(( 32.83393375f,-90.21049159f))
                &&  Poly9[ 6].IsRoughly(( 83.13843876f,-48f         )) &&  Poly9[ 7].IsRoughly(( 94.54154428f, 16.67022505f))
                &&  Poly9[ 8].IsRoughly(( 61.70761052f, 73.54026653f))

                && Poly10[ 0].IsRoughly((  0f         , 96f         )) && Poly10[ 1].IsRoughly((-56.42738422f, 77.66563145f))
                && Poly10[ 2].IsRoughly((-91.30142556f, 29.66563145f)) && Poly10[ 3].IsRoughly((-91.30142556f,-29.66563145f))
                && Poly10[ 4].IsRoughly((-56.42738422f,-77.66563145f)) && Poly10[ 5].IsRoughly((  0f         ,-96f         ))
                && Poly10[ 6].IsRoughly(( 56.42738422f,-77.66563145f)) && Poly10[ 7].IsRoughly(( 91.30142556f,-29.66563145f))
                && Poly10[ 8].IsRoughly(( 91.30142556f, 29.66563145f)) && Poly10[ 9].IsRoughly(( 56.42738422f, 77.66563145f))

                && Poly11[ 0].IsRoughly((  0f         , 96f         )) && Poly11[ 1].IsRoughly((-51.90151847f, 80.76033915f))
                && Poly11[ 2].IsRoughly((-87.32467155f, 39.87984124f)) && Poly11[ 3].IsRoughly((-95.02285842f,-13.66222447f))
                && Poly11[ 4].IsRoughly((-72.55195913f,-62.86663045f)) && Poly11[ 5].IsRoughly((-27.04632545f,-92.11132546f))
                && Poly11[ 6].IsRoughly(( 27.04632545f,-92.11132546f)) && Poly11[ 7].IsRoughly(( 72.55195913f,-62.86663045f))
                && Poly11[ 8].IsRoughly(( 95.02285842f,-13.66222447f)) && Poly11[ 9].IsRoughly(( 87.32467155f, 39.87984124f))
                && Poly11[10].IsRoughly(( 51.90151847f, 80.76033915f))

                && Poly12[ 0].IsRoughly((  0f         , 96f         )) && Poly12[ 1].IsRoughly((-48f         , 83.13843876f))
                && Poly12[ 2].IsRoughly((-83.13843876f, 48f         )) && Poly12[ 3].IsRoughly((-96f         ,  0f         ))
                && Poly12[ 4].IsRoughly((-83.13843876f,-48f         )) && Poly12[ 5].IsRoughly((-48f         ,-83.13843876f))
                && Poly12[ 6].IsRoughly((  0f         ,-96f         )) && Poly12[ 7].IsRoughly(( 48f         ,-83.13843876f))
                && Poly12[ 8].IsRoughly(( 83.13843876f,-48f         )) && Poly12[ 9].IsRoughly(( 96f         ,  0f         ))
                && Poly12[10].IsRoughly(( 83.13843876f, 48f         )) && Poly12[11].IsRoughly(( 48f         , 83.13843876f))
            );
        }

        //======================================================================================================================================================
        {
            vec3[] Poly5 = Polygon3(5,96), Poly6  = Polygon3( 6,96), Poly7  = Polygon3( 7,96), Poly8  = Polygon3( 8,96),
                   Poly9 = Polygon3(9,96), Poly10 = Polygon3(10,96), Poly11 = Polygon3(11,96), Poly12 = Polygon3(12,96);

            RESULT("Polygon3()", true
                &&  Poly5[ 0].IsRoughly((  0.0f       , 0f,-96.0f       )) &&  Poly5[ 1].IsRoughly((-91.30142556f, 0f,-29.66563145f))
                &&  Poly5[ 2].IsRoughly((-56.42738422f, 0f, 77.66563145f)) &&  Poly5[ 3].IsRoughly(( 56.42738422f, 0f, 77.66563145f))
                &&  Poly5[ 4].IsRoughly(( 91.30142556f, 0f,-29.66563145f))

                &&  Poly6[ 0].IsRoughly((  0f         , 0f,-96f         )) &&  Poly6[ 1].IsRoughly((-83.13843876f, 0f,-48f         ))
                &&  Poly6[ 2].IsRoughly((-83.13843876f, 0f, 48f         )) &&  Poly6[ 3].IsRoughly((  0f         , 0f, 96f         ))
                &&  Poly6[ 4].IsRoughly(( 83.13843876f, 0f, 48f         )) &&  Poly6[ 5].IsRoughly(( 83.13843876f, 0f,-48f         ))

                &&  Poly7[ 0].IsRoughly((  0f         , 0f,-96f         )) &&  Poly7[ 1].IsRoughly((-75.05582231f, 0f,-59.85502097f))
                &&  Poly7[ 2].IsRoughly((-93.59307956f, 0f, 21.36200965f)) &&  Poly7[ 3].IsRoughly((-41.65283895f, 0f, 86.49301131f))
                &&  Poly7[ 4].IsRoughly(( 41.65283895f, 0f, 86.49301131f)) &&  Poly7[ 5].IsRoughly(( 93.59307956f, 0f, 21.36200965f))
                &&  Poly7[ 6].IsRoughly(( 75.05582231f, 0f,-59.85502097f))

                &&  Poly8[ 0].IsRoughly((  0f         , 0f,-96f         )) &&  Poly8[ 1].IsRoughly((-67.88225099f, 0f,-67.88225099f))
                &&  Poly8[ 2].IsRoughly((-96f         , 0f,- 0f         )) &&  Poly8[ 3].IsRoughly((-67.88225099f, 0f, 67.88225099f))
                &&  Poly8[ 4].IsRoughly((  0f         , 0f, 96f         )) &&  Poly8[ 5].IsRoughly(( 67.88225099f, 0f, 67.88225099f))
                &&  Poly8[ 6].IsRoughly(( 96f         , 0f,- 0f         )) &&  Poly8[ 7].IsRoughly(( 67.88225099f, 0f,-67.88225099f))

                &&  Poly9[ 0].IsRoughly((  0f         , 0f,-96f         )) &&  Poly9[ 1].IsRoughly((-61.70761052f, 0f,-73.54026653f))
                &&  Poly9[ 2].IsRoughly((-94.54154428f, 0f,-16.67022505f)) &&  Poly9[ 3].IsRoughly((-83.13843876f, 0f, 48f         ))
                &&  Poly9[ 4].IsRoughly((-32.83393375f, 0f, 90.21049159f)) &&  Poly9[ 5].IsRoughly(( 32.83393375f, 0f, 90.21049159f))
                &&  Poly9[ 6].IsRoughly(( 83.13843876f, 0f, 48f         )) &&  Poly9[ 7].IsRoughly(( 94.54154428f, 0f,-16.67022505f))
                &&  Poly9[ 8].IsRoughly(( 61.70761052f, 0f,-73.54026653f))

                && Poly10[ 0].IsRoughly((  0f         , 0f,-96f         )) && Poly10[ 1].IsRoughly((-56.42738422f, 0f,-77.66563145f))
                && Poly10[ 2].IsRoughly((-91.30142556f, 0f,-29.66563145f)) && Poly10[ 3].IsRoughly((-91.30142556f, 0f, 29.66563145f))
                && Poly10[ 4].IsRoughly((-56.42738422f, 0f, 77.66563145f)) && Poly10[ 5].IsRoughly((  0f         , 0f, 96f         ))
                && Poly10[ 6].IsRoughly(( 56.42738422f, 0f, 77.66563145f)) && Poly10[ 7].IsRoughly(( 91.30142556f, 0f, 29.66563145f))
                && Poly10[ 8].IsRoughly(( 91.30142556f, 0f,-29.66563145f)) && Poly10[ 9].IsRoughly(( 56.42738422f, 0f,-77.66563145f))

                && Poly11[ 0].IsRoughly((  0f         , 0f,-96f         )) && Poly11[ 1].IsRoughly((-51.90151847f, 0f,-80.76033915f))
                && Poly11[ 2].IsRoughly((-87.32467155f, 0f,-39.87984124f)) && Poly11[ 3].IsRoughly((-95.02285842f, 0f, 13.66222447f))
                && Poly11[ 4].IsRoughly((-72.55195913f, 0f, 62.86663045f)) && Poly11[ 5].IsRoughly((-27.04632545f, 0f, 92.11132546f))
                && Poly11[ 6].IsRoughly(( 27.04632545f, 0f, 92.11132546f)) && Poly11[ 7].IsRoughly(( 72.55195913f, 0f, 62.86663045f))
                && Poly11[ 8].IsRoughly(( 95.02285842f, 0f, 13.66222447f)) && Poly11[ 9].IsRoughly(( 87.32467155f, 0f,-39.87984124f))
                && Poly11[10].IsRoughly(( 51.90151847f, 0f,-80.76033915f))

                && Poly12[ 0].IsRoughly((  0f         , 0f,-96f         )) && Poly12[ 1].IsRoughly((-48f         , 0f,-83.13843876f))
                && Poly12[ 2].IsRoughly((-83.13843876f, 0f,-48f         )) && Poly12[ 3].IsRoughly((-96f         , 0f,  0f         ))
                && Poly12[ 4].IsRoughly((-83.13843876f, 0f, 48f         )) && Poly12[ 5].IsRoughly((-48f         , 0f, 83.13843876f))
                && Poly12[ 6].IsRoughly((  0f         , 0f, 96f         )) && Poly12[ 7].IsRoughly(( 48f         , 0f, 83.13843876f))
                && Poly12[ 8].IsRoughly(( 83.13843876f, 0f, 48f         )) && Poly12[ 9].IsRoughly(( 96f         , 0f,  0f         ))
                && Poly12[10].IsRoughly(( 83.13843876f, 0f,-48f         )) && Poly12[11].IsRoughly(( 48f         , 0f,-83.13843876f))
            );
        }

        //======================================================================================================================================================
        #if false
            vec2[] A = ___LINE___((-3.5f, 2.5f), (4.25f, -1.5f), 3, 2f);

            string STR = "";
            foreach (vec2 P in A) {
                STR += $"({P.x},{P.y}),";
            }

            PRINT(STR);
        #endif

        //======================================================================================================================================================
    }
}
