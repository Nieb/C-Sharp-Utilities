

namespace Utility;
internal static partial class VEC_Color {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float ByteToUnit(byte Byte) => (float)Byte / 255f;
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static byte UnitToByte(float Unit) => (byte)round(Unit * 255f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/f270540546
    //  https://entropymine.com/imageworsener/srgbformula/
    //
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float sRGB_to_Lin(float C) => (C <= 0.0404482362771082f) ? (C / 12.92f) : pow((C+0.055f)/1.055f, 2.4f);

    internal static vec3 sRGB_to_Lin(vec3 C) => sRGB_to_Lin(C.r, C.g, C.b);
    internal static vec3 sRGB_to_Lin(float R, float G, float B) => new vec3(sRGB_to_Lin(R), sRGB_to_Lin(G), sRGB_to_Lin(B));

    //[Impl(AggressiveInlining|AggressiveOptimization)] internal static vec3 sRGB_to_Lin(vec3 C) => new vec3(sRGB_to_Lin(C.r), sRGB_to_Lin(C.g), sRGB_to_Lin(C.b));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static vec4 sRGB_to_Lin(vec4 C) => new vec4(sRGB_to_Lin(C.r), sRGB_to_Lin(C.g), sRGB_to_Lin(C.b), C.a);

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] internal static float Lin_to_sRGB(float C) => (C <= 0.00313066844250063f) ? (C * 12.92f) : pow(C, 1f/2.4f)*1.055f - 0.055f;

    internal static vec3 Lin_to_sRGB(vec3 C) => Lin_to_sRGB(C.r, C.g, C.b);
    internal static vec3 Lin_to_sRGB(float R, float G, float B) => new vec3(Lin_to_sRGB(R), Lin_to_sRGB(G), Lin_to_sRGB(B));

    //[Impl(AggressiveInlining|AggressiveOptimization)] internal static vec3 Lin_to_sRGB(vec3 C) => new vec3(Lin_to_sRGB(C.r), Lin_to_sRGB(C.g), Lin_to_sRGB(C.b));

    [Impl(AggressiveInlining|AggressiveOptimization)] internal static vec4 Lin_to_sRGB(vec4 C) => new vec4(Lin_to_sRGB(C.r), Lin_to_sRGB(C.g), Lin_to_sRGB(C.b), C.a);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "(Hue, Saturation, Value)  to  (Red, Green, Blue)"
    //
    //      H: 0..6,
    //      S: 0..1,
    //      V: 0..1
    //
    //             |-----------@ C
    //             |-------@ X .
    //    |--------@ M     .   .
    //             .       .   .
    //    +-------------------------+
    //  R |=========       .   .    |
    //    |                .   .    |
    //  G |=================   .    |
    //    |                    .    |
    //  B |=====================    |
    //    +-------------------------+
    //
    //       Red Ylw Grn Cyn Blu Vlt Red
    //  Hue:  0   1   2   3   4   5   6
    //        :   1       1       1   :
    //        :  / \     / \     / \  :
    //    X:  : /   \   /   \   /   \ :
    //        :/     \ /     \ /     \:
    //        0       0       0       0
    //
    [Impl(AggressiveInlining|AggressiveOptimization)]
    internal static vec3 HSV_to_RGB(vec3 HSV) =>
        HSV_to_RGB(HSV.x, HSV.y, HSV.z);

    internal static vec3 HSV_to_RGB(float Hue, float Sat, float Val) {
        Hue = wrap(Hue, 0f, 6f);
        Sat = clamp(Sat);
        Val = clamp(Val);

        //  Is color Grey?
        if (Sat <= 0f)
            return new vec3(Val);

        float C = Val * Sat;
        float X = fract(Hue);
        float M = Val - C;

        return (Hue < 1f) ? new vec3(         Val,      C*X + M,            M)  //  Red
             : (Hue < 2f) ? new vec3(C*(1f-X) + M,          Val,            M)  //     Ylw
             : (Hue < 3f) ? new vec3(           M,          Val,      C*X + M)  //  Grn
             : (Hue < 4f) ? new vec3(           M, C*(1f-X) + M,          Val)  //     Cyn
             : (Hue < 5f) ? new vec3(     C*X + M,            M,          Val)  //  Blu
                          : new vec3(         Val,            M, C*(1f-X) + M); //     Vlt
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)]
    internal static vec3 RGB_to_HSV(vec3 RGB) =>
        HSV_to_RGB(RGB.r, RGB.g, RGB.b);

    internal static vec3 RGB_to_HSV(float Red, float Grn, float Blu) {
        Red = clamp(Red);
        Grn = clamp(Grn);
        Blu = clamp(Blu);

        //  Is color Grey?
        if (Red == Grn && Red == Blu)
            return new vec3(0f, 0f, Red);

        float Val = max(Red, Grn, Blu);

        float Dlt = Val - min(Red, Grn, Blu);

        float Hue = (Red == Val) ? (Grn - Blu)/Dlt
                  : (Grn == Val) ? (Blu - Red)/Dlt + 2f
                                 : (Red - Grn)/Dlt + 4f;
        Hue += (Hue < 0f) ? 6f : 0f; // Wrap.

        float Sat = Dlt / Val;

        return new vec3(Hue, Sat, Val);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Input should be in LinearSpace.
    //
    [Impl(AggressiveInlining|AggressiveOptimization)]
    internal static float ToBrightness(vec3 C) => (
          C.r * 0.2126f
        + C.g * 0.7152f
        + C.b * 0.0722f
    );

    //==========================================================================================================================================================
    //
    //  Based on OkLab ColorSpace.
    //
    //  Input should be in LinearSpace.
    //
    internal static float ToLightness(vec3 C) => (
          0.2104542553f * cbrt(0.4122214708f*C.r + 0.5363325363f*C.g + 0.0514459929f*C.b)
        + 0.7936177850f * cbrt(0.2119034982f*C.r + 0.6806995451f*C.g + 0.1073969566f*C.b)
        - 0.0040720468f * cbrt(0.0883024619f*C.r + 0.2817188376f*C.g + 0.6299787005f*C.b)
    );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Pseudo-ToneMapping:
    //      "Pseudo" because it operates on normalized-values instead of quantitative-values.
    //
    internal static float PseudoToneMap(float V, float A, float B) {
        float iB = 1f-B;
        float iV = 1f-V;
        float VV = V*V;
        return pow(V, A) + (VV*iV)/(VV*iB + B);
    }

    internal static vec3 PseudoToneMap(vec3 V, float A, float B) {
        float iB = 1f-B;
        vec3  iV = 1f-V;
        vec3  VV = V*V;
        return pow(V, A) + (VV*iV)/(VV*iB + B);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
