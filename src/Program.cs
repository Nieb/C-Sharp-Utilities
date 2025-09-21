

namespace UtilityTest;
internal static partial class Program {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    static void Main(string[] args) {
        //Test__Float();
        //Test__Intrinsics();

        //Gen__TurboColor();

        #if true
            PRINTC("                                  ~~~ START ~~~");
            Time Time = new();

            Test__Integer();

            Test__String();

            Test__Vector();
            Test__VectorArray();
            Test__VectorBasicOps();
            Test__VectorMatrix4();

            Test__Vector_Collision2();
            Test__Vector_Collision3();
            Test__Vector_Color();
            Test__Vector_Generate();
            Test__Vector_Geometry();
            Test__Vector_Interpolation();
            Test__Vector_Miscellaneous();
            Test__Vector_Rotation();


            Test___();

            Time.Update();
            PRINT("\n                                 ~~~ FINISH ~~~");
            PRINT($"\n                                   {Time.SinceStart,10:0.0000000}\n");
        #endif
    }
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
