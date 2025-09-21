using System;
using System.Text;

namespace Utility;
internal static partial class STR {
    //######################################################################################################################################################
    //######################################################################################################################################################
    [Impl(AggressiveOptimization)]
    internal static int CurrentLineLength(this StringBuilder StrBldr) {
        string STR = StrBldr.ToString();
        int IndexOfLastNewLine = STR.LastIndexOf('\n');

        if (IndexOfLastNewLine == -1)
            return STR.Length;

        return STR.Length - IndexOfLastNewLine - 1;
    }

    //######################################################################################################################################################
    //######################################################################################################################################################
}
