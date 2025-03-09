using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace TEST;
internal static partial class Program {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    private const string BAR = "################################################################################################################################################################";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    private static void PRINT(string PrintMe, bool NewLine = true) {
        if (NewLine)
            Console.WriteLine(PrintMe);
        else
            Console.Write(PrintMe);
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    #if false
        static void RESULT(string TestLabel, bool Result) =>
            Console.WriteLine(
                $"{TestLabel,32}: " + (Result ? "Pass" : "FAILURE")
            );
    #else
        static void RESULT(string TestLabel, bool Result) {
            if (Result == false)
                Console.WriteLine(
                    $"{TestLabel,32}: FAILURE"
                );
        }
    #endif

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //  DebugStruct(typeof(vec2));
    //  DebugStruct(typeof(vec3));
    //  DebugStruct(typeof(vec4));
    //
    private static void DebugStruct(Type STRUCT) {

        //Console.WriteLine($"\nStruct: \"{STRUCT.Name}\"  {Marshal.SizeOf(STRUCT)} bytes");
        Console.WriteLine($"\n\n[\"{STRUCT.Name}\"  {Marshal.SizeOf(STRUCT)} bytes]");

        // Show fields and their [FieldOffset] values:
        var Struct_Fields = STRUCT.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        if (Struct_Fields.Count() > 0) {
            Console.WriteLine($"    Offset  Type      Field");
                              //____   123__abc     __"abc"   __

            foreach (var field in Struct_Fields) {
                var Field_Attributes = field.GetCustomAttributes(typeof(FieldOffsetAttribute), false);

                if (Field_Attributes.Count() > 0) {
                    var Field_Offset = (FieldOffsetAttribute)Field_Attributes.First();
                    Console.WriteLine($"    {Field_Offset.Value,6}  {field.FieldType.ToString().Split('.').Last(),-8}  {$"\"{field.Name}\"",-8}");
                } else {
                    Console.WriteLine($"    {"\""+field.Name+"\"",-12}");
                }
                /*
                field.CustomAttributes       //  (Inherited from MemberInfo)  Gets a collection that contains this member's custom attributes.
                field.DeclaringType          //  (Inherited from MemberInfo)  Gets the class that declares this member.
                field.IsCollectible          //  (Inherited from MemberInfo)  Gets a value that indicates whether this MemberInfo object is part of an assembly held in a collectible AssemblyLoadContext.
                field.MetadataToken          //  (Inherited from MemberInfo)  Gets a value that identifies a metadata element.
                field.Module                 //  (Inherited from MemberInfo)  Gets the module in which the type that declares the member represented by the current MemberInfo is defined.
                field.Name                   //  (Inherited from MemberInfo)  Gets the name of the current member.
                field.ReflectedType          //  (Inherited from MemberInfo)  Gets the class object that was used to obtain this instance of MemberInfo.

                field.Attributes             //  Gets the attributes associated with this field.
                field.FieldHandle            //  Gets a RuntimeFieldHandle, which is a handle to the internal metadata representation of a field.
                field.FieldType              //  Gets the type of this field object.
                field.IsAssembly             //  Gets a value indicating whether the potential visibility of this field is described by Assembly; that is, the field is visible at most to other types in the same assembly, and is not visible to derived types outside the assembly.
                field.IsFamily               //  Gets a value indicating whether the visibility of this field is described by Family; that is, the field is visible only within its class and derived classes.
                field.IsFamilyAndAssembly    //  Gets a value indicating whether the visibility of this field is described by FamANDAssem; that is, the field can be accessed from derived classes, but only if they are in the same assembly.
                field.IsFamilyOrAssembly     //  Gets a value indicating whether the potential visibility of this field is described by FamORAssem; that is, the field can be accessed by derived classes wherever they are, and by classes in the same assembly.
                field.IsInitOnly             //  Gets a value indicating whether the field can only be set in the body of the constructor.
                field.IsLiteral              //  Gets a value indicating whether the value is written at compile time and cannot be changed.
                field.IsNotSerialized        //  Obsolete.  Gets a value indicating whether this field has the NotSerialized attribute.
                field.IsPinvokeImpl          //  Gets a value indicating whether the corresponding PinvokeImpl attribute is set in FieldAttributes.
                field.IsPrivate              //  Gets a value indicating whether the field is private.
                field.IsPublic               //  Gets a value indicating whether the field is public.
                field.IsSecurityCritical     //  Gets a value that indicates whether the current field is security-critical or security-safe-critical at the current trust level.
                field.IsSecuritySafeCritical //  Gets a value that indicates whether the current field is security-safe-critical at the current trust level.
                field.IsSecurityTransparent  //  Gets a value that indicates whether the current field is transparent at the current trust level.
                field.IsSpecialName          //  Gets a value indicating whether the corresponding SpecialName attribute is set in the FieldAttributes enumerator.
                field.IsStatic               //  Gets a value indicating whether the field is static.
                field.MemberType             //  Gets a MemberTypes value indicating that this member is a field.
                */
            }
        }
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
