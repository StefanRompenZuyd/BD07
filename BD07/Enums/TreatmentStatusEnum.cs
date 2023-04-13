using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace BD07.Enums
{
    public enum TreatmentStatusEnum
    {
        Huisarts = 0,
        Ziekenhuis = 1,
        Thuiszorg = 2,
        Mantelzorger = 3,
        Overig = 4,
        Geen = 5,
    }
}
