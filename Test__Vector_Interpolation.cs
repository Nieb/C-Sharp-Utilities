
namespace TEST;
internal static partial class Program {
    static void Test__Vector_Interpolation() {
        PRINT("\n[Utility.Vector_Interpolation]");


        RESULT("Mix()", true
            && round(Mix(0.0f, 1.7f, 3.4f), 0.000001f) == 1.7f
            && round(Mix(0.5f, 1.7f, 3.4f), 0.000001f) == 2.55f
            && round(Mix(1.0f, 1.7f, 3.4f), 0.000001f) == 3.4f
        );

        RESULT("BiMix()", true
            && BiMix(new vec2(0.0f, 0.0f), 0f, 1f, 2f, 3f) == 0f
            && BiMix(new vec2(1.0f, 0.0f), 0f, 1f, 2f, 3f) == 1f
            && BiMix(new vec2(0.0f, 1.0f), 0f, 1f, 2f, 3f) == 2f
            && BiMix(new vec2(1.0f, 1.0f), 0f, 1f, 2f, 3f) == 3f

            && BiMix(new vec2(0.25f, 0.25f), 0f, 1f, 2f, 3f) == 0.75f
            && BiMix(new vec2(0.50f, 0.25f), 0f, 1f, 2f, 3f) == 1.00f
            && BiMix(new vec2(0.75f, 0.25f), 0f, 1f, 2f, 3f) == 1.25f
            && BiMix(new vec2(0.25f, 0.50f), 0f, 1f, 2f, 3f) == 1.25f
            && BiMix(new vec2(0.50f, 0.50f), 0f, 1f, 2f, 3f) == 1.50f
            && BiMix(new vec2(0.75f, 0.50f), 0f, 1f, 2f, 3f) == 1.75f
            && BiMix(new vec2(0.25f, 0.75f), 0f, 1f, 2f, 3f) == 1.75f
            && BiMix(new vec2(0.50f, 0.75f), 0f, 1f, 2f, 3f) == 2.00f
            && BiMix(new vec2(0.75f, 0.75f), 0f, 1f, 2f, 3f) == 2.25f
        );

        RESULT("SmoothMix()", true
            && round(SmoothMix(0.0f, 1.7f, 3.4f), 0.000001f) == 1.7f
            && round(SmoothMix(0.5f, 1.7f, 3.4f), 0.000001f) == 2.55f
            && round(SmoothMix(1.0f, 1.7f, 3.4f), 0.000001f) == 3.4f
        );




        PRINT("");
        RESULT("Step()", true
            && Step(0.0f, 1.0f) == 0f
            && Step(0.5f, 1.0f) == 0f
            && Step(1.0f, 1.0f) == 1f
            && Step(1.5f, 1.0f) == 1f
            && Step(2.0f, 1.0f) == 1f
        );

        RESULT("LinearStep()", true
            && round(LinearStep(1.70f, 1.7f, 3.4f), 0.000001f) == 0.0f
            && round(LinearStep(2.55f, 1.7f, 3.4f), 0.000001f) == 0.5f
            && round(LinearStep(3.40f, 1.7f, 3.4f), 0.000001f) == 1.0f
            //...
        );

        RESULT("SmoothStep()", true
            && round(SmoothStep(1.70f, 1.7f, 3.4f), 0.000001f) == 0.0f
            && round(SmoothStep(2.55f, 1.7f, 3.4f), 0.000001f) == 0.5f
            && round(SmoothStep(3.40f, 1.7f, 3.4f), 0.000001f) == 1.0f
            //...
        );


    }
}
