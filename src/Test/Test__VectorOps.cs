
namespace UtilityTest;
internal static partial class Program {
    static void Test__VectorBasicOps() {
        PRINT("\n[Utility.VEC Ops]");
        //PRINT($"{}");

        //======================================================================================================================================================
        RESULT("abs()", true
            &&    abs(-2f) == 2f    &&    abs((-2f,-2f)) == (2f,2f)    &&    abs((-2f,-2f,-2f)) == (2f,2f,2f)    &&    abs((-2f,-2f,-2f,-2f)) == (2f,2f,2f,2f)
            &&    abs(-1f) == 1f    &&    abs((-1f,-1f)) == (1f,1f)    &&    abs((-1f,-1f,-1f)) == (1f,1f,1f)    &&    abs((-1f,-1f,-1f,-1f)) == (1f,1f,1f,1f)
            &&    abs( 0f) == 0f    &&    abs(( 0f, 0f)) == (0f,0f)    &&    abs(( 0f, 0f, 0f)) == (0f,0f,0f)    &&    abs(( 0f, 0f, 0f, 0f)) == (0f,0f,0f,0f)
            &&    abs( 1f) == 1f    &&    abs(( 1f, 1f)) == (1f,1f)    &&    abs(( 1f, 1f, 1f)) == (1f,1f,1f)    &&    abs(( 1f, 1f, 1f, 1f)) == (1f,1f,1f,1f)
            &&    abs( 2f) == 2f    &&    abs(( 2f, 2f)) == (2f,2f)    &&    abs(( 2f, 2f, 2f)) == (2f,2f,2f)    &&    abs(( 2f, 2f, 2f, 2f)) == (2f,2f,2f,2f)
        );

        //======================================================================================================================================================
        RESULT("avg()", true
            && avg(0f,1f      ) == 0.5f
            && avg(0f,1f,2f   ) == 1.0f
            && avg(0f,1f,2f,3f) == 1.5f

            && avg((0f,0f), (1f,1f)                  ) == (0.5f, 0.5f)
            && avg((0f,0f), (1f,1f), (2f,2f)         ) == (1.0f, 1.0f)
            && avg((0f,0f), (1f,1f), (2f,2f), (3f,3f)) == (1.5f, 1.5f)

            && avg((0f,0f,0f), (1f,1f,1f)                        ) == (0.5f, 0.5f, 0.5f)
            && avg((0f,0f,0f), (1f,1f,1f), (2f,2f,2f)            ) == (1.0f, 1.0f, 1.0f)
            && avg((0f,0f,0f), (1f,1f,1f), (2f,2f,2f), (3f,3f,3f)) == (1.5f, 1.5f, 1.5f)
        );

        //======================================================================================================================================================
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
        RESULT("distance(A,B)", true
            && distance((-1f, -1f), ( 1f,  1f)) == (2f * SQRT2)
            && distance(( 1f,  1f), (-1f, -1f)) == (2f * SQRT2)

            && distance((-1f,  1f), ( 1f, -1f)) == (2f * SQRT2)
            && distance(( 1f, -1f), (-1f,  1f)) == (2f * SQRT2)

            && distance((-1f, -1f, -1f), ( 1f,  1f,  1f)) == (2f * SQRT3)
            && distance(( 1f,  1f,  1f), (-1f, -1f, -1f)) == (2f * SQRT3)

            && distance((-1f, -1f,  1f), ( 1f,  1f, -1f)) == (2f * SQRT3)
            && distance(( 1f,  1f, -1f), (-1f, -1f,  1f)) == (2f * SQRT3)

            && distance((-1f,  1f, -1f), ( 1f, -1f,  1f)) == (2f * SQRT3)
            && distance(( 1f, -1f,  1f), (-1f,  1f, -1f)) == (2f * SQRT3)

            && distance(( 1f, -1f, -1f), (-1f,  1f,  1f)) == (2f * SQRT3)
            && distance((-1f,  1f,  1f), ( 1f, -1f, -1f)) == (2f * SQRT3)
        );

        //======================================================================================================================================================
        RESULT("normalize(A)", true
            && normalize((-5f, -5f)) == (-SQRT2_RCP,-SQRT2_RCP)
            && normalize((-1f, -1f)) == (-SQRT2_RCP,-SQRT2_RCP)
            && normalize(( 1f,  1f)) == ( SQRT2_RCP, SQRT2_RCP)
            && normalize(( 5f,  5f)) == ( SQRT2_RCP, SQRT2_RCP)

            && normalize((-5f, -5f, -5f)) == (-SQRT3_RCP,-SQRT3_RCP,-SQRT3_RCP)
            && normalize((-1f, -1f, -1f)) == (-SQRT3_RCP,-SQRT3_RCP,-SQRT3_RCP)
            && normalize(( 1f,  1f,  1f)) == ( SQRT3_RCP, SQRT3_RCP, SQRT3_RCP)
            && normalize(( 5f,  5f,  5f)) == ( SQRT3_RCP, SQRT3_RCP, SQRT3_RCP)
        );

        //======================================================================================================================================================
        RESULT("min(A,B)", true
            && min(-2f,  2f) == -2f
            && min(-1f,  1f) == -1f
            && min(-1f, -1f) == -1f
            && min( 0f,  0f) ==  0f
            && min( 1f,  1f) ==  1f
            && min( 1f, -1f) == -1f
            && min( 2f, -2f) == -2f
        );
        RESULT("min(A,B,C)", true
            && min(1f,2f,3f) == 1f
            && min(1f,3f,2f) == 1f
            && min(2f,1f,3f) == 1f
            && min(2f,3f,1f) == 1f
            && min(3f,1f,2f) == 1f
            && min(3f,2f,1f) == 1f
            && min(5f,5f,5f) == 5f
        );
        RESULT("min(A,B,C,D)", true
            && min(1f,2f,3f,4f) == 1f
            && min(1f,2f,4f,3f) == 1f
            && min(1f,3f,2f,4f) == 1f
            && min(1f,3f,4f,2f) == 1f
            && min(1f,4f,2f,3f) == 1f
            && min(1f,4f,3f,2f) == 1f
            && min(2f,1f,3f,4f) == 1f
            && min(2f,1f,4f,3f) == 1f
            && min(2f,3f,1f,4f) == 1f
            && min(2f,3f,4f,1f) == 1f
            && min(2f,4f,1f,3f) == 1f
            && min(2f,4f,3f,1f) == 1f
            && min(3f,2f,1f,4f) == 1f
            && min(3f,2f,4f,1f) == 1f
            && min(3f,1f,2f,4f) == 1f
            && min(3f,1f,4f,2f) == 1f
            && min(3f,4f,2f,1f) == 1f
            && min(3f,4f,1f,2f) == 1f
            && min(4f,2f,3f,1f) == 1f
            && min(4f,2f,1f,3f) == 1f
            && min(4f,3f,2f,1f) == 1f
            && min(4f,3f,1f,2f) == 1f
            && min(4f,1f,2f,3f) == 1f
            && min(4f,1f,3f,2f) == 1f
            && min(7f,7f,7f,7f) == 7f
        );

        RESULT("max(A,B)", true
            && max(-2f,  2f) ==  2f
            && max(-1f,  1f) ==  1f
            && max(-1f, -1f) == -1f
            && max( 0f,  0f) ==  0f
            && max( 1f,  1f) ==  1f
            && max( 1f, -1f) ==  1f
            && max( 2f, -2f) ==  2f
        );
        RESULT("max(A,B,C)", true
            && max(1f,2f,3f) == 3f
            && max(1f,3f,2f) == 3f
            && max(2f,1f,3f) == 3f
            && max(2f,3f,1f) == 3f
            && max(3f,1f,2f) == 3f
            && max(3f,2f,1f) == 3f
            && max(5f,5f,5f) == 5f
        );
        RESULT("max(A,B,C,D)", true
            && max(1f,2f,3f,4f) == 4f
            && max(1f,2f,4f,3f) == 4f
            && max(1f,3f,2f,4f) == 4f
            && max(1f,3f,4f,2f) == 4f
            && max(1f,4f,2f,3f) == 4f
            && max(1f,4f,3f,2f) == 4f
            && max(2f,1f,3f,4f) == 4f
            && max(2f,1f,4f,3f) == 4f
            && max(2f,3f,1f,4f) == 4f
            && max(2f,3f,4f,1f) == 4f
            && max(2f,4f,1f,3f) == 4f
            && max(2f,4f,3f,1f) == 4f
            && max(3f,2f,1f,4f) == 4f
            && max(3f,2f,4f,1f) == 4f
            && max(3f,1f,2f,4f) == 4f
            && max(3f,1f,4f,2f) == 4f
            && max(3f,4f,2f,1f) == 4f
            && max(3f,4f,1f,2f) == 4f
            && max(4f,2f,3f,1f) == 4f
            && max(4f,2f,1f,3f) == 4f
            && max(4f,3f,2f,1f) == 4f
            && max(4f,3f,1f,2f) == 4f
            && max(4f,1f,2f,3f) == 4f
            && max(4f,1f,3f,2f) == 4f
            && max(7f,7f,7f,7f) == 7f
        );

        //======================================================================================================================================================
        RESULT("round(A, RoundTo)", true
            && round(-2.0f, 0.5f) == -2.0f
            && round(-1.9f, 0.5f) == -2.0f
            && round(-1.8f, 0.5f) == -2.0f

            && round(-1.7f, 0.5f) == -1.5f
            && round(-1.6f, 0.5f) == -1.5f
            && round(-1.5f, 0.5f) == -1.5f
            && round(-1.4f, 0.5f) == -1.5f
            && round(-1.3f, 0.5f) == -1.5f

            && round(-1.2f, 0.5f) == -1.0f
            && round(-1.1f, 0.5f) == -1.0f
            && round(-1.0f, 0.5f) == -1.0f
            && round(-0.9f, 0.5f) == -1.0f
            && round(-0.8f, 0.5f) == -1.0f

            && round(-0.7f, 0.5f) == -0.5f
            && round(-0.6f, 0.5f) == -0.5f
            && round(-0.5f, 0.5f) == -0.5f
            && round(-0.4f, 0.5f) == -0.5f
            && round(-0.3f, 0.5f) == -0.5f

            && round(-0.2f, 0.5f) == -0.0f
            && round(-0.1f, 0.5f) == -0.0f
            && round( 0.0f, 0.5f) == 0.0f
            && round( 0.1f, 0.5f) == 0.0f
            && round( 0.2f, 0.5f) == 0.0f

            && round( 0.3f, 0.5f) == 0.5f
            && round( 0.4f, 0.5f) == 0.5f
            && round( 0.5f, 0.5f) == 0.5f
            && round( 0.6f, 0.5f) == 0.5f
            && round( 0.7f, 0.5f) == 0.5f

            && round( 0.8f, 0.5f) == 1.0f
            && round( 0.9f, 0.5f) == 1.0f
            && round( 1.0f, 0.5f) == 1.0f
            && round( 1.1f, 0.5f) == 1.0f
            && round( 1.2f, 0.5f) == 1.0f

            && round( 1.3f, 0.5f) == 1.5f
            && round( 1.4f, 0.5f) == 1.5f
            && round( 1.5f, 0.5f) == 1.5f
            && round( 1.6f, 0.5f) == 1.5f
            && round( 1.7f, 0.5f) == 1.5f

            && round( 1.8f, 0.5f) == 2.0f
            && round( 1.9f, 0.5f) == 2.0f
            && round( 2.0f, 0.5f) == 2.0f
        );

        //======================================================================================================================================================
    }
}
