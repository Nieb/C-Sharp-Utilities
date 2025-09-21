using System;
using System.Runtime.CompilerServices;

namespace Utility;
internal static partial class VEC_Generate {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  Generate array of points of a regular polygon.
    //
    //  Point weinding is anti-clockwise.
    //  Though, using a negative radius will reverse the order.
    //
    //  https://www.desmos.com/calculator/ljqolw7ab1
    //
    internal static vec2[] Polygon2(int Sides, float Radius = 1f) {
        #if DEBUG
            if (Sides < 3) throw new ArgumentException("Derp?");
        #endif

        vec2[] Polygon = new vec2[Sides];

        for (int i = 0; i < Sides; ++i) {
            float rad = -i * (PI2/Sides);
            Polygon[i] = new vec2(sin(rad)*Radius, cos(rad)*Radius);
        }

        return Polygon;
    }

    //==========================================================================================================================================================
    internal static vec3[] Polygon3(int Sides, float Radius = 1f) {
        #if DEBUG
            if (Sides < 3) throw new ArgumentException("Derp?");
        #endif

        vec3[] Polygon = new vec3[Sides];

        for (int i = 0; i < Sides; ++i) {
            float rad = -i * (PI2/Sides);
            Polygon[i] = new vec3(sin(rad)*Radius, 0f, -cos(rad)*Radius);
        }

        return Polygon;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      LINE(  A = (x,y), B = (x,y),    Segs = 2, Rds = 1f  )
    //
    //                        0            9
    //                    1 .-+------------+-. 8
    //                     / \|            |/ \
    //                  2 +---A------------B---+ 7
    //                     \ /|            |\ /
    //                    3 '-+------------+-' 6
    //                        4            5
    //
    //  Segments is per-Quadrant.
    //
    internal static vec2[] ___LINE___(vec2 A, vec2 B, int Segments, float Radius = 1f) {
        vec2 dAB = B-A;
        vec2 P0 = normalize( (-dAB.y, dAB.x) );

        vec2[] P = new vec2[4*Segments+2];

        P[         0  ] = A + Radius*P0;
        P[  Segments  ] = A + Radius*new vec2(-P0.y,  P0.x);
        P[2*Segments  ] = A - Radius*P0;

        P[2*Segments+1] = B - Radius*P0;
        P[3*Segments+1] = B + Radius*new vec2( P0.y, -P0.x);
        P[4*Segments+1] = B + Radius*P0;

        if (Segments > 1) {
            int i1 =   Segments;
            int i2 = 2*Segments + 1;
            int i3 = 3*Segments + 1;

            float ThetaStep = -PIH/Segments;
            vec2 dP;

            for (int iSeg = 1; iSeg < Segments; ++iSeg) {

                dP = rot(P0, ThetaStep * (float)iSeg);

                P[   iSeg] = A + Radius*dP;
                P[i1+iSeg] = A + Radius*new vec2(-dP.y,  dP.x);

                P[i2+iSeg] = B + Radius*new vec2(-dP.x, -dP.y);
                P[i3+iSeg] = B + Radius*new vec2( dP.y, -dP.x);
            }
        }


        return P;
    }



        /*
            vec2[] P = new vec2[10];
            P[0] = A +      P0;
            P[1] = A + rot( P0, -ToRad( 45f));
            P[2] = A + rot( P0, -ToRad( 90f));
            P[3] = A + rot( P0, -ToRad(135f));
            P[4] = A +     -P0;
            P[5] = B +     -P0;
            P[6] = B + rot(-P0, -ToRad( 45f));
            P[7] = B + rot(-P0, -ToRad( 90f));
            P[8] = B + rot(-P0, -ToRad(135f));
            P[9] = B +      P0;
        */


    #if  false

    internal static void DrawCircleX(vec3 C, float Cr, int Segments) {
        //vec3 A = (0f, Cr, 0f);
        //vec3 B = (0f, 0f, 0f);

        float A_y = Cr, A_z = 0f;
        float B_y = 0f, B_z = 0f;

        if (Segments > 1) {
            float StepSize = PIH/Segments;

            for (int iSeg = 1; iSeg < Segments; ++iSeg) {
                B_y = cos(StepSize*iSeg) * Cr;
                B_z = sin(StepSize*iSeg) * Cr;
                DrawLine( WorldToScreen(C.x, C.y+A_y, -C.z-A_z), WorldToScreen(C.x, C.y+B_y, -C.z-B_z) );
                DrawLine( WorldToScreen(C.x, C.y-A_y, -C.z-A_z), WorldToScreen(C.x, C.y-B_y, -C.z-B_z) );
                DrawLine( WorldToScreen(C.x, C.y-A_y, -C.z+A_z), WorldToScreen(C.x, C.y-B_y, -C.z+B_z) );
                DrawLine( WorldToScreen(C.x, C.y+A_y, -C.z+A_z), WorldToScreen(C.x, C.y+B_y, -C.z+B_z) );
                A_y = B_y;
                A_z = B_z;
            }
        }

        B_y = 0f;
        B_z = Cr;
        DrawLine( WorldToScreen(C.x, C.y+A_y, -C.z-A_z), WorldToScreen(C.x, C.y+B_y, -C.z-B_z) );
        DrawLine( WorldToScreen(C.x, C.y-A_y, -C.z-A_z), WorldToScreen(C.x, C.y-B_y, -C.z-B_z) );
        DrawLine( WorldToScreen(C.x, C.y-A_y, -C.z+A_z), WorldToScreen(C.x, C.y-B_y, -C.z+B_z) );
        DrawLine( WorldToScreen(C.x, C.y+A_y, -C.z+A_z), WorldToScreen(C.x, C.y+B_y, -C.z+B_z) );
    }

    internal static vec2 WorldToScreen(vec3 W) => WorldToScreen(W.x, W.y, W.z);
    internal static vec2 WorldToScreen(float W_x, float W_y, float W_z) {
        vec2 ScreenPos = new();
        return ScreenPos;
    }


    #endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
