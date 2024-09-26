using System;
using System.Diagnostics;

namespace TEST;
internal static partial class Program {
    static void PRINT(string PrintMe) => Console.WriteLine(PrintMe);

    static void RESULT(string TestLabel, bool Result) =>
        Console.WriteLine( $"{TestLabel,32}" + (Result ? ": Pass" : ": FAILURE") );
}
