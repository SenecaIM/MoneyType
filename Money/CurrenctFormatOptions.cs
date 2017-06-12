using System;

namespace FinancialTypes
{
    [Flags]
    public enum CurrenctFormatOptions
    {
        None = 0,
        Major = 1,
        Minor = 2,
        ISO = 4
    }
}