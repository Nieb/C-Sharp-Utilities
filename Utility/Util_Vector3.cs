using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Sequential)]
public struct vec3 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    public float r {  get => this.x;  set => this.x = value;  }
    public float g {  get => this.y;  set => this.y = value;  }
    public float b {  get => this.z;  set => this.z = value;  }

    //==========================================================================================================================================================
    public float LengthSquared => (this.x*this.x + this.y*this.y + this.z*this.z);

    public float Length {
        get => MathF.Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);
        set {
            if (this.x == 0f && this.y == 0f && this.z == 0f) { //  Avoid Divide-by-Zero.
                _ = value;
            } else {
                float Scaler = value / MathF.Sqrt(this.x*this.x + this.y*this.y + this.z*this.z); //  (LengthNew / LengthOld).

                this = new vec3(this.x*Scaler, this.y*Scaler, this.z*Scaler);
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec3(float X, float Y, float Z) {
        this.x = X;
        this.y = Y;
        this.z = Z;
    }

    public vec3(float XYZ) {
        this.x = XYZ;
        this.y = XYZ;
        this.z = XYZ;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators, Arithmetic:  +  -  *  /  %

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator +(vec3  A, vec3  B) => new vec3(A.x+B.x, A.y+B.y, A.z+B.z); //  "Addition"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator +(vec3  A, float B) => new vec3(A.x+B  , A.y+B  , A.z+B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator +(float A, vec3  B) => new vec3(A  +B.x, A  +B.y, A  +B.z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator -(vec3  A, vec3  B) => new vec3(A.x-B.x, A.y-B.y, A.z-B.z); //  "Subtraction"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator -(vec3  A, float B) => new vec3(A.x-B  , A.y-B  , A.z-B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator -(float A, vec3  B) => new vec3(A  -B.x, A  -B.y, A  -B.z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator -(vec3 A)           => new vec3(   -A.x,    -A.y,    -A.z); //  "Negation"

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator *(vec3  A, vec3  B) => new vec3(A.x*B.x, A.y*B.y, A.z*B.z); //  "Multiplication"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator *(vec3  A, float B) => new vec3(A.x*B  , A.y*B  , A.z*B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator *(float A, vec3  B) => new vec3(A  *B.x, A  *B.y, A  *B.z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator /(vec3  A, vec3  B) => new vec3(A.x/B.x, A.y/B.y, A.z/B.z); //  "Division"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator /(vec3  A, float B) => new vec3(A.x/B  , A.y/B  , A.z/B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator /(float A, vec3  B) => new vec3(A  /B.x, A  /B.y, A  /B.z);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator %(vec3  A, vec3  B) => new vec3(A.x%B.x, A.y%B.y, A.z%B.z); //  "Modulo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator %(vec3  A, float B) => new vec3(A.x%B  , A.y%B  , A.z%B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec3 operator %(float A, vec3  B) => new vec3(A  %B.x, A  %B.y, A  %B.z);

    //==========================================================================================================================================================
    //  Operators, Binary:  &  |  ^  <<  >>

    //==========================================================================================================================================================
    //  Operators, Logical:  ==  !=  <  >  <=  >=

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(vec3  A, vec3  B) => (A.x == B.x && A.y == B.y && A.z == B.z); //  "EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(vec3  A, float B) => (A.x == B   && A.y == B   && A.z == B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(vec3  A, vec3  B) => (A.x != B.x && A.y != B.y && A.z != B.z); //  "NotEqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(vec3  A, float B) => (A.x != B   && A.y != B   && A.z != B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(vec3  A, vec3  B) =>  (A.x <  B.x && A.y <  B.y && A.z <  B.z); //  "LessThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(vec3  A, float B) =>  (A.x <  B   && A.y <  B   && A.z <  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(vec3  A, vec3  B) =>  (A.x >  B.x && A.y >  B.y && A.z >  B.z); //  "GreaterThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(vec3  A, float B) =>  (A.x >  B   && A.y >  B   && A.z >  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(vec3  A, vec3  B) => (A.x <= B.x && A.y <= B.y && A.z <= B.z); //  "LessThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(vec3  A, float B) => (A.x <= B   && A.y <= B   && A.z <= B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(vec3  A, vec3  B) => (A.x >= B.x && A.y >= B.y && A.z >= B.z); //  "GreaterThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(vec3  A, float B) => (A.x >= B   && A.y >= B   && A.z >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public string ToString(string FormatStr, IFormatProvider FormatProvider) {
        if (FormatStr.IsVoid())
            return $"( {this.x,9:0.000000}, {this.y,9:0.000000}, {this.z,9:0.000000} )";

        int Padding = FormatStr.Length+1;
        return "( " + this.x.ToString(FormatStr).PadLeft(Padding)
             + ", " + this.y.ToString(FormatStr).PadLeft(Padding)
             + ", " + this.z.ToString(FormatStr).PadLeft(Padding)
             + " )";
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"( {this.x,9:0.000000}, {this.y,9:0.000000}, {this.z,9:0.000000} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public override bool Equals(object obj) { if (obj is vec3 other) return (this == other); return false; }
    public override int GetHashCode() => HashCode.Combine(x, y, z);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
