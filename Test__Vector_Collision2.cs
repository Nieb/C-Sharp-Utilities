using System;

namespace TEST;
internal static partial class Program {
    static void Test__Vector_Collision2() {
        PRINT("\n\n[Utility.VEC -- Collision2]\n");
        //PRINT($"{}");
        //PRINT($"{PointVsPolygon((0, 0.9f), UnitPolygon(5) )}");

        //======================================================================================================================================================
        RESULT("CircleVsAar()", true
            && CircleVsAar((2.6f, 2.6f), 1f, (3.3f, 3.3f), (2f, 2f)) == true
            && CircleVsAar((2.5f, 2.5f), 1f, (3.3f, 3.3f), (2f, 2f)) == false

            && CircleVsAar((5.0f, 5.0f), 1f, (3.3f, 3.3f), (1f, 1f)) == true
            && CircleVsAar((5.1f, 5.1f), 1f, (3.3f, 3.3f), (1f, 1f)) == false
        );

        //======================================================================================================================================================
        RESULT("PointVsPolygon()", true
            && PointVsPolygon((0, 0.9f), Polygon2(5)) == true
            && PointVsPolygon((0, 1.1f), Polygon2(5)) == false
        );

        //======================================================================================================================================================
    }
}
