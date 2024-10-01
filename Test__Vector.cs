
namespace TEST;
internal static partial class Program {
    static void Test__Vector() {
        PRINT("\n[Utility.VEC]");

        //======================================================================================================================================================
        RESULT("abs()", true
            &&    abs(-2f) == 2f    &&    abs(new vec2(-2f)) == new vec2(2f)    &&    abs(new vec3(-2f)) == new vec3(2f)    &&    abs(new vec4(-2f)) == new vec4(2f)
            &&    abs(-1f) == 1f    &&    abs(new vec2(-1f)) == new vec2(1f)    &&    abs(new vec3(-1f)) == new vec3(1f)    &&    abs(new vec4(-1f)) == new vec4(1f)
            &&    abs( 0f) == 0f    &&    abs(new vec2( 0f)) == new vec2(0f)    &&    abs(new vec3( 0f)) == new vec3(0f)    &&    abs(new vec4( 0f)) == new vec4(0f)
            &&    abs( 1f) == 1f    &&    abs(new vec2( 1f)) == new vec2(1f)    &&    abs(new vec3( 1f)) == new vec3(1f)    &&    abs(new vec4( 1f)) == new vec4(1f)
            &&    abs( 2f) == 2f    &&    abs(new vec2( 2f)) == new vec2(2f)    &&    abs(new vec3( 2f)) == new vec3(2f)    &&    abs(new vec4( 2f)) == new vec4(2f)
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("avg()", true
            &&    avg(0f, 1f        ) == 0.5f    &&    avg(new vec2(0f), new vec2(1f)                            ) == new vec2(0.5f)    &&    avg(new vec3(0f), new vec3(1f)                            ) == new vec3(0.5f)
            &&    avg(0f, 1f, 2f    ) == 1.0f    &&    avg(new vec2(0f), new vec2(1f), new vec2(2f)              ) == new vec2(1.0f)    &&    avg(new vec3(0f), new vec3(1f), new vec3(2f)              ) == new vec3(1.0f)
            &&    avg(0f, 1f, 2f, 3f) == 1.5f    &&    avg(new vec2(0f), new vec2(1f), new vec2(2f), new vec2(3f)) == new vec2(1.5f)    &&    avg(new vec3(0f), new vec3(1f), new vec3(2f), new vec3(3f)) == new vec3(1.5f)
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("clamp()", true
            && clamp(-3f, -1f, 1f) == -1f
            && clamp(-2f, -1f, 1f) == -1f
            && clamp(-1f, -1f, 1f) == -1f
            && clamp( 0f, -1f, 1f) ==  0f
            && clamp( 1f, -1f, 1f) ==  1f
            && clamp( 2f, -1f, 1f) ==  1f
            && clamp( 3f, -1f, 1f) ==  1f
        );

        RESULT("wrap()", true
            && wrap(-8f, 0f, 4f) == 0f
            && wrap(-7f, 0f, 4f) == 1f
            && wrap(-6f, 0f, 4f) == 2f
            && wrap(-5f, 0f, 4f) == 3f
            && wrap(-4f, 0f, 4f) == 0f
            && wrap(-3f, 0f, 4f) == 1f
            && wrap(-2f, 0f, 4f) == 2f
            && wrap(-1f, 0f, 4f) == 3f
            && wrap( 0f, 0f, 4f) == 0f
            && wrap( 1f, 0f, 4f) == 1f
            && wrap( 2f, 0f, 4f) == 2f
            && wrap( 3f, 0f, 4f) == 3f
            && wrap( 4f, 0f, 4f) == 0f
            && wrap( 5f, 0f, 4f) == 1f
            && wrap( 6f, 0f, 4f) == 2f
            && wrap( 7f, 0f, 4f) == 3f
            && wrap( 8f, 0f, 4f) == 0f
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("min()", true
            && min(-2f,  2f) == -2f
            && min(-1f,  1f) == -1f
            && min(-1f, -1f) == -1f
            && min( 0f,  0f) ==  0f
            && min( 1f,  1f) ==  1f
            && min( 1f, -1f) == -1f
            && min( 2f, -2f) == -2f
        );

        RESULT("max()", true
            && max(-2f,  2f) ==  2f
            && max(-1f,  1f) ==  1f
            && max(-1f, -1f) == -1f
            && max( 0f,  0f) ==  0f
            && max( 1f,  1f) ==  1f
            && max( 1f, -1f) ==  1f
            && max( 2f, -2f) ==  2f
        );

        //======================================================================================================================================================
    }
}
