using System.Runtime.InteropServices;

namespace Utility;
[StructLayout(LayoutKind.Explicit, Pack=4)]
internal struct mat4 {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    [FieldOffset( 0)] public float xx;  [FieldOffset( 4)] public float yx;  [FieldOffset( 8)] public float zx;  [FieldOffset(12)] public float wx;
    [FieldOffset(16)] public float xy;  [FieldOffset(20)] public float yy;  [FieldOffset(24)] public float zy;  [FieldOffset(28)] public float wy;
    [FieldOffset(32)] public float xz;  [FieldOffset(36)] public float yz;  [FieldOffset(40)] public float zz;  [FieldOffset(44)] public float wz;
    [FieldOffset(48)] public float xw;  [FieldOffset(52)] public float yw;  [FieldOffset(56)] public float zw;  [FieldOffset(60)] public float ww;

    //==========================================================================================================================================================
    //[FieldOffset(0)] private fixed float index[16];
    //#if DEBUG
    //    public readonly float this[int i]        => (i < 0 || i > 15)                  ? throw new System.IndexOutOfRangeException() : this.index[i];
    //    public readonly float this[int x, int y] => (x < 0 || x > 3 || y < 0 || y > 3) ? throw new System.IndexOutOfRangeException() : this.index[x + 4*y];
    //#else
    //    public readonly float this[int i]        => this.index[i];
    //    public readonly float this[int x, int y] => this.index[x + 4*y];
    //#endif

    public float this[int i] {
        get {
            switch (i) {
                case  0:return xx;  case  1:return yx;  case  2:return zx;  case  3:return wx;
                case  4:return xy;  case  5:return yy;  case  6:return zy;  case  7:return wy;
                case  8:return xz;  case  9:return yz;  case 10:return zz;  case 11:return wz;
                case 12:return xw;  case 13:return yw;  case 14:return zw;  case 15:return ww;
            }
            throw new System.IndexOutOfRangeException();
        }
        set {
            switch (i) {
                case  0: xx = value;return;  case  1: yx = value;return;  case  2: zx = value;return;  case  3: wx = value;return;
                case  4: xy = value;return;  case  5: yy = value;return;  case  6: zy = value;return;  case  7: wy = value;return;
                case  8: xz = value;return;  case  9: yz = value;return;  case 10: zz = value;return;  case 11: wz = value;return;
                case 12: xw = value;return;  case 13: yw = value;return;  case 14: zw = value;return;  case 15: ww = value;return;
            }
            throw new System.IndexOutOfRangeException();
        }
    }

