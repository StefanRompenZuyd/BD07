using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BD07.Enums
{
    public enum TreatmentStatusEnum
    {
        [EnumMember(Value = "Geen behandeling")]
        NoTreatment = 0,

        [EnumMember(Value = "Korte duur (< 5 weken)")]
        ShortTreatment = 1,

        [EnumMember(Value = "Lange duur (> 5 weken)")]
        ShortTreatment2 = 2,

        [EnumMember(Value = "Chronisch")]
        fullTreatment = 3,

        [EnumMember(Value = "Nog onduidelijk")]
        QTreatment = 4,


    }
}
