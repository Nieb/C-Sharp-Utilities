using System;

namespace TEST;
internal static partial class Program {
    static void Test__Vector_Collision2() {
        PRINT("\n\n[Utility.VEC -- Collision2]\n");
        //PRINT($"{}");

        //======================================================================================================================================================
        //PRINT($"{PointVsPolygon((0, 0.9f), UnitPolygon(5) )}");
        RESULT("PointVsPolygon()", true
            && PointVsPolygon((0, 0.9f), Polygon2(5)) == true
            && PointVsPolygon((0, 1.1f), Polygon2(5)) == false
        );

        //======================================================================================================================================================
    }
}
