using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ColorService;

public class KnitwearYarnColorsOptionEnumManager : IOptionColorService
{
    private static readonly Dictionary<KnitwearYarnColorsOptionEnum, string> ColorHexMapping = new()
    {
        { KnitwearYarnColorsOptionEnum.Color_090909, "#090909" },
        { KnitwearYarnColorsOptionEnum.Color_404040, "#404040" },
        { KnitwearYarnColorsOptionEnum.Color_563c33, "#563c33" },
        { KnitwearYarnColorsOptionEnum.Color_d52213, "#d52213" },
        { KnitwearYarnColorsOptionEnum.Color_6e5242, "#6e5242" },
        { KnitwearYarnColorsOptionEnum.Color_7f6a53, "#7f6a53" },
        { KnitwearYarnColorsOptionEnum.Color_cd5e38, "#cd5e38" },
        { KnitwearYarnColorsOptionEnum.Color_b57648, "#b57648" },
        { KnitwearYarnColorsOptionEnum.Color_d1773b, "#d1773b" },
        { KnitwearYarnColorsOptionEnum.Color_d68785, "#d68785" },
        { KnitwearYarnColorsOptionEnum.Color_c6b5a7, "#c6b5a7" },
        { KnitwearYarnColorsOptionEnum.Color_d6c6b4, "#d6c6b4" },
        { KnitwearYarnColorsOptionEnum.Color_dcd3cc, "#dcd3cc" },
        { KnitwearYarnColorsOptionEnum.Color_edd9d9, "#edd9d9" },
        { KnitwearYarnColorsOptionEnum.Color_e2dfdc, "#e2dfdc" },
        { KnitwearYarnColorsOptionEnum.Color_fdfafa, "#fdfafa" },
        { KnitwearYarnColorsOptionEnum.Color_999996, "#999996" },
        { KnitwearYarnColorsOptionEnum.Color_dda032, "#dda032" },
        { KnitwearYarnColorsOptionEnum.Color_d1c6ae, "#d1c6ae" },
        { KnitwearYarnColorsOptionEnum.Color_eddea4, "#eddea4" },
        { KnitwearYarnColorsOptionEnum.Color_48542e, "#48542e" },
        { KnitwearYarnColorsOptionEnum.Color_6e8c4b, "#6e8c4b" },
        { KnitwearYarnColorsOptionEnum.Color_c0c1bd, "#c0c1bd" },
        { KnitwearYarnColorsOptionEnum.Color_243f33, "#243f33" },
        { KnitwearYarnColorsOptionEnum.Color_c5d1d0, "#c5d1d0" },
        { KnitwearYarnColorsOptionEnum.Color_175387, "#175387" },
        { KnitwearYarnColorsOptionEnum.Color_237d96, "#237d96" },
        { KnitwearYarnColorsOptionEnum.Color_787979, "#787979" },
        { KnitwearYarnColorsOptionEnum.Color_343d55, "#343d55" },
        { KnitwearYarnColorsOptionEnum.Color_4e59be, "#4e59be" },
        { KnitwearYarnColorsOptionEnum.Color_566e99, "#566e99" },
        { KnitwearYarnColorsOptionEnum.Color_504372, "#504372" },
        { KnitwearYarnColorsOptionEnum.Color_4c1c29, "#4c1c29" },
        { KnitwearYarnColorsOptionEnum.Color_f66274, "#f66274" },
        { KnitwearYarnColorsOptionEnum.Color_eda6b4, "#eda6b4" },
        { KnitwearYarnColorsOptionEnum.Color_ddabc8, "#ddabc8" }
    };

    public string ColorToString(object colorOption)
    {

        if (colorOption is KnitwearYarnColorsOptionEnum enumValue)
        {
            return ColorHexMapping.TryGetValue(enumValue, out var hexValue) ? hexValue : "";
        }

        throw new ArgumentException("Unknown Color Option");
    }
};

