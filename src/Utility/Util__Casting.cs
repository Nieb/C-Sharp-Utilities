using System.Runtime.InteropServices;

namespace Utility;
internal static class Casting {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static byte  ClampToByte (int A) =>  (byte)clamp(A, 0, MAX_BYTE);

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static short ClampToShort(int A) => (short)clamp(A, MIN_SHORT, MAX_SHORT);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}


internal static class BitCast {
    [StructLayout(LayoutKind.Explicit, Pack=4)]
    private struct Data32 {
        [FieldOffset(0)] public float F;
        [FieldOffset(0)] public   int I;
        [FieldOffset(0)] public  uint U;

        public Data32(float F) => this.F = F;
        public Data32(  int I) => this.I = I;
        public Data32( uint U) => this.U = U;
    }

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float ToFloat( int A) => new Data32(A).F;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float ToFloat(uint A) => new Data32(A).F;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static   int ToInt( float A) => new Data32(A).I;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static   int ToInt(  uint A) => new Data32(A).I;

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static  uint ToUint(float A) => new Data32(A).U;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static  uint ToUint(  int A) => new Data32(A).U;
}
