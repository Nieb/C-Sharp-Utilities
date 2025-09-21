
namespace Utility;
internal static class Loops {
#if false
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  loop(Count, i => {
    //      Thing[i] = i;
    //  });
    //
    //  loop(SizeX, SizeY, (iX, iY) => {
    //      Thing[iX, iY] = iX + iY*SizeX;
    //  });
    //
    //  loop(SizeX, SizeY, SizeZ, (iX, iY, iZ) => {
    //      Thing[iX, iY, iZ] = iX + iY*SizeX + iZ*SizeX*SizeY;
    //  });
    //
    //  NOTE:  Avoid allocating/declaring vars inside body, as it will likely result in a performance hit.
    //
    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)]
    internal static void loop(int n, System.Action<int> body) {
        for (int i = 0; i < n; ++i)
            body(i);
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)]
    internal static void loop(int nX, int nY, System.Action<int,int> body) {
        for (int iY = 0; iY < nY; ++iY)
            for (int iX = 0; iX < nX; ++iX)
                body(iX, iY);
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)]
    internal static void loop(int nX, int nY, int nZ, System.Action<int,int,int> body) {
        for (int iZ = 0; iZ < nZ; ++iZ)
            for (int iY = 0; iY < nY; ++iY)
                for (int iX = 0; iX < nX; ++iX)
                    body(iX, iY, iZ);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
#endif
}
