using System;
using System.Diagnostics;

namespace TEST {
internal static partial class Program {
    static void PRINT(string PrintMe) => Console.WriteLine(PrintMe);

    static void RESULT(string TestLabel, bool Result) =>
        Console.WriteLine( $"{TestLabel,32}" + (Result ? ": Pass" : ": FAILURE") );
}}

namespace Utility {
public static partial class VEC {
#if true
    public static bool ApproximatelyEquals(this float A, float B) => abs(A-B) < EPSILON;
    public static bool ApproximatelyEquals(this vec2  A, vec2  B) => abs(A-B) < EPSILON;
    public static bool ApproximatelyEquals(this vec3  A, vec3  B) => abs(A-B) < EPSILON;
    public static bool ApproximatelyEquals(this vec4  A, vec4  B) => abs(A-B) < EPSILON;
#endif

#if false
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >>(vec3  A, vec3  B) => (abs(A.x-B.x) < EPSILON && abs(A.y-B.y) < EPSILON && abs(A.z-B.z) < EPSILON); //  "Approximately EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >>(vec3  A, float B) => (abs(A.x-B  ) < EPSILON && abs(A.y-B  ) < EPSILON && abs(A.z-B  ) < EPSILON);
#endif

#if false
    public static vec2 ToDeg(vec2 Radians) => (Radians * (float)(180 / 3.14159265358979323846264338327950288419716939937511));
    public static vec3 ToDeg(vec3 Radians) => (Radians * (float)(180 / 3.14159265358979323846264338327950288419716939937511));

    public static vec2 ToRad(vec2 Degrees) => (Degrees * (float)(3.14159265358979323846264338327950288419716939937511 / 180));
    public static vec3 ToRad(vec3 Degrees) => (Degrees * (float)(3.14159265358979323846264338327950288419716939937511 / 180));
#endif
}}
