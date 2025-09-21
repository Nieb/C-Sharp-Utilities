using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec2 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public float x;    [FieldOffset(0)] public float u;
    [FieldOffset(4)] public float y;    [FieldOffset(4)] public float v;

    //==========================================================================================================================================================
    //  NOTE: Length is computed each time it is accessed.
    public float length {
        get => sqrt(x*x + y*y);
        set => this = (this == 0f) ? this : this*(value/sqrt(x*x + y*y));
    }

    public readonly float length2 => (x*x + y*y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec2() {}
    public vec2(float X, float Y) { x = X;  y = Y;  }
    public vec2(float XY        ) { x = XY; y = XY; }

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator vec2( (float X, float Y) t ) => new vec2(t.X, t.Y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator bool(vec2 A) => (A.x != 0f || A.y != 0f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator +(vec2  A, vec2  B) => new vec2(A.x+B.x, A.y+B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator +(vec2  A, float B) => new vec2(A.x+B  , A.y+B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator +(float A, vec2  B) => new vec2(A  +B.x, A  +B.y);


    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator -(vec2  A, vec2  B) => new vec2(A.x-B.x, A.y-B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator -(vec2  A, float B) => new vec2(A.x-B  , A.y-B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator -(float A, vec2  B) => new vec2(A  -B.x, A  -B.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator -(vec2 A)           => new vec2(   -A.x,    -A.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator *(vec2  A, vec2  B) => new vec2(A.x*B.x, A.y*B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator *(vec2  A, float B) => new vec2(A.x*B  , A.y*B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator *(float A, vec2  B) => new vec2(A  *B.x, A  *B.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator /(vec2  A, vec2  B) => new vec2(A.x/B.x, A.y/B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator /(vec2  A, float B) => new vec2(A.x/B  , A.y/B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator /(float A, vec2  B) => new vec2(A  /B.x, A  /B.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator %(vec2  A, vec2  B) => new vec2(A.x%B.x, A.y%B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator %(vec2  A, float B) => new vec2(A.x%B  , A.y%B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec2 operator %(float A, vec2  B) => new vec2(A  %B.x, A  %B.y);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator ==(vec2  A, vec2  B) => (A.x == B.x && A.y == B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator ==(vec2  A, float B) => (A.x == B   && A.y == B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator !=(vec2  A, vec2  B) => (A.x != B.x || A.y != B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator !=(vec2  A, float B) => (A.x != B   || A.y != B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  <(vec2  A, vec2  B) => (A.x <  B.x && A.y <  B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  <(vec2  A, float B) => (A.x <  B   && A.y <  B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  >(vec2  A, vec2  B) => (A.x >  B.x && A.y >  B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  >(vec2  A, float B) => (A.x >  B   && A.y >  B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator <=(vec2  A, vec2  B) => (A.x <= B.x && A.y <= B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator <=(vec2  A, float B) => (A.x <= B   && A.y <= B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator >=(vec2  A, vec2  B) => (A.x >= B.x && A.y >= B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator >=(vec2  A, float B) => (A.x >= B   && A.y >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length+1;

        return $"( {this.x.ToString(FormatStr).PadLeft(Padding)}, {this.y.ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] public readonly override string ToString() => $"( {this.x,9:0.000000}, {this.y,9:0.000000} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    [Impl(AggressiveInlining|AggressiveOptimization)] public readonly override bool Equals(object obj) => false;
    [Impl(AggressiveInlining|AggressiveOptimization)] public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
