using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Sequential)]
public struct vec4 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;
    public float w = 0f;

    public float r {  get => this.x;  set => this.x = value;  }
    public float g {  get => this.y;  set => this.y = value;  }
    public float b {  get => this.z;  set => this.z = value;  }
    public float a {  get => this.w;  set => this.w = value;  }

    public vec3 xyz {  get => new vec3(this.x, this.y, this.z);  set { this.x = value.x; this.y = value.y; this.z = value.z; } }
    public vec3 rgb {  get => new vec3(this.x, this.y, this.z);  set { this.x = value.x; this.y = value.y; this.z = value.z; } }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec4(float X, float Y, float Z, float W) {
        this.x = X;
        this.y = Y;
        this.z = Z;
        this.w = W;
    }

    public vec4(vec3 XYZ, float W) {
        this.x = XYZ.x;
        this.y = XYZ.y;
        this.z = XYZ.z;
        this.w = W;
    }

    public vec4(float XYZ, float W) {
        this.x = XYZ;
        this.y = XYZ;
        this.z = XYZ;
        this.w = W;
    }

    public vec4(float XYZW) {
        this.x = XYZW;
        this.y = XYZW;
        this.z = XYZW;
        this.w = XYZW;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator +(vec4  A, vec4  B) => new vec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w); //  "Addition"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator +(vec4  A, float B) => new vec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator +(float A, vec4  B) => new vec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator -(vec4  A, vec4  B) => new vec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w); //  "Subtraction"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator -(vec4  A, float B) => new vec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator -(float A, vec4  B) => new vec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator -(vec4 A)           => new vec4(   -A.x,    -A.y,    -A.z,    -A.w); //  "Negation"

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator *(vec4  A, vec4  B) => new vec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w); //  "Multiplication"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator *(vec4  A, float B) => new vec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator *(float A, vec4  B) => new vec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator /(vec4  A, vec4  B) => new vec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w); //  "Division"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator /(vec4  A, float B) => new vec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator /(float A, vec4  B) => new vec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator %(vec4  A, vec4  B) => new vec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w); //  "Modulo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator %(vec4  A, float B) => new vec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec4 operator %(float A, vec4  B) => new vec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(vec4  A, vec4  B) => (A.x == B.x && A.y == B.y && A.z == B.z && A.w == B.w); //  "EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(vec4  A, float B) => (A.x == B   && A.y == B   && A.z == B   && A.w == B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(vec4  A, vec4  B) => (A.x != B.x && A.y != B.y && A.z != B.z && A.w != B.w); //  "NotEqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(vec4  A, float B) => (A.x != B   && A.y != B   && A.z != B   && A.w != B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(vec4  A, vec4  B)  => (A.x <  B.x && A.y <  B.y && A.z <  B.z && A.w <  B.w); //  "LessThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(vec4  A, float B)  => (A.x <  B   && A.y <  B   && A.z <  B   && A.w <  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(vec4  A, vec4  B)  => (A.x >  B.x && A.y >  B.y && A.z >  B.z && A.w >  B.w); //  "GreaterThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(vec4  A, float B)  => (A.x >  B   && A.y >  B   && A.z >  B   && A.w >  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(vec4  A, vec4  B) => (A.x <= B.x && A.y <= B.y && A.z <= B.z && A.w <= B.w); //  "LessThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(vec4  A, float B) => (A.x <= B   && A.y <= B   && A.z <= B   && A.w <= B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(vec4  A, vec4  B) => (A.x >= B.x && A.y >= B.y && A.z >= B.z && A.w >= B.w); //  "GreaterThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(vec4  A, float B) => (A.x >= B   && A.y >= B   && A.z >= B   && A.w >= B  );

    //==========================================================================================================================================================
    //  Operators Binary:  &  |  ^  <<  >>

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public string ToString(string FormatStr, IFormatProvider FormatProvider) {
        if (FormatStr.IsVoid())
            return $"( {this.x,9:0.000000}, {this.y,9:0.000000}, {this.z,9:0.000000}, {this.w,9:0.000000} )";

        int Padding = FormatStr.Length+1;
        return "( " + this.x.ToString(FormatStr).PadLeft(Padding)
             + ", " + this.y.ToString(FormatStr).PadLeft(Padding)
             + ", " + this.z.ToString(FormatStr).PadLeft(Padding)
             + ", " + this.w.ToString(FormatStr).PadLeft(Padding)
             + " )";
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"( {this.x,9:0.000000}, {this.y,9:0.000000}, {this.z,9:0.000000}, {this.w,9:0.000000} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public override bool Equals(object obj) { if (obj is vec4 other) { return this == other; } return false; }
    public override int GetHashCode() => HashCode.Combine(x, y, z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
