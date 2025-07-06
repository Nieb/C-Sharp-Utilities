using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Utility;
internal static partial class STR {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Random is not ThreadSafe.
    private static readonly Random Random     = new Random();
    private static readonly object ThreadLock = new object();

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Generate String:
    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string DateTimeStamp() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string DateStamp()     => DateTime.Now.ToString("yyyy-MM-dd");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string TimeStamp()     => DateTime.Now.ToString("HH:mm:ss.ffffff");

    //==========================================================================================================================================================
    internal static string RandomDigits(int Count) {
        if (Count <= 0)
            return "";

        lock (ThreadLock) {
            Thread.Sleep(66);

            string Result = "";
            for (int i = 0; i < Count; i++)
                Result += Random.Next(0, 10).ToString(); //  Random.Next(Inclusive, Exclusive)

            return Result;
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Convert FROM String:
    //==========================================================================================================================================================
    internal static bool ToBool(this string STR) {
        if (STR.IsVoid())
            return false;

        bool Parse_Succeed = Boolean.TryParse(STR, out bool Parse_Result);

        if (!Parse_Succeed)
            return false;

        return Parse_Result;
    }

    //==========================================================================================================================================================
    internal static DateTime ToDateTime(this string STR) {
        if (STR.IsVoid())
            return DateTime.MinValue;

        bool Parse_Succeed = DateTime.TryParse(STR, out DateTime Parse_Result);

        //  If parse fails, result is 'DateTime.MinValue'.

        return Parse_Result;
    }

    //==========================================================================================================================================================
    internal static IPAddress ToIpAddress(this string STR) {
        if (STR.IsVoid())
            return new IPAddress(0);

        bool Parse_Succeed = IPAddress.TryParse(STR, out IPAddress Parse_Result);

        if (!Parse_Succeed)
            return new IPAddress(0);

        return Parse_Result;
    }

    //==========================================================================================================================================================
    ///
    ///     var Blarg = "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()
    ///
    ///     Blarg["ABC"] == "123,789"
    ///     Blarg["def"] == "Xyz"
    ///     Blarg["G"]   == "456"
    ///     Blarg["H"]   == "1.414"
    ///     Blarg["i"]   == "0"
    ///
    internal static NameValueCollection ToNameValueCollection(this string STR) {
        if (STR.IsVoid())
            return null;

        var NameValueCol = new NameValueCollection();

        foreach (string pair in STR.Split(',')) {
            int SplitIndex = pair.IndexOf('=');
            if (SplitIndex > 0) {
                string PairName  = pair.Substring(0, SplitIndex).Trim();
                string PairValue = pair.Substring(SplitIndex + 1).Trim();
                NameValueCol.Add(PairName, PairValue);
            }
        }

        return NameValueCol;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Convert TO String:
    //==========================================================================================================================================================
    internal static string ByteArrayToString(byte[] ByteArr, int BytesPerLine = 16, string Delimiter = " ") {
        if (ByteArr == null)
            return "NULL";

        string Result = "";

        for (int iY = 0; iY < ByteArr.Length; iY += BytesPerLine) {
            for (int iX = 0; iX < BytesPerLine && iY + iX < ByteArr.Length; iX++) {
                Result += $"{ByteArr[iY+iX]:X2}{Delimiter}";
            }
            if (iY + BytesPerLine < ByteArr.Length)
                Result += "\n";
        }

        return Result; //Regex.Replace(Result, @"\n$", "");
    }

    //==========================================================================================================================================================
    internal static string EnumerableToString<T>(IEnumerable<T> Enmrbl, int ItemsPerLine = 0, int ItemPadding = 0, int LineIndent = 0, string LineDelimiter = "\n", string ItemDelimiter = ", ") {
        if (Enmrbl == null)
            return "";

        string Result = "";

        if (ItemsPerLine < 1) {
            foreach (var item in Enmrbl) {
                Result += (Result == "") ? $"{item}" : $"{ItemDelimiter}{item}";
            }
        } else {
            string Indent = new String(' ', LineIndent);
            for (int iY = 0; iY < Enumerable.Count(Enmrbl); iY += ItemsPerLine) {
                Result += Indent;
                for (int iX = 0; (iX < ItemsPerLine) && (iY + iX < Enumerable.Count(Enmrbl)); iX++) {

                    Result += $"{Enmrbl.ElementAt(iY+iX)}".Pad(ItemPadding);

                    Result += ((iX < ItemsPerLine) && (iY+iX+1 < Enumerable.Count(Enmrbl))) ? ItemDelimiter : "";
                }
                if (iY + ItemsPerLine < Enumerable.Count(Enmrbl))
                    Result += LineDelimiter;
            }
        }

        return Result;
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string IntToBinaryString(byte   INT) =>               Convert.ToString(      INT, 2).PadLeft( 8,'0');
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string IntToBinaryString(sbyte  INT) =>               Convert.ToString(      INT, 2).PadLeft( 8,'0');
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string IntToBinaryString(short  INT) => Regex.Replace(Convert.ToString(      INT, 2).PadLeft(16,'0'), @".{8}(?!$)", @"$0_");
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string IntToBinaryString(ushort INT) => Regex.Replace(Convert.ToString(      INT, 2).PadLeft(16,'0'), @".{8}(?!$)", @"$0_");
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string IntToBinaryString(int    INT) => Regex.Replace(Convert.ToString(      INT, 2).PadLeft(32,'0'), @".{8}(?!$)", @"$0_");
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string IntToBinaryString(uint   INT) => Regex.Replace(Convert.ToString(      INT, 2).PadLeft(32,'0'), @".{8}(?!$)", @"$0_");
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string IntToBinaryString(long   INT) => Regex.Replace(Convert.ToString(      INT, 2).PadLeft(64,'0'), @".{8}(?!$)", @"$0_");
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string IntToBinaryString(ulong  INT) => Regex.Replace(Convert.ToString((long)INT, 2).PadLeft(64,'0'), @".{8}(?!$)", @"$0_");

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  String Is<Something>:
    //==========================================================================================================================================================
    internal static bool IsNumeric(this string STR, bool Signed = false, bool Decimal = false) {
        if (STR.IsVoid())
            return false;

        string Pattern = (Signed  ? @"^(\-)?"             : @"^"      )
                       + (Decimal ? @"[0-9]*(\.)?[0-9]+$" : @"[0-9]+$");

        return new Regex(Pattern).IsMatch(STR);
    }

    //==========================================================================================================================================================
    ///
    ///     "user@sub.domain.top".IsValidEmailAddress()                       == TRUE
    ///     "user@sub.domain.top".IsValidEmailAddress("top", "domain", "sub") == TRUE
    ///     "user@sub.domain.top".IsValidEmailAddress("blarg")                == FALSE
    ///
    internal static bool IsValidEmailAddress(this string STR, string DomainTop = "", string Domain = "", string DomainSub = "") {
        if (STR.IsVoid())
            return false;

        /* Validate Input: STR */{
            STR = STR.Trim();

            const int MaxLen_EmailAddress = 317;
            const int MaxLen_Domain       = 253;
            const int MaxLen_Local        =  63;

            if (STR.Length > MaxLen_EmailAddress)
                return false;

            string[] STR_Split = STR.Split('@');

            if (STR_Split.Length != 2 || STR_Split[0].Length > MaxLen_Local || STR_Split[1].Length > MaxLen_Domain)
                return false;
        }

        /* Regex: "<Local>@<Domain>" */{
            //  0-9  A-Z  a-z  +  -  _  ~  !  #  $  %  &  ‘  .  /  =  ^  '  {  }  |
            string Ptrn_Local = @"^[0-9A-Za-z\+\-_~!#\$%\&'./=\^{}\|]+";

            //  0-9  A-Z  a-z  -  (cannot end with -)
            string Ptrn_Domain  = (DomainSub.IsVoid() ? @"(?:[A-Za-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)?" : $"{Regex.Escape(DomainSub)}\\.");
                   Ptrn_Domain += (Domain   .IsVoid() ? @"[A-Za-z0-9](?:[a-z0-9-]*[a-z0-9])?\."      : $"{Regex.Escape(Domain)   }\\.");

            #if true
                   Ptrn_Domain += (DomainTop.IsVoid() ? @"[A-Za-z]{2,}(\.[A-Za-z]{2,})*$"            : $"{Regex.Escape(DomainTop)}"   ); //  Multi-part, such as: "co.uk"
            #else
                   Ptrn_Domain += (DomainTop.IsVoid() ? @"[A-Za-z]{2,}$"                             : $"{Regex.Escape(DomainTop)}"   );
            #endif

            return new Regex($"{Ptrn_Local}@{Ptrn_Domain}").IsMatch(STR);
        }
    }

    //==========================================================================================================================================================
    ///
    ///     String.IsNullOrEmpty("blarg")  is stupid :P
    ///
    ///     "blarg".IsVoid()  much better.
    ///
    internal static bool IsVoid(this string STR) {
        if (STR == null)
            return true;

        for (int i = 0; i < STR.Length; i++)
            if (!Char.IsWhiteSpace(STR[i]))
                return false;

        return true;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  String Operators:
    //==========================================================================================================================================================
    ///
    ///     "blarg".ContainsAny( {"ugh", "arg"} ) == TRUE
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool ContainsAny(this string STR, string[] OfThese) {
        return OfThese.Any(x => STR.Contains(x));
    }

    //==========================================================================================================================================================
    ///
    ///     "blarg".ContainsAny_GetMatches( {"bla", "ugh", "arg"} ) == {"bla", "arg"}
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string[] ContainsAny_GetMatches(this string STR, string[] OfThese) {
        return OfThese.Where(x => STR.Contains(x))
                      .ToArray();
    }

    //==========================================================================================================================================================
    ///
    /// This works on strings that contain newline "\n" characters.
    ///
    ///     "blarg\nblarg\nblarg".Indent() == "    blarg\n    blarg\n    blarg"
    ///
    internal static string Indent(this string STR, int IndentSize = 4, char IndentWith = ' ') {
        string Indent = new String(IndentWith, IndentSize);

        if (STR.IsVoid())
            return Indent;

        if (STR.Contains("\n")) {
            string[] STR_Split = STR.Split('\n');
            string Result = "";

            foreach (string line in STR_Split)
                Result += Indent + line + "\n";

            return Regex.Replace(Result, @"\n$", "");

        } else {
            return Indent + STR;
        }
    }

    //==========================================================================================================================================================
    ///
    ///     "blargblargblarg".InsertEvery(5, ", ") == "blarg, blarg, blarg"
    ///
    internal static string InsertEvery(this string STR, uint nChars, string InsertMe, bool NotAtEnd = true) {
        return Regex.Replace(
            STR,
            $".{{{nChars}}}" + (NotAtEnd ? "(?!$)" : ""),
            $"$0{InsertMe}"
        );
    }

    //==========================================================================================================================================================
    ///
    /// This works on strings that contain newline "\n" characters.
    ///
    ///     "blarg".Pad(-10) == "     blarg"
    ///     "blarg".Pad( 10) == "blarg     "
    ///
    internal static string Pad(this string STR, int PadSize, char PadWith = ' ') {
        if (STR.IsVoid())
            return new String(PadWith, PadSize);

        if (STR.Contains("\n")) {
            string[] STR_Split = STR.Split('\n');
            string Result = "";

            if (PadSize < 0)
                foreach (string line in STR_Split)
                    Result += line.PadLeft(-PadSize, PadWith) + "\n";
            else
                foreach (string line in STR_Split)
                    Result += line.PadRight(PadSize, PadWith) + "\n";

            return Regex.Replace(Result, @"\n$", "");

        } else {
            return (PadSize < 0) ? STR.PadLeft(-PadSize, PadWith)
                                 : STR.PadRight(PadSize, PadWith);
        }
    }

    //==========================================================================================================================================================
    ///
    /// This works on strings that contain newline "\n" characters.
    ///
    ///     "blarg\nblarg\nblarg".Prepend(" ~~ ") == " ~~ blarg\n ~~ blarg\n ~~ blarg"
    ///
    internal static string Prepend(this string STR, string PrependWith) {
        if (STR.IsVoid())
            return PrependWith;

        if (STR.Contains("\n")) {
            string[] STR_Split = STR.Split('\n');
            string Result = "";

            foreach (string line in STR_Split)
                Result += PrependWith + line + "\n";

            return Regex.Replace(Result, @"\n$", "");

        } else {
            return PrependWith + STR;
        }
    }

    //==========================================================================================================================================================
    ///
    ///     "blarg".Repeat(3) == "blargblargblarg"
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string Repeat(this string STR, int Count) {
        return (Count <= 0 || STR == null || STR == "") ? ""
             : (Count == 1)                             ? STR
             : new StringBuilder(STR.Length * Count).Insert(0, STR, Count).ToString();
    }

    //==========================================================================================================================================================
    ///
    ///     "blarg BLARG bLaRg".ToTitleCase() == "Blarg Blarg Blarg"
    ///
    internal static string ToTitleCase(this string STR) {
        if (STR.IsVoid())
            return "";

        char[] Result = STR.ToLower().ToCharArray();
        bool CapitalizeNext = true;

        for (int i = 0; i < Result.Length; i++) {
            if (char.IsWhiteSpace(Result[i])) {
                CapitalizeNext = true;
            } else if (CapitalizeNext && char.IsLetter(Result[i])) {
                Result[i] = char.ToUpper(Result[i]);
                CapitalizeNext = false;
            }
        }

        return new string(Result);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
