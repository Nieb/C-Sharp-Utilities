
namespace UtilityTest;
internal static partial class Program {
    static void Test__VectorMatrix4() {
        PRINT("\n[Utility.VEC Matrix4]");
        //PRINT($"{}");

        //======================================================================================================================================================
        mat4 A = new mat4(
             1f,  2f,  3f,  4f,
             5f,  6f,  7f,  8f,
             9f, 10f, 11f, 12f,
            13f, 14f, 15f, 16f
        );

        bool Ex0 = false;  try { float Test = A[  -1 ]; }  catch (System.IndexOutOfRangeException) { Ex0 = true; }
        bool Ex1 = false;  try { float Test = A[  16 ]; }  catch (System.IndexOutOfRangeException) { Ex1 = true; }
        bool Ex2 = false;  try { float Test = A[-1, 0]; }  catch (System.IndexOutOfRangeException) { Ex2 = true; }
        bool Ex3 = false;  try { float Test = A[ 0, 4]; }  catch (System.IndexOutOfRangeException) { Ex3 = true; }

        RESULT("mat4", true
            &&  A.xx   ==  1f  &&  A.yx   ==  2f &&  A.zx   ==  3f  &&  A.wx   ==  4f
            &&  A.xy   ==  5f  &&  A.yy   ==  6f &&  A.zy   ==  7f  &&  A.wy   ==  8f
            &&  A.xz   ==  9f  &&  A.yz   == 10f &&  A.zz   == 11f  &&  A.wz   == 12f
            &&  A.xw   == 13f  &&  A.yw   == 14f &&  A.zw   == 15f  &&  A.ww   == 16f

            &&  A[ 0]  ==  1f  &&  A[ 1]  ==  2f &&  A[ 2]  ==  3f  &&  A[ 3]  ==  4f
            &&  A[ 4]  ==  5f  &&  A[ 5]  ==  6f &&  A[ 6]  ==  7f  &&  A[ 7]  ==  8f
            &&  A[ 8]  ==  9f  &&  A[ 9]  == 10f &&  A[10]  == 11f  &&  A[11]  == 12f
            &&  A[12]  == 13f  &&  A[13]  == 14f &&  A[14]  == 15f  &&  A[15]  == 16f

            &&  A[0,0] ==  1f  &&  A[1,0] ==  2f &&  A[2,0] ==  3f  &&  A[3,0] ==  4f
            &&  A[0,1] ==  5f  &&  A[1,1] ==  6f &&  A[2,1] ==  7f  &&  A[3,1] ==  8f
            &&  A[0,2] ==  9f  &&  A[1,2] == 10f &&  A[2,2] == 11f  &&  A[3,2] == 12f
            &&  A[0,3] == 13f  &&  A[1,3] == 14f &&  A[2,3] == 15f  &&  A[3,3] == 16f

            && Ex0 && Ex1 && Ex2 && Ex3
        );

        //======================================================================================================================================================
    }
}
