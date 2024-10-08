
namespace TEST;
internal static partial class Program {
    static void Test__Vector() {
        PRINT("\n\n[Utility.VEC]\n");
        //PRINT($"{}");

        //======================================================================================================================================================
        RESULT("abs()", true
            &&    abs(-2) == 2    &&    abs((-2,-2)) == (2,2)    &&    abs((-2,-2,-2)) == (2,2,2)    &&    abs((-2,-2,-2,-2)) == (2,2,2,2)
            &&    abs(-1) == 1    &&    abs((-1,-1)) == (1,1)    &&    abs((-1,-1,-1)) == (1,1,1)    &&    abs((-1,-1,-1,-1)) == (1,1,1,1)
            &&    abs( 0) == 0    &&    abs(( 0, 0)) == (0,0)    &&    abs(( 0, 0, 0)) == (0,0,0)    &&    abs(( 0, 0, 0, 0)) == (0,0,0,0)
            &&    abs( 1) == 1    &&    abs(( 1, 1)) == (1,1)    &&    abs(( 1, 1, 1)) == (1,1,1)    &&    abs(( 1, 1, 1, 1)) == (1,1,1,1)
            &&    abs( 2) == 2    &&    abs(( 2, 2)) == (2,2)    &&    abs(( 2, 2, 2)) == (2,2,2)    &&    abs(( 2, 2, 2, 2)) == (2,2,2,2)
        );

        //======================================================================================================================================================
        RESULT("avg()", true
            &&    avg(0, 1      ) == 0.5f    &&    avg((0,0), (1,1)              ) == (0.5f, 0.5f)    &&    avg((0,0,0), (1,1,1)                  ) == (0.5f, 0.5f, 0.5f)
            &&    avg(0, 1, 2   ) == 1.0f    &&    avg((0,0), (1,1), (2,2)       ) == (1.0f, 1.0f)    &&    avg((0,0,0), (1,1,1), (2,2,2)         ) == (1.0f, 1.0f, 1.0f)
            &&    avg(0, 1, 2, 3) == 1.5f    &&    avg((0,0), (1,1), (2,2), (3,3)) == (1.5f, 1.5f)    &&    avg((0,0,0), (1,1,1), (2,2,2), (3,3,3)) == (1.5f, 1.5f, 1.5f)
        );

        //======================================================================================================================================================
        RESULT("clamp()", true
            && clamp(-3, -1, 1) == -1
            && clamp(-2, -1, 1) == -1
            && clamp(-1, -1, 1) == -1
            && clamp( 0, -1, 1) ==  0
            && clamp( 1, -1, 1) ==  1
            && clamp( 2, -1, 1) ==  1
            && clamp( 3, -1, 1) ==  1
        );

        RESULT("wrap()", true
            && wrap(-8, 0, 4) == 0
            && wrap(-7, 0, 4) == 1
            && wrap(-6, 0, 4) == 2
            && wrap(-5, 0, 4) == 3
            && wrap(-4, 0, 4) == 0
            && wrap(-3, 0, 4) == 1
            && wrap(-2, 0, 4) == 2
            && wrap(-1, 0, 4) == 3
            && wrap( 0, 0, 4) == 0
            && wrap( 1, 0, 4) == 1
            && wrap( 2, 0, 4) == 2
            && wrap( 3, 0, 4) == 3
            && wrap( 4, 0, 4) == 0
            && wrap( 5, 0, 4) == 1
            && wrap( 6, 0, 4) == 2
            && wrap( 7, 0, 4) == 3
            && wrap( 8, 0, 4) == 0
        );

        //======================================================================================================================================================
        RESULT("min(A,B)", true
            && min(-2,  2) == -2
            && min(-1,  1) == -1
            && min(-1, -1) == -1
            && min( 0,  0) ==  0
            && min( 1,  1) ==  1
            && min( 1, -1) == -1
            && min( 2, -2) == -2
        );
        RESULT("min(A,B,C)", true
            && min(1,2,3) == 1
            && min(1,3,2) == 1
            && min(2,1,3) == 1
            && min(2,3,1) == 1
            && min(3,1,2) == 1
            && min(3,2,1) == 1
            && min(5,5,5) == 5
        );
        RESULT("min(A,B,C,D)", true
            && min(1,2,3,4) == 1
            && min(1,2,4,3) == 1
            && min(1,3,2,4) == 1
            && min(1,3,4,2) == 1
            && min(1,4,2,3) == 1
            && min(1,4,3,2) == 1
            && min(2,1,3,4) == 1
            && min(2,1,4,3) == 1
            && min(2,3,1,4) == 1
            && min(2,3,4,1) == 1
            && min(2,4,1,3) == 1
            && min(2,4,3,1) == 1
            && min(3,2,1,4) == 1
            && min(3,2,4,1) == 1
            && min(3,1,2,4) == 1
            && min(3,1,4,2) == 1
            && min(3,4,2,1) == 1
            && min(3,4,1,2) == 1
            && min(4,2,3,1) == 1
            && min(4,2,1,3) == 1
            && min(4,3,2,1) == 1
            && min(4,3,1,2) == 1
            && min(4,1,2,3) == 1
            && min(4,1,3,2) == 1
            && min(7,7,7,7) == 7
        );

        RESULT("max(A,B)", true
            && max(-2,  2) ==  2
            && max(-1,  1) ==  1
            && max(-1, -1) == -1
            && max( 0,  0) ==  0
            && max( 1,  1) ==  1
            && max( 1, -1) ==  1
            && max( 2, -2) ==  2
        );
        RESULT("max(A,B,C)", true
            && max(1,2,3) == 3
            && max(1,3,2) == 3
            && max(2,1,3) == 3
            && max(2,3,1) == 3
            && max(3,1,2) == 3
            && max(3,2,1) == 3
            && max(5,5,5) == 5
        );
        RESULT("max(A,B,C,D)", true
            && max(1,2,3,4) == 4
            && max(1,2,4,3) == 4
            && max(1,3,2,4) == 4
            && max(1,3,4,2) == 4
            && max(1,4,2,3) == 4
            && max(1,4,3,2) == 4
            && max(2,1,3,4) == 4
            && max(2,1,4,3) == 4
            && max(2,3,1,4) == 4
            && max(2,3,4,1) == 4
            && max(2,4,1,3) == 4
            && max(2,4,3,1) == 4
            && max(3,2,1,4) == 4
            && max(3,2,4,1) == 4
            && max(3,1,2,4) == 4
            && max(3,1,4,2) == 4
            && max(3,4,2,1) == 4
            && max(3,4,1,2) == 4
            && max(4,2,3,1) == 4
            && max(4,2,1,3) == 4
            && max(4,3,2,1) == 4
            && max(4,3,1,2) == 4
            && max(4,1,2,3) == 4
            && max(4,1,3,2) == 4
            && max(7,7,7,7) == 7
        );

        //======================================================================================================================================================
    }
}
