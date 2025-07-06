using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec2 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public float x;
    [FieldOffset(0)] public float u;

    [FieldOffset(4)] public float y;
    [FieldOffset(4)] public float v;

    //==========================================================================================================================================================
    //  NOTICE: Length is computed each time it is accessed.
    public float LengthSquared => (this.x*this.x + this.y*this.y);

    public float Length {
        get => MathF.Sqrt(this.x*this.x + this.y*this.y);
        set {
            if (this == 0f) { //  Avoid Divide-by-Zero.
                _ = value;
                #if DEBUG
                    throw new ArgumentException("Can't lengthen zero vector.");
                #endif
            } else {
                float Scaler = value / MathF.Sqrt(this.x*this.x + this.y*this.y); //  (LengthNew / LengthOld).
                this = new vec2(this.x*Scaler, this.y*Scaler);
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec2() {}
    public vec2(float X, float Y) { this.x = X;  this.y = Y;  }
    public vec2(float XY        ) { this.x = XY; this.y = XY; }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator vec2( (float X, float Y) t ) => new vec2(t.X, t.Y);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static implicit operator vec2( float XY ) => new vec2(XY, XY);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(vec2 A) => (A.x != 0f || A.y != 0f);    //  Has Value/Magnitude/Length.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

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

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Binary:  ~  <<  >>  >>>

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Logical:  !  &  |  ^

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator !(vec2 A) => !(A.x != 0f || A.y != 0f);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec2 operator &(vec2 A, vec2 B) => B;                             //  Not interested in component-wise logic.  These satisfy && and ||.

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec2 operator |(vec2 A, vec2 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec2 operator ^(vec2 A, vec2 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator  true(vec2 A) => (A.x != 0f || A.y != 0f);          //  Value/Magnitude/Length "IsNotZero"

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator false(vec2 A) => (A.x == 0f && A.y == 0f);          //  Value/Magnitude/Length "IsZero"

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Comparison:  ==  !=  <  >  <=  >=

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
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public string ToString(string FormatStr, IFormatProvider FormatProvider) {
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length+1;

        return $"( {(this.x.IsApproximatelyZero() ? 0f : this.x).ToString(FormatStr).PadLeft(Padding)}"
             + $", {(this.y.IsApproximatelyZero() ? 0f : this.y).ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    public override string ToString() =>
          $"( {(this.x.IsApproximatelyZero() ? 0f : this.x),9:0.000000}"
        + $", {(this.y.IsApproximatelyZero() ? 0f : this.y),9:0.000000} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    public override bool Equals(object obj) => false;
    public override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
