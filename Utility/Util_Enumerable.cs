#if false
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Utility;
internal static class ENM {
    //######################################################################################################################################################
    //######################################################################################################################################################
    /// <summary>
    /// Proper "Length" method.  (zero inclusive)
    ///
    ///           o----|--->|
    ///           0    1    2
    /// Blarg = {"A", "B", "C"}
    ///
    /// Blarg.Len()   = 2       -1 is empty.
    /// Blarg.Count() = 3        0 is empty.
    ///
    /// This works on Arrays, Strings, Lists, etc.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int Len<T>(this IEnumerable<T> Enmrbl) {
        if (Enmrbl == null) return -1;
        return Enumerable.Count(Enmrbl) - 1;
    }

    //######################################################################################################################################################
    //######################################################################################################################################################
}
#endif
