using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static class INT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int abs(int A) =>
        (A >= 0) ? A : -A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int clamp(int A, int Min, int Max) =>
        (A < Min) ? Min  :
        (A > Max) ? Max  :  A;

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int wrap(int A, int Min, int Max) {
        #if DEBUG
            if (Max <= Min)
                throw new ArgumentException("Max must be greater than Min.");
        #endif

        int Range  = Max - Min;
        int Result = (A - Min) % Range;

        return (Result < 0) ? Result + Range + Min
                            : Result         + Min;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int min(int A, int B) =>
        (A < B) ? A : B;

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int max(int A, int B) =>
        (A > B) ? A : B;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    ///     trunc(12345, -2) ==   345
    ///     trunc(12345,  2) == 123
    ///
    public static int trunc(int A, int Digits) {
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

    public static long trunc(long A, int Digits) {
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
}
