using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Utility;
internal static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float ByteToUnit(byte Byte) => (float)Byte / 255f;

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static byte UnitToByte(float Unit) => (byte)MathF.Round(Unit * 255f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  https://www.desmos.com/calculator/6uaprr91ju
    //  https://entropymine.com/imageworsener/srgbformula/
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float sRGB_to_Lin(float C) => (C <= 0.0404482362771082f) ? (C / 12.92f) : MathF.Pow((C+0.055f) / 1.055f, 2.4f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 sRGB_to_Lin(vec3 C) =>
        new vec3(
            (C.r <= 0.0404482362771082f) ? (C.r / 12.92f) : MathF.Pow((C.r+0.055f) / 1.055f, 2.4f),
            (C.g <= 0.0404482362771082f) ? (C.g / 12.92f) : MathF.Pow((C.g+0.055f) / 1.055f, 2.4f),
            (C.b <= 0.0404482362771082f) ? (C.b / 12.92f) : MathF.Pow((C.b+0.055f) / 1.055f, 2.4f)
        );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 sRGB_to_Lin(vec4 C) =>
        new vec4(
            (C.r <= 0.0404482362771082f) ? (C.r / 12.92f) : MathF.Pow((C.r+0.055f) / 1.055f, 2.4f),
            (C.g <= 0.0404482362771082f) ? (C.g / 12.92f) : MathF.Pow((C.g+0.055f) / 1.055f, 2.4f),
            (C.b <= 0.0404482362771082f) ? (C.b / 12.92f) : MathF.Pow((C.b+0.055f) / 1.055f, 2.4f),
             C.a
        );

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float Lin_to_sRGB(float C) => (C <= 0.00313066844250063f) ? (C * 12.92f) : MathF.Pow(C, 1f/2.4f)*1.055f - 0.055f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 Lin_to_sRGB(vec3 C) =>
        new vec3(
            (C.r <= 0.00313066844250063f) ? (C.r * 12.92f) : MathF.Pow(C.r, 1f/2.4f)*1.055f - 0.055f,
            (C.g <= 0.00313066844250063f) ? (C.g * 12.92f) : MathF.Pow(C.g, 1f/2.4f)*1.055f - 0.055f,
            (C.b <= 0.00313066844250063f) ? (C.b * 12.92f) : MathF.Pow(C.b, 1f/2.4f)*1.055f - 0.055f
        );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec4 Lin_to_sRGB(vec4 C) =>
        new vec4(
            (C.r <= 0.00313066844250063f) ? (C.r * 12.92f) : MathF.Pow(C.r, 1f/2.4f)*1.055f - 0.055f,
            (C.g <= 0.00313066844250063f) ? (C.g * 12.92f) : MathF.Pow(C.g, 1f/2.4f)*1.055f - 0.055f,
            (C.b <= 0.00313066844250063f) ? (C.b * 12.92f) : MathF.Pow(C.b, 1f/2.4f)*1.055f - 0.055f,
             C.a
        );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "(Hue, Saturation, Value) to (Red, Green, Blue)"
    //
    //  This is technically color space agnostic...
    //
    //      H: 0 to 3.6
    //      S: 0 to 1
    //      V: 0 to 1
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static vec3 HSV_to_RGB(vec3 HSV) => HSV_to_RGB(HSV.x, HSV.y, HSV.z);

    internal static vec3 HSV_to_RGB(float Hue, float Sat, float Val) {
        Sat = clamp(Sat);
        Val = clamp(Val);

        if (Sat <= 0f)
            return new vec3(Val);

        Hue = wrap(Hue, 0f, 3.6f);

        //             |-----------@ Chroma
        //             |-------@ X .
        //    |--------@ Min   .   .
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
        //  Hue: 0.0 0.6 1.2 1.8 2.4 3.0 3.6
        //            1       1       1
        //           / \     / \     / \
        //    X:    /   \   /   \   /   \
        //         /     \ /     \ /     \
        //        0       0       0       0

        #if true
            float C = Val * Sat;
            float X;
            float M = Val - C;

            const float R = 1f/0.6f;

            if      (Hue < 0.6f) { X = M + (     C*( Hue       * R)); return new vec3(Val,   X,   M); } //  Red
            else if (Hue < 1.2f) { X = M + (1f - C*((Hue-0.6f) * R)); return new vec3(  X, Val,   M); } //     Ylw
            else if (Hue < 1.8f) { X = M + (     C*((Hue-1.2f) * R)); return new vec3(  M, Val,   X); } //  Grn
            else if (Hue < 2.4f) { X = M + (1f - C*((Hue-1.8f) * R)); return new vec3(  M,   X, Val); } //     Cyn
            else if (Hue < 3.0f) { X = M + (     C*((Hue-2.4f) * R)); return new vec3(  X,   M, Val); } //  Blu
            else                 { X = M + (1f - C*((Hue-3.0f) * R)); return new vec3(Val,   M,   X); } //     Vlt
        #else
            float X = M + (1f - abs(Hue % 1.2f - 0.6f) / 0.6f)*C;

            return (Hue < 0.6f) ? new vec3(Val,   X,   M)
                 : (Hue < 1.2f) ? new vec3(  X, Val,   M)
                 : (Hue < 1.8f) ? new vec3(  M, Val,   X)
                 : (Hue < 2.4f) ? new vec3(  M,   X, Val)
                 : (Hue < 3.0f) ? new vec3(  X,   M, Val)
                 : /*   < 3.6f */ new vec3(Val,   M,   X);
        #endif
    }

    //==========================================================================================================================================================
    internal static vec3 FromHSB(vec3 HSB) => FromHSB(HSB.x, HSB.y, HSB.z);

    internal static vec3 FromHSB(float Hue, float Sat, float Bri) {
        //  Generate colors with uniform-ish brightness...?
        //      Not actually uniform, but an approximation.
        //      To be truly uniform,
        //      all colors would be restricted to the brightness of the darkest perceived color. (blue?)
        return new vec3();
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  "Luminance":    Quantitative    (A quantity of light.)
    //  "Lightness":    Perceptual      (What the light looks like.)
    //  "Brightness":   Colloquial term, a less rigorous version of "Lightness"
    //
    //  Input should be in LinearSpace.
    //
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static float ToBrightness(vec3 C) => (C.r * 0.2126f  +  C.g * 0.7152f  +  C.b * 0.0722f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
