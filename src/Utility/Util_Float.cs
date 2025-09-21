

namespace Utility;
internal static class FLT {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal const float FLOAT_MIN      = System.Single.MinValue;
    internal const float FLOAT_MAX      = System.Single.MaxValue;

    internal const float FLOAT_NEG_INF  = System.Single.NegativeInfinity;
    internal const float FLOAT_NEG_ZERO = System.Single.NegativeZero;
    internal const float FLOAT_INF      = System.Single.PositiveInfinity;

    internal const float FLOAT_NaN      = System.Single.NaN;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Use-of "float" identifier restricted.
    //
    #if false
        [MethodImpl(MethodImplOptions.AggressiveInlining)] internal static float flt(byte   A) => (float)A;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] internal static float flt(short  A) => (float)A;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] internal static float flt(int    A) => (float)A;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] internal static float flt(uint   A) => (float)A;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] internal static float flt(double A) => (float)A;
    #endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float BitDec(float A) => System.MathF.BitDecrement(A);
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float BitInc(float A) => System.MathF.BitIncrement(A);

    //public static float operator --(float operand) => System.MathF.BitDecrement(A);
    //public static float operator ++(float operand) => System.MathF.BitIncrement(A);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
