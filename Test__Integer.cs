
namespace TEST;
internal static partial class Program {
    static void Test__Integer() {
        PRINT("\n[Utility.INT]");
        //PRINT($"{}");

        //======================================================================================================================================================
        RESULT("abs()", true
            && abs(-2) == 2
            && abs(-1) == 1
            && abs( 0) == 0
            && abs( 1) == 1
            && abs( 2) == 2
        );

        //======================================================================================================================================================
        RESULT("clamp()", true
            &&    clamp(-8, -5, -3) == -5    &&    clamp(-8, -2,  3) == -2    &&    clamp(-8,  1,  5) ==  1
            &&    clamp(-7, -5, -3) == -5    &&    clamp(-7, -2,  3) == -2    &&    clamp(-7,  1,  5) ==  1
            &&    clamp(-6, -5, -3) == -5    &&    clamp(-6, -2,  3) == -2    &&    clamp(-6,  1,  5) ==  1
            &&    clamp(-5, -5, -3) == -5    &&    clamp(-5, -2,  3) == -2    &&    clamp(-5,  1,  5) ==  1
            &&    clamp(-4, -5, -3) == -4    &&    clamp(-4, -2,  3) == -2    &&    clamp(-4,  1,  5) ==  1
            &&    clamp(-3, -5, -3) == -3    &&    clamp(-3, -2,  3) == -2    &&    clamp(-3,  1,  5) ==  1
            &&    clamp(-2, -5, -3) == -3    &&    clamp(-2, -2,  3) == -2    &&    clamp(-2,  1,  5) ==  1
            &&    clamp(-1, -5, -3) == -3    &&    clamp(-1, -2,  3) == -1    &&    clamp(-1,  1,  5) ==  1
            &&    clamp( 0, -5, -3) == -3    &&    clamp( 0, -2,  3) ==  0    &&    clamp( 0,  1,  5) ==  1
            &&    clamp( 1, -5, -3) == -3    &&    clamp( 1, -2,  3) ==  1    &&    clamp( 1,  1,  5) ==  1
            &&    clamp( 2, -5, -3) == -3    &&    clamp( 2, -2,  3) ==  2    &&    clamp( 2,  1,  5) ==  2
            &&    clamp( 3, -5, -3) == -3    &&    clamp( 3, -2,  3) ==  3    &&    clamp( 3,  1,  5) ==  3
            &&    clamp( 4, -5, -3) == -3    &&    clamp( 4, -2,  3) ==  3    &&    clamp( 4,  1,  5) ==  4
            &&    clamp( 5, -5, -3) == -3    &&    clamp( 5, -2,  3) ==  3    &&    clamp( 5,  1,  5) ==  5
            &&    clamp( 6, -5, -3) == -3    &&    clamp( 6, -2,  3) ==  3    &&    clamp( 6,  1,  5) ==  5
            &&    clamp( 7, -5, -3) == -3    &&    clamp( 7, -2,  3) ==  3    &&    clamp( 7,  1,  5) ==  5
            &&    clamp( 8, -5, -3) == -3    &&    clamp( 8, -2,  3) ==  3    &&    clamp( 8,  1,  5) ==  5
        );

        RESULT("wrap()", true
            &&    wrap(-8, 0, 4) == 0    &&    wrap(-8, -2, 2) ==  0    &&    wrap(-8, -6, -2) == -4
            &&    wrap(-7, 0, 4) == 1    &&    wrap(-7, -2, 2) ==  1    &&    wrap(-7, -6, -2) == -3
            &&    wrap(-6, 0, 4) == 2    &&    wrap(-6, -2, 2) == -2    &&    wrap(-6, -6, -2) == -6
            &&    wrap(-5, 0, 4) == 3    &&    wrap(-5, -2, 2) == -1    &&    wrap(-5, -6, -2) == -5
            &&    wrap(-4, 0, 4) == 0    &&    wrap(-4, -2, 2) ==  0    &&    wrap(-4, -6, -2) == -4
            &&    wrap(-3, 0, 4) == 1    &&    wrap(-3, -2, 2) ==  1    &&    wrap(-3, -6, -2) == -3
            &&    wrap(-2, 0, 4) == 2    &&    wrap(-2, -2, 2) == -2    &&    wrap(-2, -6, -2) == -6
            &&    wrap(-1, 0, 4) == 3    &&    wrap(-1, -2, 2) == -1    &&    wrap(-1, -6, -2) == -5
            &&    wrap( 0, 0, 4) == 0    &&    wrap( 0, -2, 2) ==  0    &&    wrap( 0, -6, -2) == -4
            &&    wrap( 1, 0, 4) == 1    &&    wrap( 1, -2, 2) ==  1    &&    wrap( 1, -6, -2) == -3
            &&    wrap( 2, 0, 4) == 2    &&    wrap( 2, -2, 2) == -2    &&    wrap( 2, -6, -2) == -6
            &&    wrap( 3, 0, 4) == 3    &&    wrap( 3, -2, 2) == -1    &&    wrap( 3, -6, -2) == -5
            &&    wrap( 4, 0, 4) == 0    &&    wrap( 4, -2, 2) ==  0    &&    wrap( 4, -6, -2) == -4
            &&    wrap( 5, 0, 4) == 1    &&    wrap( 5, -2, 2) ==  1    &&    wrap( 5, -6, -2) == -3
            &&    wrap( 6, 0, 4) == 2    &&    wrap( 6, -2, 2) == -2    &&    wrap( 6, -6, -2) == -6
            &&    wrap( 7, 0, 4) == 3    &&    wrap( 7, -2, 2) == -1    &&    wrap( 7, -6, -2) == -5
            &&    wrap( 8, 0, 4) == 0    &&    wrap( 8, -2, 2) ==  0    &&    wrap( 8, -6, -2) == -4
        );

        //======================================================================================================================================================
        RESULT("min()", true
            && min(-2,  2) == -2
            && min(-1,  1) == -1
            && min(-1, -1) == -1
            && min( 0,  0) ==  0
            && min( 1,  1) ==  1
            && min( 1, -1) == -1
            && min( 2, -2) == -2
        );

        RESULT("max()", true
            && max(-2,  2) ==  2
            && max(-1,  1) ==  1
            && max(-1, -1) == -1
            && max( 0,  0) ==  0
            && max( 1,  1) ==  1
            && max( 1, -1) ==  1
            && max( 2, -2) ==  2
        );

        //======================================================================================================================================================
        RESULT("trunk()", true
            && trunk((int)          2147483647, -2) == (int)            47483647
            && trunk((int)          2147483647,  2) == (int)          21474836
            && trunk((long)9223372036854775807, -2) == (long)  23372036854775807
            && trunk((long)9223372036854775807,  2) == (long)92233720368547758
        );

        //======================================================================================================================================================
    }
}
