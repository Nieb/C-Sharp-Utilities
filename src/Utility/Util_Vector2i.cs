using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec2 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public int x;
    [FieldOffset(0)] public int u;

    [FieldOffset(4)] public int y;
    [FieldOffset(4)] public int v;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public ivec2() {}
    public ivec2(int X, int Y) { this.x = X;  this.y = Y;  }
    public ivec2(int XY      ) { this.x = XY; this.y = XY; }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ivec2( (int X, int Y) t ) => new ivec2(t.X, t.Y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(ivec2 A) => (A.x != 0 || A.y != 0);    //  Has Value/Magnitude/Length.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator +(ivec2 A, ivec2 B) => new ivec2(A.x+B.x, A.y+B.y); //  "Addition"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator +(ivec2 A, int   B) => new ivec2(A.x+B  , A.y+B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator +(int   A, ivec2 B) => new ivec2(A  +B.x, A  +B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator -(ivec2 A, ivec2 B) => new ivec2(A.x-B.x, A.y-B.y); //  "Subtraction"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator -(ivec2 A, int   B) => new ivec2(A.x-B  , A.y-B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator -(int   A, ivec2 B) => new ivec2(A  -B.x, A  -B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator -(ivec2 A)          => new ivec2(   -A.x,    -A.y); //  "Negation"

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator *(ivec2 A, ivec2 B) => new ivec2(A.x*B.x, A.y*B.y); //  "Multiplication"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator *(ivec2 A, int   B) => new ivec2(A.x*B  , A.y*B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator *(int   A, ivec2 B) => new ivec2(A  *B.x, A  *B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator /(ivec2 A, ivec2 B) => new ivec2(A.x/B.x, A.y/B.y); //  "Division"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator /(ivec2 A, int   B) => new ivec2(A.x/B  , A.y/B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator /(int   A, ivec2 B) => new ivec2(A  /B.x, A  /B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator %(ivec2 A, ivec2 B) => new ivec2(A.x%B.x, A.y%B.y); //  "Modulo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator %(ivec2 A, int   B) => new ivec2(A.x%B  , A.y%B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec2 operator %(int   A, ivec2 B) => new ivec2(A  %B.x, A  %B.y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Binary:  ~  <<  >>  >>>

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Logical:  !  &  |  ^

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator !(ivec2 A) => !(A.x != 0 || A.y != 0);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec2 operator &(ivec2 A, ivec2 B) => B;                          //  Not interested in component-wise logic.  These satisfy && and ||.

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec2 operator |(ivec2 A, ivec2 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec2 operator ^(ivec2 A, ivec2 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator  true(ivec2 A) => (A.x != 0 || A.y != 0);           //  Value/Magnitude/Length "IsNotZero"

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator false(ivec2 A) => (A.x == 0 && A.y == 0);           //  Value/Magnitude/Length "IsZero"

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Comparison:  ==  !=  <  >  <=  >=

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ivec2 A, ivec2 B) => (A.x == B.x && A.y == B.y); //  "EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ivec2 A, int   B) => (A.x == B   && A.y == B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ivec2 A, ivec2 B) => (A.x != B.x && A.y != B.y); //  "NotEqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ivec2 A, int   B) => (A.x != B   && A.y != B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ivec2 A, ivec2 B) =>  (A.x <  B.x && A.y <  B.y); //  "LessThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ivec2 A, int   B) =>  (A.x <  B   && A.y <  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ivec2 A, ivec2 B) =>  (A.x >  B.x && A.y >  B.y); //  "GreaterThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ivec2 A, int   B) =>  (A.x >  B   && A.y >  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ivec2 A, ivec2 B) => (A.x <= B.x && A.y <= B.y); //  "LessThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ivec2 A, int   B) => (A.x <= B   && A.y <= B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ivec2 A, ivec2 B) => (A.x >= B.x && A.y >= B.y); //  "GreaterThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ivec2 A, int   B) => (A.x >= B   && A.y >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public string ToString(string FormatStr, IFormatProvider FormatProvider) {
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length;

        return $"( {this.x.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.y.ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"( {this.x,3}, {this.y,3} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    public override bool Equals(object obj) => false;
    public override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
