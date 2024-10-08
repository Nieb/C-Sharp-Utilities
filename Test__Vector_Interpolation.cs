
namespace TEST;
internal static partial class Program {
    static void Test__Vector_Interpolation() {
        PRINT("\n\n[Utility.VEC -- Interpolation]\n");
        //PRINT($"{}");

        //======================================================================================================================================================
        RESULT("Mix()", true
            && Mix(0.0f, 1.7f, 3.4f).IsApproximately(1.7f)
            && Mix(0.5f, 1.7f, 3.4f).IsApproximately(2.55f)
            && Mix(1.0f, 1.7f, 3.4f).IsApproximately(3.4f)

            //@@ more...
        );

        RESULT("BiMix()", true
            && BiMix((0.0f, 0.0f), 0, 1, 2, 3).IsApproximately(0)
            && BiMix((1.0f, 0.0f), 0, 1, 2, 3).IsApproximately(1)
            && BiMix((0.0f, 1.0f), 0, 1, 2, 3).IsApproximately(2)
            && BiMix((1.0f, 1.0f), 0, 1, 2, 3).IsApproximately(3)

            && BiMix((0.25f, 0.25f), 0, 1, 2, 3).IsApproximately(0.75f)
            && BiMix((0.50f, 0.25f), 0, 1, 2, 3).IsApproximately(1.00f)
            && BiMix((0.75f, 0.25f), 0, 1, 2, 3).IsApproximately(1.25f)
            && BiMix((0.25f, 0.50f), 0, 1, 2, 3).IsApproximately(1.25f)
            && BiMix((0.50f, 0.50f), 0, 1, 2, 3).IsApproximately(1.50f)
            && BiMix((0.75f, 0.50f), 0, 1, 2, 3).IsApproximately(1.75f)
            && BiMix((0.25f, 0.75f), 0, 1, 2, 3).IsApproximately(1.75f)
            && BiMix((0.50f, 0.75f), 0, 1, 2, 3).IsApproximately(2.00f)
            && BiMix((0.75f, 0.75f), 0, 1, 2, 3).IsApproximately(2.25f)

            //@@ more...
        );

        RESULT("SmoothMix()", true
            && SmoothMix(0.0f, 1.7f, 3.4f).IsApproximately(1.7f)
            && SmoothMix(0.5f, 1.7f, 3.4f).IsApproximately(2.55f)
            && SmoothMix(1.0f, 1.7f, 3.4f).IsApproximately(3.4f)

            //@@ more...
        );

        //======================================================================================================================================================
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
            && LinearStep(1.70f, 1.7f, 3.4f).IsApproximately(0.0f)
            && LinearStep(2.55f, 1.7f, 3.4f).IsApproximately(0.5f)
            && LinearStep(3.40f, 1.7f, 3.4f).IsApproximately(1.0f)

            //@@ more...
        );

        RESULT("SmoothStep()", true
            && SmoothStep(1.70f, 1.7f, 3.4f).IsApproximately(0.0f)
            && SmoothStep(2.55f, 1.7f, 3.4f).IsApproximately(0.5f)
            && SmoothStep(3.40f, 1.7f, 3.4f).IsApproximately(1.0f)

            //@@ more...
        );

        //======================================================================================================================================================
    }
}
