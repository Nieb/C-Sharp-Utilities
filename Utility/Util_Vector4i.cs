using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec4 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public int x;
    [FieldOffset( 0)] public int r;

    [FieldOffset( 4)] public int y;
    [FieldOffset( 4)] public int g;

    [FieldOffset( 8)] public int z;
    [FieldOffset( 8)] public int b;

    [FieldOffset(12)] public int w;
    [FieldOffset(12)] public int a;

    //==========================================================================================================================================================
    public ivec3 xyz {  get => new ivec3(this.x, this.y, this.z);  set { this.x = value.x; this.y = value.y; this.z = value.z; }  }
    public ivec3 rgb {  get => new ivec3(this.x, this.y, this.z);  set { this.x = value.x; this.y = value.y; this.z = value.z; }  }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public ivec4() {}
    public ivec4(int X, int Y, int Z, int W) { this.x = X;     this.y = Y;     this.z = Z;     this.w = W;    }
    public ivec4(ivec3 XYZ          , int W) { this.x = XYZ.x; this.y = XYZ.y; this.z = XYZ.z; this.w = W;    }
    public ivec4(int XYZ            , int W) { this.x = XYZ;   this.y = XYZ;   this.z = XYZ;   this.w = W;    }
    public ivec4(int XYZW                  ) { this.x = XYZW;  this.y = XYZW;  this.z = XYZW;  this.w = XYZW; }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ivec4( (int X, int Y, int Z, int W) t ) => new ivec4(t.X, t.Y, t.Z, t.W);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator ivec4( (ivec3 XYZ, int W) t ) => new ivec4(t.XYZ.x, t.XYZ.y, t.XYZ.z, t.W);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(ivec4 A) => (A.x != 0 || A.y != 0 || A.z != 0 || A.w != 0);    //  Has Value/Magnitude/Length.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator +(ivec4 A, ivec4 B) => new ivec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);  //  "Addition"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator +(ivec4 A, int   B) => new ivec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator +(int   A, ivec4 B) => new ivec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator -(ivec4 A, ivec4 B) => new ivec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);  //  "Subtraction"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator -(ivec4 A, int   B) => new ivec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator -(int   A, ivec4 B) => new ivec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator -(ivec4 A)          => new ivec4(   -A.x,    -A.y,    -A.z,    -A.w);  //  "Negation"

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator *(ivec4 A, ivec4 B) => new ivec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);  //  "Multiplication"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator *(ivec4 A, int   B) => new ivec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator *(int   A, ivec4 B) => new ivec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator /(ivec4 A, ivec4 B) => new ivec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);  //  "Division"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator /(ivec4 A, int   B) => new ivec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator /(int   A, ivec4 B) => new ivec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator %(ivec4 A, ivec4 B) => new ivec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);  //  "Modulo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator %(ivec4 A, int   B) => new ivec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ivec4 operator %(int   A, ivec4 B) => new ivec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Binary:  ~  <<  >>  >>>

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Logical:  !  &  |  ^

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator !(ivec4 A) => !(A.x != 0 || A.y != 0 || A.z != 0 || A.w != 0);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec4 operator &(ivec4 A, ivec4 B) => B;                                              //  Not interested in component-wise logic.  These satisfy && and ||.

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec4 operator |(ivec4 A, ivec4 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static ivec4 operator ^(ivec4 A, ivec4 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator  true(ivec4 A) => (A.x != 0 || A.y != 0 || A.z != 0 || A.w != 0);       //  Value/Magnitude/Length "IsNotZero"

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator false(ivec4 A) => (A.x == 0 && A.y == 0 && A.z == 0 && A.w == 0);       //  Value/Magnitude/Length "IsZero"

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Comparison:  ==  !=  <  >  <=  >=

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ivec4 A, ivec4 B) => (A.x == B.x && A.y == B.y && A.z == B.z && A.w == B.w); //  "EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(ivec4 A, int   B) => (A.x == B   && A.y == B   && A.z == B   && A.w == B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ivec4 A, ivec4 B) => (A.x != B.x && A.y != B.y && A.z != B.z && A.w != B.w); //  "NotEqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(ivec4 A, int   B) => (A.x != B   && A.y != B   && A.z != B   && A.w != B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ivec4 A, ivec4 B)  => (A.x <  B.x && A.y <  B.y && A.z <  B.z && A.w <  B.w); //  "LessThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(ivec4 A, int   B)  => (A.x <  B   && A.y <  B   && A.z <  B   && A.w <  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ivec4 A, ivec4 B)  => (A.x >  B.x && A.y >  B.y && A.z >  B.z && A.w >  B.w); //  "GreaterThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(ivec4 A, int   B)  => (A.x >  B   && A.y >  B   && A.z >  B   && A.w >  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ivec4 A, ivec4 B) => (A.x <= B.x && A.y <= B.y && A.z <= B.z && A.w <= B.w); //  "LessThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(ivec4 A, int   B) => (A.x <= B   && A.y <= B   && A.z <= B   && A.w <= B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ivec4 A, ivec4 B) => (A.x >= B.x && A.y >= B.y && A.z >= B.z && A.w >= B.w); //  "GreaterThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(ivec4 A, int   B) => (A.x >= B   && A.y >= B   && A.z >= B   && A.w >= B  );

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
             + $", {this.z.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.w.ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"( {this.x,3}, {this.y,3}, {this.z,3}, {this.w,3} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    public override bool Equals(object obj) => false;
    public override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
