using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct ivec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public int x;  [FieldOffset( 0)] public int r;
    [FieldOffset( 4)] public int y;  [FieldOffset( 4)] public int g;
    [FieldOffset( 8)] public int z;  [FieldOffset( 8)] public int b;
    [FieldOffset(12)] public int w;  [FieldOffset(12)] public int a;

    //==========================================================================================================================================================
    public ivec3 xyz {  get => new ivec3(x, y, z);  set { x = value.x; y = value.y; z = value.z; }  }
    public ivec3 rgb {  get => new ivec3(x, y, z);  set { x = value.x; y = value.y; z = value.z; }  }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public ivec4() {}
    public ivec4(int X, int Y, int Z, int W) { x = X;     y = Y;     z = Z;     w = W;    }
    public ivec4(ivec3 XYZ          , int W) { x = XYZ.x; y = XYZ.y; z = XYZ.z; w = W;    }
    public ivec4(int XYZ            , int W) { x = XYZ;   y = XYZ;   z = XYZ;   w = W;    }
    public ivec4(int XYZW                  ) { x = XYZW;  y = XYZW;  z = XYZW;  w = XYZW; }

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator ivec4( (int X, int Y, int Z, int W) t ) => new ivec4(t.X, t.Y, t.Z, t.W);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator ivec4( (ivec3 XYZ, int W) t           ) => new ivec4(t.XYZ.x, t.XYZ.y, t.XYZ.z, t.W);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator bool(ivec4 A) => (A.x != 0 || A.y != 0 || A.z != 0 || A.w != 0);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator +(ivec4 A, ivec4 B) => new ivec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator +(ivec4 A, int   B) => new ivec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator +(int   A, ivec4 B) => new ivec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator -(ivec4 A, ivec4 B) => new ivec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator -(ivec4 A, int   B) => new ivec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator -(int   A, ivec4 B) => new ivec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator -(ivec4 A)          => new ivec4(   -A.x,    -A.y,    -A.z,    -A.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator *(ivec4 A, ivec4 B) => new ivec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator *(ivec4 A, int   B) => new ivec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator *(int   A, ivec4 B) => new ivec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator /(ivec4 A, ivec4 B) => new ivec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator /(ivec4 A, int   B) => new ivec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator /(int   A, ivec4 B) => new ivec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator %(ivec4 A, ivec4 B) => new ivec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator %(ivec4 A, int   B) => new ivec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator %(int   A, ivec4 B) => new ivec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(also shifts signed-bit)

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator ~(ivec4 A)          => new ivec4(   ~A.x,    ~A.y,    ~A.z,    ~A.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator &(ivec4 A, ivec4 B) => new ivec4(A.x&B.x, A.y&B.y, A.z&B.z, A.w&B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator |(ivec4 A, ivec4 B) => new ivec4(A.x|B.x, A.y|B.y, A.z|B.z, A.w|B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator ^(ivec4 A, ivec4 B) => new ivec4(A.x^B.x, A.y^B.y, A.z^B.z, A.w^B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator  <<(ivec4 A, int d) => new ivec4(A.x  << d, A.y  << d, A.z  << d, A.w  << d);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator  >>(ivec4 A, int d) => new ivec4(A.x  >> d, A.y  >> d, A.z  >> d, A.w  >> d);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static ivec4 operator >>>(ivec4 A, int d) => new ivec4(A.x >>> d, A.y >>> d, A.z >>> d, A.w >>> d);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator ==(ivec4 A, ivec4 B) => (A.x == B.x && A.y == B.y && A.z == B.z && A.w == B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator ==(ivec4 A, int   B) => (A.x == B   && A.y == B   && A.z == B   && A.w == B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator !=(ivec4 A, ivec4 B) => (A.x != B.x || A.y != B.y || A.z != B.z || A.w != B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator !=(ivec4 A, int   B) => (A.x != B   || A.y != B   || A.z != B   || A.w != B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  <(ivec4 A, ivec4 B) => (A.x <  B.x && A.y <  B.y && A.z <  B.z && A.w <  B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  <(ivec4 A, int   B) => (A.x <  B   && A.y <  B   && A.z <  B   && A.w <  B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  >(ivec4 A, ivec4 B) => (A.x >  B.x && A.y >  B.y && A.z >  B.z && A.w >  B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  >(ivec4 A, int   B) => (A.x >  B   && A.y >  B   && A.z >  B   && A.w >  B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator <=(ivec4 A, ivec4 B) => (A.x <= B.x && A.y <= B.y && A.z <= B.z && A.w <= B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator <=(ivec4 A, int   B) => (A.x <= B   && A.y <= B   && A.z <= B   && A.w <= B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator >=(ivec4 A, ivec4 B) => (A.x >= B.x && A.y >= B.y && A.z >= B.z && A.w >= B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator >=(ivec4 A, int   B) => (A.x >= B   && A.y >= B   && A.z >= B   && A.w >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [Impl(AggressiveOptimization)]
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length;

        return $"( {this.x.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.y.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.z.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.w.ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] public readonly override string ToString() => $"( {this.x,3}, {this.y,3}, {this.z,3}, {this.w,3} )";

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
