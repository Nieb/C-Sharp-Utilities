using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct vec4 : System.IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float x;  [FieldOffset( 0)] public float r;
    [FieldOffset( 4)] public float y;  [FieldOffset( 4)] public float g;
    [FieldOffset( 8)] public float z;  [FieldOffset( 8)] public float b;
    [FieldOffset(12)] public float w;  [FieldOffset(12)] public float a;

    //==========================================================================================================================================================
    public vec3 xyz {  get => new vec3(x, y, z);  set { x = value.x; y = value.y; z = value.z; }  }
    public vec3 rgb {  get => new vec3(x, y, z);  set { x = value.x; y = value.y; z = value.z; }  }

    //==========================================================================================================================================================
    //  NOTE: Length is computed each time it is accessed.
    public float length {
        get => sqrt(x*x + y*y + z*z + w*w);
        set => this = (this == 0f) ? this : this*(value/sqrt(x*x + y*y + z*z + w*w));
    }

    public readonly float length2 => (x*x + y*y + z*z + w*w);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public vec4() {}
    public vec4(float X, float Y, float Z, float W) { x = X;     y = Y;     z = Z;     w = W;    }
    public vec4(vec3 XYZ                 , float W) { x = XYZ.x; y = XYZ.y; z = XYZ.z; w = W;    }
    public vec4(float XYZ                , float W) { x = XYZ;   y = XYZ;   z = XYZ;   w = W;    }
    public vec4(float XYZW                        ) { x = XYZW;  y = XYZW;  z = XYZW;  w = XYZW; }

    //==========================================================================================================================================================
    //                                                               Tuple "Constructor"
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator vec4( (float X, float Y, float Z, float W) t ) => new vec4(t.X, t.Y, t.Z, t.W);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator vec4( (vec3 XYZ, float W) t                  ) => new vec4(t.XYZ.x, t.XYZ.y, t.XYZ.z, t.W);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //                                                            Has Value/Magnitude/Length
    [Impl(AggressiveInlining|AggressiveOptimization)] public static implicit operator bool(vec4 A) => (A.x != 0f || A.y != 0f || A.z != 0f || A.w != 0f);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator +(vec4  A, vec4  B) => new vec4(A.x+B.x, A.y+B.y, A.z+B.z, A.w+B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator +(vec4  A, float B) => new vec4(A.x+B  , A.y+B  , A.z+B  , A.w+B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator +(float A, vec4  B) => new vec4(A  +B.x, A  +B.y, A  +B.z, A  +B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator -(vec4  A, vec4  B) => new vec4(A.x-B.x, A.y-B.y, A.z-B.z, A.w-B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator -(vec4  A, float B) => new vec4(A.x-B  , A.y-B  , A.z-B  , A.w-B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator -(float A, vec4  B) => new vec4(A  -B.x, A  -B.y, A  -B.z, A  -B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator -(vec4 A)           => new vec4(   -A.x,    -A.y,    -A.z,    -A.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator *(vec4  A, vec4  B) => new vec4(A.x*B.x, A.y*B.y, A.z*B.z, A.w*B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator *(vec4  A, float B) => new vec4(A.x*B  , A.y*B  , A.z*B  , A.w*B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator *(float A, vec4  B) => new vec4(A  *B.x, A  *B.y, A  *B.z, A  *B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator /(vec4  A, vec4  B) => new vec4(A.x/B.x, A.y/B.y, A.z/B.z, A.w/B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator /(vec4  A, float B) => new vec4(A.x/B  , A.y/B  , A.z/B  , A.w/B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator /(float A, vec4  B) => new vec4(A  /B.x, A  /B.y, A  /B.z, A  /B.w);

    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator %(vec4  A, vec4  B) => new vec4(A.x%B.x, A.y%B.y, A.z%B.z, A.w%B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator %(vec4  A, float B) => new vec4(A.x%B  , A.y%B  , A.z%B  , A.w%B  );
    [Impl(AggressiveInlining|AggressiveOptimization)] public static vec4 operator %(float A, vec4  B) => new vec4(A  %B.x, A  %B.y, A  %B.z, A  %B.w);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(cast to uint, shift, cast back to int)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator ==(vec4 A, vec4  B) => (A.x == B.x && A.y == B.y && A.z == B.z && A.w == B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator ==(vec4 A, float B) => (A.x == B   && A.y == B   && A.z == B   && A.w == B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator !=(vec4 A, vec4  B) => (A.x != B.x || A.y != B.y || A.z != B.z || A.w != B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator !=(vec4 A, float B) => (A.x != B   || A.y != B   || A.z != B   || A.w != B  );

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  <(vec4 A, vec4  B) => (A.x <  B.x && A.y <  B.y && A.z <  B.z && A.w <  B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  <(vec4 A, float B) => (A.x <  B   && A.y <  B   && A.z <  B   && A.w <  B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  >(vec4 A, vec4  B) => (A.x >  B.x && A.y >  B.y && A.z >  B.z && A.w >  B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator  >(vec4 A, float B) => (A.x >  B   && A.y >  B   && A.z >  B   && A.w >  B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator <=(vec4 A, vec4  B) => (A.x <= B.x && A.y <= B.y && A.z <= B.z && A.w <= B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator <=(vec4 A, float B) => (A.x <= B   && A.y <= B   && A.z <= B   && A.w <= B  );

    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator >=(vec4 A, vec4  B) => (A.x >= B.x && A.y >= B.y && A.z >= B.z && A.w >= B.w);
    [Impl(AggressiveInlining|AggressiveOptimization)] public static bool operator >=(vec4 A, float B) => (A.x >= B   && A.y >= B   && A.z >= B   && A.w >= B  );

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly string ToString(string FormatStr, System.IFormatProvider FormatProvider) {
        _ = FormatProvider;
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length+1;

        return $"( {this.x.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.y.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.z.ToString(FormatStr).PadLeft(Padding)}"
             + $", {this.w.ToString(FormatStr).PadLeft(Padding)} )";
    }

    //==========================================================================================================================================================
    [Impl(AggressiveInlining|AggressiveOptimization)] public readonly override string ToString() => $"( {this.x,9:0.000000}, {this.y,9:0.000000}, {this.z,9:0.000000}, {this.w,9:0.000000} )";

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
