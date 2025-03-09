using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static class INT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int abs(int A) =>
        (A >= 0) ? A : -A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int clamp(int A, int Min, int Max) =>
        (A < Min) ? Min :
        (A > Max) ? Max : A;

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int wrap(int A, int Min, int Max) {
        #if DEBUG
            if (Max <= Min) throw new ArgumentException("Max must be greater than Min.");
        #endif

        int Range  = Max - Min;
        int Result = (A - Min) % Range;

        return (Result < 0) ? Result + Range + Min
                            : Result         + Min;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int min(int A, int B) => (A < B) ? A : B;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int min(int A, int B, int C) => (A < B) ? ((A < C) ? A : C)
                                                            : ((B < C) ? B : C);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int min(int A, int B, int C, int D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                              : ((C < D) ? C : D))
                                                                   : ((B < C) ? ((B < D) ? B : D)
                                                                              : ((C < D) ? C : D));

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int max(int A, int B) => (A > B) ? A : B;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int max(int A, int B, int C) => (A > B) ? ((A > C) ? A : C)
                                                            : ((B > C) ? B : C);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int max(int A, int B, int C, int D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
                                                                              : ((C > D) ? C : D))
                                                                   : ((B > C) ? ((B > D) ? B : D)
                                                                              : ((C > D) ? C : D));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     trunk(12345, -2) ==   345
    ///     trunk(12345,  2) == 123
    ///
    internal static int trunk(int A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        if (Digits > 0) {
            return (Astr.Length <= Digits) ? 0 : Convert.ToInt32(Astr.Remove(Astr.Length-Digits, Digits)); // Truncate Right
        } else {
            Digits = -Digits;
            return (Astr.Length <= Digits) ? 0 : Convert.ToInt32(Astr.Remove(                 0, Digits)); // Truncate Left
        }
    }

    internal static long trunk(long A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        if (Digits > 0) {
            return (Astr.Length <= Digits) ? 0 : Convert.ToInt64(Astr.Remove(Astr.Length-Digits, Digits)); // Truncate Right
        } else {
            Digits = -Digits;
            return (Astr.Length <= Digits) ? 0 : Convert.ToInt64(Astr.Remove(                 0, Digits)); // Truncate Left
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################


    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitCount.xhtml            bitCount()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldExtract.xhtml     bitfieldExtract()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldReverse.xhtml     bitfieldReverse()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldInsert.xhtml      bitfieldInsert()


    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
