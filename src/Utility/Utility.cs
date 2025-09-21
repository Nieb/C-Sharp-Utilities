//##############################################################################################################################################################
//##############################################################################################################################################################
global using Utility;

global using static Utility.Casting;
global using static Utility.Loops;

global using static Utility.ARY;
global using static Utility.FLT;
global using static Utility.INT;
global using static Utility.STR;

global using static Utility.VEC;
global using static Utility.VEC_Color;
global using static Utility.VEC_Collision2;
global using static Utility.VEC_Collision3;
global using static Utility.VEC_Filter;
global using static Utility.VEC_Geometry;
global using static Utility.VEC_Generate;
global using static Utility.VEC_Interpolation;
global using static Utility.VEC_Miscellaneous;
global using static Utility.VEC_Rotation;

//##############################################################################################################################################################
//##############################################################################################################################################################
#if false
    global using iptr = System.IntPtr;  //  nint            Depends on platform (computed at runtime)             Signed 32-bit or 64-bit integer
    global using uptr = System.UIntPtr; //  nuint           Depends on platform (computed at runtime)           Unsigned 32-bit or 64-bit integer
#endif
#if false
    global using  i8 = System.SByte;    //  sbyte                         -128 to 127                             Signed 8-bit integer
    global using  u8 = System.Byte;     //  byte                             0 to 255                           Unsigned 8-bit integer

    global using i16 = System.Int16;    //  short                      -32,768 to 32,767                          Signed 16-bit integer
    global using u16 = System.UInt16;   //  ushort                           0 to 65,535                        Unsigned 16-bit integer

    global using i32 = System.Int32;    //  int                 -2,147,483,648 to 2,147,483,647                   Signed 32-bit integer
    global using u32 = System.UInt32;   //  uint                             0 to 4,294,967,295                 Unsigned 32-bit integer

    global using i64 = System.Int64;    //  long    -9,223,372,036,854,775,808 to  9,223,372,036,854,775,807      Signed 64-bit integer
    global using u64 = System.UInt64;   //  ulong                            0 to 18,446,744,073,709,551,615    Unsigned 64-bit integer
#endif

//==============================================================================================================================================================
#if false
    global using f32 = System.Single;
    global using f64 = System.Double;
#endif
#if false
    global using vec2 = System.Numerics.Vector2;
    global using vec3 = System.Numerics.Vector3;
    global using vec4 = System.Numerics.Vector4;

    global using mat4 = System.Numerics.Matrix4;
#endif

//##############################################################################################################################################################
//##############################################################################################################################################################
//                                                               Method Implementation Options

global using Impl = System.Runtime.CompilerServices.MethodImplAttribute;
global using static System.Runtime.CompilerServices.MethodImplOptions;

/*
    MethodImpl
    Imploy
    Employ
    Implement
    Impl

    [Impl(AggressiveInlining|AggressiveOptimization)]
    [Impl(AggressiveInlining)]
    [Impl(AggressiveOptimization)]

    [MethodImpl(MethodImplOptions.AggressiveInlining|MethodImplOptions.AggressiveOptimization)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
*/
/*

        Unmanaged               The method is implemented in unmanaged code.

        NoInlining              The method cannot be inlined.
                                Inlining is an optimization by which a method call is replaced with the method body.

        ForwardRef              The method is declared, but its implementation is provided elsewhere.

        Synchronized            The method can be executed by only one thread at a time.
                                Static methods lock on the type, whereas instance methods lock on the instance.
                                Only one thread can execute in any of the instance functions, and only one thread can execute in any of a class's static functions.

        NoOptimization          The method is not optimized by the just-in-time (JIT) compiler or by native code generation (see Ngen.exe) when debugging possible code generation problems.

        PreserveSig             The method signature is exported exactly as declared.

        AggressiveInlining      The method should be inlined if possible.
                                Unnecessary use of this attribute can reduce performance.
                                The attribute might cause implementation limits to be encountered that will result in slower generated code.
                                Always measure performance to ensure it's helpful to apply this attribute.

        AggressiveOptimization  The method contains code that should always be optimized for performance.
                                It's rarely appropriate to use this attribute.
                                Methods that apply this attribute bypass the first tier of tiered compilation and therefore don't benefit from optimizations that rely on tiered compilation.
                                Those optimizations include dynamic PGO and optimizations based on initialized classes.
                                Use of this attribute may also increase memory use.
                                Always measure performance to ensure it's helpful to apply this attribute.

        InternalCall            The call is internal, that is, it calls a method that's implemented within the common language runtime.

*/
