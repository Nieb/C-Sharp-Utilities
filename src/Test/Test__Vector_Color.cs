
namespace UtilityTest;
internal static partial class Program {
    static void Test__Vector_Color() {
        PRINT("\n[Utility.VEC -- Color]");
        //PRINT($"{}");

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
        RESULT("sRGB_to_Lin()", true
            && sRGB_to_Lin(0.00f) == 0.0f         && sRGB_to_Lin(0.01f) == 0.0007739938f && sRGB_to_Lin(0.02f) == 0.0015479876f && sRGB_to_Lin(0.03f) == 0.0023219814f && sRGB_to_Lin(0.04f) == 0.0030959751f && sRGB_to_Lin(0.05f) == 0.0039359396f && sRGB_to_Lin(0.06f) == 0.0048963088f && sRGB_to_Lin(0.07f) == 0.005981059f && sRGB_to_Lin(0.08f) == 0.0071944077f && sRGB_to_Lin(0.09f) == 0.008540383f
            && sRGB_to_Lin(0.10f) == 0.010022826f && sRGB_to_Lin(0.11f) == 0.011645429f  && sRGB_to_Lin(0.12f) == 0.013411746f  && sRGB_to_Lin(0.13f) == 0.015325204f  && sRGB_to_Lin(0.14f) == 0.0173891f    && sRGB_to_Lin(0.15f) == 0.01960665f   && sRGB_to_Lin(0.16f) == 0.021980947f  && sRGB_to_Lin(0.17f) == 0.02451501f  && sRGB_to_Lin(0.18f) == 0.027211785f  && sRGB_to_Lin(0.19f) == 0.030074105f
            && sRGB_to_Lin(0.20f) == 0.033104762f && sRGB_to_Lin(0.21f) == 0.036306474f  && sRGB_to_Lin(0.22f) == 0.039681915f  && sRGB_to_Lin(0.23f) == 0.043233637f  && sRGB_to_Lin(0.24f) == 0.046964195f  && sRGB_to_Lin(0.25f) == 0.05087609f   && sRGB_to_Lin(0.26f) == 0.05497173f   && sRGB_to_Lin(0.27f) == 0.059253525f && sRGB_to_Lin(0.28f) == 0.0637238f    && sRGB_to_Lin(0.29f) == 0.068384856f
            && sRGB_to_Lin(0.30f) == 0.07323897f  && sRGB_to_Lin(0.31f) == 0.078288324f  && sRGB_to_Lin(0.32f) == 0.08353512f   && sRGB_to_Lin(0.33f) == 0.08898155f   && sRGB_to_Lin(0.34f) == 0.09462964f   && sRGB_to_Lin(0.35f) == 0.10048152f   && sRGB_to_Lin(0.36f) == 0.10653924f   && sRGB_to_Lin(0.37f) == 0.11280479f  && sRGB_to_Lin(0.38f) == 0.11928018f   && sRGB_to_Lin(0.39f) == 0.1259674f
            && sRGB_to_Lin(0.40f) == 0.13286833f  && sRGB_to_Lin(0.41f) == 0.1399849f    && sRGB_to_Lin(0.42f) == 0.14731899f   && sRGB_to_Lin(0.43f) == 0.15487249f   && sRGB_to_Lin(0.44f) == 0.16264722f   && sRGB_to_Lin(0.45f) == 0.17064494f   && sRGB_to_Lin(0.46f) == 0.1788675f    && sRGB_to_Lin(0.47f) == 0.18731666f  && sRGB_to_Lin(0.48f) == 0.19599415f   && sRGB_to_Lin(0.49f) == 0.20490181f
            && sRGB_to_Lin(0.50f) == 0.21404114f  && sRGB_to_Lin(0.51f) == 0.223414f     && sRGB_to_Lin(0.52f) == 0.23302203f   && sRGB_to_Lin(0.53f) == 0.2428668f    && sRGB_to_Lin(0.54f) == 0.25295013f   && sRGB_to_Lin(0.55f) == 0.26327342f   && sRGB_to_Lin(0.56f) == 0.27383846f   && sRGB_to_Lin(0.57f) == 0.2846467f   && sRGB_to_Lin(0.58f) == 0.2956998f    && sRGB_to_Lin(0.59f) == 0.30699936f
            && sRGB_to_Lin(0.60f) == 0.31854683f  && sRGB_to_Lin(0.61f) == 0.33034378f   && sRGB_to_Lin(0.62f) == 0.34239164f   && sRGB_to_Lin(0.63f) == 0.3546921f    && sRGB_to_Lin(0.64f) == 0.3672465f    && sRGB_to_Lin(0.65f) == 0.38005632f   && sRGB_to_Lin(0.66f) == 0.3931232f    && sRGB_to_Lin(0.67f) == 0.40644833f  && sRGB_to_Lin(0.68f) == 0.42003334f   && sRGB_to_Lin(0.69f) == 0.4338796f
            && sRGB_to_Lin(0.70f) == 0.44798842f  && sRGB_to_Lin(0.71f) == 0.4623614f    && sRGB_to_Lin(0.72f) == 0.47699985f   && sRGB_to_Lin(0.73f) == 0.49190512f   && sRGB_to_Lin(0.74f) == 0.50707865f   && sRGB_to_Lin(0.75f) == 0.5225216f    && sRGB_to_Lin(0.76f) == 0.5382356f    && sRGB_to_Lin(0.77f) == 0.55422175f  && sRGB_to_Lin(0.78f) == 0.5704816f    && sRGB_to_Lin(0.79f) == 0.5870164f
            && sRGB_to_Lin(0.80f) == 0.6038274f   && sRGB_to_Lin(0.81f) == 0.62091595f   && sRGB_to_Lin(0.82f) == 0.63828325f   && sRGB_to_Lin(0.83f) == 0.65593076f   && sRGB_to_Lin(0.84f) == 0.67385954f   && sRGB_to_Lin(0.85f) == 0.6920712f    && sRGB_to_Lin(0.86f) == 0.71056664f   && sRGB_to_Lin(0.87f) == 0.72934717f  && sRGB_to_Lin(0.88f) == 0.7484142f    && sRGB_to_Lin(0.89f) == 0.7677688f
            && sRGB_to_Lin(0.90f) == 0.78741235f  && sRGB_to_Lin(0.91f) == 0.8073461f    && sRGB_to_Lin(0.92f) == 0.827571f     && sRGB_to_Lin(0.93f) == 0.8480884f    && sRGB_to_Lin(0.94f) == 0.86889946f   && sRGB_to_Lin(0.95f) == 0.8900055f    && sRGB_to_Lin(0.96f) == 0.91140765f   && sRGB_to_Lin(0.97f) == 0.9331069f   && sRGB_to_Lin(0.98f) == 0.95510465f   && sRGB_to_Lin(0.99f) == 0.9774019f
            && sRGB_to_Lin(1.00f) == 1.0f
        );

        RESULT("Lin_to_sRGB()", true
            && Lin_to_sRGB(0.0f) == 0.0f        && Lin_to_sRGB(0.01f) == 0.09985282f && Lin_to_sRGB(0.02f) == 0.15170372f && Lin_to_sRGB(0.03f) == 0.18974826f && Lin_to_sRGB(0.04f) == 0.22091633f && Lin_to_sRGB(0.05f) == 0.2478005f  && Lin_to_sRGB(0.06f) == 0.27169976f && Lin_to_sRGB(0.07f) == 0.29337204f && Lin_to_sRGB(0.08f) == 0.31330416f && Lin_to_sRGB(0.09f) == 0.33183002f
            && Lin_to_sRGB(0.1f) == 0.34919018f && Lin_to_sRGB(0.11f) == 0.3655646f  && Lin_to_sRGB(0.12f) == 0.38109183f && Lin_to_sRGB(0.13f) == 0.39588124f && Lin_to_sRGB(0.14f) == 0.41002086f && Lin_to_sRGB(0.15f) == 0.42358285f && Lin_to_sRGB(0.16f) == 0.43662703f && Lin_to_sRGB(0.17f) == 0.44920385f && Lin_to_sRGB(0.18f) == 0.4613561f  && Lin_to_sRGB(0.19f) == 0.47312063f
            && Lin_to_sRGB(0.2f) == 0.4845292f  && Lin_to_sRGB(0.21f) == 0.49560964f && Lin_to_sRGB(0.22f) == 0.5063864f  && Lin_to_sRGB(0.23f) == 0.5168811f  && Lin_to_sRGB(0.24f) == 0.5271128f  && Lin_to_sRGB(0.25f) == 0.5370987f  && Lin_to_sRGB(0.26f) == 0.5468542f  && Lin_to_sRGB(0.27f) == 0.5563933f  && Lin_to_sRGB(0.28f) == 0.56572837f && Lin_to_sRGB(0.29f) == 0.574871f
            && Lin_to_sRGB(0.3f) == 0.5838315f  && Lin_to_sRGB(0.31f) == 0.5926193f  && Lin_to_sRGB(0.32f) == 0.6012434f  && Lin_to_sRGB(0.33f) == 0.6097116f  && Lin_to_sRGB(0.34f) == 0.6180314f  && Lin_to_sRGB(0.35f) == 0.6262097f  && Lin_to_sRGB(0.36f) == 0.6342527f  && Lin_to_sRGB(0.37f) == 0.64216644f && Lin_to_sRGB(0.38f) == 0.64995646f && Lin_to_sRGB(0.39f) == 0.65762764f
            && Lin_to_sRGB(0.4f) == 0.66518503f && Lin_to_sRGB(0.41f) == 0.67263293f && Lin_to_sRGB(0.42f) == 0.6799757f  && Lin_to_sRGB(0.43f) == 0.6872171f  && Lin_to_sRGB(0.44f) == 0.694361f   && Lin_to_sRGB(0.45f) == 0.7014107f  && Lin_to_sRGB(0.46f) == 0.7083696f  && Lin_to_sRGB(0.47f) == 0.71524084f && Lin_to_sRGB(0.48f) == 0.7220273f  && Lin_to_sRGB(0.49f) == 0.7287318f
            && Lin_to_sRGB(0.5f) == 0.7353569f  && Lin_to_sRGB(0.51f) == 0.7419052f  && Lin_to_sRGB(0.52f) == 0.74837905f && Lin_to_sRGB(0.53f) == 0.7547806f  && Lin_to_sRGB(0.54f) == 0.76111215f && Lin_to_sRGB(0.55f) == 0.7673756f  && Lin_to_sRGB(0.56f) == 0.77357304f && Lin_to_sRGB(0.57f) == 0.7797062f  && Lin_to_sRGB(0.58f) == 0.7857769f  && Lin_to_sRGB(0.59f) == 0.79178685f
            && Lin_to_sRGB(0.6f) == 0.7977377f  && Lin_to_sRGB(0.61f) == 0.80363095f && Lin_to_sRGB(0.62f) == 0.8094681f  && Lin_to_sRGB(0.63f) == 0.81525064f && Lin_to_sRGB(0.64f) == 0.82097983f && Lin_to_sRGB(0.65f) == 0.826657f   && Lin_to_sRGB(0.66f) == 0.8322835f  && Lin_to_sRGB(0.67f) == 0.83786047f && Lin_to_sRGB(0.68f) == 0.84338915f && Lin_to_sRGB(0.69f) == 0.8488705f
            && Lin_to_sRGB(0.7f) == 0.8543058f  && Lin_to_sRGB(0.71f) == 0.8596959f  && Lin_to_sRGB(0.72f) == 0.865042f   && Lin_to_sRGB(0.73f) == 0.8703449f  && Lin_to_sRGB(0.74f) == 0.8756056f  && Lin_to_sRGB(0.75f) == 0.880825f   && Lin_to_sRGB(0.76f) == 0.8860039f  && Lin_to_sRGB(0.77f) == 0.8911432f  && Lin_to_sRGB(0.78f) == 0.8962438f  && Lin_to_sRGB(0.79f) == 0.90130645f
            && Lin_to_sRGB(0.8f) == 0.9063317f  && Lin_to_sRGB(0.81f) == 0.9113205f  && Lin_to_sRGB(0.82f) == 0.9162735f  && Lin_to_sRGB(0.83f) == 0.9211914f  && Lin_to_sRGB(0.84f) == 0.9260748f  && Lin_to_sRGB(0.85f) == 0.93092453f && Lin_to_sRGB(0.86f) == 0.93574095f && Lin_to_sRGB(0.87f) == 0.94052494f && Lin_to_sRGB(0.88f) == 0.9452768f  && Lin_to_sRGB(0.89f) == 0.94999737f
            && Lin_to_sRGB(0.9f) == 0.95468706f && Lin_to_sRGB(0.91f) == 0.9593465f  && Lin_to_sRGB(0.92f) == 0.9639762f  && Lin_to_sRGB(0.93f) == 0.9685765f  && Lin_to_sRGB(0.94f) == 0.97314817f && Lin_to_sRGB(0.95f) == 0.9776915f  && Lin_to_sRGB(0.96f) == 0.982207f   && Lin_to_sRGB(0.97f) == 0.98669523f && Lin_to_sRGB(0.98f) == 0.9911565f  && Lin_to_sRGB(0.99f) == 0.9955912f
            && Lin_to_sRGB(1.0f) == 0.99999994f
        );

        //======================================================================================================================================================
        RESULT("HSV_to_RGB()", true
            && RGB_to_HSV(1f, 0f, 0f).IsApproximately((0f, 1f, 1f))  &&  RGB_to_HSV(1.0f, 0.5f, 0.0f).IsApproximately((0.5f, 1f, 1f))
            && RGB_to_HSV(1f, 1f, 0f).IsApproximately((1f, 1f, 1f))  &&  RGB_to_HSV(0.5f, 1.0f, 0.0f).IsApproximately((1.5f, 1f, 1f))

            && RGB_to_HSV(0f, 1f, 0f).IsApproximately((2f, 1f, 1f))  &&  RGB_to_HSV(0.0f, 1.0f, 0.5f).IsApproximately((2.5f, 1f, 1f))
            && RGB_to_HSV(0f, 1f, 1f).IsApproximately((3f, 1f, 1f))  &&  RGB_to_HSV(0.0f, 0.5f, 1.0f).IsApproximately((3.5f, 1f, 1f))

            && RGB_to_HSV(0f, 0f, 1f).IsApproximately((4f, 1f, 1f))  &&  RGB_to_HSV(0.5f, 0.0f, 1.0f).IsApproximately((4.5f, 1f, 1f))
            && RGB_to_HSV(1f, 0f, 1f).IsApproximately((5f, 1f, 1f))  &&  RGB_to_HSV(1.0f, 0.0f, 0.5f).IsApproximately((5.5f, 1f, 1f))
        );

        //======================================================================================================================================================
        RESULT("HSV_to_RGB()", true
            && HSV_to_RGB(-6f, 1, 1).IsApproximately((1.0f, 0.0f, 0.0f))  &&  HSV_to_RGB(-5.5f, 1f, 1f).IsApproximately((1.0f, 0.5f, 0.0f))
            && HSV_to_RGB(-5f, 1, 1).IsApproximately((1.0f, 1.0f, 0.0f))  &&  HSV_to_RGB(-4.5f, 1f, 1f).IsApproximately((0.5f, 1.0f, 0.0f))
            && HSV_to_RGB(-4f, 1, 1).IsApproximately((0.0f, 1.0f, 0.0f))  &&  HSV_to_RGB(-3.5f, 1f, 1f).IsApproximately((0.0f, 1.0f, 0.5f))
            && HSV_to_RGB(-3f, 1, 1).IsApproximately((0.0f, 1.0f, 1.0f))  &&  HSV_to_RGB(-2.5f, 1f, 1f).IsApproximately((0.0f, 0.5f, 1.0f))
            && HSV_to_RGB(-2f, 1, 1).IsApproximately((0.0f, 0.0f, 1.0f))  &&  HSV_to_RGB(-1.5f, 1f, 1f).IsApproximately((0.5f, 0.0f, 1.0f))
            && HSV_to_RGB(-1f, 1, 1).IsApproximately((1.0f, 0.0f, 1.0f))  &&  HSV_to_RGB(-0.5f, 1f, 1f).IsApproximately((1.0f, 0.0f, 0.5f))

            && HSV_to_RGB( 0f, 1, 1).IsApproximately((1.0f, 0.0f, 0.0f))  &&  HSV_to_RGB( 0.5f, 1f, 1f).IsApproximately((1.0f, 0.5f, 0.0f))
            && HSV_to_RGB( 1f, 1, 1).IsApproximately((1.0f, 1.0f, 0.0f))  &&  HSV_to_RGB( 1.5f, 1f, 1f).IsApproximately((0.5f, 1.0f, 0.0f))
            && HSV_to_RGB( 2f, 1, 1).IsApproximately((0.0f, 1.0f, 0.0f))  &&  HSV_to_RGB( 2.5f, 1f, 1f).IsApproximately((0.0f, 1.0f, 0.5f))
            && HSV_to_RGB( 3f, 1, 1).IsApproximately((0.0f, 1.0f, 1.0f))  &&  HSV_to_RGB( 3.5f, 1f, 1f).IsApproximately((0.0f, 0.5f, 1.0f))
            && HSV_to_RGB( 4f, 1, 1).IsApproximately((0.0f, 0.0f, 1.0f))  &&  HSV_to_RGB( 4.5f, 1f, 1f).IsApproximately((0.5f, 0.0f, 1.0f))
            && HSV_to_RGB( 5f, 1, 1).IsApproximately((1.0f, 0.0f, 1.0f))  &&  HSV_to_RGB( 5.5f, 1f, 1f).IsApproximately((1.0f, 0.0f, 0.5f))

            && HSV_to_RGB( 6f, 1, 1).IsApproximately((1.0f, 0.0f, 0.0f))  &&  HSV_to_RGB( 6.5f, 1f, 1f).IsApproximately((1.0f, 0.5f, 0.0f))
            && HSV_to_RGB( 7f, 1, 1).IsApproximately((1.0f, 1.0f, 0.0f))  &&  HSV_to_RGB( 7.5f, 1f, 1f).IsApproximately((0.5f, 1.0f, 0.0f))
            && HSV_to_RGB( 8f, 1, 1).IsApproximately((0.0f, 1.0f, 0.0f))  &&  HSV_to_RGB( 8.5f, 1f, 1f).IsApproximately((0.0f, 1.0f, 0.5f))
            && HSV_to_RGB( 9f, 1, 1).IsApproximately((0.0f, 1.0f, 1.0f))  &&  HSV_to_RGB( 9.5f, 1f, 1f).IsApproximately((0.0f, 0.5f, 1.0f))
            && HSV_to_RGB(10f, 1, 1).IsApproximately((0.0f, 0.0f, 1.0f))  &&  HSV_to_RGB(10.5f, 1f, 1f).IsApproximately((0.5f, 0.0f, 1.0f))
            && HSV_to_RGB(11f, 1, 1).IsApproximately((1.0f, 0.0f, 1.0f))  &&  HSV_to_RGB(11.5f, 1f, 1f).IsApproximately((1.0f, 0.0f, 0.5f))
        );

        //======================================================================================================================================================
        RESULT("TurboColorMapLUT()", true
            && ColorMap.Turbo(  0f/255f) == (0.18995f,0.07176f,0.23217f) && ColorMap.Turbo(  1f/255f) == (0.19483f,0.08339f,0.26149f)
            && ColorMap.Turbo(  2f/255f) == (0.19956f,0.09498f,0.29024f) && ColorMap.Turbo(  3f/255f) == (0.20415f,0.10652f,0.31844f)
            && ColorMap.Turbo(  4f/255f) == (0.20860f,0.11802f,0.34607f) && ColorMap.Turbo(  5f/255f) == (0.21291f,0.12947f,0.37314f)
            && ColorMap.Turbo(  6f/255f) == (0.21708f,0.14087f,0.39964f) && ColorMap.Turbo(  7f/255f) == (0.22111f,0.15223f,0.42558f)
            && ColorMap.Turbo(  8f/255f) == (0.22500f,0.16354f,0.45096f) && ColorMap.Turbo(  9f/255f) == (0.22875f,0.17481f,0.47578f)
            && ColorMap.Turbo( 10f/255f) == (0.23236f,0.18603f,0.50004f) && ColorMap.Turbo( 11f/255f) == (0.23582f,0.19720f,0.52373f)
            && ColorMap.Turbo( 12f/255f) == (0.23915f,0.20833f,0.54686f) && ColorMap.Turbo( 13f/255f) == (0.24234f,0.21941f,0.56942f)
            && ColorMap.Turbo( 14f/255f) == (0.24539f,0.23044f,0.59142f) && ColorMap.Turbo( 15f/255f) == (0.24830f,0.24143f,0.61286f)
            && ColorMap.Turbo( 16f/255f) == (0.25107f,0.25237f,0.63374f) && ColorMap.Turbo( 17f/255f) == (0.25369f,0.26327f,0.65406f)
            && ColorMap.Turbo( 18f/255f) == (0.25618f,0.27412f,0.67381f) && ColorMap.Turbo( 19f/255f) == (0.25853f,0.28492f,0.69300f)
            && ColorMap.Turbo( 20f/255f) == (0.26074f,0.29568f,0.71162f) && ColorMap.Turbo( 21f/255f) == (0.26280f,0.30639f,0.72968f)
            && ColorMap.Turbo( 22f/255f) == (0.26473f,0.31706f,0.74718f) && ColorMap.Turbo( 23f/255f) == (0.26652f,0.32768f,0.76412f)
            && ColorMap.Turbo( 24f/255f) == (0.26816f,0.33825f,0.78050f) && ColorMap.Turbo( 25f/255f) == (0.26967f,0.34878f,0.79631f)
            && ColorMap.Turbo( 26f/255f) == (0.27103f,0.35926f,0.81156f) && ColorMap.Turbo( 27f/255f) == (0.27226f,0.36970f,0.82624f)
            && ColorMap.Turbo( 28f/255f) == (0.27334f,0.38008f,0.84037f) && ColorMap.Turbo( 29f/255f) == (0.27429f,0.39043f,0.85393f)
            && ColorMap.Turbo( 30f/255f) == (0.27509f,0.40072f,0.86692f) && ColorMap.Turbo( 31f/255f) == (0.27576f,0.41097f,0.87936f)
            && ColorMap.Turbo( 32f/255f) == (0.27628f,0.42118f,0.89123f) && ColorMap.Turbo( 33f/255f) == (0.27667f,0.43134f,0.90254f)
            && ColorMap.Turbo( 34f/255f) == (0.27691f,0.44145f,0.91328f) && ColorMap.Turbo( 35f/255f) == (0.27701f,0.45152f,0.92347f)
            && ColorMap.Turbo( 36f/255f) == (0.27698f,0.46153f,0.93309f) && ColorMap.Turbo( 37f/255f) == (0.27680f,0.47151f,0.94214f)
            && ColorMap.Turbo( 38f/255f) == (0.27648f,0.48144f,0.95064f) && ColorMap.Turbo( 39f/255f) == (0.27603f,0.49132f,0.95857f)
            && ColorMap.Turbo( 40f/255f) == (0.27543f,0.50115f,0.96594f) && ColorMap.Turbo( 41f/255f) == (0.27469f,0.51094f,0.97275f)
            && ColorMap.Turbo( 42f/255f) == (0.27381f,0.52069f,0.97899f) && ColorMap.Turbo( 43f/255f) == (0.27273f,0.53040f,0.98461f)
            && ColorMap.Turbo( 44f/255f) == (0.27106f,0.54015f,0.98930f) && ColorMap.Turbo( 45f/255f) == (0.26878f,0.54995f,0.99303f)
            && ColorMap.Turbo( 46f/255f) == (0.26592f,0.55979f,0.99583f) && ColorMap.Turbo( 47f/255f) == (0.26252f,0.56967f,0.99773f)
            && ColorMap.Turbo( 48f/255f) == (0.25862f,0.57958f,0.99876f) && ColorMap.Turbo( 49f/255f) == (0.25425f,0.58950f,0.99896f)
            && ColorMap.Turbo( 50f/255f) == (0.24946f,0.59943f,0.99835f) && ColorMap.Turbo( 51f/255f) == (0.24427f,0.60937f,0.99697f)
            && ColorMap.Turbo( 52f/255f) == (0.23874f,0.61931f,0.99485f) && ColorMap.Turbo( 53f/255f) == (0.23288f,0.62923f,0.99202f)
            && ColorMap.Turbo( 54f/255f) == (0.22676f,0.63913f,0.98851f) && ColorMap.Turbo( 55f/255f) == (0.22039f,0.64901f,0.98436f)
            && ColorMap.Turbo( 56f/255f) == (0.21382f,0.65886f,0.97959f) && ColorMap.Turbo( 57f/255f) == (0.20708f,0.66866f,0.97423f)
            && ColorMap.Turbo( 58f/255f) == (0.20021f,0.67842f,0.96833f) && ColorMap.Turbo( 59f/255f) == (0.19326f,0.68812f,0.96190f)
            && ColorMap.Turbo( 60f/255f) == (0.18625f,0.69775f,0.95498f) && ColorMap.Turbo( 61f/255f) == (0.17923f,0.70732f,0.94761f)
            && ColorMap.Turbo( 62f/255f) == (0.17223f,0.71680f,0.93981f) && ColorMap.Turbo( 63f/255f) == (0.16529f,0.72620f,0.93161f)
            && ColorMap.Turbo( 64f/255f) == (0.15844f,0.73551f,0.92305f) && ColorMap.Turbo( 65f/255f) == (0.15173f,0.74472f,0.91416f)
            && ColorMap.Turbo( 66f/255f) == (0.14519f,0.75381f,0.90496f) && ColorMap.Turbo( 67f/255f) == (0.13886f,0.76279f,0.89550f)
            && ColorMap.Turbo( 68f/255f) == (0.13278f,0.77165f,0.88580f) && ColorMap.Turbo( 69f/255f) == (0.12698f,0.78037f,0.87590f)
            && ColorMap.Turbo( 70f/255f) == (0.12151f,0.78896f,0.86581f) && ColorMap.Turbo( 71f/255f) == (0.11639f,0.79740f,0.85559f)
            && ColorMap.Turbo( 72f/255f) == (0.11167f,0.80569f,0.84525f) && ColorMap.Turbo( 73f/255f) == (0.10738f,0.81381f,0.83484f)
            && ColorMap.Turbo( 74f/255f) == (0.10357f,0.82177f,0.82437f) && ColorMap.Turbo( 75f/255f) == (0.10026f,0.82955f,0.81389f)
            && ColorMap.Turbo( 76f/255f) == (0.09750f,0.83714f,0.80342f) && ColorMap.Turbo( 77f/255f) == (0.09532f,0.84455f,0.79299f)
            && ColorMap.Turbo( 78f/255f) == (0.09377f,0.85175f,0.78264f) && ColorMap.Turbo( 79f/255f) == (0.09287f,0.85875f,0.77240f)
            && ColorMap.Turbo( 80f/255f) == (0.09267f,0.86554f,0.76230f) && ColorMap.Turbo( 81f/255f) == (0.09320f,0.87211f,0.75237f)
            && ColorMap.Turbo( 82f/255f) == (0.09451f,0.87844f,0.74265f) && ColorMap.Turbo( 83f/255f) == (0.09662f,0.88454f,0.73316f)
            && ColorMap.Turbo( 84f/255f) == (0.09958f,0.89040f,0.72393f) && ColorMap.Turbo( 85f/255f) == (0.10342f,0.89600f,0.71500f)
            && ColorMap.Turbo( 86f/255f) == (0.10815f,0.90142f,0.70599f) && ColorMap.Turbo( 87f/255f) == (0.11374f,0.90673f,0.69651f)
            && ColorMap.Turbo( 88f/255f) == (0.12014f,0.91193f,0.68660f) && ColorMap.Turbo( 89f/255f) == (0.12733f,0.91701f,0.67627f)
            && ColorMap.Turbo( 90f/255f) == (0.13526f,0.92197f,0.66556f) && ColorMap.Turbo( 91f/255f) == (0.14391f,0.92680f,0.65448f)
            && ColorMap.Turbo( 92f/255f) == (0.15323f,0.93151f,0.64308f) && ColorMap.Turbo( 93f/255f) == (0.16319f,0.93609f,0.63137f)
            && ColorMap.Turbo( 94f/255f) == (0.17377f,0.94053f,0.61938f) && ColorMap.Turbo( 95f/255f) == (0.18491f,0.94484f,0.60713f)
            && ColorMap.Turbo( 96f/255f) == (0.19659f,0.94901f,0.59466f) && ColorMap.Turbo( 97f/255f) == (0.20877f,0.95304f,0.58199f)
            && ColorMap.Turbo( 98f/255f) == (0.22142f,0.95692f,0.56914f) && ColorMap.Turbo( 99f/255f) == (0.23449f,0.96065f,0.55614f)
            && ColorMap.Turbo(100f/255f) == (0.24797f,0.96423f,0.54303f) && ColorMap.Turbo(101f/255f) == (0.26180f,0.96765f,0.52981f)
            && ColorMap.Turbo(102f/255f) == (0.27597f,0.97092f,0.51653f) && ColorMap.Turbo(103f/255f) == (0.29042f,0.97403f,0.50321f)
            && ColorMap.Turbo(104f/255f) == (0.30513f,0.97697f,0.48987f) && ColorMap.Turbo(105f/255f) == (0.32006f,0.97974f,0.47654f)
            && ColorMap.Turbo(106f/255f) == (0.33517f,0.98234f,0.46325f) && ColorMap.Turbo(107f/255f) == (0.35043f,0.98477f,0.45002f)
            && ColorMap.Turbo(108f/255f) == (0.36581f,0.98702f,0.43688f) && ColorMap.Turbo(109f/255f) == (0.38127f,0.98909f,0.42386f)
            && ColorMap.Turbo(110f/255f) == (0.39678f,0.99098f,0.41098f) && ColorMap.Turbo(111f/255f) == (0.41229f,0.99268f,0.39826f)
            && ColorMap.Turbo(112f/255f) == (0.42778f,0.99419f,0.38575f) && ColorMap.Turbo(113f/255f) == (0.44321f,0.99551f,0.37345f)
            && ColorMap.Turbo(114f/255f) == (0.45854f,0.99663f,0.36140f) && ColorMap.Turbo(115f/255f) == (0.47375f,0.99755f,0.34963f)
            && ColorMap.Turbo(116f/255f) == (0.48879f,0.99828f,0.33816f) && ColorMap.Turbo(117f/255f) == (0.50362f,0.99879f,0.32701f)
            && ColorMap.Turbo(118f/255f) == (0.51822f,0.99910f,0.31622f) && ColorMap.Turbo(119f/255f) == (0.53255f,0.99919f,0.30581f)
            && ColorMap.Turbo(120f/255f) == (0.54658f,0.99907f,0.29581f) && ColorMap.Turbo(121f/255f) == (0.56026f,0.99873f,0.28623f)
            && ColorMap.Turbo(122f/255f) == (0.57357f,0.99817f,0.27712f) && ColorMap.Turbo(123f/255f) == (0.58646f,0.99739f,0.26849f)
            && ColorMap.Turbo(124f/255f) == (0.59891f,0.99638f,0.26038f) && ColorMap.Turbo(125f/255f) == (0.61088f,0.99514f,0.25280f)
            && ColorMap.Turbo(126f/255f) == (0.62233f,0.99366f,0.24579f) && ColorMap.Turbo(127f/255f) == (0.63323f,0.99195f,0.23937f)
            && ColorMap.Turbo(128f/255f) == (0.64362f,0.98999f,0.23356f) && ColorMap.Turbo(129f/255f) == (0.65394f,0.98775f,0.22835f)
            && ColorMap.Turbo(130f/255f) == (0.66428f,0.98524f,0.22370f) && ColorMap.Turbo(131f/255f) == (0.67462f,0.98246f,0.21960f)
            && ColorMap.Turbo(132f/255f) == (0.68494f,0.97941f,0.21602f) && ColorMap.Turbo(133f/255f) == (0.69525f,0.97610f,0.21294f)
            && ColorMap.Turbo(134f/255f) == (0.70553f,0.97255f,0.21032f) && ColorMap.Turbo(135f/255f) == (0.71577f,0.96875f,0.20815f)
            && ColorMap.Turbo(136f/255f) == (0.72596f,0.96470f,0.20640f) && ColorMap.Turbo(137f/255f) == (0.73610f,0.96043f,0.20504f)
            && ColorMap.Turbo(138f/255f) == (0.74617f,0.95593f,0.20406f) && ColorMap.Turbo(139f/255f) == (0.75617f,0.95121f,0.20343f)
            && ColorMap.Turbo(140f/255f) == (0.76608f,0.94627f,0.20311f) && ColorMap.Turbo(141f/255f) == (0.77591f,0.94113f,0.20310f)
            && ColorMap.Turbo(142f/255f) == (0.78563f,0.93579f,0.20336f) && ColorMap.Turbo(143f/255f) == (0.79524f,0.93025f,0.20386f)
            && ColorMap.Turbo(144f/255f) == (0.80473f,0.92452f,0.20459f) && ColorMap.Turbo(145f/255f) == (0.81410f,0.91861f,0.20552f)
            && ColorMap.Turbo(146f/255f) == (0.82333f,0.91253f,0.20663f) && ColorMap.Turbo(147f/255f) == (0.83241f,0.90627f,0.20788f)
            && ColorMap.Turbo(148f/255f) == (0.84133f,0.89986f,0.20926f) && ColorMap.Turbo(149f/255f) == (0.85010f,0.89328f,0.21074f)
            && ColorMap.Turbo(150f/255f) == (0.85868f,0.88655f,0.21230f) && ColorMap.Turbo(151f/255f) == (0.86709f,0.87968f,0.21391f)
            && ColorMap.Turbo(152f/255f) == (0.87530f,0.87267f,0.21555f) && ColorMap.Turbo(153f/255f) == (0.88331f,0.86553f,0.21719f)
            && ColorMap.Turbo(154f/255f) == (0.89112f,0.85826f,0.21880f) && ColorMap.Turbo(155f/255f) == (0.89870f,0.85087f,0.22038f)
            && ColorMap.Turbo(156f/255f) == (0.90605f,0.84337f,0.22188f) && ColorMap.Turbo(157f/255f) == (0.91317f,0.83576f,0.22328f)
            && ColorMap.Turbo(158f/255f) == (0.92004f,0.82806f,0.22456f) && ColorMap.Turbo(159f/255f) == (0.92666f,0.82025f,0.22570f)
            && ColorMap.Turbo(160f/255f) == (0.93301f,0.81236f,0.22667f) && ColorMap.Turbo(161f/255f) == (0.93909f,0.80439f,0.22744f)
            && ColorMap.Turbo(162f/255f) == (0.94489f,0.79634f,0.22800f) && ColorMap.Turbo(163f/255f) == (0.95039f,0.78823f,0.22831f)
            && ColorMap.Turbo(164f/255f) == (0.95560f,0.78005f,0.22836f) && ColorMap.Turbo(165f/255f) == (0.96049f,0.77181f,0.22811f)
            && ColorMap.Turbo(166f/255f) == (0.96507f,0.76352f,0.22754f) && ColorMap.Turbo(167f/255f) == (0.96931f,0.75519f,0.22663f)
            && ColorMap.Turbo(168f/255f) == (0.97323f,0.74682f,0.22536f) && ColorMap.Turbo(169f/255f) == (0.97679f,0.73842f,0.22369f)
            && ColorMap.Turbo(170f/255f) == (0.98000f,0.73000f,0.22161f) && ColorMap.Turbo(171f/255f) == (0.98289f,0.72140f,0.21918f)
            && ColorMap.Turbo(172f/255f) == (0.98549f,0.71250f,0.21650f) && ColorMap.Turbo(173f/255f) == (0.98781f,0.70330f,0.21358f)
            && ColorMap.Turbo(174f/255f) == (0.98986f,0.69382f,0.21043f) && ColorMap.Turbo(175f/255f) == (0.99163f,0.68408f,0.20706f)
            && ColorMap.Turbo(176f/255f) == (0.99314f,0.67408f,0.20348f) && ColorMap.Turbo(177f/255f) == (0.99438f,0.66386f,0.19971f)
            && ColorMap.Turbo(178f/255f) == (0.99535f,0.65341f,0.19577f) && ColorMap.Turbo(179f/255f) == (0.99607f,0.64277f,0.19165f)
            && ColorMap.Turbo(180f/255f) == (0.99654f,0.63193f,0.18738f) && ColorMap.Turbo(181f/255f) == (0.99675f,0.62093f,0.18297f)
            && ColorMap.Turbo(182f/255f) == (0.99672f,0.60977f,0.17842f) && ColorMap.Turbo(183f/255f) == (0.99644f,0.59846f,0.17376f)
            && ColorMap.Turbo(184f/255f) == (0.99593f,0.58703f,0.16899f) && ColorMap.Turbo(185f/255f) == (0.99517f,0.57549f,0.16412f)
            && ColorMap.Turbo(186f/255f) == (0.99419f,0.56386f,0.15918f) && ColorMap.Turbo(187f/255f) == (0.99297f,0.55214f,0.15417f)
            && ColorMap.Turbo(188f/255f) == (0.99153f,0.54036f,0.14910f) && ColorMap.Turbo(189f/255f) == (0.98987f,0.52854f,0.14398f)
            && ColorMap.Turbo(190f/255f) == (0.98799f,0.51667f,0.13883f) && ColorMap.Turbo(191f/255f) == (0.98590f,0.50479f,0.13367f)
            && ColorMap.Turbo(192f/255f) == (0.98360f,0.49291f,0.12849f) && ColorMap.Turbo(193f/255f) == (0.98108f,0.48104f,0.12332f)
            && ColorMap.Turbo(194f/255f) == (0.97837f,0.46920f,0.11817f) && ColorMap.Turbo(195f/255f) == (0.97545f,0.45740f,0.11305f)
            && ColorMap.Turbo(196f/255f) == (0.97234f,0.44565f,0.10797f) && ColorMap.Turbo(197f/255f) == (0.96904f,0.43399f,0.10294f)
            && ColorMap.Turbo(198f/255f) == (0.96555f,0.42241f,0.09798f) && ColorMap.Turbo(199f/255f) == (0.96187f,0.41093f,0.09310f)
            && ColorMap.Turbo(200f/255f) == (0.95801f,0.39958f,0.08831f) && ColorMap.Turbo(201f/255f) == (0.95398f,0.38836f,0.08362f)
            && ColorMap.Turbo(202f/255f) == (0.94977f,0.37729f,0.07905f) && ColorMap.Turbo(203f/255f) == (0.94538f,0.36638f,0.07461f)
            && ColorMap.Turbo(204f/255f) == (0.94084f,0.35566f,0.07031f) && ColorMap.Turbo(205f/255f) == (0.93612f,0.34513f,0.06616f)
            && ColorMap.Turbo(206f/255f) == (0.93125f,0.33482f,0.06218f) && ColorMap.Turbo(207f/255f) == (0.92623f,0.32473f,0.05837f)
            && ColorMap.Turbo(208f/255f) == (0.92105f,0.31489f,0.05475f) && ColorMap.Turbo(209f/255f) == (0.91572f,0.30530f,0.05134f)
            && ColorMap.Turbo(210f/255f) == (0.91024f,0.29599f,0.04814f) && ColorMap.Turbo(211f/255f) == (0.90463f,0.28696f,0.04516f)
            && ColorMap.Turbo(212f/255f) == (0.89888f,0.27824f,0.04243f) && ColorMap.Turbo(213f/255f) == (0.89298f,0.26981f,0.03993f)
            && ColorMap.Turbo(214f/255f) == (0.88691f,0.26152f,0.03753f) && ColorMap.Turbo(215f/255f) == (0.88066f,0.25334f,0.03521f)
            && ColorMap.Turbo(216f/255f) == (0.87422f,0.24526f,0.03297f) && ColorMap.Turbo(217f/255f) == (0.86760f,0.23730f,0.03082f)
            && ColorMap.Turbo(218f/255f) == (0.86079f,0.22945f,0.02875f) && ColorMap.Turbo(219f/255f) == (0.85380f,0.22170f,0.02677f)
            && ColorMap.Turbo(220f/255f) == (0.84662f,0.21407f,0.02487f) && ColorMap.Turbo(221f/255f) == (0.83926f,0.20654f,0.02305f)
            && ColorMap.Turbo(222f/255f) == (0.83172f,0.19912f,0.02131f) && ColorMap.Turbo(223f/255f) == (0.82399f,0.19182f,0.01966f)
            && ColorMap.Turbo(224f/255f) == (0.81608f,0.18462f,0.01809f) && ColorMap.Turbo(225f/255f) == (0.80799f,0.17753f,0.01660f)
            && ColorMap.Turbo(226f/255f) == (0.79971f,0.17055f,0.01520f) && ColorMap.Turbo(227f/255f) == (0.79125f,0.16368f,0.01387f)
            && ColorMap.Turbo(228f/255f) == (0.78260f,0.15693f,0.01264f) && ColorMap.Turbo(229f/255f) == (0.77377f,0.15028f,0.01148f)
            && ColorMap.Turbo(230f/255f) == (0.76476f,0.14374f,0.01041f) && ColorMap.Turbo(231f/255f) == (0.75556f,0.13731f,0.00942f)
            && ColorMap.Turbo(232f/255f) == (0.74617f,0.13098f,0.00851f) && ColorMap.Turbo(233f/255f) == (0.73661f,0.12477f,0.00769f)
            && ColorMap.Turbo(234f/255f) == (0.72686f,0.11867f,0.00695f) && ColorMap.Turbo(235f/255f) == (0.71692f,0.11268f,0.00629f)
            && ColorMap.Turbo(236f/255f) == (0.70680f,0.10680f,0.00571f) && ColorMap.Turbo(237f/255f) == (0.69650f,0.10102f,0.00522f)
            && ColorMap.Turbo(238f/255f) == (0.68602f,0.09536f,0.00481f) && ColorMap.Turbo(239f/255f) == (0.67535f,0.08980f,0.00449f)
            && ColorMap.Turbo(240f/255f) == (0.66449f,0.08436f,0.00424f) && ColorMap.Turbo(241f/255f) == (0.65345f,0.07902f,0.00408f)
            && ColorMap.Turbo(242f/255f) == (0.64223f,0.07380f,0.00401f) && ColorMap.Turbo(243f/255f) == (0.63082f,0.06868f,0.00401f)
            && ColorMap.Turbo(244f/255f) == (0.61923f,0.06367f,0.00410f) && ColorMap.Turbo(245f/255f) == (0.60746f,0.05878f,0.00427f)
            && ColorMap.Turbo(246f/255f) == (0.59550f,0.05399f,0.00453f) && ColorMap.Turbo(247f/255f) == (0.58336f,0.04931f,0.00486f)
            && ColorMap.Turbo(248f/255f) == (0.57103f,0.04474f,0.00529f) && ColorMap.Turbo(249f/255f) == (0.55852f,0.04028f,0.00579f)
            && ColorMap.Turbo(250f/255f) == (0.54583f,0.03593f,0.00638f) && ColorMap.Turbo(251f/255f) == (0.53295f,0.03169f,0.00705f)
            && ColorMap.Turbo(252f/255f) == (0.51989f,0.02756f,0.00780f) && ColorMap.Turbo(253f/255f) == (0.50664f,0.02354f,0.00863f)
            && ColorMap.Turbo(254f/255f) == (0.49321f,0.01963f,0.00955f) && ColorMap.Turbo(255f/255f) == (0.47960f,0.01583f,0.01055f)
        );

        //======================================================================================================================================================
        #if false
        {
            PRINT("");
            vec3 C = new();
            string BLARG = "";
            for (int i = 0; i < 256; ++i) {
                C = ColorMap_Magma( ((float)i)/255f );
                BLARG += $"({round(C.r*255f),3},{round(C.g*255f),3},{round(C.b*255f),3},255)";
            }
            PRINT(BLARG);
        }
        #endif

        #if false
        {
            PRINT("");
            uint C = new();
            string BLARG = "        ";
            for (int i = 0; i < 256; ++i) {
                if (i != 0 && i%8 == 0)
                    BLARG += "\n        ";

                C = ColorMap.BlackBody(i);
                //C = ByteFlip(ColorMap.BlackBody(i));

                BLARG += $"0x{C:X8},";
            }
            PRINT(BLARG);
        }
        #endif

        //======================================================================================================================================================
    }
}
