#if false
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct ray : IFormattable {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal vec3 Pos;

    internal vec3 Nrm;
    internal vec3 Rcp;

    internal float Length;

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal void SetNrm(vec3 NRM) {
        this.Nrm.x = NRM.x;
        this.Nrm.y = NRM.y;
        this.Nrm.z = NRM.z;

        this.Rcp.x = (NRM.x > -EPSILON && NRM.x < EPSILON) ? 0f : 1f/NRM.x;
        this.Rcp.y = (NRM.y > -EPSILON && NRM.y < EPSILON) ? 0f : 1f/NRM.y;
        this.Rcp.z = (NRM.z > -EPSILON && NRM.z < EPSILON) ? 0f : 1f/NRM.z;
    }

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal ray(vec3 POS, vec3 NRM, float LENGTH) {
        this.Pos.x = POS.x;
        this.Pos.y = POS.y;
        this.Pos.z = POS.z;

        this.Nrm.x = NRM.x;
        this.Nrm.y = NRM.y;
        this.Nrm.z = NRM.z;

        this.Rcp.x = (NRM.x > -EPSILON && NRM.x < EPSILON) ? 0f : 1f/NRM.x;
        this.Rcp.y = (NRM.y > -EPSILON && NRM.y < EPSILON) ? 0f : 1f/NRM.y;
        this.Rcp.z = (NRM.z > -EPSILON && NRM.z < EPSILON) ? 0f : 1f/NRM.z;

        this.Length = LENGTH;
    }

    internal ray(float POS_x, float POS_y, float POS_z,  float NRM_x, float NRM_y, float NRM_z,  float LENGTH) {
        this.Pos.x = POS_x;
        this.Pos.y = POS_y;
        this.Pos.z = POS_z;

        this.Nrm.x = NRM_x;
        this.Nrm.y = NRM_y;
        this.Nrm.z = NRM_z;

        this.Rcp.x = (NRM_x > -EPSILON && NRM_x < EPSILON) ? 0f : 1f/NRM_x;
        this.Rcp.y = (NRM_y > -EPSILON && NRM_y < EPSILON) ? 0f : 1f/NRM_y;
        this.Rcp.z = (NRM_z > -EPSILON && NRM_z < EPSILON) ? 0f : 1f/NRM_z;

        this.Length = LENGTH;
    }

    internal ray() {
        this.Pos.x =  0f;
        this.Pos.y =  0f;
        this.Pos.z =  0f;

        this.Nrm.x =  0f;
        this.Nrm.y =  0f;
        this.Nrm.z = -1f;

        this.Rcp.x =  0f;
        this.Rcp.y =  0f;
        this.Rcp.z = -1f;

        this.Length = 1f;
    }

    //==========================================================================================================================================================
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static implicit operator ray( (vec3 POS, vec3 NRM, float LENGTH) t ) =>
        new ray(t.POS,  t.NRM,  t.LENGTH);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static implicit operator ray( (float POS_x, float POS_y, float POS_z,  float NRM_x, float NRM_y, float NRM_z,  float LENGTH) t ) =>
        new ray(t.POS_x, t.POS_y, t.POS_z,  t.NRM_x, t.NRM_y, t.NRM_z,  t.LENGTH);

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Operators, Arithmetic:  +  -  *  /  %

    //==========================================================================================================================================================
    //  Operators, Binary:  &  |  ^  <<  >>

    //==========================================================================================================================================================
    //  Operators, Logical:  ==  !=  <  >  <=  >=

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool operator ==(ray A, ray B) => false; //  "EqualTo"

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool operator !=(ray A, ray B) => true; //  "NotEqualTo"

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal string ToString(string FormatStr, IFormatProvider FormatProvider) {
        if (FormatStr.IsVoid())
            return this.ToString();

        int Padding = FormatStr.Length+1;
        return "( "
             + "Pos: "
             + (this.Pos.x .IsApproximatelyZero() ? 0f : this.Pos.x ).ToString(FormatStr).PadLeft(Padding)+ ", "
             + (this.Pos.y .IsApproximatelyZero() ? 0f : this.Pos.y ).ToString(FormatStr).PadLeft(Padding)+ ", "
             + (this.Pos.z .IsApproximatelyZero() ? 0f : this.Pos.z ).ToString(FormatStr).PadLeft(Padding)
             + "  Nrm: "
             + (this.Nrm.x .IsApproximatelyZero() ? 0f : this.Nrm.x ).ToString(FormatStr).PadLeft(Padding)+ ", "
             + (this.Nrm.y .IsApproximatelyZero() ? 0f : this.Nrm.y ).ToString(FormatStr).PadLeft(Padding)+ ", "
             + (this.Nrm.z .IsApproximatelyZero() ? 0f : this.Nrm.z ).ToString(FormatStr).PadLeft(Padding)
             + "  Rcp: "
             + (this.Rcp.x .IsApproximatelyZero() ? 0f : this.Rcp.x ).ToString(FormatStr).PadLeft(Padding)+ ", "
             + (this.Rcp.y .IsApproximatelyZero() ? 0f : this.Rcp.y ).ToString(FormatStr).PadLeft(Padding)+ ", "
             + (this.Rcp.z .IsApproximatelyZero() ? 0f : this.Rcp.z ).ToString(FormatStr).PadLeft(Padding)
             + "  Length: "
             + (this.Length.IsApproximatelyZero() ? 0f : this.Length).ToString(FormatStr).PadLeft(Padding)
             + " )";
    }

    //==========================================================================================================================================================
    internal override string ToString() => "( "
        + "Pos: "
        + $"{(this.Pos.x .IsApproximatelyZero() ? 0f : this.Pos.x ),6:0.000}, "
        + $"{(this.Pos.y .IsApproximatelyZero() ? 0f : this.Pos.y ),6:0.000}, "
        + $"{(this.Pos.z .IsApproximatelyZero() ? 0f : this.Pos.z ),6:0.000}    "
        + "Nrm: "
        + $"{(this.Nrm.x .IsApproximatelyZero() ? 0f : this.Nrm.x ),6:0.000}, "
        + $"{(this.Nrm.y .IsApproximatelyZero() ? 0f : this.Nrm.y ),6:0.000}, "
        + $"{(this.Nrm.z .IsApproximatelyZero() ? 0f : this.Nrm.z ),6:0.000}    "
        + "Rcp: "
        + $"{(this.Rcp.x .IsApproximatelyZero() ? 0f : this.Rcp.x ),6:0.000}, "
        + $"{(this.Rcp.y .IsApproximatelyZero() ? 0f : this.Rcp.y ),6:0.000}, "
        + $"{(this.Rcp.z .IsApproximatelyZero() ? 0f : this.Rcp.z ),6:0.000}    "
        + "Length: "
        + $"{(this.Length.IsApproximatelyZero() ? 0f : this.Length),6:0.000} )";

    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //  Required by DotNet "object" type:
    internal override bool Equals(object obj) => false;
    internal override int GetHashCode() => HashCode.Combine(HashCode.Combine(Pos.x, Pos.y, Pos.z, Nrm.x, Nrm.y),
                                                          HashCode.Combine(Nrm.z, Rcp.x, Rcp.y, Rcp.z, Length));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}
#endif
