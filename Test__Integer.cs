
namespace TEST;
internal static partial class Program {
    static void Test__Integer() {
        PRINT("\n[Utility.INT]");

        RESULT("abs()", true
            && (abs(-2) == 2)
            && (abs(-1) == 1)
            && (abs( 0) == 0)
            && (abs( 1) == 1)
            && (abs( 2) == 2)
        );

        RESULT("clamp()", true
            && (clamp(-3, -1, 1) == -1)
            && (clamp(-2, -1, 1) == -1)
            && (clamp(-1, -1, 1) == -1)
            && (clamp( 0, -1, 1) ==  0)
            && (clamp( 1, -1, 1) ==  1)
            && (clamp( 2, -1, 1) ==  1)
            && (clamp( 3, -1, 1) ==  1)
        );

        RESULT("wrap()", true
            && (wrap(-8, 0, 4) == 0)
            && (wrap(-7, 0, 4) == 1)
            && (wrap(-6, 0, 4) == 2)
            && (wrap(-5, 0, 4) == 3)
            && (wrap(-4, 0, 4) == 0)
            && (wrap(-3, 0, 4) == 1)
            && (wrap(-2, 0, 4) == 2)
            && (wrap(-1, 0, 4) == 3)
            && (wrap( 0, 0, 4) == 0)
            && (wrap( 1, 0, 4) == 1)
            && (wrap( 2, 0, 4) == 2)
            && (wrap( 3, 0, 4) == 3)
            && (wrap( 4, 0, 4) == 0)
            && (wrap( 5, 0, 4) == 1)
            && (wrap( 6, 0, 4) == 2)
            && (wrap( 7, 0, 4) == 3)
            && (wrap( 8, 0, 4) == 0)
        );

        RESULT("min()", true
            && (min(-2,  2) == -2)
            && (min(-1,  1) == -1)
            && (min(-1, -1) == -1)
            && (min( 0,  0) ==  0)
            && (min( 1,  1) ==  1)
            && (min( 1, -1) == -1)
            && (min( 2, -2) == -2)
        );

        RESULT("max()", true
            && (max(-2,  2) ==  2)
            && (max(-1,  1) ==  1)
            && (max(-1, -1) == -1)
            && (max( 0,  0) ==  0)
            && (max( 1,  1) ==  1)
            && (max( 1, -1) ==  1)
            && (max( 2, -2) ==  2)
        );

        RESULT("trunc()", true
            && (trunc(12345 , -2) == 345 )
            && (trunc(12345 ,  2) == 123 )
            && (trunc(12345L, -2) == 345L)
            && (trunc(12345L,  2) == 123L)
        );
    }
}
