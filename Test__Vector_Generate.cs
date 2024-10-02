
namespace TEST;
internal static partial class Program {
    static void Test__Vector_Generate() {
        PRINT("\n[Utility.VEC -- Generate]");

        //======================================================================================================================================================
        RESULT("FromAng()", true
            && FromAng(        0 ).ApproximatelyEquals(new vec2( 0, 1))
            && FromAng(ToRad( 90)).ApproximatelyEquals(new vec2( 1, 0))
            && FromAng(ToRad(180)).ApproximatelyEquals(new vec2( 0,-1))
            && FromAng(ToRad(270)).ApproximatelyEquals(new vec2(-1, 0))
            && FromAng(ToRad(360)).ApproximatelyEquals(new vec2( 0, 1))
        );

        //======================================================================================================================================================
        PRINT("");
        //PRINT($"    FromPch(  0) == {FromPch(        0 ):0.000}");
        //PRINT($"    FromPch( 45) == {FromPch(ToRad( 45)):0.000}");
        //PRINT($"    FromPch( 90) == {FromPch(ToRad( 90)):0.000}");
        //PRINT($"    FromPch(135) == {FromPch(ToRad(135)):0.000}");
        //PRINT($"    FromPch(180) == {FromPch(ToRad(180)):0.000}");
        //PRINT($"    FromPch(270) == {FromPch(ToRad(270)):0.000}");
        //PRINT($"    FromPch(360) == {FromPch(ToRad(360)):0.000}");
        //PRINT("");
        //PRINT($"    FromYaw(  0) == {FromYaw(        0 ):0.000}");
        //PRINT($"    FromYaw( 45) == {FromYaw(ToRad( 45)):0.000}");
        //PRINT($"    FromYaw( 90) == {FromYaw(ToRad( 90)):0.000}");
        //PRINT($"    FromYaw(135) == {FromYaw(ToRad(135)):0.000}");
        //PRINT($"    FromYaw(180) == {FromYaw(ToRad(180)):0.000}");
        //PRINT($"    FromYaw(270) == {FromYaw(ToRad(270)):0.000}");
        //PRINT($"    FromYaw(360) == {FromYaw(ToRad(360)):0.000}");
        //PRINT("");
        //PRINT($"    FromRol(  0) == {FromRol(        0 ):0.000}");
        //PRINT($"    FromRol( 45) == {FromRol(ToRad( 45)):0.000}");
        //PRINT($"    FromRol( 90) == {FromRol(ToRad( 90)):0.000}");
        //PRINT($"    FromRol(135) == {FromRol(ToRad(135)):0.000}");
        //PRINT($"    FromRol(180) == {FromRol(ToRad(180)):0.000}");
        //PRINT($"    FromRol(270) == {FromRol(ToRad(270)):0.000}");
        //PRINT($"    FromRol(360) == {FromRol(ToRad(360)):0.000}");
        //PRINT("");
        RESULT("FromPch()", true
            && FromPch(        0 ).ApproximatelyEquals(new vec3( 0,         0,        -1))
            && FromPch(ToRad( 45)).ApproximatelyEquals(new vec3( 0,-SQRT2_RCP,-SQRT2_RCP))
            && FromPch(ToRad( 90)).ApproximatelyEquals(new vec3( 0,        -1,         0))
            && FromPch(ToRad(135)).ApproximatelyEquals(new vec3( 0,-SQRT2_RCP, SQRT2_RCP))
            && FromPch(ToRad(180)).ApproximatelyEquals(new vec3( 0,         0,         1))
            && FromPch(ToRad(270)).ApproximatelyEquals(new vec3( 0,         1,         0))
            && FromPch(ToRad(360)).ApproximatelyEquals(new vec3( 0,         0,        -1))
        );

        RESULT("FromYaw()", true
            && FromYaw(        0 ).ApproximatelyEquals(new vec3(        0, 0,        -1))
            && FromYaw(ToRad( 45)).ApproximatelyEquals(new vec3(SQRT2_RCP, 0,-SQRT2_RCP))
            && FromYaw(ToRad( 90)).ApproximatelyEquals(new vec3(        1, 0,         0))
            && FromYaw(ToRad(135)).ApproximatelyEquals(new vec3(SQRT2_RCP, 0, SQRT2_RCP))
            && FromYaw(ToRad(180)).ApproximatelyEquals(new vec3(        0, 0,         1))
            && FromYaw(ToRad(270)).ApproximatelyEquals(new vec3(       -1, 0,         0))
            && FromYaw(ToRad(360)).ApproximatelyEquals(new vec3(        0, 0,        -1))
        );

        RESULT("FromRol()", true
            && FromRol(        0 ).ApproximatelyEquals(new vec3(        0,         1, 0))
            && FromRol(ToRad( 45)).ApproximatelyEquals(new vec3(SQRT2_RCP, SQRT2_RCP, 0))
            && FromRol(ToRad( 90)).ApproximatelyEquals(new vec3(        1,         0, 0))
            && FromRol(ToRad(135)).ApproximatelyEquals(new vec3(SQRT2_RCP,-SQRT2_RCP, 0))
            && FromRol(ToRad(180)).ApproximatelyEquals(new vec3(        0,        -1, 0))
            && FromRol(ToRad(270)).ApproximatelyEquals(new vec3(       -1,         0, 0))
            && FromRol(ToRad(360)).ApproximatelyEquals(new vec3(        0,         1, 0))
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("FromPchYaw()", true
            && FromPchYaw(ToRad(-360), 0).ApproximatelyEquals(new vec3 ( 0, 0,-1))
            && FromPchYaw(ToRad(-270), 0).ApproximatelyEquals(new vec3 ( 0,-1, 0))
            && FromPchYaw(ToRad(-180), 0).ApproximatelyEquals(new vec3 ( 0, 0, 1))
            && FromPchYaw(ToRad( -90), 0).ApproximatelyEquals(new vec3 ( 0, 1, 0))
            && FromPchYaw(         0 , 0).ApproximatelyEquals(new vec3 ( 0, 0,-1))
            && FromPchYaw(ToRad(  90), 0).ApproximatelyEquals(new vec3 ( 0,-1, 0))
            && FromPchYaw(ToRad( 180), 0).ApproximatelyEquals(new vec3 ( 0, 0, 1))
            && FromPchYaw(ToRad( 270), 0).ApproximatelyEquals(new vec3 ( 0, 1, 0))
            && FromPchYaw(ToRad( 360), 0).ApproximatelyEquals(new vec3 ( 0, 0,-1))

            && FromPchYaw( 0,ToRad(-360)).ApproximatelyEquals(new vec3 ( 0, 0,-1))
            && FromPchYaw( 0,ToRad(-270)).ApproximatelyEquals(new vec3 ( 1, 0, 0))
            && FromPchYaw( 0,ToRad(-180)).ApproximatelyEquals(new vec3 ( 0, 0, 1))
            && FromPchYaw( 0,ToRad( -90)).ApproximatelyEquals(new vec3 (-1, 0, 0))
            && FromPchYaw( 0,         0 ).ApproximatelyEquals(new vec3 ( 0, 0,-1))
            && FromPchYaw( 0,ToRad(  90)).ApproximatelyEquals(new vec3 ( 1, 0, 0))
            && FromPchYaw( 0,ToRad( 180)).ApproximatelyEquals(new vec3 ( 0, 0, 1))
            && FromPchYaw( 0,ToRad( 270)).ApproximatelyEquals(new vec3 (-1, 0, 0))
            && FromPchYaw( 0,ToRad( 360)).ApproximatelyEquals(new vec3 ( 0, 0,-1))
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("RotFromVec()", true
            && RotFromVec(new vec3 ( 0, 0,-1))                .ApproximatelyEquals(new vec3(         0,         0, 0))
            && RotFromVec(new vec3 ( 0,-1, 0))                .ApproximatelyEquals(new vec3(ToRad( 90),         0, 0))
            && RotFromVec(new vec3 ( 0, 0, 1))                .ApproximatelyEquals(new vec3(         0,ToRad(180), 0))
            && RotFromVec(new vec3 ( 0, 1, 0))                .ApproximatelyEquals(new vec3(ToRad(-90),         0, 0))

            && RotFromVec(new vec3 ( 0, 0,-1))                .ApproximatelyEquals(new vec3(         0,         0, 0))
            && RotFromVec(new vec3 ( 1, 0, 0))                .ApproximatelyEquals(new vec3(         0,ToRad( 90), 0))
            && RotFromVec(new vec3 ( 0, 0, 1))                .ApproximatelyEquals(new vec3(         0,ToRad(180), 0))
            && RotFromVec(new vec3 (-1, 0, 0))                .ApproximatelyEquals(new vec3(         0,ToRad(270), 0))

            && RotFromVec(new vec3 ( 0,-SQRT2_RCP,-SQRT2_RCP)).ApproximatelyEquals(new vec3(ToRad( 45),         0, 0))
            && RotFromVec(new vec3 ( 0,-SQRT2_RCP, SQRT2_RCP)).ApproximatelyEquals(new vec3(ToRad( 45),ToRad(180), 0))
            && RotFromVec(new vec3 ( 0, SQRT2_RCP, SQRT2_RCP)).ApproximatelyEquals(new vec3(ToRad(-45),ToRad(180), 0))
            && RotFromVec(new vec3 ( 0, SQRT2_RCP,-SQRT2_RCP)).ApproximatelyEquals(new vec3(ToRad(-45),         0, 0))

            && RotFromVec(new vec3 ( SQRT2_RCP, 0,-SQRT2_RCP)).ApproximatelyEquals(new vec3(         0,ToRad( 45), 0))
            && RotFromVec(new vec3 ( SQRT2_RCP, 0, SQRT2_RCP)).ApproximatelyEquals(new vec3(         0,ToRad(135), 0))
            && RotFromVec(new vec3 (-SQRT2_RCP, 0, SQRT2_RCP)).ApproximatelyEquals(new vec3(         0,ToRad(225), 0))
            && RotFromVec(new vec3 (-SQRT2_RCP, 0,-SQRT2_RCP)).ApproximatelyEquals(new vec3(         0,ToRad(315), 0))
        );

        //======================================================================================================================================================
    }
}
