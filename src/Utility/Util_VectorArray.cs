using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static float[] CopyToFloatArray(this vec2[] Source) {
        int ByteCount = Source.Length * 8;
        float[] Result = new float[Source.Length * 2];
        unsafe {
            //  Pin both arrays so the GC doesn't move them:
            fixed ( vec2* pSrc  = &Source[0])
            fixed (float* pDest = &Result[0]) {
                Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDest,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //==========================================================================================================================================================
    internal static float[] CopyToFloatArray(this vec3[] Source) {
        int ByteCount = Source.Length * 12;
        float[] Result = new float[Source.Length * 3];
        unsafe {
            //  Pin both arrays so the GC doesn't move them:
            fixed ( vec3* pSrc  = &Source[0])
            fixed (float* pDest = &Result[0]) {
                Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDest,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //==========================================================================================================================================================
    internal static float[] CopyToFloatArray(this vec4[] Source) {
        int ByteCount = Source.Length * 16;
        float[] Result = new float[Source.Length * 4];
        unsafe {
            //  Pin both arrays so the GC doesn't move them:
            fixed ( vec4* pSrc  = &Source[0])
            fixed (float* pDest = &Result[0]) {
                Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDest,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
