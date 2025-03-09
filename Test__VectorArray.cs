
namespace TEST;
internal static partial class Program {
    static void Test__VectorArray() {
        PRINT("\n[Utility.VEC Array]");
        //PRINT($"{}");

        //======================================================================================================================================================
        {
            vec2[] A = new vec2[] {
                ( 0.1f, 1.1f), ( 2.1f, 3.1f), ( 4.1f, 5.1f), ( 6.1f, 7.1f),
                ( 8.1f, 9.1f), (10.1f,11.1f), (12.1f,13.1f), (14.1f,15.1f),
                (16.1f,17.1f), (18.1f,19.1f), (20.1f,21.1f), (22.1f,23.1f),
                (24.1f,25.1f), (26.1f,27.1f), (28.1f,29.1f), (30.1f,31.1f)
            };
            float[] B = A.CopyToFloatArray();

            //PRINT($"vec2[]  A:\n{EnumerableToString(A,4,-8,4)}\n");
            //PRINT($"float[] B:\n{EnumerableToString(B,8,-8,4)}\n");

            bool Result = true;
            for (int i = 0; i < A.Length; ++i) {
                Result = Result && (A[i].x == B[i*2  ]);
                Result = Result && (A[i].y == B[i*2+1]);
            }
            RESULT("vec2[].CopyToFloatArray()", Result);
        }

        //======================================================================================================================================================
        {
            vec3[] A = new vec3[] {
                ( 0.1f, 1.1f, 2.1f), ( 3.1f, 4.1f, 5.1f), ( 6.1f, 7.1f, 8.1f), ( 9.1f,10.1f,11.1f),
                (12.1f,13.1f,14.1f), (15.1f,16.1f,17.1f), (18.1f,19.1f,20.1f), (21.1f,22.1f,23.1f),
                (24.1f,25.1f,26.1f), (27.1f,28.1f,29.1f), (30.1f,31.1f,32.1f), (33.1f,34.1f,35.1f),
                (36.1f,37.1f,38.1f), (39.1f,40.1f,41.1f), (42.1f,43.1f,44.1f), (45.1f,46.1f,47.1f)
            };
            float[] B = A.CopyToFloatArray();

            //PRINT($"vec3[]  A:\n{EnumerableToString(A, 4,-8,4)}\n");
            //PRINT($"float[] B:\n{EnumerableToString(B,12,-8,4)}\n");

            bool Result = true;
            for (int i = 0; i < A.Length; ++i) {
                Result = Result && (A[i].x == B[i*3  ]);
                Result = Result && (A[i].y == B[i*3+1]);
                Result = Result && (A[i].z == B[i*3+2]);
            }
            RESULT("vec3[].CopyToFloatArray()", Result);
        }

        //======================================================================================================================================================
        {
            vec4[] A = new vec4[] {
                ( 0.1f, 1.1f, 2.1f, 3.1f), ( 4.1f, 5.1f, 6.1f, 7.1f), ( 8.1f, 9.1f,10.1f,11.1f), (12.1f,13.1f,14.1f,15.1f),
                (16.1f,17.1f,18.1f,19.1f), (20.1f,21.1f,22.1f,23.1f), (24.1f,25.1f,26.1f,27.1f), (28.1f,29.1f,30.1f,31.1f),
                (32.1f,33.1f,34.1f,35.1f), (36.1f,37.1f,38.1f,39.1f), (40.1f,41.1f,42.1f,43.1f), (44.1f,45.1f,46.1f,47.1f),
                (48.1f,49.1f,50.1f,51.1f), (52.1f,53.1f,54.1f,55.1f), (56.1f,57.1f,58.1f,59.1f), (60.1f,61.1f,62.1f,63.1f)
            };
            float[] B = A.CopyToFloatArray();

            //PRINT($"vec4[]  A:\n{EnumerableToString(A, 4,-8,4)}\n");
            //PRINT($"float[] B:\n{EnumerableToString(B,16,-8,4)}");

            bool Result = true;
            for (int i = 0; i < A.Length; ++i) {
                Result = Result && (A[i].x == B[i*4  ]);
                Result = Result && (A[i].y == B[i*4+1]);
                Result = Result && (A[i].z == B[i*4+2]);
                Result = Result && (A[i].w == B[i*4+3]);
            }
            RESULT("vec4[].CopyToFloatArray()", Result);
        }

        //======================================================================================================================================================
        {
            //float A;
            //float B = A;          //  error: Use of unassigned local variable 'A'

            //vec3  C;
            //float D = C.x;        //  error: Use of possibly unassigned field 'x'

            vec3[] J = new vec3[8]; //  Arrays are allocated, then all bytes zeroed.
            float K = J[4].x;
        }

        //======================================================================================================================================================
    }
}
