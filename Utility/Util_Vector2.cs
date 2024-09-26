using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Sequential)]
public struct vec2 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public float x = 0f;
    public float y = 0f;

    public float u {  get => this.x;  set => this.x = value;  }
    public float v {  get => this.y;  set => this.y = value;  }

    //==========================================================================================================================================================
    public float LengthSquared => (this.x*this.x + this.y*this.y);

    public float Length {
        get => MathF.Sqrt(this.x*this.x + this.y*this.y);
        set {
            if (this.x == 0f && this.y == 0f) { //  Avoid Divide-by-Zero.
                _ = value;
            } else {
                float Scaler = value / MathF.Sqrt(this.x*this.x + this.y*this.y); //  (LengthNew / LengthOld).

                this = new vec2(this.x*Scaler, this.y*Scaler);
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec2(float X, float Y) {
        this.x = X;
        this.y = Y;
    }

    public vec2(float XY) {
        this.x = XY;
        this.y = XY;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators, Arithmetic:  +  -  *  /  %

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator +(vec2  A, vec2  B) => new vec2(A.x+B.x, A.y+B.y); //  "Addition"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator +(vec2  A, float B) => new vec2(A.x+B  , A.y+B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator +(float A, vec2  B) => new vec2(A  +B.x, A  +B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator -(vec2  A, vec2  B) => new vec2(A.x-B.x, A.y-B.y); //  "Subtraction"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator -(vec2  A, float B) => new vec2(A.x-B  , A.y-B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator -(float A, vec2  B) => new vec2(A  -B.x, A  -B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator -(vec2 A)           => new vec2(   -A.x,    -A.y); //  "Negation"

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator *(vec2  A, vec2  B) => new vec2(A.x*B.x, A.y*B.y); //  "Multiplication"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator *(vec2  A, float B) => new vec2(A.x*B  , A.y*B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator *(float A, vec2  B) => new vec2(A  *B.x, A  *B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator /(vec2  A, vec2  B) => new vec2(A.x/B.x, A.y/B.y); //  "Division"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator /(vec2  A, float B) => new vec2(A.x/B  , A.y/B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator /(float A, vec2  B) => new vec2(A  /B.x, A  /B.y);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator %(vec2  A, vec2  B) => new vec2(A.x%B.x, A.y%B.y); //  "Modulo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator %(vec2  A, float B) => new vec2(A.x%B  , A.y%B  );
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static vec2 operator %(float A, vec2  B) => new vec2(A  %B.x, A  %B.y);

    //==========================================================================================================================================================
    //  Operators, Binary:  &  |  ^  <<  >>

    //==========================================================================================================================================================
    //  Operators, Logical:  ==  !=  <  >  <=  >=

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(vec2  A, vec2  B) => (A.x == B.x && A.y == B.y); //  "EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator ==(vec2  A, float B) => (A.x == B   && A.y == B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(vec2  A, vec2  B) => (A.x != B.x && A.y != B.y); //  "NotEqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator !=(vec2  A, float B) => (A.x != B   && A.y != B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(vec2  A, vec2  B) =>  (A.x <  B.x && A.y <  B.y); //  "LessThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <(vec2  A, float B) =>  (A.x <  B   && A.y <  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(vec2  A, vec2  B) =>  (A.x >  B.x && A.y >  B.y); //  "GreaterThan"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >(vec2  A, float B) =>  (A.x >  B   && A.y >  B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(vec2  A, vec2  B) => (A.x <= B.x && A.y <= B.y); //  "LessThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator <=(vec2  A, float B) => (A.x <= B   && A.y <= B  );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(vec2  A, vec2  B) => (A.x >= B.x && A.y >= B.y); //  "GreaterThan OR EqualTo"
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool operator >=(vec2  A, float B) => (A.x >= B   && A.y >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public string ToString(string FormatStr, IFormatProvider FormatProvider) {
        if (FormatStr.IsVoid())
            return $"( {this.x,9:0.000000}, {this.y,9:0.000000} )";

        int Padding = FormatStr.Length+1;
        return "( " + this.x.ToString(FormatStr).PadLeft(Padding)
             + ", " + this.y.ToString(FormatStr).PadLeft(Padding)
             + " )";
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => $"( {this.x,9:0.000000}, {this.y,9:0.000000} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public override bool Equals(object obj) { if (obj is vec2 other) { return (this == other); } return false; }
    public override int GetHashCode() => HashCode.Combine(this.x, this.y);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
