
namespace TEST;
internal static partial class Program {
    static void Test__Vector_Color() {
        PRINT("\n[Utility.VEC -- Color]");

        //======================================================================================================================================================
        RESULT("ByteToUnit()", true
            && ByteToUnit(  0) == 0.0f             && ByteToUnit(  1) == 0.0039215686274f && ByteToUnit(  2) == 0.0078431372549f && ByteToUnit(  3) == 0.0117647058823f && ByteToUnit(  4) == 0.0156862745098f && ByteToUnit(  5) == 0.0196078431372f && ByteToUnit(  6) == 0.0235294117647f && ByteToUnit(  7) == 0.0274509803921f
            && ByteToUnit(  8) == 0.0313725490196f && ByteToUnit(  9) == 0.0352941176470f && ByteToUnit( 10) == 0.0392156862745f && ByteToUnit( 11) == 0.0431372549019f && ByteToUnit( 12) == 0.0470588235294f && ByteToUnit( 13) == 0.0509803921568f && ByteToUnit( 14) == 0.0549019607843f && ByteToUnit( 15) == 0.0588235294117f
            && ByteToUnit( 16) == 0.0627450980392f && ByteToUnit( 17) == 0.0666666666666f && ByteToUnit( 18) == 0.0705882352941f && ByteToUnit( 19) == 0.0745098039215f && ByteToUnit( 20) == 0.0784313725490f && ByteToUnit( 21) == 0.0823529411764f && ByteToUnit( 22) == 0.0862745098039f && ByteToUnit( 23) == 0.0901960784313f
            && ByteToUnit( 24) == 0.0941176470588f && ByteToUnit( 25) == 0.0980392156862f && ByteToUnit( 26) == 0.1019607843137f && ByteToUnit( 27) == 0.1058823529411f && ByteToUnit( 28) == 0.1098039215686f && ByteToUnit( 29) == 0.1137254901960f && ByteToUnit( 30) == 0.1176470588235f && ByteToUnit( 31) == 0.1215686274509f

            && ByteToUnit( 32) == 0.1254901960784f && ByteToUnit( 33) == 0.1294117647058f && ByteToUnit( 34) == 0.1333333333333f && ByteToUnit( 35) == 0.1372549019607f && ByteToUnit( 36) == 0.1411764705882f && ByteToUnit( 37) == 0.1450980392156f && ByteToUnit( 38) == 0.1490196078431f && ByteToUnit( 39) == 0.1529411764705f
            && ByteToUnit( 40) == 0.1568627450980f && ByteToUnit( 41) == 0.1607843137254f && ByteToUnit( 42) == 0.1647058823529f && ByteToUnit( 43) == 0.1686274509803f && ByteToUnit( 44) == 0.1725490196078f && ByteToUnit( 45) == 0.1764705882352f && ByteToUnit( 46) == 0.1803921568627f && ByteToUnit( 47) == 0.1843137254901f
            && ByteToUnit( 48) == 0.1882352941176f && ByteToUnit( 49) == 0.1921568627450f && ByteToUnit( 50) == 0.1960784313725f && ByteToUnit( 51) == 0.2f             && ByteToUnit( 52) == 0.2039215686274f && ByteToUnit( 53) == 0.2078431372549f && ByteToUnit( 54) == 0.2117647058823f && ByteToUnit( 55) == 0.2156862745098f
            && ByteToUnit( 56) == 0.2196078431372f && ByteToUnit( 57) == 0.2235294117647f && ByteToUnit( 58) == 0.2274509803921f && ByteToUnit( 59) == 0.2313725490196f && ByteToUnit( 60) == 0.2352941176470f && ByteToUnit( 61) == 0.2392156862745f && ByteToUnit( 62) == 0.2431372549019f && ByteToUnit( 63) == 0.2470588235294f

            && ByteToUnit( 64) == 0.2509803921568f && ByteToUnit( 65) == 0.2549019607843f && ByteToUnit( 66) == 0.2588235294117f && ByteToUnit( 67) == 0.2627450980392f && ByteToUnit( 68) == 0.2666666666666f && ByteToUnit( 69) == 0.2705882352941f && ByteToUnit( 70) == 0.2745098039215f && ByteToUnit( 71) == 0.2784313725490f
            && ByteToUnit( 72) == 0.2823529411764f && ByteToUnit( 73) == 0.2862745098039f && ByteToUnit( 74) == 0.2901960784313f && ByteToUnit( 75) == 0.2941176470588f && ByteToUnit( 76) == 0.2980392156862f && ByteToUnit( 77) == 0.3019607843137f && ByteToUnit( 78) == 0.3058823529411f && ByteToUnit( 79) == 0.3098039215686f
            && ByteToUnit( 80) == 0.3137254901960f && ByteToUnit( 81) == 0.3176470588235f && ByteToUnit( 82) == 0.3215686274509f && ByteToUnit( 83) == 0.3254901960784f && ByteToUnit( 84) == 0.3294117647058f && ByteToUnit( 85) == 0.3333333333333f && ByteToUnit( 86) == 0.3372549019607f && ByteToUnit( 87) == 0.3411764705882f
            && ByteToUnit( 88) == 0.3450980392156f && ByteToUnit( 89) == 0.3490196078431f && ByteToUnit( 90) == 0.3529411764705f && ByteToUnit( 91) == 0.3568627450980f && ByteToUnit( 92) == 0.3607843137254f && ByteToUnit( 93) == 0.3647058823529f && ByteToUnit( 94) == 0.3686274509803f && ByteToUnit( 95) == 0.3725490196078f

            && ByteToUnit( 96) == 0.3764705882352f && ByteToUnit( 97) == 0.3803921568627f && ByteToUnit( 98) == 0.3843137254901f && ByteToUnit( 99) == 0.3882352941176f && ByteToUnit(100) == 0.3921568627450f && ByteToUnit(101) == 0.3960784313725f && ByteToUnit(102) == 0.4f             && ByteToUnit(103) == 0.4039215686274f
            && ByteToUnit(104) == 0.4078431372549f && ByteToUnit(105) == 0.4117647058823f && ByteToUnit(106) == 0.4156862745098f && ByteToUnit(107) == 0.4196078431372f && ByteToUnit(108) == 0.4235294117647f && ByteToUnit(109) == 0.4274509803921f && ByteToUnit(110) == 0.4313725490196f && ByteToUnit(111) == 0.4352941176470f
            && ByteToUnit(112) == 0.4392156862745f && ByteToUnit(113) == 0.4431372549019f && ByteToUnit(114) == 0.4470588235294f && ByteToUnit(115) == 0.4509803921568f && ByteToUnit(116) == 0.4549019607843f && ByteToUnit(117) == 0.4588235294117f && ByteToUnit(118) == 0.4627450980392f && ByteToUnit(119) == 0.4666666666666f
            && ByteToUnit(120) == 0.4705882352941f && ByteToUnit(121) == 0.4745098039215f && ByteToUnit(122) == 0.4784313725490f && ByteToUnit(123) == 0.4823529411764f && ByteToUnit(124) == 0.4862745098039f && ByteToUnit(125) == 0.4901960784313f && ByteToUnit(126) == 0.4941176470588f && ByteToUnit(127) == 0.4980392156862f

            && ByteToUnit(128) == 0.5019607843137f && ByteToUnit(129) == 0.5058823529411f && ByteToUnit(130) == 0.5098039215686f && ByteToUnit(131) == 0.5137254901960f && ByteToUnit(132) == 0.5176470588235f && ByteToUnit(133) == 0.5215686274509f && ByteToUnit(134) == 0.5254901960784f && ByteToUnit(135) == 0.5294117647058f
            && ByteToUnit(136) == 0.5333333333333f && ByteToUnit(137) == 0.5372549019607f && ByteToUnit(138) == 0.5411764705882f && ByteToUnit(139) == 0.5450980392156f && ByteToUnit(140) == 0.5490196078431f && ByteToUnit(141) == 0.5529411764705f && ByteToUnit(142) == 0.5568627450980f && ByteToUnit(143) == 0.5607843137254f
            && ByteToUnit(144) == 0.5647058823529f && ByteToUnit(145) == 0.5686274509803f && ByteToUnit(146) == 0.5725490196078f && ByteToUnit(147) == 0.5764705882352f && ByteToUnit(148) == 0.5803921568627f && ByteToUnit(149) == 0.5843137254901f && ByteToUnit(150) == 0.5882352941176f && ByteToUnit(151) == 0.5921568627450f
            && ByteToUnit(152) == 0.5960784313725f && ByteToUnit(153) == 0.6f             && ByteToUnit(154) == 0.6039215686274f && ByteToUnit(155) == 0.6078431372549f && ByteToUnit(156) == 0.6117647058823f && ByteToUnit(157) == 0.6156862745098f && ByteToUnit(158) == 0.6196078431372f && ByteToUnit(159) == 0.6235294117647f

            && ByteToUnit(160) == 0.6274509803921f && ByteToUnit(161) == 0.6313725490196f && ByteToUnit(162) == 0.6352941176470f && ByteToUnit(163) == 0.6392156862745f && ByteToUnit(164) == 0.6431372549019f && ByteToUnit(165) == 0.6470588235294f && ByteToUnit(166) == 0.6509803921568f && ByteToUnit(167) == 0.6549019607843f
            && ByteToUnit(168) == 0.6588235294117f && ByteToUnit(169) == 0.6627450980392f && ByteToUnit(170) == 0.6666666666666f && ByteToUnit(171) == 0.6705882352941f && ByteToUnit(172) == 0.6745098039215f && ByteToUnit(173) == 0.6784313725490f && ByteToUnit(174) == 0.6823529411764f && ByteToUnit(175) == 0.6862745098039f
            && ByteToUnit(176) == 0.6901960784313f && ByteToUnit(177) == 0.6941176470588f && ByteToUnit(178) == 0.6980392156862f && ByteToUnit(179) == 0.7019607843137f && ByteToUnit(180) == 0.7058823529411f && ByteToUnit(181) == 0.7098039215686f && ByteToUnit(182) == 0.7137254901960f && ByteToUnit(183) == 0.7176470588235f
            && ByteToUnit(184) == 0.7215686274509f && ByteToUnit(185) == 0.7254901960784f && ByteToUnit(186) == 0.7294117647058f && ByteToUnit(187) == 0.7333333333333f && ByteToUnit(188) == 0.7372549019607f && ByteToUnit(189) == 0.7411764705882f && ByteToUnit(190) == 0.7450980392156f && ByteToUnit(191) == 0.7490196078431f

            && ByteToUnit(192) == 0.7529411764705f && ByteToUnit(193) == 0.7568627450980f && ByteToUnit(194) == 0.7607843137254f && ByteToUnit(195) == 0.7647058823529f && ByteToUnit(196) == 0.7686274509803f && ByteToUnit(197) == 0.7725490196078f && ByteToUnit(198) == 0.7764705882352f && ByteToUnit(199) == 0.7803921568627f
            && ByteToUnit(200) == 0.7843137254901f && ByteToUnit(201) == 0.7882352941176f && ByteToUnit(202) == 0.7921568627450f && ByteToUnit(203) == 0.7960784313725f && ByteToUnit(204) == 0.8f             && ByteToUnit(205) == 0.8039215686274f && ByteToUnit(206) == 0.8078431372549f && ByteToUnit(207) == 0.8117647058823f
            && ByteToUnit(208) == 0.8156862745098f && ByteToUnit(209) == 0.8196078431372f && ByteToUnit(210) == 0.8235294117647f && ByteToUnit(211) == 0.8274509803921f && ByteToUnit(212) == 0.8313725490196f && ByteToUnit(213) == 0.8352941176470f && ByteToUnit(214) == 0.8392156862745f && ByteToUnit(215) == 0.8431372549019f
            && ByteToUnit(216) == 0.8470588235294f && ByteToUnit(217) == 0.8509803921568f && ByteToUnit(218) == 0.8549019607843f && ByteToUnit(219) == 0.8588235294117f && ByteToUnit(220) == 0.8627450980392f && ByteToUnit(221) == 0.8666666666666f && ByteToUnit(222) == 0.8705882352941f && ByteToUnit(223) == 0.8745098039215f

            && ByteToUnit(224) == 0.8784313725490f && ByteToUnit(225) == 0.8823529411764f && ByteToUnit(226) == 0.8862745098039f && ByteToUnit(227) == 0.8901960784313f && ByteToUnit(228) == 0.8941176470588f && ByteToUnit(229) == 0.8980392156862f && ByteToUnit(230) == 0.9019607843137f && ByteToUnit(231) == 0.9058823529411f
            && ByteToUnit(232) == 0.9098039215686f && ByteToUnit(233) == 0.9137254901960f && ByteToUnit(234) == 0.9176470588235f && ByteToUnit(235) == 0.9215686274509f && ByteToUnit(236) == 0.9254901960784f && ByteToUnit(237) == 0.9294117647058f && ByteToUnit(238) == 0.9333333333333f && ByteToUnit(239) == 0.9372549019607f
            && ByteToUnit(240) == 0.9411764705882f && ByteToUnit(241) == 0.9450980392156f && ByteToUnit(242) == 0.9490196078431f && ByteToUnit(243) == 0.9529411764705f && ByteToUnit(244) == 0.9568627450980f && ByteToUnit(245) == 0.9607843137254f && ByteToUnit(246) == 0.9647058823529f && ByteToUnit(247) == 0.9686274509803f
            && ByteToUnit(248) == 0.9725490196078f && ByteToUnit(249) == 0.9764705882352f && ByteToUnit(250) == 0.9803921568627f && ByteToUnit(251) == 0.9843137254901f && ByteToUnit(252) == 0.9882352941176f && ByteToUnit(253) == 0.9921568627450f && ByteToUnit(254) == 0.9960784313725f && ByteToUnit(255) == 1.0f
        );

        RESULT("UnitToByte()", true
            && UnitToByte(0.0f)             ==   0 && UnitToByte(0.0039215686274f) ==   1 && UnitToByte(0.0078431372549f) ==   2 && UnitToByte(0.0117647058823f) ==   3 && UnitToByte(0.0156862745098f) ==   4 && UnitToByte(0.0196078431372f) ==   5 && UnitToByte(0.0235294117647f) ==   6 && UnitToByte(0.0274509803921f) ==   7
            && UnitToByte(0.0313725490196f) ==   8 && UnitToByte(0.0352941176470f) ==   9 && UnitToByte(0.0392156862745f) ==  10 && UnitToByte(0.0431372549019f) ==  11 && UnitToByte(0.0470588235294f) ==  12 && UnitToByte(0.0509803921568f) ==  13 && UnitToByte(0.0549019607843f) ==  14 && UnitToByte(0.0588235294117f) ==  15
            && UnitToByte(0.0627450980392f) ==  16 && UnitToByte(0.0666666666666f) ==  17 && UnitToByte(0.0705882352941f) ==  18 && UnitToByte(0.0745098039215f) ==  19 && UnitToByte(0.0784313725490f) ==  20 && UnitToByte(0.0823529411764f) ==  21 && UnitToByte(0.0862745098039f) ==  22 && UnitToByte(0.0901960784313f) ==  23
            && UnitToByte(0.0941176470588f) ==  24 && UnitToByte(0.0980392156862f) ==  25 && UnitToByte(0.1019607843137f) ==  26 && UnitToByte(0.1058823529411f) ==  27 && UnitToByte(0.1098039215686f) ==  28 && UnitToByte(0.1137254901960f) ==  29 && UnitToByte(0.1176470588235f) ==  30 && UnitToByte(0.1215686274509f) ==  31

            && UnitToByte(0.1254901960784f) ==  32 && UnitToByte(0.1294117647058f) ==  33 && UnitToByte(0.1333333333333f) ==  34 && UnitToByte(0.1372549019607f) ==  35 && UnitToByte(0.1411764705882f) ==  36 && UnitToByte(0.1450980392156f) ==  37 && UnitToByte(0.1490196078431f) ==  38 && UnitToByte(0.1529411764705f) ==  39
            && UnitToByte(0.1568627450980f) ==  40 && UnitToByte(0.1607843137254f) ==  41 && UnitToByte(0.1647058823529f) ==  42 && UnitToByte(0.1686274509803f) ==  43 && UnitToByte(0.1725490196078f) ==  44 && UnitToByte(0.1764705882352f) ==  45 && UnitToByte(0.1803921568627f) ==  46 && UnitToByte(0.1843137254901f) ==  47
            && UnitToByte(0.1882352941176f) ==  48 && UnitToByte(0.1921568627450f) ==  49 && UnitToByte(0.1960784313725f) ==  50 && UnitToByte(0.2f)             ==  51 && UnitToByte(0.2039215686274f) ==  52 && UnitToByte(0.2078431372549f) ==  53 && UnitToByte(0.2117647058823f) ==  54 && UnitToByte(0.2156862745098f) ==  55
            && UnitToByte(0.2196078431372f) ==  56 && UnitToByte(0.2235294117647f) ==  57 && UnitToByte(0.2274509803921f) ==  58 && UnitToByte(0.2313725490196f) ==  59 && UnitToByte(0.2352941176470f) ==  60 && UnitToByte(0.2392156862745f) ==  61 && UnitToByte(0.2431372549019f) ==  62 && UnitToByte(0.2470588235294f) ==  63

            && UnitToByte(0.2509803921568f) ==  64 && UnitToByte(0.2549019607843f) ==  65 && UnitToByte(0.2588235294117f) ==  66 && UnitToByte(0.2627450980392f) ==  67 && UnitToByte(0.2666666666666f) ==  68 && UnitToByte(0.2705882352941f) ==  69 && UnitToByte(0.2745098039215f) ==  70 && UnitToByte(0.2784313725490f) ==  71
            && UnitToByte(0.2823529411764f) ==  72 && UnitToByte(0.2862745098039f) ==  73 && UnitToByte(0.2901960784313f) ==  74 && UnitToByte(0.2941176470588f) ==  75 && UnitToByte(0.2980392156862f) ==  76 && UnitToByte(0.3019607843137f) ==  77 && UnitToByte(0.3058823529411f) ==  78 && UnitToByte(0.3098039215686f) ==  79
            && UnitToByte(0.3137254901960f) ==  80 && UnitToByte(0.3176470588235f) ==  81 && UnitToByte(0.3215686274509f) ==  82 && UnitToByte(0.3254901960784f) ==  83 && UnitToByte(0.3294117647058f) ==  84 && UnitToByte(0.3333333333333f) ==  85 && UnitToByte(0.3372549019607f) ==  86 && UnitToByte(0.3411764705882f) ==  87
            && UnitToByte(0.3450980392156f) ==  88 && UnitToByte(0.3490196078431f) ==  89 && UnitToByte(0.3529411764705f) ==  90 && UnitToByte(0.3568627450980f) ==  91 && UnitToByte(0.3607843137254f) ==  92 && UnitToByte(0.3647058823529f) ==  93 && UnitToByte(0.3686274509803f) ==  94 && UnitToByte(0.3725490196078f) ==  95

            && UnitToByte(0.3764705882352f) ==  96 && UnitToByte(0.3803921568627f) ==  97 && UnitToByte(0.3843137254901f) ==  98 && UnitToByte(0.3882352941176f) ==  99 && UnitToByte(0.3921568627450f) == 100 && UnitToByte(0.3960784313725f) == 101 && UnitToByte(0.4f)             == 102 && UnitToByte(0.4039215686274f) == 103
            && UnitToByte(0.4078431372549f) == 104 && UnitToByte(0.4117647058823f) == 105 && UnitToByte(0.4156862745098f) == 106 && UnitToByte(0.4196078431372f) == 107 && UnitToByte(0.4235294117647f) == 108 && UnitToByte(0.4274509803921f) == 109 && UnitToByte(0.4313725490196f) == 110 && UnitToByte(0.4352941176470f) == 111
            && UnitToByte(0.4392156862745f) == 112 && UnitToByte(0.4431372549019f) == 113 && UnitToByte(0.4470588235294f) == 114 && UnitToByte(0.4509803921568f) == 115 && UnitToByte(0.4549019607843f) == 116 && UnitToByte(0.4588235294117f) == 117 && UnitToByte(0.4627450980392f) == 118 && UnitToByte(0.4666666666666f) == 119
            && UnitToByte(0.4705882352941f) == 120 && UnitToByte(0.4745098039215f) == 121 && UnitToByte(0.4784313725490f) == 122 && UnitToByte(0.4823529411764f) == 123 && UnitToByte(0.4862745098039f) == 124 && UnitToByte(0.4901960784313f) == 125 && UnitToByte(0.4941176470588f) == 126 && UnitToByte(0.4980392156862f) == 127

            && UnitToByte(0.5019607843137f) == 128 && UnitToByte(0.5058823529411f) == 129 && UnitToByte(0.5098039215686f) == 130 && UnitToByte(0.5137254901960f) == 131 && UnitToByte(0.5176470588235f) == 132 && UnitToByte(0.5215686274509f) == 133 && UnitToByte(0.5254901960784f) == 134 && UnitToByte(0.5294117647058f) == 135
            && UnitToByte(0.5333333333333f) == 136 && UnitToByte(0.5372549019607f) == 137 && UnitToByte(0.5411764705882f) == 138 && UnitToByte(0.5450980392156f) == 139 && UnitToByte(0.5490196078431f) == 140 && UnitToByte(0.5529411764705f) == 141 && UnitToByte(0.5568627450980f) == 142 && UnitToByte(0.5607843137254f) == 143
            && UnitToByte(0.5647058823529f) == 144 && UnitToByte(0.5686274509803f) == 145 && UnitToByte(0.5725490196078f) == 146 && UnitToByte(0.5764705882352f) == 147 && UnitToByte(0.5803921568627f) == 148 && UnitToByte(0.5843137254901f) == 149 && UnitToByte(0.5882352941176f) == 150 && UnitToByte(0.5921568627450f) == 151
            && UnitToByte(0.5960784313725f) == 152 && UnitToByte(0.6f)             == 153 && UnitToByte(0.6039215686274f) == 154 && UnitToByte(0.6078431372549f) == 155 && UnitToByte(0.6117647058823f) == 156 && UnitToByte(0.6156862745098f) == 157 && UnitToByte(0.6196078431372f) == 158 && UnitToByte(0.6235294117647f) == 159

            && UnitToByte(0.6274509803921f) == 160 && UnitToByte(0.6313725490196f) == 161 && UnitToByte(0.6352941176470f) == 162 && UnitToByte(0.6392156862745f) == 163 && UnitToByte(0.6431372549019f) == 164 && UnitToByte(0.6470588235294f) == 165 && UnitToByte(0.6509803921568f) == 166 && UnitToByte(0.6549019607843f) == 167
            && UnitToByte(0.6588235294117f) == 168 && UnitToByte(0.6627450980392f) == 169 && UnitToByte(0.6666666666666f) == 170 && UnitToByte(0.6705882352941f) == 171 && UnitToByte(0.6745098039215f) == 172 && UnitToByte(0.6784313725490f) == 173 && UnitToByte(0.6823529411764f) == 174 && UnitToByte(0.6862745098039f) == 175
            && UnitToByte(0.6901960784313f) == 176 && UnitToByte(0.6941176470588f) == 177 && UnitToByte(0.6980392156862f) == 178 && UnitToByte(0.7019607843137f) == 179 && UnitToByte(0.7058823529411f) == 180 && UnitToByte(0.7098039215686f) == 181 && UnitToByte(0.7137254901960f) == 182 && UnitToByte(0.7176470588235f) == 183
            && UnitToByte(0.7215686274509f) == 184 && UnitToByte(0.7254901960784f) == 185 && UnitToByte(0.7294117647058f) == 186 && UnitToByte(0.7333333333333f) == 187 && UnitToByte(0.7372549019607f) == 188 && UnitToByte(0.7411764705882f) == 189 && UnitToByte(0.7450980392156f) == 190 && UnitToByte(0.7490196078431f) == 191

            && UnitToByte(0.7529411764705f) == 192 && UnitToByte(0.7568627450980f) == 193 && UnitToByte(0.7607843137254f) == 194 && UnitToByte(0.7647058823529f) == 195 && UnitToByte(0.7686274509803f) == 196 && UnitToByte(0.7725490196078f) == 197 && UnitToByte(0.7764705882352f) == 198 && UnitToByte(0.7803921568627f) == 199
            && UnitToByte(0.7843137254901f) == 200 && UnitToByte(0.7882352941176f) == 201 && UnitToByte(0.7921568627450f) == 202 && UnitToByte(0.7960784313725f) == 203 && UnitToByte(0.8f)             == 204 && UnitToByte(0.8039215686274f) == 205 && UnitToByte(0.8078431372549f) == 206 && UnitToByte(0.8117647058823f) == 207
            && UnitToByte(0.8156862745098f) == 208 && UnitToByte(0.8196078431372f) == 209 && UnitToByte(0.8235294117647f) == 210 && UnitToByte(0.8274509803921f) == 211 && UnitToByte(0.8313725490196f) == 212 && UnitToByte(0.8352941176470f) == 213 && UnitToByte(0.8392156862745f) == 214 && UnitToByte(0.8431372549019f) == 215
            && UnitToByte(0.8470588235294f) == 216 && UnitToByte(0.8509803921568f) == 217 && UnitToByte(0.8549019607843f) == 218 && UnitToByte(0.8588235294117f) == 219 && UnitToByte(0.8627450980392f) == 220 && UnitToByte(0.8666666666666f) == 221 && UnitToByte(0.8705882352941f) == 222 && UnitToByte(0.8745098039215f) == 223

            && UnitToByte(0.8784313725490f) == 224 && UnitToByte(0.8823529411764f) == 225 && UnitToByte(0.8862745098039f) == 226 && UnitToByte(0.8901960784313f) == 227 && UnitToByte(0.8941176470588f) == 228 && UnitToByte(0.8980392156862f) == 229 && UnitToByte(0.9019607843137f) == 230 && UnitToByte(0.9058823529411f) == 231
            && UnitToByte(0.9098039215686f) == 232 && UnitToByte(0.9137254901960f) == 233 && UnitToByte(0.9176470588235f) == 234 && UnitToByte(0.9215686274509f) == 235 && UnitToByte(0.9254901960784f) == 236 && UnitToByte(0.9294117647058f) == 237 && UnitToByte(0.9333333333333f) == 238 && UnitToByte(0.9372549019607f) == 239
            && UnitToByte(0.9411764705882f) == 240 && UnitToByte(0.9450980392156f) == 241 && UnitToByte(0.9490196078431f) == 242 && UnitToByte(0.9529411764705f) == 243 && UnitToByte(0.9568627450980f) == 244 && UnitToByte(0.9607843137254f) == 245 && UnitToByte(0.9647058823529f) == 246 && UnitToByte(0.9686274509803f) == 247
            && UnitToByte(0.9725490196078f) == 248 && UnitToByte(0.9764705882352f) == 249 && UnitToByte(0.9803921568627f) == 250 && UnitToByte(0.9843137254901f) == 251 && UnitToByte(0.9882352941176f) == 252 && UnitToByte(0.9921568627450f) == 253 && UnitToByte(0.9960784313725f) == 254 && UnitToByte(1.0f)             == 255
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("sRGB_To_Lin()", true
            && sRGB_To_Lin(0.00f) == 0.0f         && sRGB_To_Lin(0.01f) == 0.0007739938f && sRGB_To_Lin(0.02f) == 0.0015479876f && sRGB_To_Lin(0.03f) == 0.0023219814f && sRGB_To_Lin(0.04f) == 0.0030959751f && sRGB_To_Lin(0.05f) == 0.0039359396f && sRGB_To_Lin(0.06f) == 0.0048963088f && sRGB_To_Lin(0.07f) == 0.005981059f && sRGB_To_Lin(0.08f) == 0.0071944077f && sRGB_To_Lin(0.09f) == 0.008540383f
            && sRGB_To_Lin(0.10f) == 0.010022826f && sRGB_To_Lin(0.11f) == 0.011645429f  && sRGB_To_Lin(0.12f) == 0.013411746f  && sRGB_To_Lin(0.13f) == 0.015325204f  && sRGB_To_Lin(0.14f) == 0.0173891f    && sRGB_To_Lin(0.15f) == 0.01960665f   && sRGB_To_Lin(0.16f) == 0.021980947f  && sRGB_To_Lin(0.17f) == 0.02451501f  && sRGB_To_Lin(0.18f) == 0.027211785f  && sRGB_To_Lin(0.19f) == 0.030074105f
            && sRGB_To_Lin(0.20f) == 0.033104762f && sRGB_To_Lin(0.21f) == 0.036306474f  && sRGB_To_Lin(0.22f) == 0.039681915f  && sRGB_To_Lin(0.23f) == 0.043233637f  && sRGB_To_Lin(0.24f) == 0.046964195f  && sRGB_To_Lin(0.25f) == 0.05087609f   && sRGB_To_Lin(0.26f) == 0.05497173f   && sRGB_To_Lin(0.27f) == 0.059253525f && sRGB_To_Lin(0.28f) == 0.0637238f    && sRGB_To_Lin(0.29f) == 0.068384856f
            && sRGB_To_Lin(0.30f) == 0.07323897f  && sRGB_To_Lin(0.31f) == 0.078288324f  && sRGB_To_Lin(0.32f) == 0.08353512f   && sRGB_To_Lin(0.33f) == 0.08898155f   && sRGB_To_Lin(0.34f) == 0.09462964f   && sRGB_To_Lin(0.35f) == 0.10048152f   && sRGB_To_Lin(0.36f) == 0.10653924f   && sRGB_To_Lin(0.37f) == 0.11280479f  && sRGB_To_Lin(0.38f) == 0.11928018f   && sRGB_To_Lin(0.39f) == 0.1259674f
            && sRGB_To_Lin(0.40f) == 0.13286833f  && sRGB_To_Lin(0.41f) == 0.1399849f    && sRGB_To_Lin(0.42f) == 0.14731899f   && sRGB_To_Lin(0.43f) == 0.15487249f   && sRGB_To_Lin(0.44f) == 0.16264722f   && sRGB_To_Lin(0.45f) == 0.17064494f   && sRGB_To_Lin(0.46f) == 0.1788675f    && sRGB_To_Lin(0.47f) == 0.18731666f  && sRGB_To_Lin(0.48f) == 0.19599415f   && sRGB_To_Lin(0.49f) == 0.20490181f
            && sRGB_To_Lin(0.50f) == 0.21404114f  && sRGB_To_Lin(0.51f) == 0.223414f     && sRGB_To_Lin(0.52f) == 0.23302203f   && sRGB_To_Lin(0.53f) == 0.2428668f    && sRGB_To_Lin(0.54f) == 0.25295013f   && sRGB_To_Lin(0.55f) == 0.26327342f   && sRGB_To_Lin(0.56f) == 0.27383846f   && sRGB_To_Lin(0.57f) == 0.2846467f   && sRGB_To_Lin(0.58f) == 0.2956998f    && sRGB_To_Lin(0.59f) == 0.30699936f
            && sRGB_To_Lin(0.60f) == 0.31854683f  && sRGB_To_Lin(0.61f) == 0.33034378f   && sRGB_To_Lin(0.62f) == 0.34239164f   && sRGB_To_Lin(0.63f) == 0.3546921f    && sRGB_To_Lin(0.64f) == 0.3672465f    && sRGB_To_Lin(0.65f) == 0.38005632f   && sRGB_To_Lin(0.66f) == 0.3931232f    && sRGB_To_Lin(0.67f) == 0.40644833f  && sRGB_To_Lin(0.68f) == 0.42003334f   && sRGB_To_Lin(0.69f) == 0.4338796f
            && sRGB_To_Lin(0.70f) == 0.44798842f  && sRGB_To_Lin(0.71f) == 0.4623614f    && sRGB_To_Lin(0.72f) == 0.47699985f   && sRGB_To_Lin(0.73f) == 0.49190512f   && sRGB_To_Lin(0.74f) == 0.50707865f   && sRGB_To_Lin(0.75f) == 0.5225216f    && sRGB_To_Lin(0.76f) == 0.5382356f    && sRGB_To_Lin(0.77f) == 0.55422175f  && sRGB_To_Lin(0.78f) == 0.5704816f    && sRGB_To_Lin(0.79f) == 0.5870164f
            && sRGB_To_Lin(0.80f) == 0.6038274f   && sRGB_To_Lin(0.81f) == 0.62091595f   && sRGB_To_Lin(0.82f) == 0.63828325f   && sRGB_To_Lin(0.83f) == 0.65593076f   && sRGB_To_Lin(0.84f) == 0.67385954f   && sRGB_To_Lin(0.85f) == 0.6920712f    && sRGB_To_Lin(0.86f) == 0.71056664f   && sRGB_To_Lin(0.87f) == 0.72934717f  && sRGB_To_Lin(0.88f) == 0.7484142f    && sRGB_To_Lin(0.89f) == 0.7677688f
            && sRGB_To_Lin(0.90f) == 0.78741235f  && sRGB_To_Lin(0.91f) == 0.8073461f    && sRGB_To_Lin(0.92f) == 0.827571f     && sRGB_To_Lin(0.93f) == 0.8480884f    && sRGB_To_Lin(0.94f) == 0.86889946f   && sRGB_To_Lin(0.95f) == 0.8900055f    && sRGB_To_Lin(0.96f) == 0.91140765f   && sRGB_To_Lin(0.97f) == 0.9331069f   && sRGB_To_Lin(0.98f) == 0.95510465f   && sRGB_To_Lin(0.99f) == 0.9774019f
            && sRGB_To_Lin(1.00f) == 1.0f
        );

        RESULT("Lin_To_sRGB()", true
            && Lin_To_sRGB(0.0f) == 0.0f        && Lin_To_sRGB(0.01f) == 0.09985282f && Lin_To_sRGB(0.02f) == 0.15170372f && Lin_To_sRGB(0.03f) == 0.18974826f && Lin_To_sRGB(0.04f) == 0.22091633f && Lin_To_sRGB(0.05f) == 0.2478005f  && Lin_To_sRGB(0.06f) == 0.27169976f && Lin_To_sRGB(0.07f) == 0.29337204f && Lin_To_sRGB(0.08f) == 0.31330416f && Lin_To_sRGB(0.09f) == 0.33183002f
            && Lin_To_sRGB(0.1f) == 0.34919018f && Lin_To_sRGB(0.11f) == 0.3655646f  && Lin_To_sRGB(0.12f) == 0.38109183f && Lin_To_sRGB(0.13f) == 0.39588124f && Lin_To_sRGB(0.14f) == 0.41002086f && Lin_To_sRGB(0.15f) == 0.42358285f && Lin_To_sRGB(0.16f) == 0.43662703f && Lin_To_sRGB(0.17f) == 0.44920385f && Lin_To_sRGB(0.18f) == 0.4613561f  && Lin_To_sRGB(0.19f) == 0.47312063f
            && Lin_To_sRGB(0.2f) == 0.4845292f  && Lin_To_sRGB(0.21f) == 0.49560964f && Lin_To_sRGB(0.22f) == 0.5063864f  && Lin_To_sRGB(0.23f) == 0.5168811f  && Lin_To_sRGB(0.24f) == 0.5271128f  && Lin_To_sRGB(0.25f) == 0.5370987f  && Lin_To_sRGB(0.26f) == 0.5468542f  && Lin_To_sRGB(0.27f) == 0.5563933f  && Lin_To_sRGB(0.28f) == 0.56572837f && Lin_To_sRGB(0.29f) == 0.574871f
            && Lin_To_sRGB(0.3f) == 0.5838315f  && Lin_To_sRGB(0.31f) == 0.5926193f  && Lin_To_sRGB(0.32f) == 0.6012434f  && Lin_To_sRGB(0.33f) == 0.6097116f  && Lin_To_sRGB(0.34f) == 0.6180314f  && Lin_To_sRGB(0.35f) == 0.6262097f  && Lin_To_sRGB(0.36f) == 0.6342527f  && Lin_To_sRGB(0.37f) == 0.64216644f && Lin_To_sRGB(0.38f) == 0.64995646f && Lin_To_sRGB(0.39f) == 0.65762764f
            && Lin_To_sRGB(0.4f) == 0.66518503f && Lin_To_sRGB(0.41f) == 0.67263293f && Lin_To_sRGB(0.42f) == 0.6799757f  && Lin_To_sRGB(0.43f) == 0.6872171f  && Lin_To_sRGB(0.44f) == 0.694361f   && Lin_To_sRGB(0.45f) == 0.7014107f  && Lin_To_sRGB(0.46f) == 0.7083696f  && Lin_To_sRGB(0.47f) == 0.71524084f && Lin_To_sRGB(0.48f) == 0.7220273f  && Lin_To_sRGB(0.49f) == 0.7287318f
            && Lin_To_sRGB(0.5f) == 0.7353569f  && Lin_To_sRGB(0.51f) == 0.7419052f  && Lin_To_sRGB(0.52f) == 0.74837905f && Lin_To_sRGB(0.53f) == 0.7547806f  && Lin_To_sRGB(0.54f) == 0.76111215f && Lin_To_sRGB(0.55f) == 0.7673756f  && Lin_To_sRGB(0.56f) == 0.77357304f && Lin_To_sRGB(0.57f) == 0.7797062f  && Lin_To_sRGB(0.58f) == 0.7857769f  && Lin_To_sRGB(0.59f) == 0.79178685f
            && Lin_To_sRGB(0.6f) == 0.7977377f  && Lin_To_sRGB(0.61f) == 0.80363095f && Lin_To_sRGB(0.62f) == 0.8094681f  && Lin_To_sRGB(0.63f) == 0.81525064f && Lin_To_sRGB(0.64f) == 0.82097983f && Lin_To_sRGB(0.65f) == 0.826657f   && Lin_To_sRGB(0.66f) == 0.8322835f  && Lin_To_sRGB(0.67f) == 0.83786047f && Lin_To_sRGB(0.68f) == 0.84338915f && Lin_To_sRGB(0.69f) == 0.8488705f
            && Lin_To_sRGB(0.7f) == 0.8543058f  && Lin_To_sRGB(0.71f) == 0.8596959f  && Lin_To_sRGB(0.72f) == 0.865042f   && Lin_To_sRGB(0.73f) == 0.8703449f  && Lin_To_sRGB(0.74f) == 0.8756056f  && Lin_To_sRGB(0.75f) == 0.880825f   && Lin_To_sRGB(0.76f) == 0.8860039f  && Lin_To_sRGB(0.77f) == 0.8911432f  && Lin_To_sRGB(0.78f) == 0.8962438f  && Lin_To_sRGB(0.79f) == 0.90130645f
            && Lin_To_sRGB(0.8f) == 0.9063317f  && Lin_To_sRGB(0.81f) == 0.9113205f  && Lin_To_sRGB(0.82f) == 0.9162735f  && Lin_To_sRGB(0.83f) == 0.9211914f  && Lin_To_sRGB(0.84f) == 0.9260748f  && Lin_To_sRGB(0.85f) == 0.93092453f && Lin_To_sRGB(0.86f) == 0.93574095f && Lin_To_sRGB(0.87f) == 0.94052494f && Lin_To_sRGB(0.88f) == 0.9452768f  && Lin_To_sRGB(0.89f) == 0.94999737f
            && Lin_To_sRGB(0.9f) == 0.95468706f && Lin_To_sRGB(0.91f) == 0.9593465f  && Lin_To_sRGB(0.92f) == 0.9639762f  && Lin_To_sRGB(0.93f) == 0.9685765f  && Lin_To_sRGB(0.94f) == 0.97314817f && Lin_To_sRGB(0.95f) == 0.9776915f  && Lin_To_sRGB(0.96f) == 0.982207f   && Lin_To_sRGB(0.97f) == 0.98669523f && Lin_To_sRGB(0.98f) == 0.9911565f  && Lin_To_sRGB(0.99f) == 0.9955912f
            && Lin_To_sRGB(1.0f) == 0.99999994f
        );

        //======================================================================================================================================================
        PRINT("");
        RESULT("FromHSV()", true
            && round(FromHSV(-3.6f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 0.0f)  &&  round(FromHSV(-3.3f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.5f, 0.0f)
            && round(FromHSV(-3.0f, 1f, 1f), 0.000001f) == new vec3(1.0f, 1.0f, 0.0f)  &&  round(FromHSV(-2.7f, 1f, 1f), 0.000001f) == new vec3(0.5f, 1.0f, 0.0f)
            && round(FromHSV(-2.4f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 0.0f)  &&  round(FromHSV(-2.1f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 0.5f)
            && round(FromHSV(-1.8f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 1.0f)  &&  round(FromHSV(-1.5f, 1f, 1f), 0.000001f) == new vec3(0.0f, 0.5f, 1.0f)
            && round(FromHSV(-1.2f, 1f, 1f), 0.000001f) == new vec3(0.0f, 0.0f, 1.0f)  &&  round(FromHSV(-0.9f, 1f, 1f), 0.000001f) == new vec3(0.5f, 0.0f, 1.0f)
            && round(FromHSV(-0.6f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 1.0f)  &&  round(FromHSV(-0.3f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 0.5f)

            && round(FromHSV( 0.0f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 0.0f)  &&  round(FromHSV( 0.3f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.5f, 0.0f)
            && round(FromHSV( 0.6f, 1f, 1f), 0.000001f) == new vec3(1.0f, 1.0f, 0.0f)  &&  round(FromHSV( 0.9f, 1f, 1f), 0.000001f) == new vec3(0.5f, 1.0f, 0.0f)
            && round(FromHSV( 1.2f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 0.0f)  &&  round(FromHSV( 1.5f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 0.5f)
            && round(FromHSV( 1.8f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 1.0f)  &&  round(FromHSV( 2.1f, 1f, 1f), 0.000001f) == new vec3(0.0f, 0.5f, 1.0f)
            && round(FromHSV( 2.4f, 1f, 1f), 0.000001f) == new vec3(0.0f, 0.0f, 1.0f)  &&  round(FromHSV( 2.7f, 1f, 1f), 0.000001f) == new vec3(0.5f, 0.0f, 1.0f)
            && round(FromHSV( 3.0f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 1.0f)  &&  round(FromHSV( 3.3f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 0.5f)

            && round(FromHSV( 3.6f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 0.0f)  &&  round(FromHSV( 3.9f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.5f, 0.0f)
            && round(FromHSV( 4.2f, 1f, 1f), 0.000001f) == new vec3(1.0f, 1.0f, 0.0f)  &&  round(FromHSV( 4.5f, 1f, 1f), 0.000001f) == new vec3(0.5f, 1.0f, 0.0f)
            && round(FromHSV( 4.8f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 0.0f)  &&  round(FromHSV( 5.1f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 0.5f)
            && round(FromHSV( 5.4f, 1f, 1f), 0.000001f) == new vec3(0.0f, 1.0f, 1.0f)  &&  round(FromHSV( 5.7f, 1f, 1f), 0.000001f) == new vec3(0.0f, 0.5f, 1.0f)
            && round(FromHSV( 6.0f, 1f, 1f), 0.000001f) == new vec3(0.0f, 0.0f, 1.0f)  &&  round(FromHSV( 6.3f, 1f, 1f), 0.000001f) == new vec3(0.5f, 0.0f, 1.0f)
            && round(FromHSV( 6.6f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 1.0f)  &&  round(FromHSV( 6.9f, 1f, 1f), 0.000001f) == new vec3(1.0f, 0.0f, 0.5f)
        );


    }
}
