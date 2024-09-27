using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Utility;
public static partial class STR {
    //######################################################################################################################################################
    //######################################################################################################################################################
    public static int CurrentLineLength(this StringBuilder StrBldr) {
        string STR = StrBldr.ToString();
        int IndexOfLastNewLine = STR.LastIndexOf('\n');

        if (IndexOfLastNewLine == -1)
            return STR.Length;

        return STR.Length - IndexOfLastNewLine - 1;
    }

    //######################################################################################################################################################
    //######################################################################################################################################################
}
