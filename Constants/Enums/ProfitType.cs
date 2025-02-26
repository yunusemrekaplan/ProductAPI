using System.ComponentModel;

namespace ProductAPI.Constants;

public enum ProfitType
{
    [Description("Milyem")]
    Milyem = 0,
    
    [Description("Yüzde")]
    Percentage = 1,
    
    [Description("Çarpan")]
    Multiplier = 2
}