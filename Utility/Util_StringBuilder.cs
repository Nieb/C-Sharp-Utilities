using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Utility;
internal static partial class STR {
    //######################################################################################################################################################
    //######################################################################################################################################################
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
