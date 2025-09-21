using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec2 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public int x;  [FieldOffset(0)] public int u;
    [FieldOffset(4)] public int y;  [FieldOffset(4)] public int v;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public ivec2() {}
    public ivec2(int X, int Y) { x = X;  y = Y;  }
    public ivec2(int XY      ) { x = XY; y = XY; }

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator ivec2( (int X, int Y) t ) => new ivec2(t.X, t.Y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator bool(ivec2 A) => (A.x != 0 || A.y != 0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator +(ivec2 A, ivec2 B) => new ivec2(A.x+B.x, A.y+B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator +(ivec2 A, int   B) => new ivec2(A.x+B  , A.y+B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator +(int   A, ivec2 B) => new ivec2(A  +B.x, A  +B.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator -(ivec2 A, ivec2 B) => new ivec2(A.x-B.x, A.y-B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator -(ivec2 A, int   B) => new ivec2(A.x-B  , A.y-B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator -(int   A, ivec2 B) => new ivec2(A  -B.x, A  -B.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator -(ivec2 A)          => new ivec2(   -A.x,    -A.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator *(ivec2 A, ivec2 B) => new ivec2(A.x*B.x, A.y*B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator *(ivec2 A, int   B) => new ivec2(A.x*B  , A.y*B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator *(int   A, ivec2 B) => new ivec2(A  *B.x, A  *B.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator /(ivec2 A, ivec2 B) => new ivec2(A.x/B.x, A.y/B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator /(ivec2 A, int   B) => new ivec2(A.x/B  , A.y/B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator /(int   A, ivec2 B) => new ivec2(A  /B.x, A  /B.y);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator %(ivec2 A, ivec2 B) => new ivec2(A.x%B.x, A.y%B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator %(ivec2 A, int   B) => new ivec2(A.x%B  , A.y%B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec2 operator %(int   A, ivec2 B) => new ivec2(A  %B.x, A  %B.y);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator ==(ivec2 A, ivec2 B) => (A.x == B.x && A.y == B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator ==(ivec2 A, int   B) => (A.x == B   && A.y == B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator !=(ivec2 A, ivec2 B) => (A.x != B.x || A.y != B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator !=(ivec2 A, int   B) => (A.x != B   || A.y != B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  <(ivec2 A, ivec2 B) => (A.x <  B.x && A.y <  B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  <(ivec2 A, int   B) => (A.x <  B   && A.y <  B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  >(ivec2 A, ivec2 B) => (A.x >  B.x && A.y >  B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  >(ivec2 A, int   B) => (A.x >  B   && A.y >  B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator <=(ivec2 A, ivec2 B) => (A.x <= B.x && A.y <= B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator <=(ivec2 A, int   B) => (A.x <= B   && A.y <= B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator >=(ivec2 A, ivec2 B) => (A.x >= B.x && A.y >= B.y);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator >=(ivec2 A, int   B) => (A.x >= B   && A.y >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length;

        return $"( {this.x.ToString(FormatStr).PadLeft(Padding)}, {this.y.ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] public readonly override string ToString() => $"( {this.x,3}, {this.y,3} )";

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
