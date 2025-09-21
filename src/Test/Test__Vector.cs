
namespace UtilityTest;
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
        #if false

            PRINT($"");
            PRINT($"{BitCast.ToFloat(0x3EAAAAABu):F98}");
            PRINT($"{ONETHIRD:F98}");
            PRINT($"");
            PRINT($"{IntToBinaryString(0x3EAAAAABu)}");
            PRINT($"{IntToBinaryString(BitCast.ToUint(ONETHIRD))}");
            PRINT($"");
            PRINT($"");
            PRINT($"{BitCast.ToFloat(0x3F2AAAABu):F98}");
            PRINT($"{TWOTHIRD:F98}");
            PRINT($"{IntToBinaryString(0x3F2AAAABu)}");
            PRINT($"{IntToBinaryString(BitCast.ToUint(TWOTHIRD))}");
            PRINT($"");
            PRINT($"");
            PRINT($"");
            PRINT($"{0.000000000000123456f:F98}");

        #endif
        //======================================================================================================================================================
        #if false

            bvec4 A = 0xFF_CC_99_33u;
            PRINT($"");
            PRINT($"    A: {A:x}");
            PRINT($"  A.x: {A.x:x}");
            PRINT($"  A.y: {A.y:x}");
            PRINT($"  A.z: {A.z:x}");
            PRINT($"  A.w: {A.w:x}");

            uint  B = A;
            PRINT($"");
            PRINT($"    B: {B:x}");

            bvec4 C = B - 0x11111111u;
            PRINT($"");
            PRINT($"    C: {C:x}");
            C.x += 0x11;
            C.y += 0x11;
            C.z += 0x11;
            C.w += 0x11;
            PRINT($"    C: {C:x}");

            bvec4 D = new bvec4(0xFF, 0xCC, 0x99, 0x33);
            PRINT($"");
            PRINT($"    D: {D:x}");

            bvec4 E = (0xFF, 0xCC, 0x99, 0x33);
            PRINT($"");
            PRINT($"    E: {E:x}");
            E = E.ByteFlip;
            PRINT($"    E: {E:x}");

            //uint S = 0b_0101_0101; // = 0x55 =  85
            //uint Z = 0b_1010_1010; // = 0xAA = 170

        #endif
        //======================================================================================================================================================
    }
}
