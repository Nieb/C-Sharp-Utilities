using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Utility;
internal static class ENM {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    /// <summary>
    /// Proper "Length" method.  (zero inclusive)
    ///
    ///           o----|--->|
    ///           0    1    2
    /// Blarg = {"A", "B", "C"}
    ///
    /// Blarg.length() = 2       -1 is empty.
    /// Blarg.count()  = 3        0 is empty.
    ///
    /// This works on Arrays, Strings, Lists, etc.
    /// </summary>
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static int count<T>(this IEnumerable<T> Enmrbl) =>
        Enumerable.Count(Enmrbl);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static int length<T>(this IEnumerable<T> Enmrbl) =>
        (Enmrbl == null) ? -1
                         : Enumerable.Count(Enmrbl) - 1;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
