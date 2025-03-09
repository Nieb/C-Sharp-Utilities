
namespace TEST;
internal static partial class Program {
    static void Test__Vector_Collision2() {
        PRINT("\n[Utility.VEC -- Collision2]");
        //PRINT($"{}");
        //PRINT($"{PointVsPolygon((0, 0.9f), UnitPolygon(5) )}");

        //======================================================================================================================================================
        RESULT("CircleVsRect()", true
            && CircleVsRect((2.6f, 2.6f), 1f, (3.3f, 3.3f), (2f, 2f)) == true
            && CircleVsRect((2.5f, 2.5f), 1f, (3.3f, 3.3f), (2f, 2f)) == false

            && CircleVsRect((5.0f, 5.0f), 1f, (3.3f, 3.3f), (1f, 1f)) == true
            && CircleVsRect((5.1f, 5.1f), 1f, (3.3f, 3.3f), (1f, 1f)) == false
        );

        //======================================================================================================================================================
        RESULT("PointVsPolygon()", true
            && PointVsPolygon((0, 0.9f), Polygon2(5)) == true
            && PointVsPolygon((0, 1.1f), Polygon2(5)) == false
        );

        //======================================================================================================================================================
    }
}
