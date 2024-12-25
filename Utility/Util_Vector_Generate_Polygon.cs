using System;
using System.Runtime.CompilerServices;

namespace Utility;
public static partial class VEC {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    ///
    /// Generate array of points of a regular polygon.
    ///
    /// Point weinding is anti-clockwise.
    /// Though, using a negative radius will reverse the order.
    ///
    /// https://www.desmos.com/calculator/ljqolw7ab1
    ///
    public static vec2[] Polygon2(int Sides, float Radius = 1f) {
        #if DEBUG
            if (Sides < 3) throw new ArgumentException("Derp?");
        #endif

        vec2[] Polygon = new vec2[Sides];

        for (int i = 0; i < Sides; ++i) {
            float rad = -i * (PI2/Sides);
            Polygon[i] = (sin(rad)*Radius, cos(rad)*Radius);
        }

        return Polygon;
    }

    //==========================================================================================================================================================
    public static vec3[] Polygon3(int Sides, float Radius = 1f) {
        #if DEBUG
            if (Sides < 3) throw new ArgumentException("Derp?");
        #endif

        vec3[] Polygon = new vec3[Sides];

        for (int i = 0; i < Sides; ++i) {
            float rad = -i * (PI2/Sides);
            Polygon[i] = (sin(rad)*Radius, 0f, -cos(rad)*Radius);
        }

        return Polygon;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
