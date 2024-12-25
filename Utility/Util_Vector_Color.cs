using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ByteToUnit(byte Byte) => (float)Byte / 255f;

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte UnitToByte(float Unit) => (byte)MathF.Round(Unit * 255f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// https://www.desmos.com/calculator/6uaprr91ju
    /// https://entropymine.com/imageworsener/srgbformula/
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float sRGB_To_Lin(float C) => (C <= 0.0404482362771082f) ? (C / 12.92f) : MathF.Pow((C+0.055f) / 1.055f, 2.4f);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 sRGB_To_Lin(vec3 C) =>
        new vec3(
            (C.r <= 0.0404482362771082f) ? (C.r / 12.92f) : MathF.Pow((C.r+0.055f) / 1.055f, 2.4f),
            (C.g <= 0.0404482362771082f) ? (C.g / 12.92f) : MathF.Pow((C.g+0.055f) / 1.055f, 2.4f),
            (C.b <= 0.0404482362771082f) ? (C.b / 12.92f) : MathF.Pow((C.b+0.055f) / 1.055f, 2.4f)
        );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 sRGB_To_Lin(vec4 C) =>
        new vec4(
            (C.r <= 0.0404482362771082f) ? (C.r / 12.92f) : MathF.Pow((C.r+0.055f) / 1.055f, 2.4f),
            (C.g <= 0.0404482362771082f) ? (C.g / 12.92f) : MathF.Pow((C.g+0.055f) / 1.055f, 2.4f),
            (C.b <= 0.0404482362771082f) ? (C.b / 12.92f) : MathF.Pow((C.b+0.055f) / 1.055f, 2.4f),
             C.a
        );

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Lin_To_sRGB(float C) => (C <= 0.00313066844250063f) ? (C * 12.92f) : MathF.Pow(C, 1f/2.4f)*1.055f - 0.055f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 Lin_To_sRGB(vec3 C) =>
        new vec3(
            (C.r <= 0.00313066844250063f) ? (C.r * 12.92f) : MathF.Pow(C.r, 1f/2.4f)*1.055f - 0.055f,
            (C.g <= 0.00313066844250063f) ? (C.g * 12.92f) : MathF.Pow(C.g, 1f/2.4f)*1.055f - 0.055f,
            (C.b <= 0.00313066844250063f) ? (C.b * 12.92f) : MathF.Pow(C.b, 1f/2.4f)*1.055f - 0.055f
        );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 Lin_To_sRGB(vec4 C) =>
        new vec4(
            (C.r <= 0.00313066844250063f) ? (C.r * 12.92f) : MathF.Pow(C.r, 1f/2.4f)*1.055f - 0.055f,
            (C.g <= 0.00313066844250063f) ? (C.g * 12.92f) : MathF.Pow(C.g, 1f/2.4f)*1.055f - 0.055f,
            (C.b <= 0.00313066844250063f) ? (C.b * 12.92f) : MathF.Pow(C.b, 1f/2.4f)*1.055f - 0.055f,
             C.a
        );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public static vec3 FromHSV(vec3 HSV) => FromHSV(HSV.x, HSV.y, HSV.z);
    public static vec3 FromHSV(float Hue, float Sat, float Val) {
        Sat = clamp(Sat, 0f, 1f);
        Val = clamp(Val, 0f, 1f);

        if (Sat <= 0f)
            return new vec3(Val);

        Hue = wrap(Hue, 0f, 3.6f);

        //      Chroma |-----------@
        //           X |---@       .
        //         min @   .       .
        //             .   .       .
        //    +-------------------------+
        //  R |=========   .       .    |
        //    |            .       .    |
        //  G |=============       .    |
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

        float Chroma = Val * Sat;

        float min    = Val - Chroma;

        float X = 1f - abs(Hue % 1.2f - 0.6f) / 0.6f;
              X = min + X*Chroma;

        return (Hue < 0.6f) ? new vec3(Val,   X, min)
             : (Hue < 1.2f) ? new vec3(  X, Val, min)
             : (Hue < 1.8f) ? new vec3(min, Val,   X)
             : (Hue < 2.4f) ? new vec3(min,   X, Val)
             : (Hue < 3.0f) ? new vec3(  X, min, Val)
             : /*   < 3.6f */ new vec3(Val, min,   X);
    }

    //==========================================================================================================================================================
    public static vec3 FromHSB(vec3 HSB) => FromHSB(HSB.x, HSB.y, HSB.z);
    public static vec3 FromHSB(float Hue, float Sat, float Bri) {
        //  ??? generate colors with uniform*** brightness...

        //  *** uniform-ish
        //  Not actually uniform, but an approximation.
        //  To be truly uniform, all other colors would be restricted to the brightness of the darkest perceived color (blue?),
        //
        return new vec3();
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Brightness  is  Perceptual
    /// Luminance   is  Quantitative
    ///
    /// Input should be in LinearSpace.
    ///
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float ToBrightness(vec3 C) => (C.r * 0.2126f  +  C.g * 0.7152f  +  C.b * 0.0722f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
