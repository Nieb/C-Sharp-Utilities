using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec3 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public int x;
    [FieldOffset(0)] public int r;

    [FieldOffset(4)] public int y;
    [FieldOffset(4)] public int g;

    [FieldOffset(8)] public int z;
    [FieldOffset(8)] public int b;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public ivec3() {}
    public ivec3(int X, int Y, int Z) { this.x = X;   this.y = Y;   this.z = Z;   }
    public ivec3(int XYZ            ) { this.x = XYZ; this.y = XYZ; this.z = XYZ; }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ivec3( (int X, int Y, int Z) t ) => new ivec3(t.X, t.Y, t.Z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(ivec3 A) => (A.x != 0 || A.y != 0 || A.z != 0);            //  Has Value/Magnitude/Length.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator +(ivec3 A, ivec3 B) => new ivec3(A.x+B.x, A.y+B.y, A.z+B.z);       //  "Addition"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator +(ivec3 A, int   B) => new ivec3(A.x+B  , A.y+B  , A.z+B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator +(int   A, ivec3 B) => new ivec3(A  +B.x, A  +B.y, A  +B.z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator -(ivec3 A, ivec3 B) => new ivec3(A.x-B.x, A.y-B.y, A.z-B.z);       //  "Subtraction"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator -(ivec3 A, int   B) => new ivec3(A.x-B  , A.y-B  , A.z-B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator -(int   A, ivec3 B) => new ivec3(A  -B.x, A  -B.y, A  -B.z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator -(ivec3 A)          => new ivec3(   -A.x,    -A.y,    -A.z);       //  "Negation"

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator *(ivec3 A, ivec3 B) => new ivec3(A.x*B.x, A.y*B.y, A.z*B.z);       //  "Multiplication"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator *(ivec3 A, int   B) => new ivec3(A.x*B  , A.y*B  , A.z*B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator *(int   A, ivec3 B) => new ivec3(A  *B.x, A  *B.y, A  *B.z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator /(ivec3 A, ivec3 B) => new ivec3(A.x/B.x, A.y/B.y, A.z/B.z);       //  "Division"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator /(ivec3 A, int   B) => new ivec3(A.x/B  , A.y/B  , A.z/B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator /(int   A, ivec3 B) => new ivec3(A  /B.x, A  /B.y, A  /B.z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator %(ivec3 A, ivec3 B) => new ivec3(A.x%B.x, A.y%B.y, A.z%B.z);       //  "Modulo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator %(ivec3 A, int   B) => new ivec3(A.x%B  , A.y%B  , A.z%B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec3 operator %(int   A, ivec3 B) => new ivec3(A  %B.x, A  %B.y, A  %B.z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Binary:  ~  <<  >>  >>>

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Logical:  !  &  |  ^

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator !(ivec3 A) => !(A.x != 0 || A.y != 0 || A.z != 0);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec3 operator &(ivec3 A, ivec3 B) => B;                                          //  Not interested in component-wise logic.  These satisfy && and ||.

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec3 operator |(ivec3 A, ivec3 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec3 operator ^(ivec3 A, ivec3 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator  true(ivec3 A) => (A.x != 0 || A.y != 0 || A.z != 0);               //  Value/Magnitude/Length "IsNotZero"

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator false(ivec3 A) => (A.x == 0 && A.y == 0 && A.z == 0);               //  Value/Magnitude/Length "IsZero"

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Comparison:  ==  !=  <  >  <=  >=

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ivec3 A, ivec3 B) => (A.x == B.x && A.y == B.y && A.z == B.z);   //  "EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ivec3 A, int   B) => (A.x == B   && A.y == B   && A.z == B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ivec3 A, ivec3 B) => (A.x != B.x && A.y != B.y && A.z != B.z);   //  "NotEqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ivec3 A, int   B) => (A.x != B   && A.y != B   && A.z != B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ivec3 A, ivec3 B) =>  (A.x <  B.x && A.y <  B.y && A.z <  B.z);   //  "LessThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ivec3 A, int   B) =>  (A.x <  B   && A.y <  B   && A.z <  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ivec3 A, ivec3 B) =>  (A.x >  B.x && A.y >  B.y && A.z >  B.z);   //  "GreaterThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ivec3 A, int   B) =>  (A.x >  B   && A.y >  B   && A.z >  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ivec3 A, ivec3 B) => (A.x <= B.x && A.y <= B.y && A.z <= B.z);   //  "LessThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ivec3 A, int   B) => (A.x <= B   && A.y <= B   && A.z <= B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ivec3 A, ivec3 B) => (A.x >= B.x && A.y >= B.y && A.z >= B.z);   //  "GreaterThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ivec3 A, int   B) => (A.x >= B   && A.y >= B   && A.z >= B  );

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
             + $", {this.y.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.z.ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"( {this.x,3}, {this.y,3}, {this.z,3} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    public override bool Equals(object obj) => false;
    public override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
