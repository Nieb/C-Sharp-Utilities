

namespace Utility;
internal static class INT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal const sbyte  MIN_SBYTE  =                       -128;
    internal const sbyte  MAX_SBYTE  =                        127;
    internal const short  MIN_SHORT  =                    -32_768;
    internal const short  MAX_SHORT  =                     32_767;
    internal const int    MIN_INT    =             -2_147_483_648; // -2^31      -0x_8000_0000
    internal const int    MAX_INT    =              2_147_483_647; //  2^31 - 1   0x_7FFF_FFFF
    internal const long   MIN_LONG   = -9_223_372_036_854_775_808;
    internal const long   MAX_LONG   =  9_223_372_036_854_775_807;

    internal const byte   MAX_BYTE   =                        255;
    internal const ushort MAX_USHORT =                     65_535;
    internal const uint   MAX_UINT   =              4_294_967_295; //  2^32      0x_FFFF_FFFF
    internal const ulong  MAX_ULONG  = 18_446_744_073_709_551_615;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int abs(int A) => (A >= 0) ? A : -A;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int clamp(int A, int Min, int Max) => (A < Min) ? Min : (A > Max) ? Max : A;

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)]
    internal static int wrap(int A, int Min, int Max) {
        #if DEBUG
            if (Max <= Min) throw new System.ArgumentException("Max must be greater than Min.");
        #endif

        int Range  = Max - Min;
        int Result = (A - Min) % Range;

        return (Result < 0) ? Result + Range + Min
                            : Result         + Min;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int min(int A, int B)               => (A < B) ? A : B;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int min(int A, int B, int C)        => (A < B) ? ((A < C) ? A : C)
                                                                                                                     : ((B < C) ? B : C);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int min(int A, int B, int C, int D) => (A < B) ? ((A < C) ? ((A < D) ? A : D)
                                                                                                                                : ((C < D) ? C : D))
                                                                                                                     : ((B < C) ? ((B < D) ? B : D)
                                                                                                                                : ((C < D) ? C : D));

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int max(int A, int B)               => (A > B) ? A : B;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int max(int A, int B, int C)        => (A > B) ? ((A > C) ? A : C)
                                                                                                                     : ((B > C) ? B : C);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static int max(int A, int B, int C, int D) => (A > B) ? ((A > C) ? ((A > D) ? A : D)
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
    [Impl(AggressiveOptimization)]
    internal static int trunk(int A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        if (Digits > 0) {
            return (Astr.Length <= Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(Astr.Length-Digits, Digits)); // Truncate Right
        } else {
            Digits = -Digits;
            return (Astr.Length <= Digits) ? 0 : System.Convert.ToInt32(Astr.Remove(                 0, Digits)); // Truncate Left
        }
    }

    [Impl(AggressiveOptimization)]
    internal static long trunk(long A, int Digits) {
        if (Digits == 0)
            return A;

        string Astr = A.ToString();

        if (Digits > 0) {
            return (Astr.Length <= Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(Astr.Length-Digits, Digits)); // Truncate Right
        } else {
            Digits = -Digits;
            return (Astr.Length <= Digits) ? 0 : System.Convert.ToInt64(Astr.Remove(                 0, Digits)); // Truncate Left
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static uint ByteFlip(uint A) => (
        ((A & 0xFF000000) >> 24) |
        ((A & 0x00FF0000) >>  8) |
        ((A & 0x0000FF00) <<  8) |
        ((A & 0x000000FF) << 24)
    );

    internal static bvec4 ByteFlip(bvec4 A) => (
        ((uint)A.x      ) |
        ((uint)A.y <<  8) |
        ((uint)A.z << 16) |
        ((uint)A.w << 24)
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################

    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitCount.xhtml            BitCount()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldExtract.xhtml     BitfieldExtract()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldReverse.xhtml     BitfieldReverse()
    //  https://registry.khronos.org/OpenGL-Refpages/gl4/html/bitfieldInsert.xhtml      BitfieldInsert()

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
