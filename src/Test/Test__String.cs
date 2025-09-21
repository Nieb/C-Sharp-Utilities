
namespace UtilityTest;
internal static partial class Program {
    static void Test__String() {
        PRINT("\n[Utility.STR]");
        //PRINT($"{}");

        //======================================================================================================================================================
        RESULT("RandomDigits()", true
            && RandomDigits(5).Length      == 5
            && RandomDigits(5).IsNumeric() == true
        );

        //======================================================================================================================================================
        RESULT(".ToBool()", true
            && "true".ToBool() == true
            && "True".ToBool() == true
            && "TRUE".ToBool() == true
            && "TrUe".ToBool() == true
            && "tRuE".ToBool() == true

            && "false".ToBool() == false
            && "False".ToBool() == false
            && "FALSE".ToBool() == false
            && "FaLsE".ToBool() == false
            && "fAlSe".ToBool() == false

            && "".ToBool() == false
            && "blarg".ToBool() == false
        );

        //RESULT(".ToDateTime()", true
        //    && "".ToDateTime() == System.DateTime.MinValue
        //);

        RESULT(".ToIpAddress()", true
            && ""               .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && " "              .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && "blarg"          .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && "0"              .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && "0.0.0.0"        .ToIpAddress().Equals(new System.Net.IPAddress(0))
            && "127.0.0.1"      .ToIpAddress().Equals(new System.Net.IPAddress(new byte[] { 0x7F, 0x00, 0x00, 0x01 }))
            && "192.168.0.1"    .ToIpAddress().Equals(new System.Net.IPAddress(new byte[] { 0xC0, 0xA8, 0x00, 0x01 }))
            && "255.255.255.255".ToIpAddress().Equals(new System.Net.IPAddress(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }))
        );

        RESULT(".ToNameValueCollection()", true
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["ABC"] == "123,789"
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["def"] == "Xyz"
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["G"]   == "456"
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["H"]   == "1.414"
            && "ABC=123, def=Xyz, G=456, H=1.414, i=0, ABC=789".ToNameValueCollection()["i"]   == "0"
        );

        //======================================================================================================================================================
        RESULT("ByteArrayToString()", true
            && ByteArrayToString(new byte[] { 0xFF, 0xCC, 0xAA })                                  == "FF CC AA "
            && ByteArrayToString(new byte[] { 0xFF, 0xCC, 0xAA, 0x99, 0x77, 0x55, 0x33, 0x11 }, 3) == "FF CC AA \n99 77 55 \n33 11 "
        );

        RESULT("EnumerableToString()", true
            && EnumerableToString(new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg", "Hh", "Ii" }) == "Aa, Bb, Cc, Dd, Ee, Ff, Gg, Hh, Ii"
            && EnumerableToString("AaBbCcDdEeFfGgHhIi")                                                  == "A, a, B, b, C, c, D, d, E, e, F, f, G, g, H, h, I, i"
            && EnumerableToString(new int[] { 1, 2, 3 })                                                 == "1, 2, 3"
        );

        RESULT("IntToBinaryString()", true
            && IntToBinaryString((sbyte )                 0x7F) ==                                                                "01111111"
            && IntToBinaryString((short )               0x7FFF) ==                                                       "01111111_11111111"
            && IntToBinaryString((int   )          0x7FFF_FFFF) ==                                     "01111111_11111111_11111111_11111111"
            && IntToBinaryString((long  )0x7FFF_FFFF_FFFF_FFFF) == "01111111_11111111_11111111_11111111_11111111_11111111_11111111_11111111"

            && IntToBinaryString((byte  )                 0xFF) ==                                                                "11111111"
            && IntToBinaryString((ushort)               0xFFFF) ==                                                       "11111111_11111111"
            && IntToBinaryString((uint  )          0xFFFF_FFFF) ==                                     "11111111_11111111_11111111_11111111"
            && IntToBinaryString((ulong )0xFFFF_FFFF_FFFF_FFFF) == "11111111_11111111_11111111_11111111_11111111_11111111_11111111_11111111"
        );

        //======================================================================================================================================================
        RESULT(".IsNumeric()", true
            && "123".IsNumeric() == true

            && "-123".IsNumeric()     == false
            && "-123".IsNumeric(true) == true

            && "-123.456".IsNumeric(true)      == false
            && "-123.456".IsNumeric(true,true) == true
            && "123.456".IsNumeric(false,true) == true

            && "ab12".IsNumeric() == false
            && "123_".IsNumeric() == false
            && "123 ".IsNumeric() == false
        );

        RESULT(".IsValidEmailAddress()", true
            && "user@sub.domain.top".IsValidEmailAddress()                         == true
            && "user@sub.domain.top".IsValidEmailAddress("top", "domain", "sub"  ) == true
            && "user@sub.domain.top".IsValidEmailAddress("top", "domain"         ) == true
            && "user@sub.domain.top".IsValidEmailAddress("top"                   ) == true
            && "user@sub.domain.top".IsValidEmailAddress("top", "domain", "blarg") == false
            && "user@sub.domain.top".IsValidEmailAddress("top", "blarg"          ) == false
            && "user@sub.domain.top".IsValidEmailAddress("blarg"                 ) == false
        );

        RESULT(".IsVoid()", true
            && "blarg".IsVoid() == false

            && "     ".IsVoid() == true
            && " \n  ".IsVoid() == true
            && "  \t ".IsVoid() == true
            && "\n\t ".IsVoid() == true

            && "".IsVoid() == true

            && ((string)null).IsVoid() == true
        );

        //======================================================================================================================================================
        RESULT(".ContainsAny()", true
            && "blarg".ContainsAny( new string[] {"ugh", "arg"} ) == true
        );

        RESULT(".ContainsAny_GetMatches()", true
            && "blarg".ContainsAny_GetMatches( new string[] {"bla", "ugh", "arg"} )[0] == "bla"
            && "blarg".ContainsAny_GetMatches( new string[] {"bla", "ugh", "arg"} )[1] == "arg"
        );

        //======================================================================================================================================================
        RESULT(".Indent()", true
            && "blarg\nblarg\nblarg".Indent() == "    blarg\n    blarg\n    blarg"
        );

        RESULT(".InsertEvery()", true
            && "blargblargblarg".InsertEvery(5, ", ") == "blarg, blarg, blarg"
        );

        RESULT(".Pad()", true
            && "blarg".Pad(-10) == "     blarg"
            && "blarg".Pad( 10) == "blarg     "
        );

        RESULT(".Prepend()", true
            && "blarg\nblarg\nblarg".Prepend(" ~~ ") == " ~~ blarg\n ~~ blarg\n ~~ blarg"
        );

        RESULT(".Repeat()", true
            && $"{"blarg".Repeat(3)}{"  ".Repeat(4)}{"blarg".Repeat(3)}" == "blargblargblarg        blargblargblarg"
            && $"{"blarg".Repeat(3)}{"\n".Repeat(4)}{"blarg".Repeat(3)}" == "blargblargblarg\n\n\n\nblargblargblarg"
        );

        RESULT(".ToTitleCase()", true
            && "blarg BLARG bLaRg".ToTitleCase() == "Blarg Blarg Blarg"
        );

        //======================================================================================================================================================
    }
}
