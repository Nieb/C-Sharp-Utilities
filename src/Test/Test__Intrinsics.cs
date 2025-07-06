using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace TEST;
internal static partial class Program {
    static void Test__Intrinsics() {
        PRINT("\n[Intrinsics]");
        //PRINT($"{}");

        //======================================================================================================================================================
        PRINT($"    Vector128.IsHardwareAccelerated: {System.Runtime.Intrinsics.Vector128.IsHardwareAccelerated}");
        PRINT($"");
        PRINT($"         X86Base: {X86Base      .IsSupported,-5}  X64: {X86Base      .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"             SSE: {Sse          .IsSupported,-5}  X64: {Sse          .X64.IsSupported,-5}");
        PRINT($"            SSE2: {Sse2         .IsSupported,-5}  X64: {Sse2         .X64.IsSupported,-5} ***");
        PRINT($"            SSE3: {Sse3         .IsSupported,-5}  X64: {Sse3         .X64.IsSupported,-5}");
        PRINT($"           SSSE3: {Ssse3        .IsSupported,-5}  X64: {Ssse3        .X64.IsSupported,-5}");
        PRINT($"           SSE41: {Sse41        .IsSupported,-5}  X64: {Sse41        .X64.IsSupported,-5}");
        PRINT($"           SSE42: {Sse42        .IsSupported,-5}  X64: {Sse42        .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"             Avx: {Avx          .IsSupported,-5}  X64: {Avx          .X64.IsSupported,-5}");
        PRINT($"            Avx2: {Avx2         .IsSupported,-5}  X64: {Avx2         .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"        Avx512BW: {Avx512BW     .IsSupported,-5}  X64: {Avx512BW     .X64.IsSupported }  VL: {Avx512BW       .VL.IsSupported,-5}");
        PRINT($"        Avx512CD: {Avx512CD     .IsSupported,-5}  X64: {Avx512CD     .X64.IsSupported }  VL: {Avx512CD       .VL.IsSupported,-5}");
        PRINT($"        Avx512DQ: {Avx512DQ     .IsSupported,-5}  X64: {Avx512DQ     .X64.IsSupported }  VL: {Avx512DQ       .VL.IsSupported,-5}");
        PRINT($"         Avx512F: {Avx512F      .IsSupported,-5}  X64: {Avx512F      .X64.IsSupported }  VL: {Avx512F        .VL.IsSupported,-5}");
        PRINT($"      Avx512Vbmi: {Avx512Vbmi   .IsSupported,-5}  X64: {Avx512Vbmi   .X64.IsSupported }  VL: {Avx512Vbmi     .VL.IsSupported,-5}");
        //PRINT($"");
        //PRINT($"         Avx10v1: {Avx10v1      .IsSupported,-5}  X64: {Avx10v1      .X64.IsSupported,-5}");
        //PRINT($"    Avx10v1.V512: {Avx10v1.V512 .IsSupported,-5}  X64: {Avx10v1.V512 .X64.IsSupported,-5}");
        //PRINT($"");
        //PRINT($"         AvxVnni: {AvxVnni      .IsSupported,-5}  X64: {AvxVnni      .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"             Aes: {Aes          .IsSupported,-5}  X64: {Aes          .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"            Bmi1: {Bmi1         .IsSupported,-5}  X64: {Bmi1         .X64.IsSupported,-5}");
        PRINT($"            Bmi2: {Bmi2         .IsSupported,-5}  X64: {Bmi2         .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"             Fma: {Fma          .IsSupported,-5}  X64: {Fma          .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"           Lzcnt: {Lzcnt        .IsSupported,-5}  X64: {Lzcnt        .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"       Pclmulqdq: {Pclmulqdq    .IsSupported,-5}  X64: {Pclmulqdq    .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"          Popcnt: {Popcnt       .IsSupported,-5}  X64: {Popcnt       .X64.IsSupported,-5}");
        PRINT($"");
        PRINT($"    X86Serialize: {X86Serialize .IsSupported,-5}  X64: {X86Serialize .X64.IsSupported,-5}");
        //======================================================================================================================================================
    }
}
