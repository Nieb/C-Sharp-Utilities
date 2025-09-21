

namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveOptimization)]
    internal static float[] ToFloatArray(this mat4 Source) {
        const int ByteCount = 16 * sizeof(float);

        float[] Result = new float[16];
        unsafe {
            //  Pin array so the GC doesn't move it:
            fixed (float* pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: &Source,
                               destination: pDes,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveOptimization)]
    internal static float[] ToFloatArray(this vec2[] Source) {
        const int SizeOfVec2 = sizeof(float) * 2;

        int ByteCount = Source.Length * SizeOfVec2;
        float[] Result = new float[Source.Length * 2];
        unsafe {
            //  Pin arrays so the GC doesn't move them:
            fixed ( vec2* pSrc = &Source[0])
            fixed (float* pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDes,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //==========================================================================================================================================================
    [Impl(AggressiveOptimization)]
    internal static float[] ToFloatArray(this vec3[] Source) {
        const int SizeOfVec3 = sizeof(float) * 3;

        int ByteCount = Source.Length * SizeOfVec3;
        float[] Result = new float[Source.Length * 3];
        unsafe {
            //  Pin arrays so the GC doesn't move them:
            fixed ( vec3* pSrc = &Source[0])
            fixed (float* pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDes,
                    destinationSizeInBytes: ByteCount,
                         sourceBytesToCopy: ByteCount
                );
            }
        }
        return Result;
    }

    //==========================================================================================================================================================
    [Impl(AggressiveOptimization)]
    internal static float[] ToFloatArray(this vec4[] Source) {
        const int SizeOfVec4 = sizeof(float) * 4;

        int ByteCount = Source.Length * SizeOfVec4;
        float[] Result = new float[Source.Length * 4];
        unsafe {
            //  Pin arrays so the GC doesn't move them:
            fixed ( vec4* pSrc = &Source[0])
            fixed (float* pDes = &Result[0]) {
                System.Buffer.MemoryCopy(
                                    source: pSrc,
                               destination: pDes,
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
