using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec4 : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float x;
    [FieldOffset( 0)] public float r;

    [FieldOffset( 4)] public float y;
    [FieldOffset( 4)] public float g;

    [FieldOffset( 8)] public float z;
    [FieldOffset( 8)] public float b;

    [FieldOffset(12)] public float w;
    [FieldOffset(12)] public float a;

    //==========================================================================================================================================================
    public vec3 xyz {  get => new vec3(this.x, this.y, this.z);  set { this.x = value.x; this.y = value.y; this.z = value.z; }  }
    public vec3 rgb {  get => new vec3(this.x, this.y, this.z);  set { this.x = value.x; this.y = value.y; this.z = value.z; }  }

    //==========================================================================================================================================================
    //  NOTICE: Length is computed each time it is accessed.
    public float LengthSquared => (this.x*this.x + this.y*this.y + this.z*this.z + this.w*this.w);

    public float Length {
        get => MathF.Sqrt(this.x*this.x + this.y*this.y + this.z*this.z + this.w*this.w);
        set {
            if (this == 0f) { //  Avoid Divide-by-Zero.
                _ = value;
                #if DEBUG
                    throw new ArgumentException("Can't lengthen zero vector.");
                #endif
            } else {
                float Scaler = value / MathF.Sqrt(this.x*this.x + this.y*this.y + this.z*this.z + this.w*this.w); //  (LengthNew / LengthOld).
                this = new vec4(this.x*Scaler, this.y*Scaler, this.z*Scaler, this.w*Scaler);
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec4() {}
    public vec4(float X, float Y, float Z, float W) { this.x = X;     this.y = Y;     this.z = Z;     this.w = W;    }
    public vec4(vec3 XYZ                 , float W) { this.x = XYZ.x; this.y = XYZ.y; this.z = XYZ.z; this.w = W;    }
    public vec4(float XYZ                , float W) { this.x = XYZ;   this.y = XYZ;   this.z = XYZ;   this.w = W;    }
    public vec4(float XYZW                        ) { this.x = XYZW;  this.y = XYZW;  this.z = XYZW;  this.w = XYZW; }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator vec4( (float X, float Y, float Z, float W) t ) => new vec4(t.X, t.Y, t.Z, t.W);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator vec4( (vec3 XYZ, float W) t ) => new vec4(t.XYZ.x, t.XYZ.y, t.XYZ.z, t.W);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static implicit operator vec4( (float XYZ, float W) t ) => new vec4(t.XYZ, t.XYZ, t.XYZ, t.W);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static implicit operator vec4( float XYZW ) => new vec4(XYZW, XYZW, XYZW, XYZW);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator bool(vec4 A) => (A.x != 0f || A.y != 0f || A.z != 0f || A.w != 0f);    //  Has Value/Magnitude/Length.

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

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Binary:  ~  <<  >>  >>>

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Logical:  !  &  |  ^

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator !(vec4 A) => !(A.x != 0f || A.y != 0f || A.z != 0f || A.w != 0f);

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec4 operator &(vec4 A, vec4 B) => B;                                                 //  Not interested in component-wise logic.  These satisfy && and ||.

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec4 operator |(vec4 A, vec4 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static vec4 operator ^(vec4 A, vec4 B) => B;

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator  true(vec4 A) => (A.x != 0f || A.y != 0f || A.z != 0f || A.w != 0f);    //  Value/Magnitude/Length "IsNotZero"

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //public static bool operator false(vec4 A) => (A.x == 0f && A.y == 0f && A.z == 0f && A.w == 0f);    //  Value/Magnitude/Length "IsZero"

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Comparison:  ==  !=  <  >  <=  >=

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
             + $", {(this.z.IsApproximatelyZero() ? 0f : this.z).ToString(FormatStr).PadLeft(Padding)}"
             + $", {(this.w.IsApproximatelyZero() ? 0f : this.w).ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    public override string ToString() =>
          $"( {(this.x.IsApproximatelyZero() ? 0f : this.x),9:0.000000}"
        + $", {(this.y.IsApproximatelyZero() ? 0f : this.y),9:0.000000}"
        + $", {(this.z.IsApproximatelyZero() ? 0f : this.z),9:0.000000}"
        + $", {(this.w.IsApproximatelyZero() ? 0f : this.w),9:0.000000} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    public override bool Equals(object obj) => false;
    public override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
