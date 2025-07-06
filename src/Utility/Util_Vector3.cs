using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec3 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset(0)] public float x;
    [FieldOffset(0)] public float r;

    [FieldOffset(4)] public float y;
    [FieldOffset(4)] public float g;

    [FieldOffset(8)] public float z;
    [FieldOffset(8)] public float b;

    //==========================================================================================================================================================
    //  NOTICE: Length is computed each time it is accessed.
    public float LengthSquared => (this.x*this.x + this.y*this.y + this.z*this.z);

    public float Length {
        get => MathF.Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);
        set {
            if (this == 0f) { //  Avoid Divide-by-Zero.
                _ = value;
                #if DEBUG
                    throw new ArgumentException("Can't lengthen zero vector.");
                #endif
            } else {
                float Scaler = value / MathF.Sqrt(this.x*this.x + this.y*this.y + this.z*this.z); //  (LengthNew / LengthOld).
                this = new vec3(this.x*Scaler, this.y*Scaler, this.z*Scaler);
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec3() {}
    public vec3(float X, float Y, float Z) { this.x = X;   this.y = Y;   this.z = Z;   }
    public vec3(float XYZ                ) { this.x = XYZ; this.y = XYZ; this.z = XYZ; }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator vec3( (float X, float Y, float Z) t ) => new vec3(t.X, t.Y, t.Z);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static implicit operator vec3( float XYZ ) => new vec3(XYZ, XYZ, XYZ);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(vec3 A) => (A.x != 0f || A.y != 0f || A.z != 0f);          //  Has Value/Magnitude/Length.

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

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

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Binary:  ~  <<  >>  >>>

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Logical:  !  &  |  ^

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator !(vec3 A) => !(A.x != 0f || A.y != 0f || A.z != 0f);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec3 operator &(vec3 A, vec3 B) => B;                                             //  Not interested in component-wise logic.  These satisfy && and ||.

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec3 operator |(vec3 A, vec3 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec3 operator ^(vec3 A, vec3 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator  true(vec3 A) => (A.x != 0f || A.y != 0f || A.z != 0f);             //  Value/Magnitude/Length "IsNotZero"

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator false(vec3 A) => (A.x == 0f && A.y == 0f && A.z == 0f);             //  Value/Magnitude/Length "IsZero"

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Comparison:  ==  !=  <  >  <=  >=

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
            return this.ToString();

        int Padding = FormatStr.Length+1;

        return $"( {(this.x.IsApproximatelyZero() ? 0f : this.x).ToString(FormatStr).PadLeft(Padding)}"
             + $", {(this.y.IsApproximatelyZero() ? 0f : this.y).ToString(FormatStr).PadLeft(Padding)}"
             + $", {(this.z.IsApproximatelyZero() ? 0f : this.z).ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    public override string ToString() =>
          $"( {(this.x.IsApproximatelyZero() ? 0f : this.x),9:0.000000}"
        + $", {(this.y.IsApproximatelyZero() ? 0f : this.y),9:0.000000}"
        + $", {(this.z.IsApproximatelyZero() ? 0f : this.z),9:0.000000} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    public override bool Equals(object obj) => false;
    public override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
