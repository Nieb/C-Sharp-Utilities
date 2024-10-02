
namespace TEST;
internal static partial class Program {
    static void Test__Vector_Interpolation() {
        PRINT("\n[Utility.VEC -- Interpolation]");

        //======================================================================================================================================================
        RESULT("Mix()", true
            && Mix(0.0f, 1.7f, 3.4f).ApproximatelyEquals(1.7f)
            && Mix(0.5f, 1.7f, 3.4f).ApproximatelyEquals(2.55f)
            && Mix(1.0f, 1.7f, 3.4f).ApproximatelyEquals(3.4f)

            //@@ more...
        );

        RESULT("BiMix()", true
            && BiMix(new vec2(0.0f, 0.0f), 0, 1, 2, 3).ApproximatelyEquals(0)
            && BiMix(new vec2(1.0f, 0.0f), 0, 1, 2, 3).ApproximatelyEquals(1)
            && BiMix(new vec2(0.0f, 1.0f), 0, 1, 2, 3).ApproximatelyEquals(2)
            && BiMix(new vec2(1.0f, 1.0f), 0, 1, 2, 3).ApproximatelyEquals(3)

            && BiMix(new vec2(0.25f, 0.25f), 0, 1, 2, 3).ApproximatelyEquals(0.75f)
            && BiMix(new vec2(0.50f, 0.25f), 0, 1, 2, 3).ApproximatelyEquals(1.00f)
            && BiMix(new vec2(0.75f, 0.25f), 0, 1, 2, 3).ApproximatelyEquals(1.25f)
            && BiMix(new vec2(0.25f, 0.50f), 0, 1, 2, 3).ApproximatelyEquals(1.25f)
            && BiMix(new vec2(0.50f, 0.50f), 0, 1, 2, 3).ApproximatelyEquals(1.50f)
            && BiMix(new vec2(0.75f, 0.50f), 0, 1, 2, 3).ApproximatelyEquals(1.75f)
            && BiMix(new vec2(0.25f, 0.75f), 0, 1, 2, 3).ApproximatelyEquals(1.75f)
            && BiMix(new vec2(0.50f, 0.75f), 0, 1, 2, 3).ApproximatelyEquals(2.00f)
            && BiMix(new vec2(0.75f, 0.75f), 0, 1, 2, 3).ApproximatelyEquals(2.25f)

            //@@ more...
        );

        RESULT("SmoothMix()", true
            && SmoothMix(0.0f, 1.7f, 3.4f).ApproximatelyEquals(1.7f)
            && SmoothMix(0.5f, 1.7f, 3.4f).ApproximatelyEquals(2.55f)
            && SmoothMix(1.0f, 1.7f, 3.4f).ApproximatelyEquals(3.4f)

            //@@ more...
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("Step()", true
            && Step(-2.00f, -1) == 0
            && Step(-1.50f, -1) == 0
            && Step(-1.01f, -1) == 0
            && Step(-1.00f, -1) == 1
            && Step(-0.99f, -1) == 1
            && Step(-0.50f, -1) == 1
            && Step( 0.00f, -1) == 1

            && Step(0.00f, 1) == 0
            && Step(0.50f, 1) == 0
            && Step(0.99f, 1) == 0
            && Step(1.00f, 1) == 1
            && Step(1.01f, 1) == 1
            && Step(1.50f, 1) == 1
            && Step(2.00f, 1) == 1
        );

        RESULT("LinearStep()", true
            && LinearStep(1.70f, 1.7f, 3.4f).ApproximatelyEquals(0.0f)
            && LinearStep(2.55f, 1.7f, 3.4f).ApproximatelyEquals(0.5f)
            && LinearStep(3.40f, 1.7f, 3.4f).ApproximatelyEquals(1.0f)

            //@@ more...
        );

        RESULT("SmoothStep()", true
            && SmoothStep(1.70f, 1.7f, 3.4f).ApproximatelyEquals(0.0f)
            && SmoothStep(2.55f, 1.7f, 3.4f).ApproximatelyEquals(0.5f)
            && SmoothStep(3.40f, 1.7f, 3.4f).ApproximatelyEquals(1.0f)

            //@@ more...
        );

        //======================================================================================================================================================
    }
}