    public float this[int x, int y] {
        get {
            switch (y) {
                case 0: switch (x) { case 0:return xx;  case 1:return yx;  case 2:return zx;  case 3:return wx; } break;
                case 1: switch (x) { case 0:return xy;  case 1:return yy;  case 2:return zy;  case 3:return wy; } break;
                case 2: switch (x) { case 0:return xz;  case 1:return yz;  case 2:return zz;  case 3:return wz; } break;
                case 3: switch (x) { case 0:return xw;  case 1:return yw;  case 2:return zw;  case 3:return ww; } break;
            }
            throw new System.IndexOutOfRangeException();
        }
        set {
            switch (y) {
                case 0: switch (x) { case 0: xx = value;return;  case 1: yx = value;return;  case 2: zx = value;return;  case 3: wx = value;return; } break;
                case 1: switch (x) { case 0: xy = value;return;  case 1: yy = value;return;  case 2: zy = value;return;  case 3: wy = value;return; } break;
                case 2: switch (x) { case 0: xz = value;return;  case 1: yz = value;return;  case 2: zz = value;return;  case 3: wz = value;return; } break;
                case 3: switch (x) { case 0: xw = value;return;  case 1: yw = value;return;  case 2: zw = value;return;  case 3: ww = value;return; } break;
            }
            throw new System.IndexOutOfRangeException();
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public mat4() {}

    public mat4(float V) {
        this.xx = V; this.yx = V; this.zx = V; this.wx = V;
        this.xy = V; this.yy = V; this.zy = V; this.wy = V;
        this.xz = V; this.yz = V; this.zz = V; this.wz = V;
        this.xw = V; this.yw = V; this.zw = V; this.ww = V;
    }

    public mat4(float XX, float YX, float ZX, float WX,
                float XY, float YY, float ZY, float WY,
                float XZ, float YZ, float ZZ, float WZ,
                float XW, float YW, float ZW, float WW){
        this.xx = XX; this.yx = YX; this.zx = ZX; this.wx = WX;
        this.xy = XY; this.yy = YY; this.zy = ZY; this.wy = WY;
        this.xz = XZ; this.yz = YZ; this.zz = ZZ; this.wz = WZ;
        this.xw = XW; this.yw = YW; this.zw = ZW; this.ww = WW;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Has Value/Magnitude/Length:
  //public static implicit operator bool(mat4 A) => (
  //    A.xx!=0f || A.yx!=0f || A.zx!=0f || A.wx!=0f ||
  //    A.xy!=0f || A.yy!=0f || A.zy!=0f || A.wy!=0f ||
  //    A.xz!=0f || A.yz!=0f || A.zz!=0f || A.wz!=0f ||
  //    A.xw!=0f || A.yw!=0f || A.zw!=0f || A.ww!=0f
  //);

  //[Impl(AggressiveInlining|AggressiveOptimization)]
  //public static implicit operator float[](mat4 A) => A.ToFloatArray();

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators Arithmetic:  +  -  *  /  %

  //public static mat4 operator +(mat4 A, mat4 B) => new mat4(A.xx+B.xx,  A.yx+B.yx,  A.zx+B.zx,  A.wx+B.wx,
  //                                                          A.xy+B.xy,  A.yy+B.yy,  A.zy+B.zy,  A.wy+B.wy,
  //                                                          A.xz+B.xz,  A.yz+B.yz,  A.zz+B.zz,  A.wz+B.wz,
  //                                                          A.xw+B.xw,  A.yw+B.yw,  A.zw+B.zw,  A.ww+B.ww);

  //public static mat4 operator -(mat4 A, mat4 B) => new mat4(A.xx-B.xx,  A.yx-B.yx,  A.zx-B.zx,  A.wx-B.wx,
  //                                                          A.xy-B.xy,  A.yy-B.yy,  A.zy-B.zy,  A.wy-B.wy,
  //                                                          A.xz-B.xz,  A.yz-B.yz,  A.zz-B.zz,  A.wz-B.wz,
  //                                                          A.xw-B.xw,  A.yw-B.yw,  A.zw-B.zw,  A.ww-B.ww);

  //public static mat4 operator -(mat4 A)         => new mat4(-A.xx, -A.yx, -A.zx, -A.wx,
  //                                                          -A.xy, -A.yy, -A.zy, -A.wy,
  //                                                          -A.xz, -A.yz, -A.zz, -A.wz,
  //                                                          -A.xw, -A.yw, -A.zw, -A.ww);

  //public static mat4 operator *(mat4 A, mat4 B) => new mat4(A.xx*B.xx,  A.yx*B.yx,  A.zx*B.zx,  A.wx*B.wx,
  //                                                          A.xy*B.xy,  A.yy*B.yy,  A.zy*B.zy,  A.wy*B.wy,
  //                                                          A.xz*B.xz,  A.yz*B.yz,  A.zz*B.zz,  A.wz*B.wz,
  //                                                          A.xw*B.xw,  A.yw*B.yw,  A.zw*B.zw,  A.ww*B.ww);

  //public static mat4 operator /(mat4 A, mat4 B) => new mat4(A.xx/B.xx,  A.yx/B.yx,  A.zx/B.zx,  A.wx/B.wx,
  //                                                          A.xy/B.xy,  A.yy/B.yy,  A.zy/B.zy,  A.wy/B.wy,
  //                                                          A.xz/B.xz,  A.yz/B.yz,  A.zz/B.zz,  A.wz/B.wz,
  //                                                          A.xw/B.xw,  A.yw/B.yw,  A.zw/B.zw,  A.ww/B.ww);

  //public static mat4 operator %(mat4 A, mat4 B) => new mat4(A.xx%B.xx,  A.yx%B.yx,  A.zx%B.zx,  A.wx%B.wx,
  //                                                          A.xy%B.xy,  A.yy%B.yy,  A.zy%B.zy,  A.wy%B.wy,
  //                                                          A.xz%B.xz,  A.yz%B.yz,  A.zz%B.zz,  A.wz%B.wz,
  //                                                          A.xw%B.xw,  A.yw%B.yw,  A.zw%B.zw,  A.ww%B.ww);

    //----------------------------------------------------------------------------------------------------------------------------------------------------------
    //
    //  Result = (Vec4 * Mat4);
    //
    //         Vx      Vy      Vz      Vw   |
    //      --------------------------------+------
    //         Mxx  +  Myx  +  Mzx  +  Mwx  |  Rx
    //                                      |
    //         Mxy  +  Myy  +  Mzy  +  Mwy  |  Ry
    //                                      |
    //         Mxz  +  Myz  +  Mzz  +  Mwz  |  Rz
    //                                      |
    //         Mxw  +  Myw  +  Mzw  +  Mww  |  Rw
    //                                      |
    //
  //[Impl(AggressiveOptimization)] public static vec4 operator +(vec4 V, mat4 M) => new vec4(V.x+M.xx + V.y+M.yx + V.z+M.zx + V.w+M.wx,
  //                                                                                         V.x+M.xy + V.y+M.yy + V.z+M.zy + V.w+M.wy,
  //                                                                                         V.x+M.xz + V.y+M.yz + V.z+M.zz + V.w+M.wz,
  //                                                                                         V.x+M.xw + V.y+M.yw + V.z+M.zw + V.w+M.ww);

  //[Impl(AggressiveOptimization)] public static vec4 operator -(vec4 V, mat4 M) => new vec4(V.x-M.xx + V.y-M.yx + V.z-M.zx + V.w-M.wx,
  //                                                                                         V.x-M.xy + V.y-M.yy + V.z-M.zy + V.w-M.wy,
  //                                                                                         V.x-M.xz + V.y-M.yz + V.z-M.zz + V.w-M.wz,
  //                                                                                         V.x-M.xw + V.y-M.yw + V.z-M.zw + V.w-M.ww);

    [Impl(AggressiveOptimization)] public static vec4 operator *(vec4 V, mat4 M) => new vec4(V.x*M.xx + V.y*M.yx + V.z*M.zx + V.w*M.wx,
                                                                                             V.x*M.xy + V.y*M.yy + V.z*M.zy + V.w*M.wy,
                                                                                             V.x*M.xz + V.y*M.yz + V.z*M.zz + V.w*M.wz,
                                                                                             V.x*M.xw + V.y*M.yw + V.z*M.zw + V.w*M.ww);

  //[Impl(AggressiveOptimization)] public static vec4 operator /(vec4 V, mat4 M) => new vec4(V.x/M.xx + V.y/M.yx + V.z/M.zx + V.w/M.wx,
  //                                                                                         V.x/M.xy + V.y/M.yy + V.z/M.zy + V.w/M.wy,
  //                                                                                         V.x/M.xz + V.y/M.yz + V.z/M.zz + V.w/M.wz,
  //                                                                                         V.x/M.xw + V.y/M.yw + V.z/M.zw + V.w/M.ww);

  //[Impl(AggressiveOptimization)] public static vec4 operator %(vec4 V, mat4 M) => new vec4(V.x%M.xx + V.y%M.yx + V.z%M.zx + V.w%M.wx,
  //                                                                                         V.x%M.xy + V.y%M.yy + V.z%M.zy + V.w%M.wy,
  //                                                                                         V.x%M.xz + V.y%M.yz + V.z%M.zz + V.w%M.wz,
  //                                                                                         V.x%M.xw + V.y%M.yw + V.z%M.zw + V.w%M.ww);

    //==========================================================================================================================================================
    //  Operators Bitwise:  ~    &    |   ^    <<          >>           >>>
    //                      NOT  AND  OR  XOR  SHIFT_LEFT  SHIFT_RIGHT  SHIFT_RIGHT(also shifts signed-bit)

    //==========================================================================================================================================================
    //  Operators Logical:  ==  !=  <  >  <=  >=     ( ! && || )

    [Impl(AggressiveOptimization)] public static bool operator ==(mat4 A, mat4 B) => (A.xx==B.xx  &&  A.yx==B.yx  &&  A.zx==B.zx  &&  A.wx==B.wx  &&
                                                                                      A.xy==B.xy  &&  A.yy==B.yy  &&  A.zy==B.zy  &&  A.wy==B.wy  &&
                                                                                      A.xz==B.xz  &&  A.yz==B.yz  &&  A.zz==B.zz  &&  A.wz==B.wz  &&
                                                                                      A.xw==B.xw  &&  A.yw==B.yw  &&  A.zw==B.zw  &&  A.ww==B.ww);

    [Impl(AggressiveOptimization)] public static bool operator !=(mat4 A, mat4 B) => (A.xx!=B.xx  ||  A.yx!=B.yx  ||  A.zx!=B.zx  ||  A.wx!=B.wx  ||
                                                                                      A.xy!=B.xy  ||  A.yy!=B.yy  ||  A.zy!=B.zy  ||  A.wy!=B.wy  ||
                                                                                      A.xz!=B.xz  ||  A.yz!=B.yz  ||  A.zz!=B.zz  ||  A.wz!=B.wz  ||
                                                                                      A.xw!=B.xw  ||  A.yw!=B.yw  ||  A.zw!=B.zw  ||  A.ww!=B.ww);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    public readonly override string ToString() =>
        $"""

            |  {this.xx,6:0.000}  {this.yx,6:0.000}  {this.zx,6:0.000}  {this.wx,6:0.000}  |
            |  {this.xy,6:0.000}  {this.yy,6:0.000}  {this.zy,6:0.000}  {this.wy,6:0.000}  |
            |  {this.xz,6:0.000}  {this.yz,6:0.000}  {this.zz,6:0.000}  {this.wz,6:0.000}  |
            |  {this.xw,6:0.000}  {this.yw,6:0.000}  {this.zw,6:0.000}  {this.ww,6:0.000}  |
        """;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    public readonly override bool Equals(object obj) => false;
    public readonly override int GetHashCode() => 0;

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
