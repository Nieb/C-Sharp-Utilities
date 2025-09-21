

namespace Utility;
internal static class ARY {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Proper "Length" method.  (zero inclusive)
    //
    //                o----|--->|
    //                0    1    2
    //      Blarg = {"A", "B", "C"}
    //
    //  Blarg.count()  == 3      0 is empty.
    //  Blarg.length() == 2     -1 is empty.
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this   byte[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this  sbyte[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this  short[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this ushort[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this    int[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this   uint[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this   long[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this  ulong[] A) => (A == null) ? 0 : A.Length;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this  float[] A) => (A == null) ? 0 : A.Length;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this double[] A) => (A == null) ? 0 : A.Length;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int  count(this  string  A) =>  A.IsVoid() ? 0 : A.Length;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this   byte[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this  sbyte[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this  short[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this ushort[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this    int[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this   uint[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this   long[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this  ulong[] A) => (A == null) ? -1 : A.Length - 1;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this  float[] A) => (A == null) ? -1 : A.Length - 1;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this double[] A) => (A == null) ? -1 : A.Length - 1;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int length(this  string  A) =>  A.IsVoid() ? -1 : A.Length - 1;

    //==========================================================================================================================================================
    //
    //  Generic version.  Works on Arrays, Lists, Strings, etc.
    //
    #if false
        [Impl(AggressiveInlining|AggressiveOptimization)]
        internal static int  count<T>(this System.Collections.Generic.IEnumerable<T> Enmrbl) => (Enmrbl == null) ?  0 : System.Linq.Enumerable.Count(Enmrbl);

        [Impl(AggressiveInlining|AggressiveOptimization)]
        internal static int length<T>(this System.Collections.Generic.IEnumerable<T> Enmrbl) => (Enmrbl == null) ? -1 : System.Linq.Enumerable.Count(Enmrbl) - 1;

    #endif
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static void Fill(this  float[] A,  float B) => System.Array.Fill(A, B);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static void Fill(this   byte[] A,   byte B) => System.Array.Fill(A, B);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static void Fill(this  short[] A,  short B) => System.Array.Fill(A, B);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static void Fill(this ushort[] A, ushort B) => System.Array.Fill(A, B);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static void Fill(this    int[] A,    int B) => System.Array.Fill(A, B);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static void Fill(this   uint[] A,   uint B) => System.Array.Fill(A, B);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
