
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Collision2() {
        PRINT("\n[Utility.VEC -- Collision2]");
        //PRINT($"{}");

        //======================================================================================================================================================
        RESULT("CircleVsRect()", true
            && CircleVsRect((2.6f, 2.6f), 1f,    (3.3f, 3.3f), (2f, 2f)) == true
            && CircleVsRect((2.5f, 2.5f), 1f,    (3.3f, 3.3f), (2f, 2f)) == false

            && CircleVsRect((5.0f, 5.0f), 1f,    (3.3f, 3.3f), (1f, 1f)) == true
            && CircleVsRect((5.1f, 5.1f), 1f,    (3.3f, 3.3f), (1f, 1f)) == false
        );

        //======================================================================================================================================================
        RESULT("PointVsPolygon()", true
            && PointVsPolygon((0, 0.9f), Polygon2(5)) == true
            && PointVsPolygon((0, 1.1f), Polygon2(5)) == false
        );

        //======================================================================================================================================================
        RESULT("LineVsRect()", true
            && LineVsRect((0.5f, 1.5f), (1.5f, 1.5f),   (1f, 1f), (1f, 1f)) == true
            && LineVsRect((1.5f, 1.5f), (2.5f, 1.5f),   (1f, 1f), (1f, 1f)) == true

            && LineVsRect((0.5f, 1.5f), (2.5f, 1.5f),   (1f, 1f), (1f, 1f)) == true
            && LineVsRect((1.5f, 0.5f), (1.5f, 2.5f),   (1f, 1f), (1f, 1f)) == true
            && LineVsRect((2.5f, 1.5f), (0.5f, 1.5f),   (1f, 1f), (1f, 1f)) == true
            && LineVsRect((1.5f, 2.5f), (1.5f, 0.5f),   (1f, 1f), (1f, 1f)) == true

            && LineVsRect((0.5f, 1.5f), (1.5f, 2.5f),   (1f, 1f), (1f, 1f)) == true
            && LineVsRect((0.5f, 1.5f), (1.5f, 2.51f),   (1f, 1f), (1f, 1f)) == false
        );
        #if false
            PRINT($"------------------------------------------------------------------------------------------------------------------------");
            PRINT($"{LineVsRect((0.5f, 1.5f), (1.5f, 1.5f),   (1f, 1f), (1f, 1f))}");
            PRINT($"");
            PRINT($"{LineVsRect((1.5f, 1.5f), (2.5f, 1.5f),   (1f, 1f), (1f, 1f))}");
            PRINT($"------------------------------------------------------------------------------------------------------------------------");
            PRINT($"{LineVsRect((0.5f, 1.5f), (2.5f, 1.5f),   (1f, 1f), (1f, 1f))}");
            PRINT($"------------------------------------------------------------------------------------------------------------------------");
            PRINT($"{LineVsRect((0.5f, 1.5f), (1.5f, 2.4f),   (1f, 1f), (1f, 1f))}");
            PRINT($"");
            PRINT($"{LineVsRect((0.5f, 1.5f), (1.0f, 2.5f),   (1f, 1f), (1f, 1f))}");
            PRINT($"------------------------------------------------------------------------------------------------------------------------");
        #endif
        /*
        UtilityTest.Program.PRINT(
            $"""
            LINEvsRECT    La: {La:0.000}    Lb: {Lb:0.000}    Rp: {Rp:0.000}    Rs: {Rs:0.000}
                L0: {L0:0.000}    L1: {L1:0.000}        dAB: {dAB:0.000}
                R0: {R0:0.000}    R1: {R1:0.000}         Rs: {Rs:0.000}

            """
        );
        UtilityTest.Program.PRINT($"    Areas overlap: {!(L0 >  R1 || L1 <  R0)}");
        UtilityTest.Program.PRINT($"        Lb inside: {(Lb >= R0 && Lb <= R1)}");
        UtilityTest.Program.PRINT($"        La inside: {(La >= R0 && La <= R1)}\n");
        UtilityTest.Program.PRINT($"    dRR: {dRR:0.000}  dRL: {dRL:0.000}    d: {d,6:0.000}  r: {r,6:0.000}  s: {s,6:0.000}    {((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f))}");
        UtilityTest.Program.PRINT($"    dRR: {dRR:0.000}  dRL: {dRL:0.000}    d: {d,6:0.000}  r: {r,6:0.000}  s: {s,6:0.000}    {((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f))}");
        UtilityTest.Program.PRINT($"    dRR: {dRR:0.000}  dRL: {dRL:0.000}    d: {d,6:0.000}  r: {r,6:0.000}  s: {s,6:0.000}    {((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f))}");
        UtilityTest.Program.PRINT($"    dRR: {dRR:0.000}  dRL: {dRL:0.000}    d: {d,6:0.000}  r: {r,6:0.000}  s: {s,6:0.000}    {((r >= 0f && r <= 1f) && (s >= 0f && s <= 1f))}");
        */

        //======================================================================================================================================================
    }
}
