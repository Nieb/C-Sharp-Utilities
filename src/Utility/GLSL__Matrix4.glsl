
vec4 V = vec4(0.25, 0.5, 0.75, 1.0);

mat4 M = mat4(
    0.0, 0.0, 0.0, 1.0,
    0.0, 0.0, 0.0, 1.0,
    0.0, 0.0, 0.0, 1.0,
    0.0, 0.0, 0.0, 1.0
);

void mainImage(out vec4 FragColor, in vec2 FragCoord) {
    vec2 ViewCoord = (FragCoord/iResolution.xy) * 2.0 - 1.0;

    //
    //   Vx  Vy  Vz  Vw |
    //  ----------------+---
    //   M + M + M + M  | Rx
    //                  |
    //   M + M + M + M  | Ry
    //                  |       "Result"
    //   M + M + M + M  | Rz
    //                  |
    //   M + M + M + M  | Rw
    //                  |
    //
    vec4 Vec_Mat = (V * M); //  ==  (1, 1, 1, 1)

    //
    //      |
    //   Vx | Mxx  Myx  Mzx  Mwx
    //      | +    +    +    +
    //   Vy | Mxy  Myy  M    M
    //      | +    +    +    +
    //   Vz | Mxz  M    Mzz  M
    //      | +    +    +    +
    //   Vw | Mxw  M    M    Mww
    //  ----+-------------------
    //      | Rx   Ry   Rz   Rw    "Result"
    //
    vec4 Mat_Vec = (M * V); //  ==  (0, 0, 0, 0)

    FragColor = (ViewCoord.x < -0.33) ? Vec_Mat // White
              : (ViewCoord.x <  0.33) ? Mat_Vec // Black
                                      : vec4(0.0, 0.0, 0.0, 1.0);
}
