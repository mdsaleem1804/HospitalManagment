using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Data.Enums
{
    public enum EnumPaymentStatus
    {
        [Description("Blanched Almond Color")]
        BlanchedAlmond = 1,
        [Description("Dark Sea Green Color")]
        DarkSeaGreen = 2,
        [Description("Deep Sky Blue Color")]
        DeepSkyBlue = 3,
        [Description("Rosy Brown Color")]
        RosyBrown = 4
    }
}
