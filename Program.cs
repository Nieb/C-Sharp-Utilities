
namespace TEST;
internal static partial class Program {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    static void Main(string[] args) {
        #if false
            PRINT($"{BAR}\n{BAR}");
            Test__Float();
        #endif

        #if false
            PRINT($"\n\n{BAR}\n{BAR}");
            Test__Intrinsics();
        #endif

        #if false
            PRINT($"\n\n{BAR}\n{BAR}");
            DebugStruct(typeof(vec2));
            DebugStruct(typeof(ivec2));
            DebugStruct(typeof(vec3));
            DebugStruct(typeof(ivec3));
            DebugStruct(typeof(vec4));
            DebugStruct(typeof(ivec4));
        #endif

        PRINT($"{BAR}\n{BAR}");
        PRINT("\n\n                                 ~~~ START ~~~", false);
        Time Time = new();

        Test__Integer();

        Test__String();

        Test__Vector();
        Test__VectorArray();
        Test__VectorBasicOps();

        Test__Vector_Collision2();
        Test__Vector_Collision3();
        Test__Vector_Color();
        Test__Vector_Generate();
        Test__Vector_Interpolation();
        Test__Vector_Rotation();

        Test___();

        Time.Update();
        PRINT("\n                                 ~~~ FINISH ~~~");

        PRINT($"\n                                   {Time.Seconds,10:0.0000000}\n");
        //PRINT($"\n\n\n\n{Time}\n");
    }
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
