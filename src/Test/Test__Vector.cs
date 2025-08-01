
namespace TEST;
internal static partial class Program {
    static void Test__Vector() {
        PRINT("\n[Utility.VEC]");
        //PRINT($"{}");

        //======================================================================================================================================================
        #if false
            PRINT($"\n\n{BAR}\n{BAR}");
            DebugStruct(typeof(vec2));
            DebugStruct(typeof(ivec2));
            DebugStruct(typeof(vec3));
            DebugStruct(typeof(ivec3));
            DebugStruct(typeof(vec4));
            DebugStruct(typeof(ivec4));
        #endif

        //======================================================================================================================================================
        RESULT("iVec2 has Value/Magnitude/Length", true
            && new ivec2(0, 0) == false
            && new ivec2(1, 0)
            && new ivec2(0, 1)
            && new ivec2(1, 1)
        );
        RESULT("Vec2 has Value/Magnitude/Length", true
            && new vec2(0f, 0f) == false
            && new vec2(1f, 0f)
            && new vec2(0f, 1f)
            && new vec2(1f, 1f)
        );

        //======================================================================================================================================================
        RESULT("iVec3 has Value/Magnitude/Length", true
            && new ivec3(0, 0, 0) == false
            && new ivec3(1, 0, 0)
            && new ivec3(0, 1, 0)
            && new ivec3(1, 1, 0)
            && new ivec3(0, 0, 1)
            && new ivec3(1, 0, 1)
            && new ivec3(0, 1, 1)
            && new ivec3(1, 1, 1)
        );
        RESULT("Vec3 has Value/Magnitude/Length", true
            && new vec3(0f, 0f, 0f) == false
            && new vec3(1f, 0f, 0f)
            && new vec3(0f, 1f, 0f)
            && new vec3(1f, 1f, 0f)
            && new vec3(0f, 0f, 1f)
            && new vec3(1f, 0f, 1f)
            && new vec3(0f, 1f, 1f)
            && new vec3(1f, 1f, 1f)
        );

        //======================================================================================================================================================
        RESULT("iVec4 has Value/Magnitude/Length", true
            && new ivec4(0, 0, 0, 0) == false
            && new ivec4(0, 0, 0, 1)
            && new ivec4(0, 0, 1, 0)
            && new ivec4(0, 0, 1, 1)
            && new ivec4(0, 1, 0, 0)
            && new ivec4(0, 1, 0, 1)
            && new ivec4(0, 1, 1, 0)
            && new ivec4(0, 1, 1, 1)
            && new ivec4(1, 0, 0, 0)
            && new ivec4(1, 0, 0, 1)
            && new ivec4(1, 0, 1, 0)
            && new ivec4(1, 0, 1, 1)
            && new ivec4(1, 1, 0, 0)
            && new ivec4(1, 1, 0, 1)
            && new ivec4(1, 1, 1, 0)
            && new ivec4(1, 1, 1, 1)
        );
        RESULT("Vec4 has Value/Magnitude/Length", true
            && new vec4(0f, 0f, 0f, 0f) == false
            && new vec4(0f, 0f, 0f, 1f)
            && new vec4(0f, 0f, 1f, 0f)
            && new vec4(0f, 0f, 1f, 1f)
            && new vec4(0f, 1f, 0f, 0f)
            && new vec4(0f, 1f, 0f, 1f)
            && new vec4(0f, 1f, 1f, 0f)
            && new vec4(0f, 1f, 1f, 1f)
            && new vec4(1f, 0f, 0f, 0f)
            && new vec4(1f, 0f, 0f, 1f)
            && new vec4(1f, 0f, 1f, 0f)
            && new vec4(1f, 0f, 1f, 1f)
            && new vec4(1f, 1f, 0f, 0f)
            && new vec4(1f, 1f, 0f, 1f)
            && new vec4(1f, 1f, 1f, 0f)
            && new vec4(1f, 1f, 1f, 1f)
        );

        //======================================================================================================================================================
    }
}
