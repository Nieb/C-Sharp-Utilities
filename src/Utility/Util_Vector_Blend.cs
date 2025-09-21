using System.Runtime.CompilerServices;

namespace Utility;
using v1 = float;
using v2 = vec2;
using v3 = vec3;
using v4 = vec4;
internal static partial class VEC_Blend {
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    //
    //      Blend_*(  Source,  Destination  )
    //
    //##########################################################################################################################################################
    //##########################################################################################################################################################
    internal static v1 Blend_Screen(v1 S, v1 D) => (S+D - S*D);

    internal static v3 Blend_Screen(v3 S, v3 D) => new v3(Blend_Screen(S.r, D.r),Blend_Screen(S.g, D.g),Blend_Screen(S.b, D.b));

    //==========================================================================================================================================================
    internal static v1 Blend_Overlay(v1 S, v1 D) => (D <= 0.5f) ?      2f*(   S)*(   D)
                                                                : 1f - 2f*(1f-S)*(1f-D);

    internal static v3 Blend_Overlay(v3 S, v3 D) => new v3(Blend_Overlay(S.r, D.r),Blend_Overlay(S.g, D.g),Blend_Overlay(S.b, D.b));

    //==========================================================================================================================================================
    internal static v1 Blend_HardLight(v1 S, v1 D) => (S <= 0.5f) ?      2f*(   S)*(   D)
                                                                  : 1f - 2f*(1f-S)*(1f-D);

    internal static v3 Blend_HardLight(v3 S, v3 D) => new v3(Blend_HardLight(S.r, D.r),Blend_HardLight(S.g, D.g),Blend_HardLight(S.b, D.b));

    //==========================================================================================================================================================
    internal static v1 Blend_SoftLight(v1 S, v1 D) => (S <= 0.5f              ) ? D - (1f-2f*S   ) * D*(       1f - D     )
                                                    : (S >  0.5f && D <= 0.25f) ? D + (   2f*S-1f) * D*((16f*D-12f)*D + 3f)
                                                                                : D + (   2f*S-1f) *   (  sqrt(D) - D     );

    internal static v3 Blend_SoftLight(v3 S, v3 D) => new v3(Blend_SoftLight(S.r, D.r),Blend_SoftLight(S.g, D.g),Blend_SoftLight(S.b, D.b));

    //##########################################################################################################################################################
    //##########################################################################################################################################################
}

#if  false
    //Mode                      Blend
    //--------------------      -----------------------------------

      MULTIPLY(Cs,Cd)           = Cs*Cd

      DARKEN(Cs,Cd)             = min(Cs,Cd)
      LIGHTEN(Cs,Cd)            = max(Cs,Cd)

      DIFFERENCE(Cs,Cd)         = abs(Cd-Cs)
      EXCLUSION(Cs,Cd)          = Cs+Cd - 2*Cs*Cd

      INVERT(Cs,Cd)             =     1-Cd
      INVERT_RGB(Cs,Cd)         = Cs*(1-Cd)


      HARDMIX(Cs,Cd)            = (Cs+Cd < 1) ? 0 : 1


      LINEARDODGE(Cs,Cd)        = (Cs+Cd <= 1) ?  Cs+Cd    : 1
      LINEARBURN(Cs,Cd)         = (Cs+Cd >  1) ?  Cs+Cd-1  : 0


      COLORDODGE(Cs,Cd)         = (Cd <= 0            ) ? 0
                                  (Cd >  0 and Cs <  1) ? min(1, Cd/(1-Cs))
                                  (Cd >  0 and Cs >= 1) ? 1

      COLORBURN(Cs,Cd)          = (Cd >= 1            ) ? 1
                                  (Cd <  1 and Cs >  0) ? 1 - min(1, (1-Cd)/Cs)
                                  (Cd <  1 and Cs <= 0) ? 0




      VIVIDLIGHT(Cs,Cd)         = (       Cs <= 0   ) ? 0
                                  (0   <  Cs <  0.5 ) ? 1-min(1, (1-Cd)/(2*Cs))
                                  (0.5 <= Cs <  1   ) ?   min(1, Cd/(2*(1-Cs)))
                                  (       Cs >= 1   ) ? 1

      LINEARLIGHT(Cs,Cd)        = (    2*Cs+Cd <= 1) ? 0
                                  (1 < 2*Cs+Cd <= 2) ? 2*Cs+Cd-1
                                  (    2*Cs+Cd >  2) ? 1

      PINLIGHT(Cs,Cd)           = (2*Cs-1> Cd and Cs< 0.5   ) ? 0
                                  (2*Cs-1> Cd and Cs>=0.5   ) ? 2*Cs-1
                                  (2*Cs-1<=Cd and Cs< 0.5*Cd) ? 2*Cs
                                  (2*Cs-1<=Cd and Cs>=0.5*Cd) ? Cd
#endif
