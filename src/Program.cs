global using Utility;
global using static Utility.ENM;
global using static Utility.INT;
global using static Utility.STR;
global using static Utility.VEC;
global using static Utility.VEC_Color;
global using static Utility.VEC_Collision2;
global using static Utility.VEC_Collision3;
global using static Utility.VEC_Filter;
global using static Utility.VEC_Geometry;
global using static Utility.VEC_Generate;
global using static Utility.VEC_Interpolation;
global using static Utility.VEC_Miscellaneous;
global using static Utility.VEC_Rotation;

namespace UtilityTest;
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
            Gen__TurboColor();
        #endif
        #if false
            //PRINT($"{BAR}\n{BAR}");
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
        #endif
    }
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
