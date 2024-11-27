using System;
using System.Diagnostics;

namespace TEST;
internal static partial class Program {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    static void PRINT(string PrintMe) =>
        Console.WriteLine(PrintMe);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #if true
        static void RESULT(string TestLabel, bool Result) =>
            Console.WriteLine(
                $"{TestLabel,32}: " + (Result ? "Pass" : "FAILURE")
            );
    #else
        static void RESULT(string TestLabel, bool Result) {
            if (Result == false)
                Console.WriteLine(
                    $"{TestLabel,32}: FAILURE"
                );
        }
    #endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
