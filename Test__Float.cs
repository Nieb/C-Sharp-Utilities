
namespace TEST;
internal static partial class Program {
    static void Test__Float() {
        PRINT("\n[FLOAT]");
        //PRINT($"{}");

        //======================================================================================================================================================
        #pragma warning disable 1718 // "Comparison made to same variable."
        PRINT($"            RAY_MISS == RAY_MISS: {RAY_MISS == RAY_MISS}");
        PRINT($"");
        PRINT($"                      NaN == NaN: {FLOAT_NaN == FLOAT_NaN}");
        PRINT($"                      NaN != NaN: {FLOAT_NaN != FLOAT_NaN}");
        PRINT($"");
        PRINT($"                      Inf == Inf: {FLOAT_INF == FLOAT_INF}");
        PRINT($"                      Inf != Inf: {FLOAT_INF != FLOAT_INF}");
        PRINT($"");
        PRINT($"                       -0 ==   0: {FLOAT_NEG_ZERO == 0}");
        PRINT($"                       -0 !=   0: {FLOAT_NEG_ZERO != 0}");
        PRINT($"");
        PRINT($"                                    ==     !=       <      <=       >      >=");
        PRINT($"                      -1 VS -Inf:   {-1f ==  FLOAT_NEG_INF,-6} {-1f !=  FLOAT_NEG_INF,-6}   {-1f <  FLOAT_NEG_INF,-6} {-1f <=  FLOAT_NEG_INF,-6}   {-1f >  FLOAT_NEG_INF,-6} {-1f >=  FLOAT_NEG_INF,-6}");
        PRINT($"                       0 VS -Inf:   { 0f ==  FLOAT_NEG_INF,-6} { 0f !=  FLOAT_NEG_INF,-6}   { 0f <  FLOAT_NEG_INF,-6} { 0f <=  FLOAT_NEG_INF,-6}   { 0f >  FLOAT_NEG_INF,-6} { 0f >=  FLOAT_NEG_INF,-6}");
        PRINT($"                       1 VS -Inf:   { 1f ==  FLOAT_NEG_INF,-6} { 1f !=  FLOAT_NEG_INF,-6}   { 1f <  FLOAT_NEG_INF,-6} { 1f <=  FLOAT_NEG_INF,-6}   { 1f >  FLOAT_NEG_INF,-6} { 1f >=  FLOAT_NEG_INF,-6}");
        PRINT($"");
        PRINT($"                      -1 VS  MIN:   {-1f ==      FLOAT_MIN,-6} {-1f !=      FLOAT_MIN,-6}   {-1f <      FLOAT_MIN,-6} {-1f <=      FLOAT_MIN,-6}   {-1f >      FLOAT_MIN,-6} {-1f >=      FLOAT_MIN,-6}");
        PRINT($"                       0 VS  MIN:   { 0f ==      FLOAT_MIN,-6} { 0f !=      FLOAT_MIN,-6}   { 0f <      FLOAT_MIN,-6} { 0f <=      FLOAT_MIN,-6}   { 0f >      FLOAT_MIN,-6} { 0f >=      FLOAT_MIN,-6}");
        PRINT($"                       1 VS  MIN:   { 1f ==      FLOAT_MIN,-6} { 1f !=      FLOAT_MIN,-6}   { 1f <      FLOAT_MIN,-6} { 1f <=      FLOAT_MIN,-6}   { 1f >      FLOAT_MIN,-6} { 1f >=      FLOAT_MIN,-6}");
        PRINT($"");
        PRINT($"                      -1 VS   -0:   {-1f == FLOAT_NEG_ZERO,-6} {-1f != FLOAT_NEG_ZERO,-6}   {-1f < FLOAT_NEG_ZERO,-6} {-1f <= FLOAT_NEG_ZERO,-6}   {-1f > FLOAT_NEG_ZERO,-6} {-1f >= FLOAT_NEG_ZERO,-6}");
        PRINT($"                       0 VS   -0:   { 0f == FLOAT_NEG_ZERO,-6} { 0f != FLOAT_NEG_ZERO,-6}   { 0f < FLOAT_NEG_ZERO,-6} { 0f <= FLOAT_NEG_ZERO,-6}   { 0f > FLOAT_NEG_ZERO,-6} { 0f >= FLOAT_NEG_ZERO,-6}");
        PRINT($"                       1 VS   -0:   { 1f == FLOAT_NEG_ZERO,-6} { 1f != FLOAT_NEG_ZERO,-6}   { 1f < FLOAT_NEG_ZERO,-6} { 1f <= FLOAT_NEG_ZERO,-6}   { 1f > FLOAT_NEG_ZERO,-6} { 1f >= FLOAT_NEG_ZERO,-6}");
        PRINT($"");
        PRINT($"                      -1 VS  MAX:   {-1f ==      FLOAT_MAX,-6} {-1f !=      FLOAT_MAX,-6}   {-1f <      FLOAT_MAX,-6} {-1f <=      FLOAT_MAX,-6}   {-1f >      FLOAT_MAX,-6} {-1f >=      FLOAT_MAX,-6}");
        PRINT($"                       0 VS  MAX:   { 0f ==      FLOAT_MAX,-6} { 0f !=      FLOAT_MAX,-6}   { 0f <      FLOAT_MAX,-6} { 0f <=      FLOAT_MAX,-6}   { 0f >      FLOAT_MAX,-6} { 0f >=      FLOAT_MAX,-6}");
        PRINT($"                       1 VS  MAX:   { 1f ==      FLOAT_MAX,-6} { 1f !=      FLOAT_MAX,-6}   { 1f <      FLOAT_MAX,-6} { 1f <=      FLOAT_MAX,-6}   { 1f >      FLOAT_MAX,-6} { 1f >=      FLOAT_MAX,-6}");
        PRINT($"");
        PRINT($"                      -1 VS  Inf:   {-1f ==      FLOAT_INF,-6} {-1f !=      FLOAT_INF,-6}   {-1f <      FLOAT_INF,-6} {-1f <=      FLOAT_INF,-6}   {-1f >      FLOAT_INF,-6} {-1f >=      FLOAT_INF,-6}");
        PRINT($"                       0 VS  Inf:   { 0f ==      FLOAT_INF,-6} { 0f !=      FLOAT_INF,-6}   { 0f <      FLOAT_INF,-6} { 0f <=      FLOAT_INF,-6}   { 0f >      FLOAT_INF,-6} { 0f >=      FLOAT_INF,-6}");
        PRINT($"                       1 VS  Inf:   { 1f ==      FLOAT_INF,-6} { 1f !=      FLOAT_INF,-6}   { 1f <      FLOAT_INF,-6} { 1f <=      FLOAT_INF,-6}   { 1f >      FLOAT_INF,-6} { 1f >=      FLOAT_INF,-6}");
        #pragma warning restore 1718 // "Comparison made to same variable."
        //======================================================================================================================================================
    }
}
