
namespace TEST;
internal static partial class Program {
    static void Test__Vector_Generate() {
        PRINT("\n[Utility.VEC -- Generate]");




        RESULT("FromAng()", true
            && round(FromAng(0f  ), 0.000001f) == new vec2 ( 1f, 0f)
            && round(FromAng(PIH ), 0.000001f) == new vec2 ( 0f,-1f)
            && round(FromAng(PI  ), 0.000001f) == new vec2 (-1f, 0f)
            && round(FromAng(PI1H), 0.000001f) == new vec2 ( 0f, 1f)
            && round(FromAng(PI2 ), 0.000001f) == new vec2 ( 1f, 0f)
        );




        PRINT("");
        RESULT("FromPch()", false //@@ revisit these...
            && round(FromPch(0f  ), 0.000001f) == new vec3 (0f, 0f,-1f)
            && round(FromPch(PIH ), 0.000001f) == new vec3 (0f,-1f, 0f)
            && round(FromPch(PI  ), 0.000001f) == new vec3 (0f, 0f, 1f)
            && round(FromPch(PI1H), 0.000001f) == new vec3 (0f, 1f, 0f)
            && round(FromPch(PI2 ), 0.000001f) == new vec3 (0f, 0f,-1f)
        );

        RESULT("FromYaw()", false //@@ revisit these...
            && round(FromYaw(0f  ), 0.000001f) == new vec3 ( 1f, 0f, 0f)
            && round(FromYaw(PIH ), 0.000001f) == new vec3 ( 0f, 0f,-1f)
            && round(FromYaw(PI  ), 0.000001f) == new vec3 (-1f, 0f, 0f)
            && round(FromYaw(PI1H), 0.000001f) == new vec3 ( 0f, 0f, 1f)
            && round(FromYaw(PI2 ), 0.000001f) == new vec3 ( 1f, 0f, 0f)
        );

        RESULT("FromRol()", false //@@ revisit these...
            && round(FromRol(0f  ), 0.000001f) == new vec3 ( 1f, 0f, 0f)
            && round(FromRol(PIH ), 0.000001f) == new vec3 ( 0f,-1f, 0f)
            && round(FromRol(PI  ), 0.000001f) == new vec3 (-1f, 0f, 0f)
            && round(FromRol(PI1H), 0.000001f) == new vec3 ( 0f, 1f, 0f)
            && round(FromRol(PI2 ), 0.000001f) == new vec3 ( 1f, 0f, 0f)
        );




        PRINT("");
        RESULT("FromPchYaw()", false //@@ revisit these...
            && round(FromPchYaw(0f  , 0f  ), 0.000001f) == new vec3 ( 0f, 0f,-1f)

            && round(FromPchYaw(PIH , 0f  ), 0.000001f) == new vec3 ( 0f,-1f, 0f)
            && round(FromPchYaw(PI  , 0f  ), 0.000001f) == new vec3 ( 0f, 0f, 1f)
            && round(FromPchYaw(PI1H, 0f  ), 0.000001f) == new vec3 ( 0f, 1f, 0f)
            && round(FromPchYaw(PI2 , 0f  ), 0.000001f) == new vec3 ( 0f, 0f,-1f)

            && round(FromPchYaw(0f  , PIH ), 0.000001f) == new vec3 ( 1f, 0f, 0f)
            && round(FromPchYaw(0f  , PI  ), 0.000001f) == new vec3 ( 0f, 0f, 1f)
            && round(FromPchYaw(0f  , PI1H), 0.000001f) == new vec3 (-1f, 0f, 0f)
            && round(FromPchYaw(0f  , PI2 ), 0.000001f) == new vec3 ( 0f, 0f,-1f)
        );




        PRINT("");
        RESULT("RotFromVec()", true
            && RotFromVec(new vec3(   1f,    0f,    0f)) == new vec3(  0f, PIH,  0f)
            && RotFromVec(new vec3(   0f,    1f,    0f)) == new vec3(-PIH,  0f,  0f)
            && RotFromVec(new vec3(   0f,    0f,    1f)) == new vec3(  0f,  PI,  0f)    // ( -0.0,  0.0,  0.0 )
            && RotFromVec(new vec3(SQRT2, SQRT2,    0f)) == new vec3(  0f,  0f,  0f)    // (  NaN,  PIH,  0.0 )
            && RotFromVec(new vec3(   0f, SQRT2, SQRT2)) == new vec3(  0f,  0f,  0f)    // (  NaN,  0.0,  0.0 )
            && RotFromVec(new vec3(SQRT2,    0f, SQRT2)) == new vec3(  0f,  0f,  0f)    // ( -0.0,  0.785398,  0.0 )
        );


    }
}
